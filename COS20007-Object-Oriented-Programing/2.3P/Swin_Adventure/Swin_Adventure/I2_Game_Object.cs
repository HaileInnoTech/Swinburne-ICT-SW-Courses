using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swin_Adventure
{
    public abstract class I2_Game_Object : I1_Identity
    {
        private string _name;
        private string _description;
        
        public I2_Game_Object(string name, string _desc, string[] ids) : base(ids)
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
                return $"{_name} ({FirstId})";
            }
        }
        public string full_Description
        {
            get
            {
                return _description;
            }
        }
    }
}
