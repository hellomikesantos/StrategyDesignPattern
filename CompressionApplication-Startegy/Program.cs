//PizzaStore winnipeg = new WinnipegPizzaStore();
//PizzaStore newfoundland = new NewFoundLandPizzaStore();

//winnipeg.OrderPizza("special");
//newfoundland.OrderPizza("special");

ToyFactory lego = new LegoToyFactory();
ToyFactory mattell = new MattellToyFactory();
lego.OrderToy("doll");
mattell.OrderToy("doll");
lego.OrderToy("car");
mattell.OrderToy("car");

public abstract class PizzaStore
{
    public Pizza OrderPizza(string type)
    {

        // this process will never change, regardless of what our store is
        Pizza pizza;
        pizza = CreatePizza(type);

        pizza.Prepare();
        pizza.Bake();
        pizza.Cut();

        return pizza;
    }

    // how we instantiate the Pizza depends upon the type of store
    protected abstract Pizza CreatePizza(string type);
}

public class NewFoundLandPizzaStore : PizzaStore
{
    protected override Pizza CreatePizza(string type)
    {
        // declare the pizza
        Pizza pizza;
        switch (type)
        {
            case "lobster":
                pizza = new LobsterPizza();
                break;
            case "cheese":
                pizza = new CheddarPizza();
                break;
            default:
                throw new Exception();
        }
        return pizza;
    }
}

public class WinnipegPizzaStore : PizzaStore
{
    protected override Pizza CreatePizza(string type)
    {
        Pizza pizza;
        switch (type)
        {
            case "special":
                pizza = new SlurpeePizza();
                break;
            case "cheese":
                pizza = new MozzarellaPizza();
                break;
            default:
                throw new Exception();
        }
        return pizza;
    }
}



public abstract class Pizza
{
    public void Bake()
    {
        Console.WriteLine("Baking the pizza");
    }

    public void Prepare()
    {
        Console.WriteLine("Preparing the pizza");
    }

    public void Cut()
    {
        Console.WriteLine("Cutting the pizza");
    }
}

public class LobsterPizza : Pizza
{

}

public class CheddarPizza : Pizza
{

}

public class MozzarellaPizza : Pizza
{

}

public class PoutinePizza
{

}

public class SlurpeePizza : Pizza
{

}


public abstract class Toy
{
    public string _description { get; set; }
    public void Paint()
    {
        Console.WriteLine("They toy has been painted");
    }
    public void Package()
    {
        Console.WriteLine("They toy has been packaged");
    }
}

public class BarbieDoll : Toy
{
    public BarbieDoll()
    {
        _description = "Barbie Doll";
    }
}

public class Minifigure : Toy
{
    public Minifigure()
    {
        _description = "Minifigure";
    }
}

public class MatellCar : Toy
{
    public MatellCar()
    {
        _description = "Mattell Car";
    }
}

public class LegoCar : Toy
{
    public LegoCar()
    {
        _description = "Lego Car";
    }
}

public abstract class ToyFactory
{
    protected abstract Toy CreateToy(string type);
    public Toy OrderToy(string type)
    {
        // declare first
        Toy toy;
        toy = CreateToy(type);

        toy.Paint();
        toy.Package();
        return toy;
    }
}

public class MattellToyFactory : ToyFactory
{
    protected override Toy CreateToy(string type)
    {
        Toy toy;
        switch (type.ToLower())
        {
            case "doll":
                toy = new BarbieDoll();
                break;
            case "car":
                toy = new MatellCar();
                break;
            default:
                throw new Exception("Mattell Toy Factory decided to stop producing this toy.");
        }
        Console.WriteLine($"Created a {toy._description} from Mattell");
        return toy;
    }
}

public class LegoToyFactory : ToyFactory
{
    protected override Toy CreateToy(string type)
    {
        Toy toy;
        switch (type)
        {
            case "doll":
                toy = new Minifigure();
                break;
            case "car":
                toy = new LegoCar();
                break;
            default :
                throw new Exception("Mattell Toy Factory decided to stop producing this toy.");
        }
        Console.WriteLine($"Created a {toy._description} from Lego");
        return toy;
    }
}