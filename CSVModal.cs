using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSVHasherCode
{
    public class CSVModal
    {
        public int SeriesName { get; set; }
        public string Filename { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Gender { get; set; }
        public List<AttributeType> attribute { get; set; }

        public string UUID { get; set; }

    }
    public class AttributeType
    {
        public string typeDa { get; set; }
        public string value { get; set; }

    }
}
