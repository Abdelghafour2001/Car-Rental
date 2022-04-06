using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CarRental.Models;
namespace CarRental.ViewModels
{
    public class ModelesByMarques :modele
    {
        public List<modele> Modeles { get; set; }
    }
}