using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using TaxBarAssociation.Areas.Identity.Data;
using TaxBarAssociation.Core.Repositories;
using TaxBarAssociation.Models;

namespace TaxBarAssociation.Controllers
{
    public class CoreController : Controller
    {
        private readonly ICoreCommitee _coreCommitee;
        public readonly AppDBContext _dBContext;
        public CoreController(ICoreCommitee coreCommitee, AppDBContext dBContext)
        {
            _dBContext = dBContext;
            _coreCommitee = coreCommitee;
        }


        [HttpGet]
        [Route("/core/core-commitee")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("/core/view-commitee")]
        public async Task<JsonResult> ViewCommitee()
        {
            var data = await _coreCommitee.GetAllCoreCommitee();
            return Json(new { data = data });
        }

        [HttpPost]
        [Route("/core/save")]
        public async Task<JsonResult> SaveData(CoreCommite core)
        {
            await _coreCommitee.SaveData(core);
            return Json(new { data = "Data saved successfully!" });
        }

        [HttpPost]
        [Route("/core/edit")]
        public async Task<JsonResult> EditData(int id)
        {
            var data = await _coreCommitee.EditData(id);
            return Json(new { data = data });
        }

        [HttpPost]
        [Route("/core/update")]
        public async Task<JsonResult> UpdateData(CoreCommite core)
        {
            await _coreCommitee.UpdateData(core);
            return Json(new { data = "Data update successfully!" });
        }

        [HttpPost]
        [Route("/core/delete")]
        public async Task<JsonResult> DeleteData(int id)
        {
            await _coreCommitee.DeleteData(id);
            return Json(new { data = "Data deleted successfully!" });
        }
    }
}
