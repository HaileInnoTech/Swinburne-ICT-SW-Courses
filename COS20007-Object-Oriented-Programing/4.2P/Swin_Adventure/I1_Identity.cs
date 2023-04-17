using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Swin_Adventure
{
    public class I1_Identity

    {
        private List<string> _identifiers;

        public I1_Identity(string[] idents)
        {
            _identifiers = new List<string>();

            foreach (string id in idents)
            {
                _identifiers.Add(id.ToLower());
            }
        }

        public bool AreYou(string id)
        {
            foreach (string i in _identifiers)
            {
                if (id.ToLower() == i)
                {
                    return true;
                }
            }
            return false;
        }
        public string FirstId()
        {
            return _identifiers[0];
        }


        public void AddIdentidfier(string id)
        {
            _identifiers.Add(id.ToLower());
        }
    }
}


