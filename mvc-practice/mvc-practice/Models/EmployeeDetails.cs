using Microsoft.Data.SqlClient;
using mvc_practice.Context;
using mvc_practice.Interface;
using System.Data;
namespace mvc_practice.Models
{



    public class EmployeeDetails : IEmployeeInterface
    {
        private readonly SqlConnection _connection;
        public EmployeeDetails(Config connect)
        {
            _connection = connect.connection;
        }
        
       
        public List<EmployeeClass> Get()
        {
            List<EmployeeClass> result = new List<EmployeeClass>();
            //SqlConnection cn = new SqlConnection();
            SqlDataReader dr;
            try
            {
                //cn.ConnectionString = @"Data Source=(localdb)\ProjectModels;Initial Catalog=Yash1;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                
                SqlCommand cmd = new SqlCommand();
                _connection.Open();
                
                cmd.Connection = _connection;
                cmd.CommandType =CommandType.StoredProcedure;
                cmd.CommandText = "SelectAllEmployees";
                
                dr = cmd.ExecuteReader();
               if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        EmployeeClass emp = new EmployeeClass();
                        emp.LoginName = dr.GetString("LoginName");
                        emp.FullName = dr.GetString("FullName");
                        emp.Password = dr.GetString("Password");
                        emp.Gender = dr.GetString("Gender");
                        emp.PhoneNumber = dr.GetString("PhoneNumber");
                        emp.CityId = dr.GetInt32("CityId");
                        emp.EmailId = dr.GetString("EmailId");
                        result.Add(emp);
                    }
                    dr.Close();
                    
                }
               return result;
            }



            catch (Exception )
            {
                throw;
            }
            finally
            {
                _connection.Close();
            }

        }

        public EmployeeClass GetById(string LoginName)
        {
            EmployeeClass emp1 = new EmployeeClass();

            //SqlConnection cn = new SqlConnection();
            SqlDataReader dr;
            try
            {
                //_connection.ConnectionString = @"Data Source=(localdb)\ProjectModels;Initial Catalog=Yash1;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                _connection.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _connection;
                cmd.CommandType = CommandType.Text;

                cmd.CommandText = "select * from RegisterUser where LoginName = @LoginName";
                cmd.Parameters.AddWithValue("@LoginName", LoginName);
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        emp1.LoginName = dr.GetString("LoginName");
                        emp1.FullName = dr.GetString("FullName");
                        emp1.Password = dr.GetString("Password");
                        emp1.Gender = dr.GetString("Gender");
                        emp1.PhoneNumber = dr.GetString("PhoneNumber");
                        emp1.CityId = dr.GetInt32("CityId");
                        emp1.EmailId = dr.GetString("EmailId");
                    }
                    dr.Close();
                }
                return emp1;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                _connection.Close();
            }
        }

        public void Insert(EmployeeClass employee)
        {
            //SqlConnection cn = new SqlConnection();
            try
            {
                //cn.ConnectionString = @"Data Source=(localdb)\ProjectModels;Initial Catalog=Yash1;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                _connection.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _connection;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into RegisterUser values(@LoginName,@FullName,@Gender,@EmailId,@PhoneNumber,@Password,@CityId) ";
                cmd.Parameters.AddWithValue("@LoginName", employee.LoginName);
                cmd.Parameters.AddWithValue("@Password", employee.Password);
                cmd.Parameters.AddWithValue("@Gender", employee.Gender);
                cmd.Parameters.AddWithValue("@FullName", employee.FullName);

                cmd.Parameters.AddWithValue("@CityId", employee.CityId);
                cmd.Parameters.AddWithValue("@PhoneNumber", employee.PhoneNumber);
                cmd.Parameters.AddWithValue("@EmailId", employee.EmailId);
                cmd.ExecuteNonQuery();

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                _connection.Close();
            }



        }
        public void Update(EmployeeClass employee)
        {
            //SqlConnection cn = new SqlConnection();
            try
            {
                //cn.ConnectionString = @"Data Source=(localdb)\ProjectModels;Initial Catalog=Yash1;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                _connection.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _connection;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Update RegisterUser Set  FullName = @FullName, Gender = @Gender, EmailId = @EmailId, PhoneNumber = @PhoneNumber, CityId = @CityId Where LoginName = @LoginName";

                cmd.Parameters.AddWithValue("@LoginName", employee.LoginName);
                cmd.Parameters.AddWithValue("@FullName", employee.FullName);
                cmd.Parameters.AddWithValue("@Gender", employee.Gender);
                cmd.Parameters.AddWithValue("@EmailId", employee.EmailId);
                cmd.Parameters.AddWithValue("@CityId", employee.CityId);
                cmd.Parameters.AddWithValue("@PhoneNumber", employee.PhoneNumber);
                cmd.Parameters.AddWithValue("@Password", employee.Password);
                cmd.ExecuteNonQuery();

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                _connection.Close();
            }



        }

        public void Delete(string LoginName)
        {
            //SqlConnection cn = new SqlConnection();
            //cn.ConnectionString = @"Data Source=(localdb)\ProjectModels;Initial Catalog=Yash1;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            try
            {
                _connection.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _connection;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Delete From RegisterUser Where LoginName = @LoginName";
                cmd.Parameters.AddWithValue("@LoginName", LoginName);
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                _connection.Close();
            }
        }
    }
}



      