#region Copyright Mitutoyo Europe GmbH 2014
//-----------------------------------------------------------------------
// <copyright file="TemperatureDatabase.cs" company="Mitutoyo Europe GmbH">
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

namespace CompanyA
{
   /// <summary>
   /// Get temperatures.
   /// </summary>
   public class TemperatureDatabase
   {
      private static readonly Random _random = new Random();
      private readonly IReadOnlyList<int> _temperatures;
      private bool _isConnected;

      /// <summary>
      /// Create an instance.
      /// </summary>
      public TemperatureDatabase()
      {
         var count = _random.Next(5) + 1;
         _temperatures = Enumerable.Range(0, count)
            .Select(i => _random.Next(-10, 120))
            .ToList();
      }

      /// <summary>
      /// Call this method before calling <see cref="GetTemperatures"/>.
      /// </summary>
      public void Connect()
      {
         if (_isConnected)
            throw new InvalidOperationException("Already connected");
         _isConnected = true;
      }

      /// <summary>
      /// Get temperature readings.
      /// </summary>
      /// <remarks>Closes the connection.</remarks>
      /// <returns>0 or more temperature readings.</returns>
      public int[] GetTemperatures()
      {
         if (!_isConnected)
            throw new InvalidOperationException("Not connected");
         return _temperatures.ToArray();
      }
   }
}