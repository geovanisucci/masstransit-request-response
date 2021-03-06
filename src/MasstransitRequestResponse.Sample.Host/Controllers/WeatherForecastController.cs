﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MassTransit;
using MasstransitRequestResponse.Sample.Domain.MessageContracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MasstransitRequestResponse.Sample.Host.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {


        private readonly ILogger<WeatherForecastController> _logger;

        IRequestClient<WeatherForecastRequest> _client;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IRequestClient<WeatherForecastRequest> client)
        {
            _logger = logger;
            _client = client;
        }


        [HttpGet]
        public async Task<IEnumerable<WeatherForecast>> Get()
        {

            var response = await _client.GetResponse<WeatherForecastResult>(new WeatherForecastRequest() { Range = Enumerable.Range(1, 5) });

            return response.Message.WeatherForecast.ToArray();

        }
    }
}
