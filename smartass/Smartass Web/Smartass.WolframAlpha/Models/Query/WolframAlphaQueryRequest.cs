namespace Smartass.WolframAlpha.Models.Query
{
    using Smartass.Models;

    public class WolframAlphaQueryRequest : IPlanRequest
    {
        public WolframAlphaQueryRequest(string input)
        {
            this.Input = input;
        }

        internal string Input { get; private set; }
    }
}