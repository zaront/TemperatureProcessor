using CompanyD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemperatureProcessor.NewCode.Sources
{
	class CompanyDSource : ISource
	{
		TemperatureSession _client;

		public CompanyDSource(TemperatureSession client)
		{
			//set fields
			_client = client ?? throw new ArgumentNullException("client");
		}

		public IEnumerable<IEnumerable<double>> GetTemperatures()
		{
			_client.SetTemperatureSource("Source0");
			yield return _client.GetTemperatures();
			_client.SetTemperatureSource("Source1");
			yield return _client.GetTemperatures();
			_client.CloseSession();
		}
	}
}
