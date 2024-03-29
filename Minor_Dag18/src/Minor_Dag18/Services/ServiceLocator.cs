﻿using System;

namespace Minor_Dag18.Services
{
    public class ServiceLocator : IServiceLocator
    {
        IServiceProvider _provider;

        public ServiceLocator(IServiceProvider provider)
        {
            _provider = provider;
        }

        public TService Locate<TService>()
        {
            return (TService) _provider.GetService(typeof(TService));
        }
    }
}
