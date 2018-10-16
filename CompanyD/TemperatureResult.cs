#region Copyright Mitutoyo Europe GmbH 2014
//-----------------------------------------------------------------------
// <copyright file="TemperatureResult.cs" company="Mitutoyo Europe GmbH">
//     Copyright (c) Mitutoyo Europe GmbH, All rights reserved
// </copyright>
//-----------------------------------------------------------------------
// Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//-----------------------------------------------------------------------
#endregion

namespace CompanyD
{
   /// <summary>
   /// One temperature result.
   /// </summary>
   public class TemperatureResult
   {
      /// <summary>
      /// Create an intance.
      /// </summary>
      public TemperatureResult(string name, double temperature)
      {
         Name = name;
         Temperature = temperature;
      }

      /// <summary>
      /// The name of the temperature result.
      /// </summary>
      public string Name { get; private set; }

      /// <summary>
      /// The value of the temperature.
      /// </summary>
      public double Temperature { get; private set; }
   }
}