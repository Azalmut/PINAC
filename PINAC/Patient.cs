using System;
using System.Collections.Generic;
using System.Text;

namespace PINAC
{
    class Patient
    {
        public string nom { get; set; }
        public string prenom { get; set; }

        public int sexe { get; set; }
        public string dateNaiss { get; set; }
        public string CP { get; set; }
        public string ville { get; set; }
        public string adresse { get; set; }
        public string telFixe { get; set; }
        public string portable { get; set; }
        public string email { get; set; }



        public List<string> antePerso { get; set; }
        public List<string> anteFamil { get; set; }
        public List<string> Risques { get; set; }
        public List<Consultation> lesConsultations { get; set; }
        public List<Prescription> lesPrescriptions { get; set; }

        public override string ToString()
        {
            return nom + " " + prenom;
        }
    }
}
