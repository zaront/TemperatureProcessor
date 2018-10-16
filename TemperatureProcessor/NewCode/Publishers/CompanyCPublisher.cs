using CompanyC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemperatureProcessor.NewCode.Publishers
{
	class CompanyCPublisher : IPublisher
	{
		TemperatureDataPublisher _client;

		public CompanyCPublisher(TemperatureDataPublisher client)
		{
			//set fields
			_client = client ?? throw new ArgumentNullException("client");
		}

		public void Publish(IEnumerable<PublishTemperature> temperatures)
		{
			_client.Connect();
			foreach (var temperature in temperatures)
				_client.AddResult(temperature.Name, (int)Math.Round(temperature.Temperature));
			_client.Disconnect();
		}
	}
}
