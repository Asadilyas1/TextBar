using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Linq.Dynamic.Core;
using TaxBarAssociation.Areas.Identity.Data;

namespace TaxBarAssociation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        private readonly AppDBContext context;
        public MemberController(AppDBContext context)
        {
            this.context = context;
        }
        [HttpPost]
        public IActionResult GetCustomers()
        {
            try
            {
                var draw = Request.Form["draw"].FirstOrDefault();
                var start = Request.Form["start"].FirstOrDefault();
                var length = Request.Form["length"].FirstOrDefault();
                var sortColumn = Request.Form["columns[" + Request.Form["order[0][column]"].FirstOrDefault() + "][name]"].FirstOrDefault();
                var sortColumnDirection = Request.Form["order[0][dir]"].FirstOrDefault();
                var searchValue = Request.Form["search[value]"].FirstOrDefault();
                int pageSize = length != null ? Convert.ToInt32(length) : 0;
                int skip = start != null ? Convert.ToInt32(start) : 0;
                int recordsTotal = 0;
                var customerData = (from tempcustomer in context.Users
                                    join userRole in context.UserRoles
                                    on tempcustomer.Id equals userRole.UserId
                                    join role in context.Roles
                                    on userRole.RoleId equals role.Id
                                    where role.Name != "Administrator"
                                    select tempcustomer);
                if (!string.IsNullOrEmpty(sortColumn))
                {
                    if (!string.IsNullOrEmpty(sortColumnDirection))
                    {
                        customerData = customerData.OrderBy(sortColumn + " " + sortColumnDirection);
                    }
                }
                if (!string.IsNullOrEmpty(searchValue))
                {
                    customerData = customerData.Where(m => m.Name.Contains(searchValue)
                                                || m.BarCouncil.Contains(searchValue));
                }
                recordsTotal = customerData.Count();
                var data = customerData.Skip(skip).Take(pageSize).ToList();
                var jsonData = new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data };
                return Ok(jsonData);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
