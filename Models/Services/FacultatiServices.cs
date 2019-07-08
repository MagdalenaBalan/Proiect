using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ISA_TWAAOS.Models.Services
{
    public class FacultatiServices : BaseService<Facultati>
    {
        public FacultatiServices(DbContext context) : base(context)
        {

        }
    }
}