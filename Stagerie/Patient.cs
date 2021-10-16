using System;
namespace Stagerie
{
    class Patient : Entity
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }

        public long NumeroSS { get; set; }

        public string SSName { get; set; }

        public string NAdh { get; set; }

        public string Adress { get; set; }

        public int TownIndex { get; set; }

        public string Centre { get; set; }

        public string TelephoneNumber { get; set; }

        public string EMail { get; set; }

        public bool Mutu { get; set; }

        public string MutuNumber { get; set; }

        public string Note { get; set; }

        public DateTime? ModifiedAt { get; set; }

        public Patient()
        {

        }

        public Patient(string firstName, string lastName, DateTime birthDate, long numeroSS, string sSName, string nAdh, string adress, int townIndex, string centre, string telephoneNumber, string eMail, bool mutu, string mutuNumber, string note, DateTime? modifiedAt)
        {
            FirstName = firstName;
            LastName = lastName;
            BirthDate = birthDate;
            NumeroSS = numeroSS;
            SSName = sSName;
            NAdh = nAdh;
            Adress = adress;
            TownIndex = townIndex;
            Centre = centre;
            TelephoneNumber = telephoneNumber;
            EMail = eMail;
            Mutu = mutu;
            MutuNumber = mutuNumber;
            Note = note;
            ModifiedAt = modifiedAt;
        }
    }
}