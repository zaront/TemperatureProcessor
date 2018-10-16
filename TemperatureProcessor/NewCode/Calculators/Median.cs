using DataProcessing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemperatureProcessor.NewCode.Calculators
{
	class Median : ICalculator
	{
		public string Name => "Median";

		public double Calculate(IEnumerable<double> temperatures)
		{
			return new MedianGetter().Calculate(temperatures);
		}
	}
}
