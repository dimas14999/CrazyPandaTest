using System;

namespace RedPanda.Project.Services.Interfaces
{
    public interface IUserService
    {
        void AddCurrency(int delta);
        void ReduceCurrency(int delta);
        bool HasCurrency(int amount);
        event Action<int> OnChangedCurrency;
        int Currency { get; }
    }
}