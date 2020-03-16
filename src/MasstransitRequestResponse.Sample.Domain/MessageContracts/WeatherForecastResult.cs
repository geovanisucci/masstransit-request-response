using System;
using System.Collections;
using System.Collections.Generic;

namespace MasstransitRequestResponse.Sample.Domain.MessageContracts
{
    public class WeatherForecastResult
    {
        public IEnumerable<WeatherForecast> WeatherForecast { get; set; }
    }
}