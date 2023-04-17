using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swin_Adventure
{
    public class I3_Bag :I2_Item, I4_I_Have_Inventory

    {

        private I2_Inventory _inventory;


        public I3_Bag(string[] ids, string name, string desc) : base( ids, name, desc)
        {
            _inventory = new I2_Inventory();
        }

        
        public I2_Game_Object Locate(string id)
        {
            {
                if (AreYou(id))
                {
                    return this;
                }
                return _inventory.Find(id);
            }
        }
        public override string full_Description
        {
            get
            {
                return $"In the {this.Name} you can see:{_inventory.Items}";
            }
        }
        public I2_Inventory Inventory
        {
            get { return _inventory; }
        }
    }
}
