//PizzaStore winnipeg = new WinnipegPizzaStore();
//PizzaStore newfoundland = new NewFoundLandPizzaStore();

//winnipeg.OrderPizza("special");
//newfoundland.OrderPizza("special");

//ToyFactory lego = new LegoToyFactory();
//ToyFactory mattell = new MattellToyFactory();
//lego.OrderToy("doll");
//mattell.OrderToy("doll");
//lego.OrderToy("car");
//mattell.OrderToy("car");
ClientHandler retailHandler = new RetailClientHandler();
ClientHandler enterpriseHandler = new EnterpriseHandler();
Console.WriteLine(enterpriseHandler.CreateClient("MANAGER", "michael", true));



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

public abstract class Client
{
    public string UserName { get; set; }
    public string UserAuthString { get; set; } = "";
    public bool HasAccess { get; set; }
    public string BuildAuthString()
    {
        return "";
    }
}

public class User : Client
{
    public User()
    {
        HasAccess = false;
    }
}

public class Manager : Client
{
    public CheckString? checkString { get; set; }
    public Manager(bool enterpriseClientHandler)
    {
        HasAccess = true;
        UserAuthString = UserAuthString + "MAN";
        if (enterpriseClientHandler)
        {
            checkString = new CheckString();
        }
    }
}

public class Admin : Client
{
    public Admin()
    {
        HasAccess = true;
        UserAuthString = UserAuthString + "ADMIN";
    }
}

public abstract class AccessBehaviour
{
    public Client client { get; set; }
    protected abstract bool HandleAccess(Client client);
}

public class CheckString : AccessBehaviour
{
    protected override bool HandleAccess(Client client)
    {
        //if (enterpriseClientHandler && client.UserAuthString.Contains("MANAGER"))
        //{
        //    return true;
        //}
        if (client.UserAuthString.Contains("ADMIN"))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}

public class SwitchAuth : AccessBehaviour
{
    protected override bool HandleAccess(Client client)
    {
        return client.HasAccess;
    }
}

public class ClientFactory
{
    public Client CreateClient(string clientType, string userName, bool isManagerInEnterprise)
    {
        Client newClient;
        switch (clientType)
        {
            case "USER":
                newClient = new User();
                newClient.UserName = userName;
                break;
            case "MANAGER":
                newClient = new Manager(isManagerInEnterprise);
                newClient.UserName = userName;
                break;
            case "ADMIN":
                newClient = new Admin();
                newClient.UserName = userName;
                break;
            default:
                throw new Exception();
        }
        Console.WriteLine(newClient.BuildAuthString());
        return newClient;
    }
}

public abstract class ClientHandler
{
    public ClientFactory ClientFactory { get; set; }
    public abstract Client CreateClient(string clientType, string userName, bool isManagerInEnterprise);
}

public class RetailClientHandler : ClientHandler
{
    public override Client CreateClient(string clientType, string userName, bool isManagerInEnterprise)
    {
        return ClientFactory.CreateClient(clientType, userName, isManagerInEnterprise);
    }
}

public class EnterpriseHandler : ClientHandler
{
    public override Client CreateClient(string clientType, string userName, bool isManagerInEnterprise)
    {
        if (clientType == "MANAGER")
        {
            Client client = ClientFactory.CreateClient(clientType, userName, true);
            return client;
        }
        else
        {
            return ClientFactory.CreateClient(clientType, userName, false);
        }
    }
}