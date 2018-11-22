using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace DTO
{
    public class Supplier
    {
        private int supplierID;

        public int SupplierID
        {
            get { return supplierID; }
            set { supplierID = value; }
        }
        private string homePage;

        public string HomePage
        {
            get { return homePage; }
            set { homePage = value; }
        }
        private string companyName;

        public string CompanyName
        {
            get { return companyName; }
            set { companyName = value; }
        }
        private string contactTitle;

        public string ContactTitle
        {
            get { return contactTitle; }
            set { contactTitle = value; }
        }
        private string contactName;

        public string ContactName
        {
            get { return contactName; }
            set { contactName = value; }
        }
        private string address;

        public string Address
        {
            get { return address; }
            set { address = value; }
        }
        private string city;

        public string City
        {
            get { return city; }
            set { city = value; }
        }
        private string region;

        public string Region
        {
            get { return region; }
            set { region = value; }
        }
        private string postalCode;

        public string PostalCode
        {
            get { return postalCode; }
            set { postalCode = value; }
        }
        private string country;

        public string Country
        {
            get { return country; }
            set { country = value; }
        }
        private string phone;

        public string Phone
        {
            get { return phone; }
            set { phone = value; }
        }
        private string fax;

        public string Fax
        {
            get { return fax; }
            set { fax = value; }
        }

     
        public static Supplier AddSupplier(int ID,string CompanyName, string ContactTitle, string ContactName, string Address, string City, string Region, string PostalCode, string Country, string Phone, string Fax, string HomePage)
        {
            var sp = new Supplier
          {
              supplierID = ID,
              companyName = CompanyName,
              contactTitle = ContactTitle,
              contactName = ContactName,
              address = Address,
              city = City,
              region = Region,
              postalCode = PostalCode,
              country = Country,
              phone = Phone,
              fax = Fax,
              homePage = HomePage
          };
            return sp;
        }
        public static Supplier ReadSupplier(DataRow dr)
        {
            var sp = new Supplier
            {
                supplierID = Convert.ToInt32(dr["SupplierID"]),
                companyName = Convert.ToString(dr["CompanyName"]),
                contactTitle = Convert.ToString(dr["ContactTitle"]),
                contactName = Convert.ToString(dr["ContactName"]),
                address = Convert.ToString(dr["Address"]),
                city = Convert.ToString(dr["City"]),
                region = Convert.ToString(dr["Region"]),
                postalCode = Convert.ToString(dr["PostalCode"]),
                country = Convert.ToString(dr["Country"]),
                phone = Convert.ToString(dr["Phone"]),
                fax = Convert.ToString(dr["Fax"]),
                homePage = Convert.ToString(dr["HomePage"])
            };
            return sp;
        }

        public static string CreateSupplierID()
        {
            int ms = DAO.DataUlti.IdMax();
            ms++;
            return ms.ToString();
        }
    }
}