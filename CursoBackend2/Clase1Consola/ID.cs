namespace Clase1Consola;

public interface IID
{
    Guid Value { get; }
}

public interface IIDSingleton : IID { }
public interface IIDScoped : IID { }
public interface IIDTrasient : IID { }

public class ID : IIDSingleton, IIDScoped, IIDTrasient
{
    public Guid Value { get; private set; } = Guid.NewGuid();
}
