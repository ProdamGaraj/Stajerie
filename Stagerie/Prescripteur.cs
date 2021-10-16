using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stagerie
{
    class Prescripteur:Entity
    {
        public string Name { get; set; }

        public string LastName { get; set; }

        public string Hospital { get; set; }

        public string RPPS { get; set; }

        public int Id { get; set; }

        public int Finess { get; set; }

        public string Spec { get; set; }

        public DateTime? ModifiedAt { get; set; }

        public Prescripteur()
        {

        }

        public Prescripteur(string name, string lastName, string hospital, string rPPS, int id, int finess, string spec, DateTime? modifiedAt)
        {
            Name = name;
            LastName = lastName;
            Hospital = hospital;
            RPPS = rPPS;
            Id = id;
            Finess = finess;
            Spec = spec;
            ModifiedAt = modifiedAt;
        }
    }
}
