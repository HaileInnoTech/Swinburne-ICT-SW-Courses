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


        public I2_Inventory() {
            _items = new List<I2_Item>(); 
        }

        public bool CarryItem(string id)
        {
            if (_items.Count == 0)
                return false;
            foreach (I2_Item item in _items)
            {

                if (item.AreYou(id))
                {
                    return true;
                }
            }
            return false;
        }

        public void Take(I2_Item item)
        { 
        _items.Add(item);
        }

        public I2_Item? Throw(string id)
        {
            foreach (I2_Item i in _items)
            {
                if (i.AreYou(id))
                {
                    I2_Item itemFound = i;
                    _items.Remove(i);
                    return itemFound;
                }
            }
            return null;
        }
        public I2_Item Find(string id)
        {
            foreach (I2_Item item in _items)
            {
                if (item.AreYou(id))
                {
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
