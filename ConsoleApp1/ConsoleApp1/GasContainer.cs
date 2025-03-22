using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class GasContainer : Container, HazardNotifier
    {
        private static int containerAmount = 0;
        private double pressure; //atm

        public GasContainer(int height, int conatinerMass, int depth, int maxLoad) 
            : base(height, conatinerMass, depth, maxLoad)
        {
            containerAmount++;
            this.serialNumber = "KON-G" + containerAmount;
            this.pressure = 0;
        }

        private void Notify(string situation)
        {
            Console.WriteLine(
                $"Hazardous situation occured in container: " +
                $"{serialNumber} \n" +
                $"{situation}");
        }
        public void EmptyContainer()
        {
            this.cargoMass *= 0.05;
        }
        public override void LoadContainer(double mass)
        {
            try
            {
                base.LoadContainer(mass);
            }
            catch (Exception ex)
            {
                Notify("Container overloaded.");
            }
        }
        public override void Info()
        {
            base.Info();
            Console.WriteLine($"\npressure - {this.pressure} atm");
        }
    }
}
