using CompanyA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemperatureProcessor.NewCode.Sources
{
	class CompanyASource : ISource
	{
		TemperatureDatabase _client;

		public CompanyASource(TemperatureDatabase client)
		{
			//set fields
			_client = client ?? throw new ArgumentNullException("client");
		}

		public IEnumerable<IEnumerable<double>> GetTemperatures()
		{
			_client.Connect();
			yield return _client.GetTemperatures().Select(i => (double)i);
		}
	}
}
