//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ISA_TWAAOS.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Specializari
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Specializari()
        {
            this.Studentis = new HashSet<Studenti>();
        }
    
        public int Id { get; set; }
        public string Nume { get; set; }
        public Nullable<int> FacultateId { get; set; }
        public Nullable<System.DateTime> DataLimita { get; set; }
    
        public virtual Facultati Facultati { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Studenti> Studentis { get; set; }
    }
}
