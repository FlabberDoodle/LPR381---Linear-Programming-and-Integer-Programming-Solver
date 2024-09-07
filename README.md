# Linear Programming and Integer Programming Solver - LPR381

## Overview
This project is a **Linear and Integer Programming Solver** designed to handle mathematical optimization problems. The solver can work with **Linear Programming (LP)** and **Integer Programming (IP)** models and provides options for **Sensitivity Analysis** to evaluate how changes in parameters affect the optimal solution. The project is implemented in a **.NET** programming language, capable of handling different algorithms and exporting the results to an output text file.

## Features
- **Solve LP/IP Models**: Handles any number of decision variables and constraints.
- **Input and Output Files**: The program reads a text file defining the mathematical model and writes all results to an output file.
- **Multiple Algorithms**: Includes:
  - **Primal Simplex Algorithm**
  - **Revised Simplex Algorithm**
  - **Branch and Bound Simplex Algorithm**
  - **Cutting Plane Algorithm**
  - **Branch and Bound Knapsack Algorithm**
- **Sensitivity Analysis**: Perform detailed sensitivity analysis on decision variables and constraints, with options for modifying non-basic/basic variables and constraints.
- **Special Case Handling**: Detect and resolve infeasible or unbounded models.

## Input File Format
The input text file must follow a specific format:
- **Objective Function**: The first line contains `max` or `min`, followed by coefficients for each decision variable.
- **Constraints**: Each line includes coefficients, the operator (`<=`, `>=`, or `=`), and the right-hand side value.
- **Sign Restrictions**: Below the constraints, sign restrictions are defined (`+`, `-`, `urs`, `int`, `bin`) for each variable.

### Example Input File
```text
max +2 +3 +3 +5 +2 +4
+11 +8 +6 +14 +10 +10 <=40
bin bin bin bin bin bin
