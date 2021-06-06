using System;

namespace budget_builder
{
  class Budget
  {
    public double Percentage { get; set; }
    public string Name { get; set; }

    public override string ToString()
    {
      return Name + ": " + Percentage + "%";
    }
  }
}