using System;
using AnimalsLibrary;
namespace Places
{
    public interface IHealthChecker
    {
        bool IsHealthy(Animal animal);
    }
}

