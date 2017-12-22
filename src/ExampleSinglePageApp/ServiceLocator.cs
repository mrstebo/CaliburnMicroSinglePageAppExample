using System;
using Caliburn.Micro;

namespace ExampleSinglePageApp
{
    public interface IServiceLocator
    {
        object Resolve(Type t);
    }

    internal class  ServiceLocator : IServiceLocator
    {
        public object Resolve(Type t)
        {
            return IoC.GetInstance(t, null);
        }
    }
}