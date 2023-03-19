using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.DAL;
using WpfApp1.Model;
namespace WpfApp1.BLL
{
    public class UserBAL
    {
        UserDAL userDAL;
        public UserBAL()
        {
           userDAL = new UserDAL();
           
        }
        public void Init()
        {
            userDAL.Open();
        }
        public int GetTatolPage(string mob, int activetype,int PageSize)
        {
            return userDAL.GetTotalPage(mob, activetype,PageSize);
        }
        public List<UserModel> GetUserModel(int pageIndex, int pageSize, string mob, int activetype, int isclick)
        {
           return userDAL.Next(pageIndex, pageSize, mob, activetype, isclick);
        }

        public List<ActiveTypeModel> GetActiveTypeModels()
        {
            return userDAL.GetActiveType();
        }

        public List<ProductModel> GetProductModels()
        {
            return userDAL.GetProduct();

        }

        public int Insert(string name,string mobile,int activetype,int product,string address)
        {
            UserModel userModel = new UserModel()
            {
                Name = name,
                Mobile = mobile,
                ActiveType = activetype,
                Product = product,
                Address = address
            };
            return userDAL.Insert(userModel);
                 
        }
        public int Update(int id,string name, string mobile, int activetype, int product, string address)
        {
            UserModel userModel = new UserModel()
            {
                ID=id,
                Name = name,
                Mobile = mobile,
                ActiveType = activetype,
                Product = product,
                Address = address
            };
            return userDAL.Update(userModel);

        }


    }
}
