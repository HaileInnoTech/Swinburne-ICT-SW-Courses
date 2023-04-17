using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swin_Adventure
{
    public abstract class I4_Command : I1_Identity
    {
        public I4_Command(string[] ids): base(ids)
        {
        }
        public abstract string Execute(I2_Player player, string[] text);
        
    }
}
