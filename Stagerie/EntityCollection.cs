using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stagerie
{
    class EntityCollection : ObservableCollection<Entity>
    {
        public EntityCollection()
        {

        }
        public void WriteJson(string path)
        {
            foreach (var item in this)
            {
                item.WriteJson(path);
            }
        }
    }
}
