using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Getty.Models
{
    public class Query
    {
        public DateCreatedRange DateCreatedRange { get; set; }

        public int EventId { get; set; }

        public string SearchPhrase { get; set; }

        public List<string> KeywordIds { get; set; }

        public List<string> SpecificPersons { get; set; }
    }

    public class DateCreatedRange
    {
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
    }
}
