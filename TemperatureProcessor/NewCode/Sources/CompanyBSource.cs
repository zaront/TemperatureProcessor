using CompanyB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemperatureProcessor.NewCode.Sources
{
	class CompanyBSource : ISource
	{
		TemperatureFeed _client;

		public CompanyBSource(TemperatureFeed client)
		{
			//set fields
			_client = client ?? throw new ArgumentNullException("client");
		}

		public IEnumerable<IEnumerable<double>> GetTemperatures()
		{
			_client.Begin();
			yield return GetAllData().ToArray();
			_client.End();

			IEnumerable<double> GetAllData()
			{
				while (!_client.IsEndOfData())
				{
					yield return _client.GetNextTemperature();
				}
			}
		}
	}
}
