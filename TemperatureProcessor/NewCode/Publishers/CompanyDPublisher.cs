using CompanyD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemperatureProcessor.NewCode.Publishers
{
	class CompanyDPublisher : IPublisher
	{
		ResultLog _client;

		public CompanyDPublisher(ResultLog client)
		{
			//set fields
			_client = client ?? throw new ArgumentNullException("client");
		}

		public void Publish(IEnumerable<PublishTemperature> temperatures)
		{
			_client.PublishData(temperatures.Select(i => new TemperatureResult(i.Name, i.Temperature)).ToArray());
		}
	}
}
