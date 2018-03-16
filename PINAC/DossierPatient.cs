using System;
using System.Collections.Generic;
using System.Text;

namespace PINAC
{
    public class DossierPatient
    {
        public string idDossier { get; set; }
        public string idPatient { get; set; }
        public DateTime dateConsultation { get; set; }
        public string motif { get; set; }
        public string examClinique { get; set; }
        public string diagnostic { get; set; }

        public override string ToString()
        {
            return idDossier + " | " + idPatient + " | " + dateConsultation + " | " + motif;
        }
    }
}