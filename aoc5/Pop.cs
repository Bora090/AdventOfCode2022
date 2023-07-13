// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Collections.Generic;

namespace System.Linq
{
    public static partial class List
    {
        public static TSource Pop<TSource>(this List<TSource> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (source.Any()) //prevent IndexOutOfRangeException for empty list
            {
                TSource last = source.Last();
                source.RemoveAt(source.Count - 1);
                return last;
            }
            throw new InvalidOperationException(source.ToString());
        }
    }
}