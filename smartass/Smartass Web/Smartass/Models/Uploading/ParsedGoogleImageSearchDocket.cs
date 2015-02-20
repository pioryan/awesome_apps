using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smartass.Models.Uploading
{
    internal class ParsedGoogleImageSearchDocket : UploadingDocketBase
    {
        public ParsedGoogleImageSearchDocket()
        {
            this.Keywords = new Dictionary<string, int>();
        }

        internal Dictionary<string, int> Keywords { get; private set; } 

        internal string BestGuess { get; set; }
    }
}
