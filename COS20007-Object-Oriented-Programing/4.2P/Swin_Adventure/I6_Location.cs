using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swin_Adventure
{
    public class I6_Location : I2_Game_Object, I4_I_Have_Inventory
    {

        private I2_Inventory _inventory;

        public I6_Location(string[] ids,string name, string description) :
           base(ids, description, name)
        {
            _inventory = new I2_Inventory();
        }

        public I2_Game_Object Locate(string id)
        {
            if (AreYou(id))
            {
                return this;
            }
            return _inventory.Find(id);
        }
        public I2_Inventory Inventory
        {
            get
            {
                return _inventory;
            }
        }
    }
}
    