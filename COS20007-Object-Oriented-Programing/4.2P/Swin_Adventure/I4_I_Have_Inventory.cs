using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swin_Adventure
{
    internal interface I4_I_Have_Inventory
    {
        I2_Game_Object Locate(string id);
        String Name { get; }
    }
}
