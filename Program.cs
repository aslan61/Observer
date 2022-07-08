using System;
using System.Collections.Generic;

namespace Observer
{
    class Program
    {
        static void Main(string[] args)
        {
            var customerob = new CustomerObserver();
            ProductManager productManager = new ProductManager();
            productManager.Attach(customerob);
            productManager.Attach(new EmployeeObserver());
            productManager.Detach(customerob);
            productManager.UpdatePrice();

            Console.ReadLine();
        }
    }
    class ProductManager
    {
        List<Observer> _observer = new List<Observer>();
        public void UpdatePrice()
        {
            Console.WriteLine("Product price changed");
            Notify();
        }
        public void Attach(Observer observer)
        {
            _observer.Add(observer);
        }
        public void Detach(Observer observer)
        {
            _observer.Remove(observer);
        }
        private void Notify()
        {
            foreach (var observer in _observer)
            {
                observer.Update();
            }
        }
    }
    abstract class Observer
    {
        public abstract void Update();
    }
    class Customer : Observer
    {
        public override void Update()
        {
            Console.WriteLine("Message to customer : Product price changed!");
        }
    }
    class CustomerObserver : Observer
    {
        public override void Update()
        {
            Console.WriteLine("Message to customer : Product price changed!");
        }
    }
    class EmployeeObserver : Observer
    {
        public override void Update()
        {
            Console.WriteLine("Message to employee : Product price changed!");
        }
    }
}
