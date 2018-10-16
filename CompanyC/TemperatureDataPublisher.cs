#region Copyright Mitutoyo Europe GmbH 2014
//-----------------------------------------------------------------------
// <copyright file="TemperatureDataPublisher.cs" company="Mitutoyo Europe GmbH">
//     Copyright (c) Mitutoyo Europe GmbH, All rights reserved
// </copyright>
//-----------------------------------------------------------------------
// Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//-----------------------------------------------------------------------
#endregion

using System;

namespace CompanyC
{
   /// <summary>
   /// Collect results for publication.
   /// </summary>
   public class TemperatureDataPublisher
   {
      private bool _isConnected;

      /// <summary>
      /// Call to open a connection to begin publishing temperatures.
      /// </summary>
      public void Connect()
      {
         if (_isConnected)
            throw new InvalidOperationException("Already connected");
         _isConnected = true;
      }

      /// <summary>
      /// Add a temperature calculation to publish.
      /// </summary>
      /// <param name="name">The name of the result.</param>
      /// <param name="datum">The value of the result.</param>
      public void AddResult(string name, int datum)
      {
         if (!_isConnected)
            throw new InvalidOperationException("Not connected");
      }

      /// <summary>
      /// Close the connection after results have been published.
      /// </summary>
      public void Disconnect()
      {
         if (!_isConnected)
            throw new InvalidOperationException("Not connected");
         _isConnected = false;
      }
   }
}