using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TaxBarAssociation.Models;
using TaxBarAssociation.Models.DTO;
using TaxBarAssociation.Areas.Identity.Data;
using System.Reflection.Metadata;
using TaxBarAssociation.Core.ViewModels;
using System.Xml.Linq;
using System.Linq.Dynamic.Core;
using Microsoft.AspNetCore.Mvc.Filters;

namespace TaxBarAssociation.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDBContext context;
        public HomeController(ILogger<HomeController> logger, AppDBContext context)
        {
            _logger = logger;
            this.context = context;
        }

        public async Task<IActionResult> Index()
        {
            HomeViewModel viewModel = new HomeViewModel
            {
                sliders = await context.Sliders.Where(x => x.Visibility == 1).OrderBy(x => x.Ord).ToListAsync(),
                galleries = await context.Galleries.ToListAsync(),
                core = await context.CoreCommite.ToListAsync()
            };
            return View(viewModel);
        }

        public IActionResult Blog(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                BlogViewModel viewModel = new BlogViewModel
                {
                    blogModel = this.GetBlogs(1)
                };
                return View(viewModel);
            }
            else
            {
                BlogViewModel viewModel = new BlogViewModel
                {
                    CatName = id,
                    blogModel = this.GetBlogsWithCategory(id, 1)
                };
                return View(viewModel);
            }
        }
        [HttpPost]
        public IActionResult Blog(string id, int currentPageIndex)
        {
            if (string.IsNullOrEmpty(id))
            {
                BlogViewModel viewModel = new BlogViewModel
                {
                    blogModel = this.GetBlogs(currentPageIndex)
                };
                return View(viewModel);
            }
            else
            {
                BlogViewModel viewModel = new BlogViewModel
                {
                    CatName = id,
                    blogModel = this.GetBlogsWithCategory(id, currentPageIndex)
                };
                return View(viewModel);
            }
        }

        private BlogModel GetBlogs(int currentPage)
        {
            int maxRows = 12;
            BlogModel customerModel = new BlogModel();

            customerModel.blogs = (from blog in context.Blogs
                                   join users in context.Users on blog.UserID equals users.Id
                                   join categories in context.Categories on blog.CategoryID equals categories.Id
                                   select new BlogData()
                                   {
                                       BlogID = blog.BlogID,
                                       Title = blog.Title,
                                       Slug = blog.Slug,
                                       Description = blog.Description,
                                       Content = blog.BlogContent,
                                       Image = blog.BlogImage,
                                       CategoryName = categories.Name,
                                       UserName = users.Name + " " + users.LastName,
                                       Date = blog.Date,
                                       Status = blog.Status
                                   })
                        .OrderBy(customer => customer.BlogID)
                        .Skip((currentPage - 1) * maxRows)
                        .Take(maxRows).ToList();

            double pageCount = (double)((decimal)this.context.Galleries.Count() / Convert.ToDecimal(maxRows));
            customerModel.PageCount = (int)Math.Ceiling(pageCount);

            customerModel.CurrentPageIndex = currentPage;

            return customerModel;
        }

        private BlogModel GetBlogsWithCategory(string id, int currentPage)
        {
            int maxRows = 12;
            BlogModel customerModel = new BlogModel();

            customerModel.blogs = (from blog in context.Blogs
                                   join users in context.Users on blog.UserID equals users.Id
                                   join categories in context.Categories on blog.CategoryID equals categories.Id
                                   where categories.Name == id
                                   select new BlogData()
                                   {
                                       BlogID = blog.BlogID,
                                       Title = blog.Title,
                                       Slug = blog.Slug,
                                       Description = blog.Description,
                                       Content = blog.BlogContent,
                                       Image = blog.BlogImage,
                                       CategoryName = categories.Name,
                                       UserName = users.Name + " " + users.LastName,
                                       Date = blog.Date,
                                       Status = blog.Status
                                   })
                        .OrderBy(customer => customer.BlogID)
                        .Skip((currentPage - 1) * maxRows)
                        .Take(maxRows).ToList();

            double pageCount = (double)((decimal)this.context.Galleries.Count() / Convert.ToDecimal(maxRows));
            customerModel.PageCount = (int)Math.Ceiling(pageCount);

            customerModel.CurrentPageIndex = currentPage;

            return customerModel;
        }
        [HttpPost]
        public PartialViewResult CommentPartial(string Slug)
        {
            var comments = context.Comments.Include(z => z.Blog).Where(y => y.Blog.Slug == Slug).OrderBy(x => x.CommentDate);
            return PartialView("_CommentPartial", comments);
        }

        [HttpPost]
        public JsonResult addNewComment(int parentId, string commentText, string username, string email, int blogId)
        {
            try
            {
                var _comment = new Comment()
                {
                    ParentId = parentId,
                    CommentText = commentText,
                    Username = username,
                    Email = email,
                    CommentDate = DateTime.Now,
                    BlogID = blogId
                };
                context.Comments.Add(_comment);
                context.SaveChanges();

                var comments = context.Comments.Where(x => x.CommentID == _comment.CommentID)
                    .Select(x => new commentViewModel
                    {
                        commentId = x.CommentID,
                        commentText = x.CommentText,
                        parentId = x.ParentId,
                        commentDate = x.CommentDate,
                        username = x.Username

                    }).FirstOrDefault();
                return Json(new { error = false, result = comments });

            }
            catch (Exception)
            {
                //Handle Error here..
            }

            return Json(new { error = true });
        }

        private List<ModelError> BuildModelErrors()
        {
            var modelErrors = new List<ModelError>();
            var erroneousFields = this.ModelState.Where(ms => ms.Value.Errors.Any())
                                                 .Select(x => new { x.Key, x.Value.Errors });

            foreach (var erroneousField in erroneousFields)
            {
                var fieldKey = erroneousField.Key;
                var fieldErrors = erroneousField.Errors.Select(error =>
                                                    new ModelError(fieldKey, error.ErrorMessage));
                modelErrors.AddRange(fieldErrors);
            }
            return modelErrors;
        }

        public IActionResult BlogDetails(string id)
        {
            var Blog = (from blog in context.Blogs
                        join users in context.Users on blog.UserID equals users.Id
                        join categories in context.Categories on blog.CategoryID equals categories.Id
                        where blog.Slug == id
                        select new BlogData()
                        {
                            BlogID = blog.BlogID,
                            Title = blog.Title,
                            Slug = blog.Slug,
                            Description = blog.Description,
                            Content = blog.BlogContent,
                            Image = blog.BlogImage,
                            CategoryName = categories.Name,
                            UserName = users.Name + " " + users.LastName,
                            Date = blog.Date,
                            Status = blog.Status
                        }).FirstOrDefault();
            if(Blog != null)
            {
                DetailsViewModel viewModel = new DetailsViewModel
                {
                    blogData = Blog,
                    comments = context.Blogs.Where(x => x.CommentShow == 1 && x.Slug == id).FirstOrDefault(),
                    commentCount = context.Comments.Where(x => x.BlogID == Blog.BlogID).ToList().Count()
                };
                return View(viewModel);
            }
            else
            {
                return RedirectToAction("Blogs", "Home");
            }
        }
        [HttpPost]
        public PartialViewResult BlogPaging(int BlogID)
        {
            DetailsViewModel viewModel = new DetailsViewModel
            {
                Next = (from x in context.Blogs
                        join users in context.Users on x.UserID equals users.Id
                        join categories in context.Categories on x.CategoryID equals categories.Id
                        where x.BlogID < BlogID
                        orderby x.BlogID descending
                        select x).FirstOrDefault(),
                Prev = (from x in context.Blogs
                        join users in context.Users on x.UserID equals users.Id
                        join categories in context.Categories on x.CategoryID equals categories.Id
                        where x.BlogID > BlogID
                        orderby x.BlogID ascending
                        select x).FirstOrDefault()
            };
            return PartialView("_BlogPaging", viewModel);
        }

        [HttpGet]
        public PartialViewResult BlogCategories()
        {
            var categories = context.Categories.Include(x => x.Blogs).ToList();
            return PartialView("_BlogCategories", categories);
        }

        [HttpGet]
        public PartialViewResult RecentBlogs()
        {
            var Blog = (from blog in context.Blogs
                        join users in context.Users on blog.UserID equals users.Id
                        join categories in context.Categories on blog.CategoryID equals categories.Id
                        select new BlogData()
                        {
                            Title = blog.Title,
                            Slug = blog.Slug,
                            Description = blog.Description,
                            Content = blog.BlogContent,
                            Image = blog.BlogImage,
                            CategoryName = categories.Name,
                            UserName = users.Name + " " + users.LastName,
                            Date = blog.Date,
                            Status = blog.Status
                        }).ToList().Take(5);
            return PartialView("_RecentPosts", Blog);
        }

        public ActionResult LoadBlogGallery(string Slug)
        {
            var gallery = context.BlogGalleries.Where(x => x.Blog.Slug == Slug).ToList();
            if(gallery.Count() == 0)
            {
                return View(new { success = false });
            }
            return PartialView("_BlogGallery", gallery);
        }

        [HttpGet]
        public ActionResult LoadBlogs()
        {
            var gallery = (from blog in context.Blogs
                           join users in context.Users on blog.UserID equals users.Id
                           join categories in context.Categories on blog.CategoryID equals categories.Id
                           where blog.Featured == 1
                           select new BlogData()
                           {
                               Title = blog.Title,
                               Slug = blog.Slug,
                               Description = blog.Description,
                               Image = blog.BlogImage,
                               CategoryName = categories.Name,
                               UserName = users.Name + " " + users.LastName,
                               Date = blog.Date,
                               Status = blog.Status
                           }).ToList().Take(2);
            return PartialView("_LoadBlogs", gallery);
        }

        public IActionResult LiveTagSearch(string search)
        {
            List<Blog> res = (
                from t in context.Blogs
                where t.Title.Contains(search)
                select t
                ).ToList();

            return PartialView(res);
        }

        public bool Between(DateTime input, int x, int y)
        {
            return (input.Hour >= x && input.Hour <= y);
        }

        public IActionResult AboutUs()
        {
            return View();
        }

        public IActionResult ContactUs()
        {
            return View();
        }

        public IActionResult Gallery()
        {
            return View(this.GetGallery(1));
        }
        [HttpPost]
        public IActionResult Gallery(int currentPageIndex)
        {
            return View(this.GetGallery(currentPageIndex));
        }

        private GalleryModel GetGallery(int currentPage)
        {
            int maxRows = 12;
            GalleryModel customerModel = new GalleryModel();

            customerModel.galleries = (from customer in this.context.Galleries
                                       select customer)
                        .OrderBy(customer => customer.GalleryID)
                        .Skip((currentPage - 1) * maxRows)
                        .Take(maxRows).ToList();

            double pageCount = (double)((decimal)this.context.Galleries.Count() / Convert.ToDecimal(maxRows));
            customerModel.PageCount = (int)Math.Ceiling(pageCount);

            customerModel.CurrentPageIndex = currentPage;

            return customerModel;
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public async Task<JsonResult> LoadSettings()
        {
            var setting = await (from s in context.Settings
                            where s.AppID == 2
                            select new Settings
                            {
                                AppID = s.AppID,
                                AboutText = s.AboutText,
                                AppName = s.AppName,
                                ContactNumber = s.ContactNumber,
                                ContactText = s.ContactText,
                                Day = s.Day,
                                EndTime = s.EndTime,
                                FooterText = s.FooterText,
                                HeaderText = s.HeaderText,
                                Location = s.Location,
                                Logo = s.Logo,
                                Map = s.Map,
                                StartTime = s.StartTime
                            }).FirstOrDefaultAsync();
            if (setting != null)
            {
                return Json(setting);
            }
            return Json(setting);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        //Class to hold model errors and the corresponding field key
        private class ModelError
        {
            public ModelError(string key, string errorMessage)
            {
                Key = key;
                ErrorMessage = errorMessage;
            }

            public string Key { get; set; }
            public string ErrorMessage { get; set; }
        }
    }
}