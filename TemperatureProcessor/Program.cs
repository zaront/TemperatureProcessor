#region Copyright Mitutoyo Europe GmbH 2014
//-----------------------------------------------------------------------
// <copyright file="Program.cs" company="Mitutoyo Europe GmbH">
//     Copyright (c) Mitutoyo Europe GmbH, All rights reserved
// </copyright>
//-----------------------------------------------------------------------
// Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//-----------------------------------------------------------------------
#endregion

using System.Linq;
using CompanyA;
using CompanyC;
using DataProcessing;
using TemperatureProcessor.NewCode;

namespace TemperatureProcessing
{
   class Program
   {
      static void Main(string[] args)
      {
         TemperatureDatabase temperatureDatabase = new TemperatureDatabase();
         temperatureDatabase.Connect();
         var temperatures = temperatureDatabase.GetTemperatures();
         var temperatureDoubles = temperatures
            .Select(i => (double)i).ToArray();
         var medianGetter = new MedianGetter();
         var result = medianGetter.Calculate(temperatureDoubles);
         TemperatureDataPublisher dataCollector = new TemperatureDataPublisher();
         dataCollector.Connect();
         dataCollector.AddResult("Median", (int)result);
         dataCollector.Disconnect();



		 //all changes/additions I've made are in the "NewCode" folder
		 var workflow = SequentialWorflow.CreateInstance();
		 workflow.Run();

		}
   }
}
