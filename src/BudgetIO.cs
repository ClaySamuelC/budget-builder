using System;
using System.IO;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace budget_builder
{
  class BudgetIO
  {
    public static async Task writeBalanceChange(double balanceChange)
    {
      using StreamWriter file = new("src/balanceChanges.txt", append: true);
      await file.WriteLineAsync(DateTime.Now.ToString() + ",\t$" + balanceChange.ToString());
    }

    private static double readBalanceTotals()
    {
      double total = 0;

      try
      {
        StreamReader sr = new StreamReader("src/balanceChanges.txt");
        total = Convert.ToDouble(sr.ReadLine());
        sr.Close();
        Console.ReadLine();
      }
      catch(Exception e)
      {
        Console.WriteLine("Exception: " + e.Message);
      }

      return total;
    }

    private static async Task writeBalanceTotals(double total)
    {
      using StreamWriter file = new("src/balanceTotals.txt");
      await file.WriteLineAsync(total.ToString());
    }

    public static double readTotalBudget()
    {
      double total = 0;

      string line;
      try
      {
        StreamReader sr = new StreamReader("src/balanceChanges.txt");
        line = sr.ReadLine();
        line = sr.ReadLine();
        while (line != null)
        {
          total += Convert.ToDouble(line.Split('$')[1]);
          line = sr.ReadLine();
        }
        sr.Close();
      }
      catch(Exception e)
      {
        Console.WriteLine("Exception: " + e.Message);
      }

      return total;
    }

    public static async Task writeBudgets(double total, List<Budget> budgets)
    {
      using StreamWriter file = new("src/balanceTotals.txt", append: false);
      foreach(Budget budget in budgets)
      {
        await file.WriteLineAsync(budget.ToString());
      }
    }
  }
}
