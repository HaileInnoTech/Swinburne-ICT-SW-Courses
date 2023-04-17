using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swin_Adventure
{
    public class I4_Look_Command : I4_Command
    {
        public I4_Look_Command() : base( new string[] { "look" })
        {
        }

        public override string Execute(I2_Player p, string[] text)
        {
            if (text[0].ToLower() != "look")
                return "Error in look input.";

            if (text[1].ToLower() != "at")
                return "What do you want to look at?";

            if (text.Length == 5)
            {
                if (text[3] != "in")
                {
                    return "What do you want to look in?";
                }
            }

            I4_I_Have_Inventory _container;

            switch (text.Length)
            {
                case 3:
                    _container = p as I4_I_Have_Inventory;
                    break;

                case 5:
                    _container = FetchContainer(p, text[4]);
                    break;

                default:
                    _container = null;
                    break;
            }

            string _itemid = text[2];
            if (_container == null)
                return "I can't find the " + text[4];
            return LookAtIn(_itemid, _container);

        }

        private I4_I_Have_Inventory FetchContainer(I2_Player p, string containerId)
        {
            return p.Locate(containerId) as I4_I_Have_Inventory;
        }

        private string LookAtIn(string thingId, I4_I_Have_Inventory container)
        {
            if (container.Locate(thingId) != null)
                return container.Locate(thingId).full_Description;

            return "I can't find the " + thingId;
        }
    }

}





















