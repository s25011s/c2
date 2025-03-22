namespace ConsoleApp1;

public class Container
{
    protected double cargoMass; //kg
    protected double height; //cm
    protected double containerMass; //kg
    protected double depth; //cm
    public string serialNumber { get; set;} //patern: KON-C-1
    protected double maxLoad; //kg

    public Container(int height, int conatinerMass, int depth, int maxLoad)
    {
        this.cargoMass = 0;
        this.height = height;
        this.containerMass = conatinerMass;
        this.depth = depth;
        this.maxLoad = maxLoad;
    }

    public void EmptyContainer()
    {
        cargoMass = 0;    
    }

    public virtual void LoadContainer(double mass)
    {
        if (mass + cargoMass > maxLoad)
        {
            throw new Exception("OverfillException");
        }
        else
        {
            cargoMass += mass;
        }
    }
    public double GetCargoMass() { return cargoMass; }
    public double GetContainerMass() { return containerMass; }
    public virtual void Info()
    {
        Console.WriteLine(
            $"---CONTAINER INFO---\n" +
            $"cargo mass - {this.cargoMass} kg\n" +
            $"height - {this.height}cm\n" +
            $"container mass - {this.containerMass} kg\n" +
            $"depth - {this.depth} cm\n" +
            $"serial number - {this.serialNumber}\n" +
            $"max load - {this.maxLoad} kg"
        );
    }
}