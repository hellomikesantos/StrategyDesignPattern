TestClass instance = new TestClass();
instance.MyField = "test";
Console.WriteLine(instance.MyField);

class TestClass
{
    // members
    // fields - no getter and setter methods on it
    public string MyField;

    // properties
    public string MyField2 { get; set; }
}

public abstract class AbstractTest
{
    public abstract void AbstractMethod();
    public virtual void ImplementationMethod(string value)
    {
        Console.WriteLine("This method is implemented on the abstract class.");
    }
}

public class ConcreteChild : AbstractTest
{
    public override void AbstractMethod()
    {
        Console.WriteLine("This is the implementation ");
    }
}

public interface IFirstInterface
{
    void Firstmethod();
}

public interface ISecondInterface
{
    void SecondMethod(bool booleanValue);
}

public abstract class Car
{
    public abstract string GoVroom();
}


public class ConcreteCar : Car, IFirstInterface, ISecondInterface
{
    public override string GoVroom()
    {
        return "String";
    }


    public void Firstmethod()
    {
        throw new NotImplementedException();
    }

    public void SecondMethod(bool booleanValue)
    {
        throw new NotImplementedException();
    }
}

// concrete class - you can instantiate
// abstract class - you cannot instantiate
// abstract method - has no body
// protected - only the child class that inherited from that parent class
//              can use it
