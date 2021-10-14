using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Stagerie
{
    class PrescripteurCollection : ObservableCollection<Prescripteur>
    {
        public PrescripteurCollection()
        {

        }
        void AddItem(string name, string lastName, string hospital, string rPPS, int id, int finess, string spec, DateTime? modifiedAt)
        {
            this.Add(new Prescripteur(name, lastName, hospital, rPPS, id, finess, spec, modifiedAt));
        }
    }
}
