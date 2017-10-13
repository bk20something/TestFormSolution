using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestForms
{
    public class Roster
    {
        private List<Solider> _soliders;  //List of all solider on a roster                  

        //Generic constructures
        public Roster()
        {
            this._soliders = new List<Solider>();
        }

        public Roster(List<Solider> soliders)
        {
            this._soliders = soliders;
        }

        //Accessor Methods
        public List<Solider> soliders { get { return _soliders; } }

        //Adds a solider to the roster
        public void addSolider(Solider solider)
        {
            _soliders.Add(solider);
        }

        //Display Methods for Debug Purposes Only
        public string _show()
        {
            string output = "";
            foreach (Solider solider in _soliders)
            {
                output = output + solider._show() + Environment.NewLine;
            }
            return output;
        }
    }
}
