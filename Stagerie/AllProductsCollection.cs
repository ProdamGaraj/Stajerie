using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stagerie
{
    class AllProductsCollection:ObservableCollection<string>
    {
        public string ProductNames { get; set; }
        public AllProductsCollection()
        {

        }
    }
}
