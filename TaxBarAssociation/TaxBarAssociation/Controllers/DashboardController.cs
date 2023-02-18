using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Drawing.Drawing2D;
using System.Drawing;
using TaxBarAssociation.Core;
using TaxBarAssociation.Models;
using static TaxBarAssociation.Core.Constants;
using System.Drawing.Imaging;
using Omu.Drawing;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using TaxBarAssociation.Areas.Identity.Data;
using Microsoft.AspNetCore.Hosting;
using System;
using System.IO;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.Reflection.Metadata;
using static System.Reflection.Metadata.BlobBuilder;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace TaxBarAssociation.Controllers
{
    public class DashboardController : Controller
    {
        private UserManager<ApplicationUser> userManager;
        private RoleManager<IdentityRole> roleManager;
        private readonly AppDBContext context;
        private IWebHostEnvironment Environment;
        public DashboardController(UserManager<ApplicationUser> usrMgr, RoleManager<IdentityRole> roleMgr, AppDBContext context, IWebHostEnvironment _environment)
        {
            userManager = usrMgr;
            roleManager = roleMgr;
            this.context = context;
            Environment = _environment;
        }
        [Authorize(Roles = "Administrator")]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Save(IFormCollection formData)
        {
            bool x = await roleManager.RoleExistsAsync("Member");
            if (!x)
            {
                var role = new IdentityRole();
                role.Name = "Member";
                await roleManager.CreateAsync(role);
            }
            var user = new ApplicationUser()
            {
                Name = formData["Name"],
                CorrespondenceAddress = formData["CorrespondenceAddress"],
                FaxNo = formData["Fax"],
                OffNo = formData["OffNo"],
                ResAddress = formData["ResAddress"],
                BarCouncil = formData["BarCouncil"],
                MemberNo = formData["MemberNo"],
                DateOfBirth = DateTime.Parse(formData["DateOfBirth"]),
                PhoneNumber = formData["PhoneNumber"],
                Email = formData["Email"],
                UserName = formData["Email"]
            };
            IdentityResult chkUser = await userManager.CreateAsync(user, formData["Password"]);
            if (chkUser.Succeeded)
            {
                var result1 = await userManager.AddToRoleAsync(user, "Member");
                if (result1.Succeeded)
                {
                    return new JsonResult("Member saved successfully!");
                }
            }
            return new JsonResult(chkUser.Errors);
        }
        public async Task<IActionResult> Edit(string id)
        {
            if(!string.IsNullOrEmpty(id))
            {
                var user = await userManager.FindByIdAsync(id);
                return new JsonResult(user);
            }
            return new JsonResult("");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(IFormCollection formData)
        {
            var user = await userManager.FindByIdAsync(formData["Id"]);
            if(user != null)
            {
                user.Name = formData["Name"];
                user.CorrespondenceAddress = formData["CorrespondenceAddress"];
                user.FaxNo = formData["Fax"];
                user.OffNo = formData["OffNo"];
                user.ResAddress = formData["ResAddress"];
                user.BarCouncil = formData["BarCouncil"];
                user.MemberNo = formData["MemberNo"];
                user.DateOfBirth = DateTime.Parse(formData["DateOfBirth"]);
                user.PhoneNumber = formData["PhoneNumber"];
                user.Email = formData["Email"];
                user.UserName = formData["Email"];
                IdentityResult chkUser = await userManager.UpdateAsync(user);  
                if (chkUser.Succeeded)
                {
                    return new JsonResult("Member update successfully!");
                }
            }
            return new JsonResult("Error! user not updated.");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            var user = await userManager.FindByIdAsync(id);
            if (user != null)
            {
                IdentityResult chkUser = await userManager.DeleteAsync(user);
                if (chkUser.Succeeded)
                {
                    return new JsonResult("Member delete successfully!");
                }
            }
            return new JsonResult("Error! user not deleted.");
        }

        [HttpGet]
        [Authorize(Roles = "Administrator")]
        public IActionResult Gallery()
        {
            return View();
        }
        [HttpGet]
        public PartialViewResult LoadGallery()
        {
            var galleries = context.Galleries.ToList();
            return PartialView("_LoadGallery", galleries);
        }
        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public ActionResult Gallery(SingleFileModel model)
        {
            Galleries galleries = new Galleries();
            var file = model.File;
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Uploads/GalleryImages");
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            var filePath = path + file.FileName;
            FileInfo files = new FileInfo(filePath);
            if (files.Exists)
            {
                files.Delete();
            }
            var allowedExtensions = new[] {
                        ".Jpg", ".png", ".jpg", ".jpeg"
                        };
            var ext = Path.GetExtension(file.FileName);
            if (allowedExtensions.Contains(ext))
            {
                string fileNameWithPath = Path.Combine(path, file.FileName);
                using (var stream = new FileStream(fileNameWithPath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
                galleries.GalleryImage = file.FileName;
                context.Galleries.Add(galleries);
                context.SaveChanges();
            }
            return Json("");
        }

        [HttpPost]
        public async Task<ActionResult> DeleteGallery(int id)
        {
            var gallery = await context.Galleries.FindAsync(id);
            if (gallery != null)
            {
                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Uploads/GalleryImages/");
                var filePath = path + gallery.GalleryImage;
                FileInfo file = new FileInfo(filePath);
                if (file.Exists)
                {
                    file.Delete();
                }
                context.Galleries.Remove(gallery);
                var i = context.SaveChanges();

                //Add default User to Role Admin    
                if (i > 0)
                {
                    return new JsonResult("Image delete successfully!");
                }
            }
            return new JsonResult("Error! image not deleted.");
        }

        [HttpGet]
        public IActionResult Settings()
        {
            var settings = context.Settings.FirstOrDefault();
            return View(settings);
        }

        [HttpPost]
        public async Task<IActionResult> Settings(Settings settings, string ButtonType)
        {
            var setting = context.Settings.FirstOrDefault();
            if(setting == null)
            {
                if(ButtonType == "UpdateSettings")
                {
                    Settings settings1 = new Settings();
                    settings1.AppName = settings.AppName;
                    settings1.ContactNumber = settings.ContactNumber;
                    settings1.Location = settings.Location;
                    context.Settings.Add(settings1);
                    await context.SaveChangesAsync();
                }
                else if (ButtonType == "UpdateLogo")
                {
                    Settings settings1 = new Settings();
                    var file = settings.LogoImage;
                    string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/website/images/logo");
                    if (!Directory.Exists(path))
                        Directory.CreateDirectory(path);
                    var filePath = path + file.FileName;
                    FileInfo files = new FileInfo(filePath);
                    if (files.Exists)
                    {
                        files.Delete();
                    }
                    var allowedExtensions = new[] {
                        ".Jpg", ".png", ".jpg", ".jpeg"
                        };
                    var ext = Path.GetExtension(file.FileName);
                    if (allowedExtensions.Contains(ext))
                    {
                        string fileNameWithPath = Path.Combine(path, file.FileName);
                        using (var stream = new FileStream(fileNameWithPath, FileMode.Create))
                        {
                            file.CopyTo(stream);
                        }
                        settings1.Logo = file.FileName;
                        context.Settings.Add(settings1);
                        await context.SaveChangesAsync();
                    }
                }
                else if (ButtonType == "UpdateText")
                {
                    Settings settings1 = new Settings();
                    settings1.HeaderText = settings.HeaderText;
                    settings1.FooterText = settings.FooterText;
                    settings1.AboutText = settings.AboutText;
                    settings1.ContactText = settings.ContactText;
                    context.Settings.Add(settings1);
                    await context.SaveChangesAsync();
                }
                else if (ButtonType == "UpdateMap")
                {
                    Settings settings1 = new Settings();
                    settings1.Map = settings.Map;
                    context.Settings.Add(settings1);
                    await context.SaveChangesAsync();
                }
                else if (ButtonType == "UpdateTiming")
                {
                    Settings settings1 = new Settings();
                    settings1.Day = settings.Day;
                    settings1.StartTime = settings.StartTime;
                    settings1.EndTime = settings.EndTime;
                    context.Settings.Add(settings1);
                    await context.SaveChangesAsync();
                }
            }
            else
            {
                if (ButtonType == "UpdateSettings")
                {
                    setting.AppName = settings.AppName;
                    setting.ContactNumber = settings.ContactNumber;
                    setting.Location = settings.Location;
                    context.Settings.Update(setting);
                    await context.SaveChangesAsync();
                }
                else if (ButtonType == "UpdateLogo")
                {
                    if (Request.Form.Files.Count() > 0)
                    {
                        var file = settings.LogoImage;
                        string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/website/images/logo");
                        if (!Directory.Exists(path))
                            Directory.CreateDirectory(path);
                        var filePath = path + file.FileName;
                        FileInfo files = new FileInfo(filePath);
                        if (files.Exists)
                        {
                            files.Delete();
                        }
                        var allowedExtensions = new[] {
                        ".Jpg", ".png", ".jpg", ".jpeg"
                        };
                        var ext = Path.GetExtension(file.FileName);
                        if (allowedExtensions.Contains(ext))
                        {
                            string fileNameWithPath = Path.Combine(path, file.FileName);
                            using (var stream = new FileStream(fileNameWithPath, FileMode.Create))
                            {
                                file.CopyTo(stream);
                            }
                            setting.Logo = file.FileName;
                            context.Settings.Update(setting);
                            await context.SaveChangesAsync();
                        }
                    }
                }
                else if (ButtonType == "UpdateText")
                {
                    setting.HeaderText = settings.HeaderText;
                    setting.FooterText = settings.FooterText;
                    setting.AboutText = settings.AboutText;
                    setting.ContactText = settings.ContactText;
                    context.Settings.Update(setting);
                    await context.SaveChangesAsync();
                }
                else if (ButtonType == "UpdateMap")
                {
                    setting.Map = settings.Map;
                    context.Settings.Update(setting);
                    await context.SaveChangesAsync();
                }
                else if (ButtonType == "UpdateTiming")
                {
                    setting.Day = settings.Day;
                    setting.StartTime = settings.StartTime;
                    setting.EndTime = settings.EndTime;
                    context.Settings.Update(setting);
                    await context.SaveChangesAsync();
                }
            }
            return View(setting);
        }

        [HttpGet]
        public IActionResult Comments()
        {
            var comments = context.Comments.ToList();
            return View(comments);
        }

        [HttpGet]
        public IActionResult Slider(int? id)
        {
            if (id != null)
            {
                var galleries = context.Sliders.Where(x => x.SliderID == id).FirstOrDefault();
                return View(galleries);
            }
            return View();
        }
        [HttpGet]
        public PartialViewResult LoadSlider()
        {
            var galleries = context.Sliders.ToList();
            return PartialView("_LoadSlider", galleries);
        }
        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult> Slider(int? id, Sliders model, string OldImage)
        {
            if (id != null)
            {
                var galleries = context.Sliders.Where(x => x.SliderID == id).FirstOrDefault();
                if (!string.IsNullOrEmpty(OldImage) && model.imageFile == null)
                {
                    galleries.SliderImage = OldImage;
                }
                else
                {
                    var file = model.imageFile;
                    string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Uploads/SliderImages");

                    //create folder if not exist
                    if (!Directory.Exists(path))
                        Directory.CreateDirectory(path);

                    var filePath = path + file.FileName;
                    FileInfo files = new FileInfo(filePath);
                    if (files.Exists)
                    {
                        files.Delete();
                    }

                    var allowedExtensions = new[] {
                        ".Jpg", ".png", ".jpg", ".jpeg"
                        };
                    var ext = Path.GetExtension(file.FileName);
                    if (allowedExtensions.Contains(ext))
                    {
                        string fileNameWithPath = Path.Combine(path, file.FileName);
                        using (var stream = new FileStream(fileNameWithPath, FileMode.Create))
                        {
                            await file.CopyToAsync(stream);
                        }
                    }
                    galleries.SliderImage = file.FileName;
                }
                galleries.Ord = model.Ord;
                galleries.Visibility = model.Visibility;
                context.Sliders.Update(galleries);
                context.SaveChanges();
                return Redirect("~/Dashboard/Slider");
            }
            else
            {
                Sliders galleries = new Sliders();
                var file = model.imageFile;
                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Uploads/SliderImages");

                //create folder if not exist
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);

                var filePath = path + file.FileName;
                FileInfo files = new FileInfo(filePath);
                if (files.Exists)
                {
                    files.Delete();
                }

                var allowedExtensions = new[] {
                        ".Jpg", ".png", ".jpg", ".jpeg"
                        };
                var ext = Path.GetExtension(file.FileName);
                if (allowedExtensions.Contains(ext))
                {
                    string fileNameWithPath = Path.Combine(path, file.FileName);
                    using (var stream = new FileStream(fileNameWithPath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                    galleries.SliderImage = file.FileName;
                    galleries.Ord = model.Ord;
                    galleries.Visibility = model.Visibility;
                    context.Sliders.Add(galleries);
                    context.SaveChanges();
                }
                return View(galleries);
            }
        }
        [HttpPost]
        public async Task<ActionResult> DeleteSlider(int id)
        {
            var gallery = await context.Sliders.FindAsync(id);
            if (gallery != null)
            {
                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Uploads/SliderImages/");
                var filePath = path + gallery.SliderImage;
                FileInfo file = new FileInfo(filePath);
                if (file.Exists)
                {
                    file.Delete();
                }
                context.Sliders.Remove(gallery);
                var i = context.SaveChanges();

                //Add default User to Role Admin    
                if (i > 0)
                {
                    return new JsonResult("Image delete successfully!");
                }
            }
            return new JsonResult("Error! image not deleted.");
        }

      


    }

}
