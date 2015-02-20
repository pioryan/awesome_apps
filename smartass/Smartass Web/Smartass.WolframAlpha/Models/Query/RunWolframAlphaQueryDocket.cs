using Smartass.Models;
using Smartass.WolframAlpha.Models.Xml;

namespace Smartass.WolframAlpha.Models.Query
{
    internal class RunWolframAlphaQueryDocket : IDocket
    {
        public RunWolframAlphaQueryDocket(QueryResult queryResult)
        {
            this.QueryResult = queryResult;
        }

        internal QueryResult QueryResult { get; private set; }
    }
}