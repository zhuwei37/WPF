using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Model;
namespace WpfApp1.DAL
{
    public class UserDAL:IDisposable
    {
        private SqlConnection conn;

       

        private const int PageSize=5;

       public  UserDAL()
        {
            
        }
        public void Open()
        {
          
            string constr = @"Data Source=127.0.0.1;uid=sa;pwd=sa;Initial Catalog=cu_client";
            SqlConnectionStringBuilder sql = new SqlConnectionStringBuilder();
            sql.InitialCatalog = "cu_client";
            sql.DataSource = "127.0.0.1";
            sql.UserID = "sa";
            sql.Password = "sa";
            conn = new SqlConnection(sql.ConnectionString);
            try
            {
                conn.Open();
                

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

      
        public int GetTotalPage(string mob, int activetype,int PageSize)
        {
            
            string sqlstr = string.Format($"exec get_tatol_page '{mob}',{activetype},{PageSize}");
            SqlCommand cmd = new SqlCommand(sqlstr, conn);
            int TotalPage = 0;
            SqlDataReader dataReader;
            try
            {
                dataReader = cmd.ExecuteReader();
                if (!dataReader.HasRows)
                {
                    dataReader.Close();

                    return 0;
                }
                dataReader.Read();
               TotalPage= dataReader.GetInt32(0);
                dataReader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
          
            return TotalPage;
        }
        public List<UserModel> Next(int pageIndex,int pageSize,string mob,int activetype,int isclick )
        {
            List<UserModel> userModels = new List<UserModel>();
            string sqlstr =string.Format( "exec get_page '{0}' , {1} , {2} , {3} , {4}",mob,activetype,pageSize,pageIndex,isclick);
            SqlCommand cmd = new SqlCommand(sqlstr, conn);
            SqlDataReader dataReader = cmd.ExecuteReader();
            if (!dataReader.HasRows)
            {
                dataReader.Close();

                return userModels;
            }
            while (dataReader.Read())
            {
                UserModel userModel = new UserModel();
                userModel.ID =  dataReader.GetInt32(0);
                userModel.Name = dataReader.IsDBNull(1) ? default(string) : dataReader.GetString(1);
                userModel.Mobile = dataReader.IsDBNull(2) ? default(string) : dataReader.GetString(2);
                userModel.ActiveType = dataReader.GetInt32(3);
                userModel.Product = dataReader.GetInt32(4);
                userModel.Address = dataReader.IsDBNull(5) ? default(string) : dataReader.GetString(5);
                userModel.Inserttime = dataReader.IsDBNull(6) ? default(DateTime):dataReader.GetDateTime(6);
                userModel.UpdateTime = dataReader.IsDBNull(7) ? default(DateTime): dataReader.GetDateTime(7);
                userModels.Add(userModel);
            }


            dataReader.Close();
            return userModels;
        }

        public  List<ActiveTypeModel> GetActiveType()
        {
            string sqlcmdstr = "exec get_activetype";
            List<ActiveTypeModel> ms = new List<ActiveTypeModel>();
            try
            {
                SqlDataReader reader;
                SqlCommand command = new SqlCommand(sqlcmdstr, conn);
                reader = command.ExecuteReader();
                if (!reader.HasRows)
                {
                    reader.Close();
                    return ms; ;
                }
                while (reader.Read())
                {
                    ActiveTypeModel model = new ActiveTypeModel();
                    model.ID = reader.GetInt32(0);
                    model.Name = reader.IsDBNull(1) ? default(string) : reader.GetString(1);
                    ms.Add(model);

                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
          
            return ms;
        }
        public List<ProductModel> GetProduct()
        {
            string sqlcmdstr = "exec get_Product";
            List<ProductModel> ms = new List<ProductModel>();
            SqlDataReader reader;
            try
            {

                SqlCommand command = new SqlCommand(sqlcmdstr, conn);
                reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    reader?.Close();
                    return ms;
                }
                while (reader.Read())
                {
                    ProductModel m = new ProductModel();
                    m.ID = reader.GetInt32(0);
                    m.Name = reader.IsDBNull(1) ? default(string) : reader.GetString(1);
                    ms.Add(m);
                }
                reader?.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
          
        
            return ms;
        }


        public int Insert(UserModel userModel)
        {
            int ok = 0;
            string commandText = "exec insert_client_ @Name,@Mobile,@Activetype,@Product,@Address";
            try
            {
                SqlDataReader reader;
                SqlCommand sqlCommand = new SqlCommand(commandText, conn);
                SqlParameter[] sqlParameters = new SqlParameter[]
                {
                    new SqlParameter("@Name",userModel.Name),
                    new SqlParameter("@Mobile",userModel.Mobile),
                    new SqlParameter("@Activetype",userModel.ActiveType),
                    new SqlParameter("@Product",userModel.Product),
                    new SqlParameter("@Address",userModel.Address),
                };
                sqlCommand.Parameters.AddRange(sqlParameters);
                reader=sqlCommand.ExecuteReader();
                if (!reader.HasRows)
                {
                    reader.Close();
                    return ok;
                }
                reader.Read();
                ok = reader.GetInt32(0);
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return ok;
        }
        public int Update(UserModel userModel)
        {
            int ok = 0;
            string commandText = "exec update_client_ @ID,@Name,@Mobile,@Activetype,@Product,@Address";
            try
            {
                SqlDataReader reader;
                SqlCommand sqlCommand = new SqlCommand(commandText, conn);
                SqlParameter[] sqlParameters = new SqlParameter[]
                {
                    new SqlParameter("@ID",userModel.ID),
                    new SqlParameter("@Name",userModel.Name),
                    new SqlParameter("@Mobile",userModel.Mobile),
                    new SqlParameter("@Activetype",userModel.ActiveType),
                    new SqlParameter("@Product",userModel.Product),
                    new SqlParameter("@Address",userModel.Address),
                };
                sqlCommand.Parameters.AddRange(sqlParameters);
                reader = sqlCommand.ExecuteReader();
                if (!reader.HasRows)
                {
                    reader.Close();
                    return ok;
                }
                reader.Read();
                ok = reader.GetInt32(0);
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return ok;
        }


        public void Dispose()
        {
            try
            {
                conn?.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        ~UserDAL()
        {
            Dispose();
        }
    }
}
