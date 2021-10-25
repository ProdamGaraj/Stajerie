using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Stagerie
{
    class PrescripteurCollection : EntityCollection
    {
        public PrescripteurCollection()
        {

        }
        void AddItem(string name, string lastName, string hospital, string rPPS, int id, int finess, string phoneNumber, string spec, string specType, DateTime? modifiedAt)
        {
            this.Add(new Prescripteur(name, lastName, hospital, rPPS, id, finess, phoneNumber, spec,specType, modifiedAt));
        }
    }
}
