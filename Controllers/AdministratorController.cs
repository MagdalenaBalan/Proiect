using ISA_TWAAOS.BussinesLogic;
using ISA_TWAAOS.Models;
using ISA_TWAAOS.Models.ViewModel;
using Microsoft.AspNet.Identity;
using System;
using System.Web.Mvc;

namespace ISA_TWAAOS.Controllers
{
    [Authorize]
    public class AdministratorController : Controller
    {
        // GET: Administrator
        public ActionResult Index()
        {
            return View();
        }
        private Entities db = new Entities();

        [HttpPost]
        public JsonResult AddFacultate(Facultati facultate)
        {
            try
            {
                Logic logic = new Logic(db);
                 logic.AddFacultate(facultate);
                return Json(Utils.JsonResponseFactory.SuccessResponse("Success"), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

            }
            return Json(Utils.JsonResponseFactory.ErrorResponse("Error"), JsonRequestBehavior.AllowGet);

        }
        [HttpPost]
        public JsonResult AddSpecializare(Specializari specializare)
        {
            try
            {
                Logic logic = new Logic(db);
                 logic.AddSpecializare(specializare);
                return Json(Utils.JsonResponseFactory.SuccessResponse("Success"), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

            }
            return Json(Utils.JsonResponseFactory.ErrorResponse("Error"), JsonRequestBehavior.AllowGet);

        }

       

        [HttpPost]
        public JsonResult GetListaFacultati()
        {
            try
            {
                Logic logic = new Logic(db);
                var items = logic.GetFacultati();
                return Json(Utils.JsonResponseFactory.SuccessResponse(items), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

            }
            return Json(Utils.JsonResponseFactory.ErrorResponse("Error"), JsonRequestBehavior.AllowGet);

        }

        
        [HttpPost]
        public JsonResult GetListaSpecializari(int facultateId)
        {
            try
            {
                Logic logic = new Logic(db);
                var items = logic.GetSpecializariByFacultateId(facultateId);
                return Json(Utils.JsonResponseFactory.SuccessResponse(items), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

            }
            return Json(Utils.JsonResponseFactory.ErrorResponse("Error"), JsonRequestBehavior.AllowGet);

        }


        [HttpGet]
        public JsonResult GetStudent()
        {
            try
            {
                var userId = User.Identity.GetUserId();
                Logic logic = new Logic(db);
                var items = logic.GetStudent(userId);
                return Json(Utils.JsonResponseFactory.SuccessResponse(items), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

            }
            return Json(Utils.JsonResponseFactory.ErrorResponse("Error"), JsonRequestBehavior.AllowGet);

        }
    }
}