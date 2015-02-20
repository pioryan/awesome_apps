using System.Net.Http;

namespace Smartass.Models.Uploading
{
    public class UploadingRequest : IPlanRequest
    {
        public UploadingRequest(HttpRequestMessage request)
        {
            this.Request = request;
        }

        internal HttpRequestMessage Request { get; private set; }
    }
}