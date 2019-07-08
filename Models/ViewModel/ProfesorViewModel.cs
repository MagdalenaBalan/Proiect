using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ISA_TWAAOS.Models.ViewModel
{
    public class ProfesorViewModel
    {
        public int Id { get; set; }
        public string Nume { get; set; }
        public string Prenume { get; set; }
        public string Facultate { get; set; }
        public Nullable<int> FacultateId { get; set; }
    }
}