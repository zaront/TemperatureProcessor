using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemperatureProcessor.NewCode.Calculators
{
	class Min : ICalculator
	{
		public string Name => "Min";

		public double Calculate(IEnumerable<double> temperatures)
		{
			return temperatures.Min();
		}
	}
}
