using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace ISA_TWAAOS.Models.ViewModel
{
    public class StudentViewModel
    {
        public int Id { get; set; }
        public string Nume { get; set; }
        public string Prenume { get; set; }
        public string InitialaTatalui { get; set; }
        public string Email { get; set; }
        public Nullable<int> SpecializareId { get; set; }
        public ICollection<SpecializareViewModel> Specializare { get; set; }
        public string SpecializareStudent { get; set; }
        public string FacultateStudent { get; set; }
        public string NivelStudii { get; set; }
        public string TitlulLucrarii { get; set; }
        public Nullable<int> ProfesorId { get; set; }
        public string NumeProfesor { get; set; }
        public string ProfesorPrenume { get; set; }
        public string ProfesorNume { get; set; }
        public Nullable<int> LucrareId { get; set; }
        public string StadiuLucrare { get; set; }
        public string UserId { get; set; }

        public virtual ICollection<AttachamentViewModel> Fisier { get; set; }
    }


    public class StudentCuFisier
    {
        public Studenti student { get; set; }

        public UploadFileViewModel uploadFile { get; set; }
    }

    public class UploadFileViewModel
    {
        public string fileByteArray { get; set; }
        public string Name { get; set; }
        public string FileType { get; set; }

        public Nullable<int> IdStudent { get; set; }

    }

    public class AttachmentDownloadViewModel
    {
        public byte[] FileBytes { get; set; }
        public string FileName { get; set; }
        public string FileType { get; set; }

    }


    public class FileWriteResponse
    {
        public string Text { get; set; }
        public bool IsError { get; set; }
    }

    public class FileReadResponse
    {
        public string Text { get; set; }
        public bool isError { get; set; }
        public FileInfo[] File { get; set; }
    }

    public class AttachamentViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public Nullable<int> IdStudent { get; set; }


    }


}