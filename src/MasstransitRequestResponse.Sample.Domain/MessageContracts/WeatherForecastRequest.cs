using System.Collections;
using System.Collections.Generic;

namespace MasstransitRequestResponse.Sample.Domain.MessageContracts
{
    public class WeatherForecastRequest
    {
        public IEnumerable<int> Range { get; set; }
    }
}