//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Gestion_pointage_tourniquet.BaseClass
{
    using System;
    using System.Collections.Generic;
    
    public partial class MACHINE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MACHINE()
        {
            this.LECTEUR = new HashSet<LECTEUR>();
            this.PASSE = new HashSet<PASSE>();
            this.POINTAGE = new HashSet<POINTAGE>();
        }
    
        public decimal ID_M { get; set; }
        public string TYPE_M { get; set; }
        public string LIB { get; set; }
        public string IP { get; set; }
        public Nullable<decimal> PORT { get; set; }
        public string PWD { get; set; }
        public Nullable<decimal> ID_LECTEUR { get; set; }
        public Nullable<decimal> CODE_S { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LECTEUR> LECTEUR { get; set; }
        public virtual SOCIETE SOCIETE { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PASSE> PASSE { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<POINTAGE> POINTAGE { get; set; }
    }
}
