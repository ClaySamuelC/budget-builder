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

    public override string ToString()
    {
      return Name + ": " + Percentage.ToString("P2") + " " + Balance.ToString("C");
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