//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CompuMarket_App.DB
{
    using System;
    using System.Collections.Generic;
    
    public partial class Services
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Services()
        {
            this.Payment = new HashSet<Payment>();
        }
    
        public int ServiseID { get; set; }
        public string FIO { get; set; }
        public Nullable<int> INN { get; set; }
        public string Adress { get; set; }
        public Nullable<System.DateTime> DatePay { get; set; }
        public string QtyRomm { get; set; }
        public Nullable<int> UserId { get; set; }
        public string QtyPeople { get; set; }
        public Nullable<bool> Status { get; set; }
        public string Square { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Payment> Payment { get; set; }
    }
}
