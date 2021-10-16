using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stagerie
{
    public class Product:Entity
    {
        public string No { get; set; }

        public string ProductName { get; set; }

        public string Liste { get; set; }//rand{1,2,3}

        public string Stock { get; set; }//rand +\-

        public string Cmd { get; set; }//rand +

        public string CodeActe { get; set; }//rand abc

        public string TVA { get; set; }//rand

        public string Base { get; set; }//rand <= prixttc

        public string PrixTTC { get; set; }//>0

        public string Remise { get; set; }//>=0

        public string Qte { get; set; }//!=0

        public string Montant { get; set; }//prixttc*Remise*qte

        public Product(){

        }

        public Product(string no, string productName, string liste, string stock, string cmd, string codeActe, string tVA, string @base, string prixTTC, string remise, string qte, string montant)
        {
            No = no;
            ProductName = productName;
            Liste = liste;
            Stock = stock;
            Cmd = cmd;
            CodeActe = codeActe;
            TVA = tVA;
            Base = @base;
            PrixTTC = prixTTC;
            Remise = remise;
            Qte = qte;
            Montant = montant;
        }
    }
}