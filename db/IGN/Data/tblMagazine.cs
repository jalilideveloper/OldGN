//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace IGN.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblMagazine
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblMagazine()
        {
            this.tblNews = new HashSet<tblNew>();
        }
    
        public int MagazineID { get; set; }
        public string MagazineName { get; set; }
        public string RssUrl { get; set; }
        public string SiteTitle { get; set; }
        public Nullable<int> MenuID { get; set; }
        public string ContentText { get; set; }
    
        public virtual tblMenu tblMenu { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblNew> tblNews { get; set; }
    }
}
