using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ISA_TWAAOS.Models.Services
{
   

    public class StudentiServices : BaseService<Studenti>
    {
        public StudentiServices(DbContext context) : base(context)
        {

        }
    }
}