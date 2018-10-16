using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemperatureProcessor.NewCode.Calculators;
using TemperatureProcessor.NewCode.Publishers;
using TemperatureProcessor.NewCode.Sources;

namespace TemperatureProcessor.NewCode
{
	/// <summary>
	/// impliments a sequential worflow.  meaning each each temperature is calculated and published as its received from the source. 
	/// Alternativly, a diffrent workflow could be constructed to batch process results.
	/// 
	/// NOTE: this would also be the right level to orchestrate exception handling and logging [not implimented]
	/// </summary>
	class SequentialWorflow : BaseWorkflow
	{
		public SequentialWorflow(IEnumerable<ISource> sources, IEnumerable<ICalculator> calculators, IEnumerable<IPublisher> publishers) //NOTE: great place to pass in loggers too
			: base (sources, calculators, publishers)
		{
		}

		/// <summary>
		/// Default wireup of the workflow
		/// 
		/// //NOTE: this method is a helper and is not nessissary for testing and Dependency Injection wireups
		/// </summary>
		/// <returns></returns>
		internal static SequentialWorflow CreateInstance()
		{
			return new SequentialWorflow(
				new ISource[]{
					new CompanyASource(new CompanyA.TemperatureDatabase()),
					new CompanyBSource(new CompanyB.TemperatureFeed()),
					new CompanyDSource(new CompanyD.TemperatureSession()) },
				new ICalculator[] { new Median(), new Max(), new Min() },
				new IPublisher[] {
					new CompanyCPublisher(new CompanyC.TemperatureDataPublisher()),
					new CompanyDPublisher(new CompanyD.ResultLog()) } );
		}

		/// <summary>
		/// publish each result as temperatures are processed
		/// </summary>
		public void Run()
		{
			//get all temperatures
			var allTemperatures = GetAllTemperatures();

			//loop through, calculate and publish each temperature set as received
			foreach (var temperatureSources in allTemperatures)
			{
				foreach (var temperatures in temperatureSources)
				{
					//calculate
					var results = RunAllCalculations(temperatures);

					//publish
					PublishTemperatures(results);
				}
			}
		}
	}
}
