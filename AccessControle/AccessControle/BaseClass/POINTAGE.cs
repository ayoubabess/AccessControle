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
    
    public partial class POINTAGE
    {
        public decimal idPointage { get; set; }
        public Nullable<System.DateTime> DATE_P { get; set; }
        public string SENS { get; set; }
        public Nullable<decimal> ID_M { get; set; }
        public string MAT { get; set; }
    
        public virtual MACHINE MACHINE { get; set; }
        public virtual PERSONNEL PERSONNEL { get; set; }
    }
}
