namespace Smartass.Models.Uploading
{
    internal class ExposeUploadedFileDocket : UploadingDocketBase
    {
        public ExposeUploadedFileDocket(string fileUrl)
        {
            this.FileUrl = fileUrl;
        }

        internal string FileUrl { get; private set; }
    }
}