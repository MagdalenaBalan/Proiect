using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ISA_TWAAOS.Models.ViewModel
{
    public class SpecializareViewModel
    {
        public int Id { get; set; }
        public string Nume { get; set; }
        public Nullable<int> FacultateId { get; set; }
        public Nullable<System.DateTime> DataLimita { get; set; }

    }
}