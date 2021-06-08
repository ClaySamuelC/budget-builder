using System.Globalization;

namespace budget_builder
{
  class Budget
  {
    public double Percentage { get; set; }
    public string Name { get; set; }
    public double Balance { get; set; }

    public Budget(double percentage, string name)
    {
      Percentage = percentage;
      Name = name;
      Balance = 0;
    }

    public string ToString(CultureInfo culture)
    {
      return Name + ": " + Percentage.ToString("P2", culture) + " " + Balance.ToString("C", culture);
    }

    public void setBalance(double preBudgetedBalance)
    {
      Balance = Percentage * preBudgetedBalance;
    }

    public void changeBalance(double preBudgetedBalanceChange)
    {
      Balance += Percentage * preBudgetedBalanceChange;
    }
  }
}