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
    
    public partial class ReservationByCar_Result
    {
        public int idreserv { get; set; }
        public Nullable<int> idclient { get; set; }
        public Nullable<int> idcar { get; set; }
        public string objectif_reserv { get; set; }
        public Nullable<double> kilometrage { get; set; }
        public Nullable<System.DateTime> date_debut { get; set; }
        public Nullable<System.DateTime> date_fin { get; set; }
    }
}
