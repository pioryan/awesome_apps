using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smartass.Models.Uploading
{
    internal class GoogleImageSearchDocket : UploadingDocketBase
    {
        public GoogleImageSearchDocket(string content)
        {
            this.Content = content;
        }

        internal string Content { get; private set; }
    }
}
