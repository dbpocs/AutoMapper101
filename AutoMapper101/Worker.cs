using AutoMApper101.Application.Commands;
using MediatR;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AutoMapper101
{
    public class Worker : BackgroundService
    {
        public Worker(ILogger<Worker> logger, IMediator mediator)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        private readonly ILogger<Worker> _logger;
        private readonly IMediator _mediator;

        private readonly DoMappingCommand _hardcodedCommand = new DoMappingCommand
        {
            SampleDTOIn = new SampleDTOIn
            {
                FirstName = "daniel",
                LastName = "baptista",
                Age = 28
            }
        };

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);

                _logger.LogInformation("SampleDTOIn: {FirstName}, {LastName}, {Age}", _hardcodedCommand.SampleDTOIn.FirstName, _hardcodedCommand.SampleDTOIn.LastName, _hardcodedCommand.SampleDTOIn.Age);
                var result = await _mediator.Send(_hardcodedCommand, stoppingToken);
                _logger.LogInformation("SampleDTOOut: {Name}, {YearOfBirth}", result.Name, result.YearOfBirth.Value);
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}