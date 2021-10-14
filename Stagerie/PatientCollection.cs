using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Stagerie
{
    class PatientCollection : ObservableCollection<Patient>
    {
        public PatientCollection()
        {

        }
        public void AddItem(string firstName, string lastName, DateTime birthDate, long numeroSS, string sSName, string nAdh, string adress, int townIndex, string centre, string telephoneNumber, string eMail, bool mutu, string mutuNumber, string note, DateTime modifiedAt)
        {
            this.Add(new Patient(firstName, lastName, birthDate, numeroSS, sSName, nAdh, adress, townIndex, centre,  telephoneNumber, eMail, mutu, mutuNumber, note, modifiedAt));
        }
    }
}
