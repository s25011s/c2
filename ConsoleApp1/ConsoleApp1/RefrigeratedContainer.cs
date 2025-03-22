using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class RefrigeratedContainer : Container, HazardNotifier
    {
        private static int containerAmount;
        private string? productType;
        private double temparature;
        private static readonly Dictionary<string, double> minimalTemperatures = 
            new Dictionary<string, double>{ 
                {"bananas", 13.3},
                {"chocolate", 18},
                {"fish", 2},
                {"meat", -15},
                {"iceCream", -18},
                {"frozenPizza", -30},
                {"cheese", 7.2},
                {"sausages", 5},
                {"butter", 20.5},
                {"eggs", 19}
            };
        public RefrigeratedContainer(int height, int conatinerMass, int depth, int maxLoad) 
            : base(height, conatinerMass, depth, maxLoad)
        {
            containerAmount++;
            this.serialNumber = "KON-C" + containerAmount;
            this.productType = null;
        }
        private void Notify(string situation)
        {
            Console.WriteLine(
                $"Problem occured in container: " +
                $"{serialNumber} \n" +
                $"{situation}");
        }
        public void LoadContainer(double mass, string type)
        {
            if(productType != null && productType == type)
            {
                try
                {
                    if (minimalTemperatures[type] < temparature)
                    {
                        Notify("Container temperature too high.");
                        return;
                    }
                    productType = type;
                    base.LoadContainer(mass);
                }
                catch (Exception e) { }
                
                
            }
            else
            {
                Notify("Incorrect cargo type.");
            }
        }
        public override void Info()
        {
            base.Info();
            Console.WriteLine(
                $"product type - {productType}\n" +
                $"temparature - {temparature}\n"
            );
        }
    }
}
