using System;
using System.Collections.Generic;
using System.Globalization;

namespace budget_builder
{
    class Program
    {
        static void addBudget(List<Budget> list, string name, double percentage)
        {
            list.Add(new Budget(percentage, name));
        }

        static double getLeftoverPercent(List<Budget> budgets)
        {
            double leftoverPercentage = 1.0;

            foreach (Budget budget in budgets)
            {
                leftoverPercentage -= budget.Percentage;
            }

            return leftoverPercentage;
        }

        static void Main(string[] args)
        {
            List<Budget> budgets = new List<Budget>();
            addBudget(budgets, "Savings", 0.5);

            string input = "";
            double inputBalance = 0.0;

            double balance = 0.0;
            double leftoverPercent = getLeftoverPercent(budgets);

            Console.WriteLine("Budget Percentages");
            foreach (Budget budget in budgets)
            {
                Console.WriteLine(budget.ToString());
            }
            Console.WriteLine("Leftover: " + leftoverPercent + "%");

            while (input != "q")
            {
                foreach (Budget budget in budgets)
                {
                    Console.WriteLine("Current Balance towards " + budget.Name + ": $" + balance * budget.Percentage);
                }
                Console.WriteLine("Leftover Balance: $" + balance * leftoverPercent);
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
                    var task = BudgetIO.writeBalanceChange(balance);
                }
            }
            Console.WriteLine(BudgetIO.readTotalBudget().ToString("C", CultureInfo.CreateSpecificCulture("en-US")));
        }
    }
}
