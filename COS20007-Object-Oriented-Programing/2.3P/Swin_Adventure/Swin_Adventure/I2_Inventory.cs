using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swin_Adventure
{
    public class I2_Inventory
    {
        private List<I2_Item> _items;


        public void I2_inventory()
        {
            _items = new List<I2_Item>();
        }

        public bool CarryItem(string id)
        {
            foreach (I2_Item item in _items)
            {
                if( item.FirstId == id)
                {
                    return true;
                }
            }
            return false;
        }

        public void Add(I2_Item item)
        {
            _items.Add(item);

        }

        public I2_Item Find(string id)
        {
            foreach(I2_Item item in _items)
            {
                if (item.AreYou(id))
                {
                    _items.Remove(item);    
                    return item;
                }
            }
            return null;
        }

        public string Items
        {
            get
            {
                string text = "";
                foreach (I2_Item item in _items)
                {
                   text = text + "\n\t" + item.short_Description;
                }
                return text;
            }
        }
    }
}
