using Smartass.Steps.Uploading;
namespace Smartass.Web.Models.Chains
{
    public static class UploadingChain
    {
        public static UploadingStepBase Create()
        {
            return new ReceiveUploadedFileStep()
                .ChainNext(new ExposeUploadedFileStep())
                .ChainNext(new GoogleImageSearchStep())
                .ChainNext(new ParseGoogleImageSearchStep())
                .ChainNext(new AlchemyImageKeywordsStep())
                .ChainNext(new ClarifaiImageKeywordStep())
                .ChainNext(new FinalizeStep());
        }
    }
}