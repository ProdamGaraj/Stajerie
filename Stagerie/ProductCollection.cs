using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Stagerie
{
    class ProductCollection : EntityCollection
    {
        public ProductCollection()
        {

        }
        public void AddItem(string no, string productName, string liste, string stock, string cmd, string codeActe, string tVA, string bbase, string prixTTC, string remise, string qte, string montant)
        {
            this.Add(new Product(no, productName, liste, stock, cmd, codeActe, tVA, bbase, prixTTC, remise, qte, montant));
        }
    }
}
