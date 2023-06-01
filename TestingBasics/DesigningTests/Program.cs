using System;
using System.Collections.Generic;

namespace DesigningTests
{
    internal class Program
    {
        private const int MaxBaseSalary = 0; 
        private static Dictionary<int, Employee> _employees = new Dictionary<int, Employee>();


        private static void Main(string[] args)
        {
            // Compute the employee bonus
            var result = ComputeEmployeeBonus(1);
            Console.WriteLine(result);
        }

        private static int ComputeEmployeeBonus(int employeeId)
        { 
            // Compute the total bonus for an employee
            
           int basicBonus = 0;
           
           // compute basic bonus for full-time low wage earners
           if (_employees[employeeId].IsFullTime && _employees[employeeId].Salary < MaxBaseSalary)
           {
               basicBonus = ComputeBasicBonus(employeeId);
           }

           int performanceBonus = 0;
           
           // compute performance bonus
           if (_employees[employeeId].IsPerformanceEligible)
           {
               performanceBonus = ComputePerformanceBonus(employeeId, basicBonus);
           }
            
           return basicBonus + performanceBonus;
        }

        private static int ComputeBasicBonus(int employeeId)
        {
            return 0;
        }

        private static int ComputePerformanceBonus(int employeeId, int basicBonus)
        {
            return 0;
        }
    }

    class Employee
    {
        private int _employeeId = 0;
        public bool IsFullTime = false;
        public bool IsPerformanceEligible = false;
        public int Salary = 0;

        public Employee(int employeeId)
        {
            _employeeId = employeeId;
        }
    }
}