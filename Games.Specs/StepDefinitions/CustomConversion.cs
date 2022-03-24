using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow.Assist;

namespace Games.Specs.StepDefinitions
{

    [Binding]
    public class CustomConversion
    {

        [StepArgumentTransformation(@"(\d+) days ago")]
        public DateTime DateTimeConversion(int daysAgo)
        {
          return  DateTime.Now.Subtract(TimeSpan.FromDays(daysAgo));
        }

        [StepArgumentTransformation]
        public IEnumerable<Weapon> ToIEnumerable(Table table)
        {
            return table.CreateSet<Weapon>();
        }
    }
}
