using System.Collections.Generic;
using System.Net.Http;

namespace Smartass.Models
{
    public class Plan
    {
        public Plan(IPlanRequest request)
        {
            this.HttpClientHandler = new HttpClientHandler();
            this.Dockets = new List<IDocket>();
            this.Request = request;
        }

        public IList<IDocket> Dockets { get; private set; }

        public HttpClientHandler HttpClientHandler { get; private set; }

        public IPlanRequest Request { get; private set; }

        public IPlanResult Result { get; set; }
    }
}