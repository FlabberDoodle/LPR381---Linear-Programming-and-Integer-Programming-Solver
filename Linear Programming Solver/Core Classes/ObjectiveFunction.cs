using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linear_Programming_Solver.Core_Classes
{
    public class ObjectiveFunction
    {
        public string Type { get; set; } // "max" or "min"
        public List<double> Coefficients { get; set; } // Coefficients of the decision variables

        public ObjectiveFunction()
        {
            Coefficients = new List<double>();
        }

        public void Parse(string input)
        {
            try
            {
                string[] parts = input.Split(' ');

                Type = parts[0];

                for (int i = 1; i < parts.Length; i++)
                {
                    Coefficients.Add(double.Parse(parts[i]));
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error parsing objective function: " + ex.Message);
            }
        }
    }
}