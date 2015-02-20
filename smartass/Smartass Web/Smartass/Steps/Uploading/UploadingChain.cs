namespace Smartass.Steps.Uploading
{
    public static class UploadingChain
    {
        public static StepBase Create()
        {
            return new ReceiveUploadedFileStep()
                .ChainNext(new ExposeUploadedFileStep())
                //.ChainNext(new GoogleImageSearchStep(), new AlchemyImageKeywordsStep()/*, new ClarifaiImageKeywordStep()*/)
                .ChainNext(new ParseGoogleImageSearchStep(), new GoogleImageSearchStep(), new AlchemyImageKeywordsStep())
                .ChainNext(new FinalizeStep());
        }
    }
}