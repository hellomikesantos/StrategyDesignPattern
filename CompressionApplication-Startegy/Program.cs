// abstract beverage class
Beverage testCoffee = new DripCoffee();
Console.WriteLine(testCoffee.GetDescription());
Console.WriteLine(testCoffee.Cost());

testCoffee = new Sugar(testCoffee);
Console.WriteLine(testCoffee.GetDescription());
Console.WriteLine(testCoffee.Cost());

Console.WriteLine("Add more sugar");
testCoffee = new Sugar(testCoffee);
Console.WriteLine(testCoffee.GetDescription());
Console.WriteLine(testCoffee.Cost());

testCoffee = new MilkCondiment(testCoffee);
Console.WriteLine(testCoffee.GetDescription());
Console.WriteLine(testCoffee.Cost());

Beverage milk = new MilkBeverage();
milk = new MilkCondiment(milk);
milk = new MilkCondiment(milk);
milk = new Sugar(milk);

Console.WriteLine(milk.GetDescription());
Console.WriteLine(milk.Cost());

public abstract class Beverage
{
    //protected means only inheriting child classes can use it
    protected string _description { get; set; } 
    public virtual string GetDescription()
    {
        return _description;
    }

    protected double _cost { get; set; }
    public virtual double Cost()
    {
        return _cost;
    }
}

// concrete class meaning a class that can be instantiated
public class DripCoffee : Beverage
{
    public DripCoffee()
    {
        _cost = 1.00;
        _description = "Columbian Coffee";
    }
    
}

public class Tea : Beverage
{
    public Tea()
    {
        _cost = 1.00;
        _description = "English Tea";
    }
}

public class MilkBeverage : Beverage
{
    public MilkBeverage()
    {
        _description = "Milk Beverage";
        _cost = 1.49;
    }
}

public abstract class CondimentDecorator : Beverage
{
    public Beverage Beverage { get; set; }
    public abstract override string GetDescription();
    public abstract override double Cost();
}

public class Sugar: CondimentDecorator
{
    public override double Cost()
    {
        return Beverage.Cost() + _cost;
    }

    public override string GetDescription()
    {
        return $"{Beverage.GetDescription()}, {_description}";
    }

    public Sugar(Beverage beverage)
    {
        Beverage = beverage;
        _cost = 0.2;
        _description = "Sugar";
    }
} 

public class MilkCondiment  : CondimentDecorator
{
    public override double Cost()
    {
        return Beverage.Cost() + _cost;
    }

    public override string GetDescription()
    {
        return $"{Beverage.GetDescription()}, {_description}";
    }

    public MilkCondiment(Beverage beverage)
    {
        Beverage = beverage;
        _cost = 1.49;
        _description = "Milk";
    }
}