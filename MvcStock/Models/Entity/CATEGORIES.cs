//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MvcStock.Models.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class CATEGORIES
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CATEGORIES()
        {
            this.PRODUCTS = new HashSet<PRODUCTS>();
        }
    
        public short KATEGORIID { get; set; }
        public string KATEGORIAD { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PRODUCTS> PRODUCTS { get; set; }
    }
}
