using ISA_TWAAOS.Models;
using ISA_TWAAOS.Models.Services;
using ISA_TWAAOS.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Web;

namespace ISA_TWAAOS.BussinesLogic
{
    public class UploadLogic
    {

        private FisiereServices  _fisiereServices;
        private DbContext _db;

        public UploadLogic(DbContext db)
        {
            _db = db;
            _fisiereServices = new FisiereServices(_db);

        }


        public AttachmentDownloadViewModel DownloadAttachment(int receivableAttachmentId)
        {
            AttachmentDownloadViewModel attFile = new AttachmentDownloadViewModel();

            FileLogic fl = new FileLogic();

            var att = _fisiereServices.Get(receivableAttachmentId);
            if (att == null)
                throw new Exception("Invalid file");
            try
            {
                attFile.FileBytes = fl.ReadFileBytesFromDisk(att.Path);
                attFile.FileName = att.Name;
                attFile.FileType = att.FileType;

            }
            catch (Exception ex)
            {
                throw new Exception("File cannot be downloaded!", ex);
            }

            return attFile;
        }

        //Add Attachment
        internal int AddAttachment(UploadFileViewModel uploadFile)
        {
            FileLogic fl = new FileLogic();
            UnicodeEncoding encoding = new UnicodeEncoding();
            //  byte[] fileByteArray = encoding.GetBytes(uploadFile.fileByteArray);
            string newName = Guid.NewGuid().ToString();

            try
            {

                fl.WriteFileToDisk(uploadFile.fileByteArray, newName);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            Fisiere att = new Fisiere()
            {
                Path = HttpContext.Current.Server.MapPath(Utils.GetAppSettings.GetAttachmentDirectoryPath() + "\\" + newName),
                Name = uploadFile.Name,
                FileType = uploadFile.FileType,

                IdStudent = uploadFile.IdStudent
            };
            //uploadFile.receivableAttachment.Path = HttpContext.Current.Server.MapPath(attachementDirectory.GetAttachmentDirectoryPath());

            // cl.AddAttachment(att);
            var newatt = _fisiereServices.Add(att);

            return newatt.Id;
        }

    
    }
}