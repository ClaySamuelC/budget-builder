using System;
using System.Collections.Generic;
using System.Globalization;

namespace budget_builder
{
    class Program
    {
        static double getLeftoverPercent(List<Budget> budgets)
        {
            double leftoverPercentage = 1.0;

            foreach (Budget budget in budgets)
            {
                leftoverPercentage -= budget.Percentage;
            }

            return leftoverPercentage;
        }

        static string budgetReport(double balance, List<Budget> budgets)
        {
            string report = "";

            report += ("Total Balance: " + balance.ToString("C") + "\n");
            report += ("Current budget:\n");
            foreach (Budget budget in budgets)
            {
                report += ("  " + budget.ToString() + "\n");
            }

            return report;
        }

        static void Main(string[] args)
        {
            // set current culture
            CultureInfo.CurrentCulture = new CultureInfo("en-US", false);

            List<Budget> budgets = new List<Budget>();
            budgets.Add(new Budget(0.5, "Savings"));
            budgets.Add(new Budget(0.1, "Transportation"));
            budgets.Add(new Budget(0.2, "Dates"));

            string input = "";
            double inputBalance = 0.0;

            double balance = BudgetIO.readTotalBudget();
            double leftoverPercent = getLeftoverPercent(budgets);

            if (leftoverPercent > 0.0)
            {
                budgets.Add(new Budget(leftoverPercent, "Leftover"));
            }

            // set each balance
            foreach (Budget budget in budgets)
            {
                budget.setBalance(balance);
            }

            while (input != "q")
            {
                Console.WriteLine(budgetReport(balance, budgets));
                Console.WriteLine("Enter a change in balance (q to quit)");

                input = Console.ReadLine();
                if (!double.TryParse(input, out inputBalance))
                {
                    if (input == "q")
                    {
                        Console.WriteLine("Quitting");
                    }
                    else
                    {
                        Console.WriteLine("Invalid Input");
                    }
                }
                else
                {
                    balance += inputBalance;
                    var task = BudgetIO.writeBalanceChange(inputBalance);
                }
            }
        }
    }
}