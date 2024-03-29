﻿using System;

namespace Kantilever.MicroService.DomainServices.Contracts
{
    public interface IMessageBus
    {
        void Publish<TMessage>(TMessage message) where TMessage : class;
        void Subscribe<TMessage>(Action<TMessage> handlerAction) where TMessage : class;
    }
}
