//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CarRental.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class contrat
    {
        public int idcontrat { get; set; }
        public Nullable<int> idclient { get; set; }
        public Nullable<System.DateTime> date_debut { get; set; }
        public Nullable<System.DateTime> date_fin { get; set; }
        public Nullable<decimal> montant_contrat { get; set; }
        public Nullable<int> idCar { get; set; }
        public Nullable<int> idreserv { get; set; }
    
        public virtual client client { get; set; }
        public virtual voiture voiture { get; set; }
        public virtual reservation reservation { get; set; }
    }
}
