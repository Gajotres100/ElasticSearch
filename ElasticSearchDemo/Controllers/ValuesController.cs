using ElasticSearchDemo.Code;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ElasticSearchDemo.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        { 
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public ApiRet Get(string id)
        {
            var client = new RestClient("http://168.63.8.167:9200");
            var request = new RestRequest($"address/_search", Method.GET);
            request.AddParameter("q", id);
            request.AddParameter("pretty", "true");
            request.AddParameter("from", "0");
            request.AddParameter("size", "100");
            var res = client.Execute<RootObject>(request).Data;
            if (res == null) return null;

            List<Citys> Citys = res.hits.hits.Select(x => new Code.Citys
            {
                Name = x._source.name,
                Id = x._source.id
            }).ToList();

            ApiRet apiret = new ApiRet();
            apiret.Citys = Citys;
            apiret.Hits = res.hits.hits.Count();

            return apiret;
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
