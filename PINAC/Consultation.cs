using System;
using System.Collections.Generic;
using System.Text;

namespace PINAC
{
    class Consultation
    {
        public DateTime dateConsultation { get; set; }
        public string etat { get; set; }
        public bool urgence { get; set; }
        public string motif { get; set; }
        public List<string> examen { get; set; }
        public List<string> diagnostic { get; set; }

    }
}
