using Google.OrTools.LinearSolver;
using Linear_Programming_Solver.Core_Classes;
using System;
using System.Linq;
using System.Collections.Generic;
using Google.OrTools.ModelBuilder;
using System.IO;
using System.Windows.Forms;
using System.Numerics;

namespace Linear_Programming_Solver.Supporting_Classes
{
    public class Solver
    {
        private readonly Google.OrTools.LinearSolver.Solver _solver;

        public Solver()
        {
            // Initialize the Google OR-Tools Solver
            _solver = Google.OrTools.LinearSolver.Solver.CreateSolver("SCIP");
            if (_solver == null)
            {
                throw new Exception("Could not create the solver.");
            }
        }

        public void Solve(IPModel ipModel)
        {
            if (_solver == null)
            {
                throw new Exception("Solver not initialized.");
            }

            // Define variables
            var variables = new List<Google.OrTools.LinearSolver.Variable>();
            for (int i = 0; i < ipModel.Objective.Coefficients.Count; i++)
            {
                variables.Add(_solver.MakeNumVar(0, double.PositiveInfinity, $"x{i}"));
            }

            // Define objective function
            var objective = _solver.Objective();
            for (int i = 0; i < ipModel.Objective.Coefficients.Count; i++)
            {
                objective.SetCoefficient(variables[i], ipModel.Objective.Coefficients[i]);
            }
            objective.SetMaximization(); // Use SetMinimization() if minimization is required

            // Define constraints
            foreach (var constraint in ipModel.Constraints)
            {
                // Create a linear expression for the constraint
                var constraintExpr = new Google.OrTools.LinearSolver.LinearExpr();
                for (int i = 0; i < constraint.Coefficients.Count; i++)
                {
                    constraintExpr += constraint.Coefficients[i] * variables[i];
                }

                switch (constraint.Relation)
                {
                    case "<=":
                        _solver.Add(constraintExpr <= constraint.RHS);
                        break;
                    case ">=":
                        _solver.Add(constraintExpr >= constraint.RHS);
                        break;
                    case "=":
                        _solver.Add(constraintExpr == constraint.RHS);
                        break;
                    default:
                        throw new Exception("Unknown constraint relation.");
                }
            }

            // Solve the model
            var resultStatus = _solver.Solve();

            if (resultStatus == Google.OrTools.LinearSolver.Solver.ResultStatus.OPTIMAL)
            {
                Console.WriteLine("Solution:");
                for (int i = 0; i < variables.Count; i++)
                {
                    Console.WriteLine($"Variable x{i}: {variables[i].SolutionValue()}");
                }
                Console.WriteLine($"Objective Value: {_solver.Objective().Value()}");
            }
            else
            {
                Console.WriteLine("No optimal solution found.");
            }
        }
    }
}