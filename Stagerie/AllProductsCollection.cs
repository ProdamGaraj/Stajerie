using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stagerie
{
    class AllProductsCollection
    {
        public ObservableCollection<string> ProductNames { get; set; } = new ObservableCollection<string>();
        public AllProductsCollection()
        {

        }
    }
}
