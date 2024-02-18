using API_practice.Context;
using API_practice.Interface;
using API_practice.Model;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

namespace API_practice.Repository
{
    public class DealerRepository :IDealerInterface
    {
        private readonly SqlConnection _dealerConnection;
        public DealerRepository(Config connection)
        {
            _dealerConnection = connection.connection;
        }

        //public List<DealerClass> GetAll()
        //{
        //    List<DealerClass> dealers = new List<DealerClass>();
        //        try
        //    {
        //        _dealerConnection.Open();
        //        SqlCommand cmd = new SqlCommand();
        //        cmd.Connection = _dealerConnection;
        //        SqlDataReader dr;
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.CommandText = "GetAllDealers";
        //        dr = cmd.ExecuteReader();
        //        if (dr.HasRows)
        //        {
        //            while (dr.Read())
        //            {
        //                DealerClass dealerClass = new DealerClass();
        //                dealerClass.DealerId = dr.GetInt32("DealerId");
        //                dealerClass.DealerName = dr.GetString("DealerName");
        //                dealerClass.DealerAddress = dr.GetString("DealerAddress");
        //                dealerClass.DealerPhone = dr.GetInt32("DealerPhone");
        //                dealerClass.DealerCountry = dr.GetString("DealerCountry");
        //                dealerClass.DealerShipStartDate = dr.GetString("DealerShipStartDate");
        //                dealerClass.Email = dr.GetString("Email");
        //                dealerClass.Active = dr.GetString("Active");
        //                dealerClass.CreatedBy = dr.GetString("CreatedBy");
        //                dealerClass.CreatedDate = dr.GetString("CreatedDate");
        //                dealerClass.ModifiedBy = dr.GetString("ModifiedBy");
        //                dealerClass.ModifiedDate = dr.GetString("ModifiedDate");
        //                dealers.Add(dealerClass);
        //            }
        //        }

        //        }
        //    catch(Exception)
        //    {
        //        throw;
        //    }
        //    finally
        //    {
        //        _dealerConnection.Close();
        //    }
        //    return dealers;
        //}

        public List<DealerClass> GetAll()
        {
            List<DealerClass> dealer = _dealerConnection.Query<DealerClass>("GetAllDealers",commandType: CommandType.StoredProcedure).ToList();
            return dealer;
        }


        public DealerClass GetById(int DealerId)
        {
            var dealer = _dealerConnection.QueryFirst<DealerClass>("GetById", new
            {
                DealerId = DealerId
            },
            commandType: CommandType.StoredProcedure);
            return dealer;
        }

        public void Insert(DealerClass dealerClass)
        {
            _dealerConnection.Execute("InsertOrUpdate", new
            {
                DealerId= dealerClass.DealerId,
                DealerName = dealerClass.DealerName,
                DealerAddress = dealerClass.DealerAddress,
                DealerPhone = dealerClass.DealerPhone,
                DealerCountry = dealerClass.DealerCountry,
                DealershipStartDate = dealerClass.DealerShipStartDate,
                Email = dealerClass.Email,
                Active = dealerClass.Active,
                CreatedBy = dealerClass.CreatedBy,
                CreatedDate = dealerClass.CreatedDate,
                ModifiedBy = dealerClass.ModifiedBy,
                ModifiedDate = dealerClass.ModifiedDate,
                Password = dealerClass.Password

            },
            commandType: CommandType.StoredProcedure
            );
        }

        public void Update(DealerClass dealerClass , int DealerId)
        {
            _dealerConnection.Execute("InsertOrUpdate", new
            {
                DealerId = DealerId,
                DealerName = dealerClass.DealerName,
                DealerAddress = dealerClass.DealerAddress,
                DealerPhone = dealerClass.DealerPhone,
                DealerCountry = dealerClass.DealerCountry,
                DealershipStartDate = dealerClass.DealerShipStartDate,
                Email = dealerClass.Email,
                Active = dealerClass.Active,
                CreatedBy = dealerClass.CreatedBy,
                CreatedDate = dealerClass.CreatedDate,
                ModifiedBy = dealerClass.ModifiedBy,
                ModifiedDate = dealerClass.ModifiedDate,
                Password = dealerClass.Password
            },
            commandType: CommandType.StoredProcedure
            );
        }

        public void Delete(int DealerId)
        {
            _dealerConnection.Execute("DeleteDealer", new
            {
                DealerId = DealerId
            }, commandType: CommandType.StoredProcedure
            );
        }
    }
}
