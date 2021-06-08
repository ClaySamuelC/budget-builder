using System;
using System.Collections.Generic;

namespace budget_builder
{
  class Display
  {
    public static string getNextAction()
    {
      return Console.ReadLine();
    }

    public static void displayHelp()
    {
      Console.WriteLine("Commands:\nquit\nhelp\nupdate balance\ndisplay budget");
    }

    public static double getBalanceChange()
    {
      return Convert.ToDouble(Console.ReadLine());
    }

    public static void displayBudgetReports(double balance, List<Budget> budgets)
    {
      Console.WriteLine("Total Balance: " + balance.ToString("C"));
      Console.WriteLine("Current budget:");

      foreach(Budget budget in budgets)
      {
        Console.WriteLine("\t" + budget.ToString());
      }
    }
  }
}