using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemperatureProcessor.NewCode
{
	interface ISource
	{
		IEnumerable<IEnumerable<double>> GetTemperatures();
	}
}
