using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linear_Programming_Solver.Core_Classes
{
    public class Constraint
    {
        public List<double> Coefficients { get; set; } // Coefficients of the decision variables
        public double RHS { get; set; } // Right-hand-side value
        public string Relation { get; set; } // Relation (e.g., <=, >=, =)

        public Constraint()
        {
            Coefficients = new List<double>();
        }

        // Parsing the constraint from a string input
        public void Parse(string input)
        {
            try
            {
                // Example input format: "1 2 3 <= 5"
                string[] parts = input.Split(' ');

                // Extract coefficients
                for (int i = 0; i < parts.Length - 2; i++)
                {
                    Coefficients.Add(double.Parse(parts[i]));
                }

                // Extract RHS
                RHS = double.Parse(parts[parts.Length - 1]);

                // Extract Relation
                Relation = parts[parts.Length - 2];
            }
            catch (Exception ex)
            {
                throw new Exception("Error parsing constraint: " + ex.Message);
            }
        }
    }
}