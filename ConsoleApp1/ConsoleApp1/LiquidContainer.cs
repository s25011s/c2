using System.ComponentModel;
using System.Transactions;

namespace ConsoleApp1;

public class LiquidContainer : Container, HazardNotifier
{
    private static int containerAmount = 0;

    public LiquidContainer(int height, int conatinerMass, int depth, int maxLoad) 
        : base(height, conatinerMass, depth, maxLoad)
    {
        containerAmount++;
        this.serialNumber = "KON-L" + containerAmount;
    }

    private void Notify(string situation)
    {
        Console.WriteLine(
            $"Hazardous situation occured in container: " +
            $"{serialNumber} \n" +
            $"{situation}");
    }

    public override void LoadContainer(double mass)
    {
        try
        {
            base.LoadContainer(mass);

            if (this.cargoMass + mass > this.maxLoad / 2)
            {
                Notify("Over 50% of maximum load while containing hazardous cargo.");
            }
            if (this.cargoMass > this.maxLoad * 0.9)
            {
                Notify("Over 90% of maximum load.");
            }
        }
        catch (Exception ex){}
    }
    public override void Info()
    {
        base.Info();
        Console.WriteLine("");
    }
}