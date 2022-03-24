using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Games.Specs.StepDefinitions.Utils
{
    public class Conversion
    {
        public static Dictionary<string, string> ToDictionary(Table table)
        {

            Dictionary<string, string> dataAsDictionary = new Dictionary<string, string>();

            foreach(var row in table.Rows)
            {
                dataAsDictionary.Add(row[0], row[1]);
            }
            return dataAsDictionary;

        }
    }
}
