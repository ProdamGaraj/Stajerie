using System.Collections.ObjectModel;

namespace Stagerie
{
    class PatientCollection : EntityCollection
    {
        public PatientCollection()
        {

        }
        public void AddItem(Patient patient)
        {
            this.Add(patient);
        }
    }
}
