using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Model
{
    public class ProductModel
    {
        public ProductModel()
        { }


        public ProductModel(int _id,string _name)
        {
            ID = _id;
            Name = _name;
        }

        public int ID;

        public string Name;
    }
}
