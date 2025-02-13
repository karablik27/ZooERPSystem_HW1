using System;
using AnimalsLibrary;
namespace Places
{
    public class VeterinaryClinic : IHealthChecker
    {
        public bool IsHealthy(Animal animal) => animal.IsHealthy;
    }
}

