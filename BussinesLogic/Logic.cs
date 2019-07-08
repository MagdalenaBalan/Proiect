using ISA_TWAAOS.Models;
using ISA_TWAAOS.Models.Services;
using ISA_TWAAOS.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ISA_TWAAOS.BussinesLogic
{
    public class Logic
    {

        private DbContext _db;

        private StudentiServices _studentiServices;
        private ProfesoriServices _profesoriServices;
        private SpecializariServices _specializariServices;
        private FacultatiServices _facultatiServices;

        public Logic(DbContext db)
        {
            _db = db;
            _studentiServices = new StudentiServices(_db);
            _profesoriServices = new ProfesoriServices(_db);
            _specializariServices = new SpecializariServices(_db);
            _facultatiServices = new FacultatiServices(_db);
        }


        #region Student
        public void DeleteStudent(int studentId)
        {
            var student = _studentiServices.Get(studentId);

            _studentiServices.Delete(student);
        }

        public void AddStudent(Studenti student)
        {
            _studentiServices.Add(student);
        }

        public void EditStudent(StudentViewModel student)
        {
            Studenti oldStudent = _studentiServices.Get(student.Id);

            oldStudent.Email = student.Email;
            oldStudent.InitialaTatalui = student.InitialaTatalui;
            oldStudent.NivelStudii = student.NivelStudii;
            oldStudent.LucrareId = student.LucrareId;
            oldStudent.Nume = student.Nume;
            oldStudent.Prenume = student.Prenume;
            oldStudent.ProfesorId = student.ProfesorId;
            oldStudent.SpecializareId = student.SpecializareId;
            oldStudent.StadiuLucrare = student.StadiuLucrare;
            oldStudent.TitlulLucrarii = student.TitlulLucrarii;

            _studentiServices.Update(oldStudent, oldStudent.Id);
        }

        public void UpdateLicentaStatus(StudentViewModel student)
        {
            Studenti oldStudent = _studentiServices.Get(student.Id);

            oldStudent.StadiuLucrare = student.StadiuLucrare;

            _studentiServices.Update(oldStudent, oldStudent.Id);
        }


        public void UpdateStudent(StudentViewModel student)
        {
            Studenti oldStudent = _studentiServices.Get(student.Id);

            oldStudent.Nume = student.Nume;
            oldStudent.Prenume = student.Prenume;
            oldStudent.InitialaTatalui = student.InitialaTatalui;
            oldStudent.Email = student.Email;
            oldStudent.TitlulLucrarii = student.TitlulLucrarii;

            _studentiServices.Update(oldStudent, oldStudent.Id);
        }
        public List<StudentViewModel> GetStudent(string UserId)
        {

            return _studentiServices.GetAllQuerable().Where(x => x.UserId == UserId).Select(x => new StudentViewModel()
            {

                Email = x.Email,
                Id = x.Id,
                InitialaTatalui = x.InitialaTatalui,
                NivelStudii = x.NivelStudii,
                LucrareId = x.LucrareId,
                Nume = x.Nume,
                Prenume = x.Prenume,
                ProfesorId = x.ProfesorId,
                SpecializareId = x.SpecializareId,
                StadiuLucrare = x.StadiuLucrare,
                TitlulLucrarii = x.TitlulLucrarii,
                UserId = x.UserId,
                NumeProfesor = x.Profesori.Nume + x.Profesori.Prenume,
                ProfesorNume = x.Profesori.Nume,
                ProfesorPrenume = x.Profesori.Prenume,
                SpecializareStudent = x.Specializari.Nume,
                FacultateStudent = x.Profesori.Facultati.Nume,
                Fisier = x.Fisieres.Select(y => new AttachamentViewModel()
                {
                    Name = y.Name,
                    Path = y.Path,
                    Id = y.Id

                }).ToList()


            }).ToList();

        }
        #endregion

        #region
        public List<StudentViewModel> GetStudentByProfesorId(string UserId)
        {

            return _studentiServices.GetAllQuerable().Where(x => x.Profesori.UserId == UserId).Select(x => new StudentViewModel()
            {

                Email = x.Email,
                Id = x.Id,
                InitialaTatalui = x.InitialaTatalui,
                NivelStudii = x.NivelStudii,
                LucrareId = x.LucrareId,
                Nume = x.Nume,
                Prenume = x.Prenume,
                ProfesorId = x.ProfesorId,
                SpecializareId = x.SpecializareId,
                StadiuLucrare = x.StadiuLucrare,
                TitlulLucrarii = x.TitlulLucrarii,
                UserId = x.UserId,
                SpecializareStudent = x.Specializari.Nume,
                FacultateStudent = x.Profesori.Facultati.Nume,
                Fisier = x.Fisieres.Select(y => new AttachamentViewModel()
                {
                    Name = y.Name,
                    Path = y.Path,
                    Id = y.Id

                }).ToList()

            }).ToList();

        }
        #endregion

        #region Profesori

        public void DeleteProfesor(int profesorId)
        {
            var profesor = _profesoriServices.Get(profesorId);

            _profesoriServices.Delete(profesor);
        }

        public void AddProfesor(Profesori profesor)
        {
            _profesoriServices.Add(profesor);
        }

        public void EditProfesor(ProfesorViewModel profesor)
        {
            Profesori oldProfesor = _profesoriServices.Get(profesor.Id);

            oldProfesor.Nume = profesor.Nume;
            oldProfesor.Prenume = profesor.Prenume;
            oldProfesor.FacultateId = profesor.FacultateId;
            _profesoriServices.Update(oldProfesor, oldProfesor.Id);
        }

        public List<ProfesorViewModel> GetProfesoriById(string UserId)
        {

            return _profesoriServices.GetAllQuerable().Where(x => x.AspNetUser.Id == UserId).Select(x => new ProfesorViewModel()
            {

                Id = x.Id,
                Nume = x.Nume,
                Prenume = x.Prenume,
                FacultateId = x.FacultateId,
                Facultate = x.Facultati.Nume


            }).ToList();

        }

        public List<ProfesorViewModel> GetProfesorByFacultate(int idFacultate)
        {

            return _profesoriServices.GetAllQuerable().Where(x => x.FacultateId == idFacultate).Select(x => new ProfesorViewModel()
            {

                Id = x.Id,
                Nume = x.Nume,
                Prenume = x.Prenume,
                FacultateId = x.FacultateId,
                Facultate = x.Facultati.Nume

            }).ToList();

        }
        #endregion

        #region Specializari

        public void DeleteSpecializare(int specializareId)
        {
            var specializare = _specializariServices.Get(specializareId);

            _specializariServices.Delete(specializare);
        }

        public void AddSpecializare(Specializari specializare)
        {
            _specializariServices.Add(specializare);
        }

        public void EditSpecializare(SpecializareViewModel specializare)
        {
            Specializari oldSpecializare = _specializariServices.Get(specializare.Id);

            oldSpecializare.FacultateId = specializare.FacultateId;
            oldSpecializare.DataLimita = specializare.DataLimita;
            oldSpecializare.Nume = specializare.Nume;

            _specializariServices.Update(oldSpecializare, oldSpecializare.Id);
        }
        public List<SpecializareViewModel> GetSpecializariByFacultateId(int IdFacultate)
        {

            return _specializariServices.GetAllQuerable().Where(x => x.FacultateId == IdFacultate).Select(x => new SpecializareViewModel()
            {
                Id = x.Id,
                Nume = x.Nume,
                FacultateId = x.FacultateId,
                DataLimita = x.DataLimita

            }).ToList();

        }
        #endregion

        #region Facultatati

        public void DeleteFacultate(int facultateId)
        {
            var facultate = _facultatiServices.Get(facultateId);

            _facultatiServices.Delete(facultate);
        }

        public void AddFacultate(Facultati facultate)
        {
            _facultatiServices.Add(facultate);
        }

        public void EditFacultate(FacultateViewModel facultate)
        {
            Facultati oldFacultate = _facultatiServices.Get(facultate.Id);

            oldFacultate.Nume = facultate.Nume;

            _facultatiServices.Update(oldFacultate, oldFacultate.Id);
        }
        public List<FacultateViewModel> GetFacultati()
        {

            return _facultatiServices.GetAllQuerable().Select(x => new FacultateViewModel()
            {
                Id = x.Id,
                Nume = x.Nume,

            }).ToList();

        }
        #endregion
    }
}