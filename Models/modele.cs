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
    
    public partial class modele
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public modele()
        {
            this.voitures = new HashSet<voiture>();
        }
    
        public int idmodele { get; set; }
        public string nom_modele { get; set; }
        public Nullable<int> idmarque { get; set; }
        public Nullable<System.DateTime> datesortie { get; set; }
    
        public virtual marque marque { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<voiture> voitures { get; set; }
    }
}
