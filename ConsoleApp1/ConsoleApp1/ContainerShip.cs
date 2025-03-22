using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class ContainerShip
    {
        private List<Container> containers;
        private double maxSpeed; //knots
        private int maxContainers;
        private double maxLoadedMass; //tons
        private double loadedMass;

        public ContainerShip(double maxSpeed, int maxContainers, double maxLoadedMass)
        {
            this.containers = new List<Container>();
            this.maxSpeed = maxSpeed;
            this.maxContainers = maxContainers;
            this.maxLoadedMass = maxLoadedMass;
            this.loadedMass = 0;
        }
        private bool Checkload(List<Container> containers)
        {
            if (maxContainers <= (containers.Count + this.containers.Count))
            {
                Console.WriteLine("Max containers reached.");
                return false;
            }
            double mass = 0;
            foreach (var c in containers)
            {
                mass += (c.GetContainerMass() + c.GetCargoMass());
            }
            
            if (mass + loadedMass > (maxLoadedMass*1000))
            {
                Console.WriteLine("Max loaded mass reached");
                return false;
            }
            this.loadedMass += mass;
            return true;
        }
        public void AddContainer(Container container)
        {
            var containers = new List<Container>();
            containers.Add(container);
            if (Checkload(containers))
            {
                this.containers.Add(container);
            }
        }
        public void AddContainer(List<Container> containers)
        {
            if (Checkload(containers))
            {
                this.containers.AddRange(containers);
            }
        }
        public void RemoveContainer(Container container)
        {
            this.containers.Remove(container);
        }
        public void ReplaceContainer(String replacingCode, Container container)
        {
            foreach (var c in this.containers)
            {
                if (c.serialNumber == replacingCode)
                {
                    this.containers.Remove(c);
                    this.containers.Add(container);
                    Console.WriteLine($"Replaced container {replacingCode} with {container.serialNumber}");
                    return;
                }
            }
            Console.WriteLine("No such container on this ship.");
        }
        public void MoveContainer(Container moveContainer, ContainerShip toShip)
        {
            foreach (var c in this.containers)
            {
                if (c.serialNumber == moveContainer.serialNumber)
                {
                    this.containers.Remove(c);
                    toShip.AddContainer(c);
                    Console.WriteLine($"Moved container {moveContainer.serialNumber} to chosen ship.");
                    return;
                }
            }
            Console.WriteLine("No such container on this ship.");
        }
        public void Info()
        {
            Console.WriteLine(
                $"---CONTAINER SHIP INFO---\n" +
                $"max speed - {maxSpeed} knots\n" +
                $"max containers - {maxContainers}\n" +
                $"max loaded mass - {maxLoadedMass} tons\n" +
                $"loaded mass - {loadedMass}\n" +
                $"containers:" 
            );
            foreach (var c in this.containers)
            {
                Console.WriteLine($"\t{c.serialNumber}");
            }
            Console.WriteLine($"\n");
        }
    }
}
