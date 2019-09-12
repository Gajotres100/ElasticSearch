using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ElasticSearchDemo.Code
{
    public class ApiRet
    {
        public List<Citys> Citys { get; set; }
        public int Hits { get; set; }
    }

    public class Citys
    {
        public string Name { get; set; }
        public int Id { get; set; }
    }
}