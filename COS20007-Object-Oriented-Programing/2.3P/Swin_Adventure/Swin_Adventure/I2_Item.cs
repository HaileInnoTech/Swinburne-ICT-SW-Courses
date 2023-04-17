using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
namespace Swin_Adventure
{
    public class I2_Item : I2_Game_Object
    { 
        public I2_Item(string[] idents, string name, string decs) : base(name, decs, idents)
        {

        }
    }
}



