using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linear_Programming_Solver.Core_Classes
{
    public class SignRestrictions
    {
        public List<string> Restrictions { get; set; } // Sign restrictions for each decision variable

        public SignRestrictions()
        {
            Restrictions = new List<string>();
        }

        public void Parse(string input)
        {
            try
            {
                string[] parts = input.Split(' ');

                foreach (string part in parts)
                {
                    Restrictions.Add(part);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error parsing sign restrictions: " + ex.Message);
            }
        }
    }
}