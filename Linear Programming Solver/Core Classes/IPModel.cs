using System;
using System.Collections.Generic;
using System.Linq;

namespace Linear_Programming_Solver.Core_Classes
{
    public class IPModel
    {
        public ObjectiveFunction Objective { get; set; }
        public List<Constraint> Constraints { get; set; }
        public SignRestrictions SignRestrictions { get; set; }
        public List<double> VariableValues { get; set; }

        public IPModel()
        {
            Objective = new ObjectiveFunction();
            Constraints = new List<Constraint>();
            SignRestrictions = new SignRestrictions();
            VariableValues = new List<double>();
        }

        public void Parse(string objectiveFunction, string constraintsText, string signRestrictionsText)
        {
            try
            {
                // Parse objective function
                var objectiveParts = objectiveFunction.Split(' ');
                if (objectiveParts.Length < 2)
                {
                    throw new Exception("Objective function format is incorrect.");
                }

                Objective.Type = objectiveParts[0].Trim();
                Objective.Coefficients = objectiveParts.Skip(1)
                    .Select(x => double.Parse(x.Trim()))
                    .ToList();

                // Parse constraints
                var constraintLines = constraintsText.Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
                if (constraintLines.Length == 0)
                {
                    throw new Exception("No constraints found.");
                }

                Constraints = constraintLines.Select(line =>
                {
                    var parts = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    if (parts.Length < 4)
                    {
                        throw new Exception("Constraint format is incorrect.");
                    }

                    var relationIndex = parts.FirstOrDefault(p => p == "<=" || p == ">=" || p == "=");
                    if (relationIndex == null)
                    {
                        throw new Exception("No relation operator found in constraint.");
                    }

                    int relationPos = Array.IndexOf(parts, relationIndex);
                    var coefficients = parts.Take(relationPos)
                        .Select(x => double.Parse(x.Trim()))
                        .ToList();
                    var rhs = double.Parse(parts[relationPos + 1].Trim());
                    var relation = relationIndex.Trim();

                    return new Constraint
                    {
                        Coefficients = coefficients,
                        RHS = rhs,
                        Relation = relation
                    };
                }).ToList();

                // Parse sign restrictions
                if (string.IsNullOrWhiteSpace(signRestrictionsText))
                {
                    throw new Exception("Sign restrictions text is empty.");
                }

                SignRestrictions.Restrictions = signRestrictionsText.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => x.Trim())
                    .ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error parsing input: " + ex.Message);
            }
        }
    }
}