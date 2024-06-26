﻿using System.Threading.Tasks;

namespace assessment_platform_developer.Infrastructure.Interfaces.Mediator
{
    public interface IMediator
    {
        TResult Send<TResult>(IMessage<TResult> data) where TResult : IMessageResult;
    }
}
