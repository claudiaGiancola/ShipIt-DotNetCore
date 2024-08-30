using System.Data;
using ShipIt.Models.ApiModels;

namespace ShipIt.Models.DataModels
{
    public class CompanyProductsStockDataModel : DataModel
    {

        [DatabaseColumnName("hld")]
        public int Held { get; set; }

        [DatabaseColumnName("gcp_cd")]
        public string Gcp { get; set; }
        [DatabaseColumnName("gln_nm")]
        public string CompanyName { get; set; }
        [DatabaseColumnName("gln_addr_02")]
        public string Addr2 { get; set; }
        [DatabaseColumnName("gln_addr_03")]
        public string Addr3 { get; set; }
        [DatabaseColumnName("gln_addr_04")]
        public string Addr4 { get; set; }
        [DatabaseColumnName("gln_addr_postalcode")]
        public string PostalCode { get; set; }
        [DatabaseColumnName("gln_addr_city")]
        public string City { get; set; }
        [DatabaseColumnName("contact_tel")]
        public string Tel { get; set; }
        [DatabaseColumnName("contact_mail")]
        public string Mail { get; set; }

        [DatabaseColumnName("gtin_cd")]
        public string Gtin { get; set; }

        [DatabaseColumnName("gtin_nm")]
        public string ProductName { get; set; }

        [DatabaseColumnName("l_th")]
        public int LowerThreshold { get; set; }

        [DatabaseColumnName("ds")]
        public int Discontinued { get; set; }

        [DatabaseColumnName("min_qt")]
        public int MinimumOrderQuantity { get; set; }


        public CompanyProductsStockDataModel(IDataReader dataReader): base(dataReader) {}

        // public CompanyProductsStockDataModel() {}

        public CompanyProductsStockDataModel()
        {
            // var dataRecord = (IDataRecord)dataReader;
            Held = this.Held;
            Gcp = this.Gcp;
            CompanyName = this.CompanyName;
            Addr2 = this.Addr2;
            Addr3 = this.Addr3;
            Addr4 = this.Addr4;
            PostalCode = this.PostalCode;
            City = this.City;
            Tel = this.Tel;
            Mail = this.Mail;
            Gtin = this.Gtin;
            ProductName = this.ProductName;
            LowerThreshold = this.LowerThreshold;
            Discontinued = this.Discontinued;
            MinimumOrderQuantity = this.MinimumOrderQuantity;
        }

    }
}