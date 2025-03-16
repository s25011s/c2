namespace ConsoleApp1;

public class Container
{
    private int wholeMass; //kg
    private int height; //cm
    private int conatinerMass; //kg
    private int depth; //cm
    public string serialNumber { get; set;} //patern: KON-C-1

    private int maxLoad; //kg

    public Container(int wholeMass, int height, int conatinerMass, int depth, int maxLoad)
    {
        this.wholeMass = wholeMass;
        this.height = height;
        this.conatinerMass = conatinerMass;
        this.depth = depth;
        this.maxLoad = maxLoad;
    }

    public void EmptyContainer()
    {
        wholeMass = conatinerMass;    
    }

    public void LoadContainer(int mass)
    {
        if (mass + wholeMass > maxLoad)
        {
            throw new Exception("OverfillException");
        }
        else
        {
            wholeMass += mass;
        }
    }
}