#region Copyright Mitutoyo Europe GmbH 2014
//-----------------------------------------------------------------------
// <copyright file="TemperatureSession.cs" company="Mitutoyo Europe GmbH">
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
   /// <summary>
   /// Get zero or more temperatures.
   /// </summary>
   public class TemperatureSession
   {
      private static readonly Random _random = new Random();
      private IReadOnlyList<TemperatureSource> _temperatureSources;
      private TemperatureSource _temperatureSource;

      /// <summary>
      /// Create an instance.
      /// </summary>
      public TemperatureSession()
      {
         _temperatureSources = new []
         {
            new TemperatureSource("Source0", 20, 90, _random),
            new TemperatureSource("Source1", -10, 100, _random)
         };
      }

      /// <summary>
      /// Set which source to use.
      /// </summary>
      /// <param name="sourceName">The name of the source.</param>
      /// <returns>True if the source exists and can be used.</returns>
      public bool SetTemperatureSource(string sourceName)
      {
         if (_temperatureSources == null)
            throw new InvalidOperationException("Session has been closed.");
         _temperatureSource = _temperatureSources.FirstOrDefault(s => s.Name.Equals(sourceName));
         return _temperatureSource != null;
      }

      /// <summary>
      /// Get the available temperatures.
      /// </summary>
      /// <returns>The avaiable temperatures.</returns>
      public IEnumerable<double> GetTemperatures()
      {
         if (_temperatureSources == null)
            throw new InvalidOperationException("Session has been closed.");
         if (_temperatureSource == null)
            throw new InvalidOperationException("No source is selected");
         return _temperatureSource.Temperatures;
      }

      /// <summary>
      /// Close the session when done getting temperatures.
      /// </summary>
      public void CloseSession()
      {
         _temperatureSources = null;
         _temperatureSource = null;
      }
   }
}