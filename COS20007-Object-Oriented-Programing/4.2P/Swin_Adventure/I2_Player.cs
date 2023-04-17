using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swin_Adventure
{
    public class I2_Player : I2_Game_Object , I4_I_Have_Inventory

    {
        private I2_Inventory _inventory;
        private I6_Location _location;

        public I2_Player(string name, string description) :
             base(new string[] { "me", "inventory" }, name, description)
        {
            _inventory = new I2_Inventory();
        }


        public I2_Game_Object Locate(string id)
        {
            if (this.AreYou(id))
            {
                return this;
            }

            if (_inventory.Find(id) != null)
            {
                return _inventory.Find(id);
            }

            return _location == null ? null : _location.Locate(id);

        }
        public override string full_Description
        {
            get
            {
                return $"You are {this.Name} {base.full_Description}\nYou are carrying:{_inventory.Items}";
            }
        }
        public I2_Inventory Inventory { get => _inventory; }
        public I6_Location Location { get => _location; set => _location = value; }


    }
}
