using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace DAO
{
    public class DataUlti
    {
        public static List<DTO.Supplier> DSSupplier()
        {
            var lqq = new List<DTO.Supplier>();
            Provider provider = new Provider();
            provider.Connect();
            string strSql = "sp_LoadSupplier";
            DataTable dt = provider.Select(CommandType.StoredProcedure, strSql);
            provider.Disconnect();
            foreach (DataRow dr in dt.Rows)
            {
                lqq.Add(DTO.Supplier.ReadSupplier(dr));
            }
            return lqq;
        }
        public static int IdMax()
        {
            Provider provider = new Provider();
            provider.Connect();
            string strSql = "sp_FindIDMax";
            int temp = provider.ExcuteScalar(CommandType.StoredProcedure, strSql);
            provider.Disconnect();
            return temp;
        }
        public static void AddSupplier(DTO.Supplier slr)
        {
            Provider provider = new Provider();
            provider.Connect();
            string strSql = "sp_AddSupplier";
            provider.ExecuteNonQuery(CommandType.StoredProcedure, strSql,
                     new SqlParameter { ParameterName = "@cpn", Value = slr.CompanyName },
                     new SqlParameter { ParameterName = "@ctn", Value = slr.ContactName },
                     new SqlParameter { ParameterName = "@ctt", Value = slr.ContactTitle },
                     new SqlParameter { ParameterName = "@adr", Value = slr.Address },
                     new SqlParameter { ParameterName = "@cty", Value = slr.City },
                     new SqlParameter { ParameterName = "@region", Value = slr.Region },
                     new SqlParameter { ParameterName = "@ptc", Value = slr.PostalCode },
                     new SqlParameter { ParameterName = "@country", Value = slr.Country },
                     new SqlParameter { ParameterName = "@phone", Value = slr.Phone },
                     new SqlParameter { ParameterName = "@fax", Value = slr.Fax },
                     new SqlParameter { ParameterName = "@hmp", Value = slr.HomePage }
                     );
            provider.Disconnect();
        }
        public static void DeleteSupplier(int id)
        {
            Provider provider = new Provider();
            provider.Connect();
            string strSql = "sp_DeleteSupplier";
            provider.ExecuteNonQuery(CommandType.StoredProcedure, strSql,
                new SqlParameter { ParameterName = "@id", Value = id });
            provider.Disconnect();
        }
        public static void UpdateSupplier(DTO.Supplier slr)
        {
            Provider provider = new Provider();
            provider.Connect();
            string strSql = "sp_UpdateSupplier";
            provider.ExecuteNonQuery(CommandType.StoredProcedure, strSql,
                     new SqlParameter { ParameterName = "@cpn", Value = slr.CompanyName },
                     new SqlParameter { ParameterName = "@ctn", Value = slr.ContactName },
                     new SqlParameter { ParameterName = "@ctt", Value = slr.ContactTitle },
                     new SqlParameter { ParameterName = "@adr", Value = slr.Address },
                     new SqlParameter { ParameterName = "@cty", Value = slr.City },
                     new SqlParameter { ParameterName = "@region", Value = slr.Region },
                     new SqlParameter { ParameterName = "@ptc", Value = slr.PostalCode },
                     new SqlParameter { ParameterName = "@country", Value = slr.Country },
                     new SqlParameter { ParameterName = "@phone", Value = slr.Phone },
                     new SqlParameter { ParameterName = "@fax", Value = slr.Fax },
                     new SqlParameter { ParameterName = "@hmp", Value = slr.HomePage },
                     new SqlParameter { ParameterName = "@id", Value = slr.SupplierID }
                     );
            provider.Disconnect();
        }
    }
}
