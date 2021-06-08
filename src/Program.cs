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

        static void Main(string[] args)
        {
            // set current culture
            CultureInfo.CurrentCulture = new CultureInfo("en-US", false);

            List<Budget> budgets = new List<Budget>();
            budgets.Add(new Budget(0.5, "Savings"));
            budgets.Add(new Budget(0.1, "Transportation"));
            budgets.Add(new Budget(0.2, "Dates"));

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


            Display.displayHelp();

            bool exitFlag = false;
            while (!exitFlag)
            {
                string nextAction = Display.getNextAction();

                switch (nextAction)
                {
                    case ("quit"):
                        exitFlag = true;
                        break;
                    case ("update balance"):
                        double balanceChange = Display.getBalanceChange();
                        var task = BudgetIO.writeBalanceChange(balanceChange);
                        break;
                    case ("display budget"):
                        Display.displayBudgetReports(balance, budgets);
                        break;
                    case ("help"):
                        Display.displayHelp();
                        break;
                }
            }
        }
    }
}