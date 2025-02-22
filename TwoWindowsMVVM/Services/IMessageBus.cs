﻿namespace TwoWindowsMVVM.Services
{
    public interface IMessageBus
    {
        IDisposable RegisterHandler<T>(Action<T>  Handler);

        void Send<T>(T message);
    }
}
