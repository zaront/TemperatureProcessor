#region Copyright Mitutoyo Europe GmbH 2014
//-----------------------------------------------------------------------
// <copyright file="TemperatureSource.cs" company="Mitutoyo Europe GmbH">
//     Copyright (c) Mitutoyo Europe GmbH, All rights reserved
// </copyright>
//-----------------------------------------------------------------------
// Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//-----------------------------------------------------------------------
#endregion

using System;
using System.Collections.Generic;
using System.Linq;

namespace CompanyD
{
   internal class TemperatureSource
   {
      public TemperatureSource(string name, double min, double max, Random random)
      {
         var count = random.Next(5) + 1;
         var range = max - min;
         Temperatures = Enumerable.Range(0, count)
            .Select(i => random.NextDouble() * range + min)
            .ToList();
         Name = name;
      }

      public string Name { get; private set; }

      public IReadOnlyList<double> Temperatures { get; private set; }
   }
}