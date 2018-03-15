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
        public int age { get; set; }
        public string adresse { get; set; }
        public string telephone { get; set; }

        public List<string> antePerso { get; set; }
        public List<string> anteFamil { get; set; }
        public List<string> Risques { get; set; }

    }
}
