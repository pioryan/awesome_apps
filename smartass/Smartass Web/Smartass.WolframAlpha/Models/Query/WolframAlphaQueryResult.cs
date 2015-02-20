using System.Collections.Generic;
using Smartass.Models;

namespace Smartass.WolframAlpha.Models.Query
{
    public class WolframAlphaQueryResult : IPlanResult
    {
        public WolframAlphaQueryResult(IEnumerable<GlassCardItem> cardItems)
        {
            this.CardItems = new List<GlassCardItem>(cardItems);
        }

        public IList<GlassCardItem> CardItems { get; private set; }
    }
}