using System;
using RedPanda.Project.Services.Interfaces;

namespace RedPanda.Project.Services
{
    public sealed class UserService : IUserService
    {
        public int Currency { get; private set; }
        public event Action<int> OnChangedCurrency;
        
        public UserService()
        {
            Currency = 1000;
        }

        void IUserService.AddCurrency(int delta)
        {
            Currency += delta;
            OnChangedCurrency?.Invoke(delta);
        }

        void IUserService.ReduceCurrency(int delta)
        {
            Currency -= delta;
            OnChangedCurrency?.Invoke(delta);
        }
        
        bool IUserService.HasCurrency(int amount)
        {
            return Currency >= amount;
        }

    }
}