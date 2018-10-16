using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemperatureProcessor.NewCode
{
	interface IPublisher
	{
		void Publish(IEnumerable<PublishTemperature> temperatures);
	}


	class PublishTemperature
	{
		public string Name { get; set; }
		public double Temperature { get; set; }
	}
}
