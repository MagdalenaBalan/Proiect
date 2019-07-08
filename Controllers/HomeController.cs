using ISA_TWAAOS.BussinesLogic;
using ISA_TWAAOS.Models;
using ISA_TWAAOS.Models.ViewModel;
using Microsoft.AspNet.Identity;
using System;
using System.Web.Mvc;

namespace ISA_TWAAOS.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private Entities db = new Entities();

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetCurrentUserById()
        {
            try
            {
                var userId = User.Identity.GetUserId();
                Logic logic = new Logic(db);
                var profesor = logic.GetProfesoriById(userId);
                if (profesor.Count == 0)
                {
                    var student = logic.GetStudent(userId);
                    return Json(Utils.JsonResponseFactory.SuccessResponse(student), JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(Utils.JsonResponseFactory.SuccessResponse(profesor), JsonRequestBehavior.AllowGet);

                }
            }
            catch (Exception ex)
            {

            }
            return Json(Utils.JsonResponseFactory.ErrorResponse("Error"), JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public JsonResult GetStudentByProfesorId()
        {
            try
            {
                var userId = User.Identity.GetUserId();
                Logic logic = new Logic(db);

                var studenti = logic.GetStudentByProfesorId(userId);
                return Json(Utils.JsonResponseFactory.SuccessResponse(studenti), JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {

            }
            return Json(Utils.JsonResponseFactory.ErrorResponse("Error"), JsonRequestBehavior.AllowGet);

        }


        public JsonResult AddProfesor(Profesori profesor)
        {
            try
            {
                profesor.UserId = User.Identity.GetUserId();
                Logic logic = new Logic(db);
                logic.AddProfesor(profesor);
                return Json(Utils.JsonResponseFactory.SuccessResponse("Success"), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

            }
            return Json(Utils.JsonResponseFactory.ErrorResponse("Error"), JsonRequestBehavior.AllowGet);

        }

        public JsonResult GetProfesorByFacultate(int idFacultate)
        {
            try
            {
                Logic logic = new Logic(db);
                var items = logic.GetProfesorByFacultate(idFacultate);
                return Json(Utils.JsonResponseFactory.SuccessResponse(items), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

            }
            return Json(Utils.JsonResponseFactory.ErrorResponse("Error"), JsonRequestBehavior.AllowGet);

        }

        public JsonResult UpdateLicentaStatus(StudentViewModel student)
        {
            try
            {
                Logic logic = new Logic(db);
                 logic.UpdateLicentaStatus(student);
                return Json(Utils.JsonResponseFactory.SuccessResponse("Success"), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

            }
            return Json(Utils.JsonResponseFactory.ErrorResponse("Error"), JsonRequestBehavior.AllowGet);

        }

        public JsonResult UpdateStudent(StudentViewModel student)
        {
            try
            {
                Logic logic = new Logic(db);
                 logic.UpdateStudent(student);
                return Json(Utils.JsonResponseFactory.SuccessResponse("Success"), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

            }
            return Json(Utils.JsonResponseFactory.ErrorResponse("Error"), JsonRequestBehavior.AllowGet);

        }

        public JsonResult GetSpecializariByFacultateId(int idFacultate)
        {
            try
            {
                Logic logic = new Logic(db);
                var items = logic.GetSpecializariByFacultateId(idFacultate);
                return Json(Utils.JsonResponseFactory.SuccessResponse(items), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

            }
            return Json(Utils.JsonResponseFactory.ErrorResponse("Error"), JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public JsonResult AddStudent(StudentCuFisier student)
        {
            try
            {
                Logic logic = new Logic(db);
                UploadLogic cl = new UploadLogic(db);


                student.student.UserId = User.Identity.GetUserId();

                logic.AddStudent(student.student);

                student.uploadFile.FileType = student.uploadFile.fileByteArray.Substring(0, student.uploadFile.fileByteArray.IndexOf(","));
                student.uploadFile.fileByteArray = student.uploadFile.fileByteArray.Substring(student.uploadFile.fileByteArray.IndexOf(",") + 1);
                student.uploadFile.IdStudent = student.student.Id;
                cl.AddAttachment(student.uploadFile);
                return Json(Utils.JsonResponseFactory.SuccessResponse("Success"), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

            }
            return Json(Utils.JsonResponseFactory.ErrorResponse("Error"), JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public JsonResult GetAttachament(int receivableAttachemntId)
        {

            AttachmentDownloadViewModel attToBeDownload = null;
            try
            {
                UploadLogic cl = new UploadLogic(db);
                attToBeDownload = cl.DownloadAttachment(receivableAttachemntId);
            }
            catch (Exception ex)
            {

            }

            //return attToBeDownload;
            return Json(Utils.JsonResponseFactory.SuccessResponse(attToBeDownload), JsonRequestBehavior.AllowGet);

        }




    }
}