using System.Collections.Generic;
using System;
using System.Linq;
using TechTalk.SpecFlow;

namespace Utilities.Extensions
{
    public static class TableExtension
    {
        public static Dictionary<string, string> ToDictionary(this Table table)
        {
            if (table is null)
                throw new ArgumentNullException(nameof(table));

            if (table.Rows.Count == 0)
                throw new InvalidOperationException("Data table has no rows");

            if (table.Rows.First().Count != 2)
                throw new InvalidOperationException($@"Data table must have exactly 2 columns. Columns found: ""{string.Join(@""", """, table.Rows.First().Keys)}""");

            return table.Rows.ToDictionary(row => row[0], row => row[1]);
        }
    }
}