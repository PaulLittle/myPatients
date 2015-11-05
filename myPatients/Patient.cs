using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myPatients
{
    public enum BloodGroup { A, AB, B, Z}

    class Patient
    {
        private string _name;
        public string Name { get { return _name; } set { _name = value; } }

        private BloodGroup _blood;
        public BloodGroup Blood { get { return _blood; } set { _blood = value; } }

        public override string ToString()
        {
            return String.Format("Name: {0} <==> Blood Type: {1}", Name, Blood);
        }

        public Patient():this("John Kelleher", BloodGroup.A)
        {}

        public Patient(string nme)
        {
            Name = nme;
        }

        public Patient(string nme, BloodGroup bg)
        {
            Name = nme;
            Blood = bg;
        }
    }
}
