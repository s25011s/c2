// See https://aka.ms/new-console-template for more information
using ConsoleApp1;
using System.Collections;

var containers = new List<Container>();
containers.Add(new LiquidContainer(10, 1, 20, 200)); //1
containers.Add(new LiquidContainer(10, 1, 20, 200));
containers.Add(new GasContainer(10, 1, 20, 200));
containers.Add(new GasContainer(10, 1, 20, 200));
containers.Add(new RefrigeratedContainer(10, 1, 20, 200));

containers[0].LoadContainer(150); //2

ContainerShip ship1 = new(10, 5, 200);
ContainerShip ship2 = new(10,5, 200);

ship1.AddContainer(containers[0]); //3
List<Container> containers1 = new List<Container>{containers[1], containers[2]};
ship1.AddContainer(containers1); //4
ship1.RemoveContainer(containers[1]); //5

containers[0].EmptyContainer(); //6

ship1.ReplaceContainer(containers[0].serialNumber, containers[3]); //7

ship1.MoveContainer(containers[2], ship2); //8

foreach (var item in containers) 
{
    item.Info(); //9
}
ship1.Info(); //10
ship2.Info();  