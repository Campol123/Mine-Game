using NUnit.Framework;

namespace Testing;

public abstract class Specification
{
    [SetUp]
    protected virtual void BeforeEach()
    {
        
    }
    
    protected static void Given(Action testAction)
    {
        testAction.Invoke();
    }

    protected static void And(Action testAction)
    {
        testAction.Invoke();
    }


    protected static void When(Action testAction)
    {
        testAction.Invoke();
    }


    protected static void Then(Action testAction)
    {
        testAction.Invoke();
    }
}