using System;
using System.Collections.Generic;
using System.Linq;

namespace Linear_Programming_Solver.Core_Classes
{
    public class LPModel : IPModel
    {
        public double ObjectiveValue { get; set; } // Stores the objective value of the LP model

        // Constructor
        public LPModel() : base()
        {
        }

        // Method to add a constraint to the LP model
        public void AddConstraint(Constraint constraint)
        {
            if (constraint == null)
                throw new ArgumentNullException(nameof(constraint));

            Constraints.Add(constraint);
        }

        // Method to parse LP-specific input (could override or extend IPModel's parsing)
        public void ParseLP(string objectiveFunction, string constraintsText, string signRestrictionsText)
        {
            // Use base class Parse method
            Parse(objectiveFunction, constraintsText, signRestrictionsText);
        }
    }
}