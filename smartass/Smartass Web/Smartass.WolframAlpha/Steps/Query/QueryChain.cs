namespace Smartass.WolframAlpha.Steps.Query
{
    using Smartass.Steps;

    public static class QueryChain
    {
        public static StepBase Create()
        {
            return new RunWolframAlphaQueryAsTextStep()
                .ChainNext(new ParseWolframAlphaStep());
        }
    }
}