using System.ComponentModel;
using System.Transactions;

namespace ConsoleApp1;

public class LiquidContainer : Container, HazardNotifier
{
    private static int containerAmount = 0;

    public LiquidContainer(int wholeMass, int height, int conatinerMass, int depth, int maxLoad) : base(wholeMass, height, conatinerMass, depth, maxLoad)
    {
        containerAmount++;
        this.serialNumber = "KON-L" + containerAmount;
    }

    private void Notify()
    {
        Console.WriteLine($"Hazardous situation occured in container: {serialNumber}");
    }

    public void LoadContainer(int mass)
    {
        base.LoadContainer(mass);
    }
}