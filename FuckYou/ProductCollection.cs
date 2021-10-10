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
                ProductName="SomeDrug",
                Liste="???",
                Stock="???",
                Cmd="???",
                CodeActe="???",
                TVA="???",
                Base="???",
                PrixTTC="3,22",
                Remise="???",
                Qte="???",
                Montant="3,22"
            });

            this.Add(new Product
            {
                No = "1",
                ProductName = "SomeDrug",
                Liste = "???",
                Stock = "???",
                Cmd = "???",
                CodeActe = "???",
                TVA = "???",
                Base = "???",
                PrixTTC = "3,22",
                Remise = "???",
                Qte = "???",
                Montant = "3,22"
            });

            this.Add(new Product
            {
                No = "2",
                ProductName = "SomeDrug",
                Liste = "???",
                Stock = "???",
                Cmd = "???",
                CodeActe = "???",
                TVA = "???",
                Base = "???",
                PrixTTC = "3,22",
                Remise = "???",
                Qte = "???",
                Montant = "3,22"
            });

            this.Add(new Product
            {
                No = "3",
                ProductName = "SomeDrug",
                Liste = "???",
                Stock = "???",
                Cmd = "???",
                CodeActe = "???",
                TVA = "???",
                Base = "???",
                PrixTTC = "3,22",
                Remise = "???",
                Qte = "???",
                Montant = "3,22"
            });

            this.Add(new Product
            {
                No = "4",
                ProductName = "SomeDrug",
                Liste = "???",
                Stock = "???",
                Cmd = "???",
                CodeActe = "???",
                TVA = "???",
                Base = "???",
                PrixTTC = "3,22",
                Remise = "???",
                Qte = "???",
                Montant = "3,22"
            });
        }
    }
}
