#region Copyright Mitutoyo Europe GmbH 2014
//-----------------------------------------------------------------------
// <copyright file="TemperatureFeed.cs" company="Mitutoyo Europe GmbH">
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

namespace CompanyB
{
   /// <summary>
   /// Get temperatures.
   /// </summary>
   public class TemperatureFeed
   {
      private static readonly Random _random = new Random();
      private readonly IReadOnlyList<float> _temperatures;
      private int _index;

      /// <summary>
      /// Create an instance.
      /// </summary>
      public TemperatureFeed()
      {
         var count = _random.Next(5) + 1;
         _temperatures = Enumerable.Range(0, count)
            .Select(i => (float)(_random.NextDouble() * 130 - 10))
            .ToList();
         End();
      }

      /// <summary>
      /// Open the feed so that temperatures can be read.
      /// </summary>
      /// <remarks>
      /// Call this method before calling <see cref="IsEndOfData"/>
      /// <see cref="End"/> must be called to close the feed.
      /// </remarks>
      public void Begin()
      {
         _index = 0;
      }

      /// <summary>
      /// Get the next temperature.
      /// </summary>
      /// <returns>A temperature.</returns>
      public float GetNextTemperature()
      {
         if (_index == -1)
            throw new InvalidOperationException("Begin has not been called.");
         if (IsEndOfData())
            throw new InvalidOperationException("There are no more temperatures.");
         return _temperatures[_index++];
      }

      /// <summary>
      /// Test if more temperatures are avaiable.
      /// </summary>
      /// <remarks>Call this method before calling <see cref="GetNextTemperature"/></remarks>
      /// <returns>True if there are no more temperatures.</returns>
      public bool IsEndOfData()
      {
         return _index >= _temperatures.Count;
      }

      /// <summary>
      /// Call when done reading temperatures.
      /// </summary>
      public void End()
      {
         _index = -1;
      }
   }
}