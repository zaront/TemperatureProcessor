using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemperatureProcessor.NewCode
{
	abstract class BaseWorkflow //NOTE: good place for IDisposable
	{
		IEnumerable<ISource> _sources;
		IEnumerable<ICalculator> _calculators;
		IEnumerable<IPublisher> _publishers;

		public BaseWorkflow(IEnumerable<ISource> sources, IEnumerable<ICalculator> calculators, IEnumerable<IPublisher> publishers)
		{
			//set fields
			_sources = sources ?? throw new ArgumentNullException("sources");
			_calculators = calculators ?? throw new ArgumentNullException("calculators");
			_publishers = publishers ?? throw new ArgumentNullException("publishers");
		}

		public IEnumerable<IEnumerable<IEnumerable<double>>> GetAllTemperatures()
		{
			return _sources.Select(i => i.GetTemperatures());
		}

		public IEnumerable<PublishTemperature> RunAllCalculations(IEnumerable<double> temperatures)
		{
			return _calculators.Select(i => new PublishTemperature() { Name = i.Name, Temperature = i.Calculate(temperatures) });
		}

		public void PublishTemperatures(IEnumerable<PublishTemperature> temperatures)
		{
			foreach (var publisher in _publishers)
				publisher.Publish(temperatures);
		}
	}
}
