using System;
namespace Stagerie
{
    class Patient : Entity
    {
        public string Nom { get; set; }

        public string Prenom { get; set; }

        public DateTime LienNeDate { get; set; }

        public string NoSS { get; set; }

        public string NoSSCode { get; set; }

        public string NoAdhMutu { get; set; }

        public string CodeRemb { get; set; }

        public string CPVilleNom { get; set; }

        public string CPVilleCode { get; set; }

        public string Centre { get; set; }

        public string TelephoneNumber { get; set; }

        public string Mail { get; set; }

        public bool Mutu { get; set; }

        public string MutuNumber { get; set; }

        public string Note { get; set; }

        public DateTime DroitSince { get; set; }

        public DateTime DroitTo { get; set; }

        public DateTime? ModifiedAt { get; set; }

        public Patient()
        {

        }

        public Patient(string firstName, string lastName, DateTime birthDate, string numeroSS, string sSName, string nAdh, string adress, string townName, string townIndex, string centre, string telephoneNumber, string eMail, bool mutu, string mutuNumber, string note, DateTime droitSince, DateTime droitTo, DateTime? modifiedAt)
        {
            Nom = firstName;
            Prenom = lastName;
            LienNeDate = birthDate;
            NoSS = numeroSS;
            NoSSCode = sSName;
            NoAdhMutu = nAdh;
            CodeRemb = adress;
            CPVilleNom = townName;
            CPVilleCode = townIndex;
            Centre = centre;
            TelephoneNumber = telephoneNumber;
            Mail = eMail;
            Mutu = mutu;
            MutuNumber = mutuNumber;
            Note = note;
            DroitSince = droitSince;
            DroitTo = droitTo;
            ModifiedAt = modifiedAt;
        }
        public override string ToString()
        {
            return Nom + ' ' + Prenom;
        }
    }
}