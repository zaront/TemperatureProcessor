#region Copyright Mitutoyo Europe GmbH 2014
//-----------------------------------------------------------------------
// <copyright file="MedianGetter.cs" company="Mitutoyo Europe GmbH">
//     Copyright (c) Mitutoyo Europe GmbH, All rights reserved
// </copyright>
//-----------------------------------------------------------------------
// Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//-----------------------------------------------------------------------
#endregion

using System.Collections.Generic;
using System.Linq;

namespace DataProcessing
{
   public class MedianGetter
   {
      public double Calculate(IEnumerable<double> values)
      {
         var valueList = values.ToList();
         valueList.Sort();
         int medianIndex = (valueList.Count - 1) / 2;
         if (IsCountEven(valueList.Count))
            return (valueList[medianIndex] + valueList[medianIndex + 1]) / 2;
         return valueList[medianIndex];
      }

      private static bool IsCountEven(int count)
      {
         return (count & 1) == 0;
      }
   }
}