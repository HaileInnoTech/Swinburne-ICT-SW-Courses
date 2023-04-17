using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swin_Adventure
{
    public abstract class I2_Game_Object : I1_Identity
    {
        private readonly string _name;
        private readonly string _description;
        
        public I2_Game_Object(string[] ids, string name, string _desc) : base(ids)
        {
            _name = name;
            _description = _desc;
        }
        public string Name { get { return _name; } }

        public string Description { get { return _description; } }  

        public string short_Description
        {
            get
            {
                return $"{Name} ({FirstId()})";

            }
        }
        public virtual string full_Description
        {
            get
            {
                return _description;
            }
        }
    }
}
