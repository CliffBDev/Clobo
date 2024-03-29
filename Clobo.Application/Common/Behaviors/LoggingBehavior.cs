﻿using System;
using MediatR.Pipeline;
using Microsoft.Extensions.Logging;

namespace Clobo.Application.Common.Behaviors
{
    public class LoggingBehavior<TRequest> : IRequestPreProcessor<TRequest> where TRequest : notnull
    {
        private readonly ILogger _logger;

        public LoggingBehavior(ILogger<TRequest> logger)
        {
            _logger = logger;
        }


        //TOOD: Will eventually 
        public async Task Process(TRequest request, CancellationToken cancellationToken)
        {
            var requestName = typeof(TRequest).Name;

            _logger.LogInformation($"Request Name: {requestName} Request: {request}");
        }
    }
}

