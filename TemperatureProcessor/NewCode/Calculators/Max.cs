using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemperatureProcessor.NewCode.Calculators
{
	class Max : ICalculator
	{
		public string Name => "Max";

		public double Calculate(IEnumerable<double> temperatures)
		{
			return temperatures.Max();
		}
	}
}
