using System.IO;

namespace Smartass.Models.Uploading
{
    internal class ReceiveUploadedFileDocket : UploadingDocketBase
    {
        public ReceiveUploadedFileDocket(FileInfo fileInfo)
        {
            this.FileInfo = fileInfo;
        }

        internal FileInfo FileInfo { get; private set; }
    }
}