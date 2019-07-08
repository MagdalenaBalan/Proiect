using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ISA_TWAAOS.Models.Services
{
    public class ProfesoriServices : BaseService<Profesori>
    {
        public ProfesoriServices(DbContext context) : base(context)
        {

        }
    }
}