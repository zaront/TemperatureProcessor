using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemperatureProcessor.NewCode
{
	interface ICalculator
	{
		string Name { get; }
		double Calculate(IEnumerable<double> temperatures);
	}
}
