using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace FuckYou
{
    public class ProductCollection:ObservableCollection<Product>
    {
        public ProductCollection()
        {
            this.Add(new Product {
                No="0",
                ProductName="",
                Liste="",
                Stock="",
                Cmd="",
                CodeActe="",
                TVA="",
                Base="",
                PrixTTC="",
                Remise="",
                Qte="",
                Montant=""
            });
        }
    }
}
