using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuratSekerCaseStudy.Helpers
{
    public static class ValidationHelper
    {
        public static bool IsUrlValid(string url)
        {
            Uri uriResult;
            bool tryCreateResult = Uri.TryCreate(url, UriKind.Absolute, out uriResult);
            if (tryCreateResult == true && uriResult != null && (url.StartsWith("http://") || url.StartsWith("https://")))
                return true;
            else
                return false;
        }

        public static bool IsRatingValid(int rating)
        {
            if (rating >= 0 && rating <= 5)
                return true;
            return false;
        }

        public static bool IsNameInUtfSet(string name)
        {
            //https://www.w3schools.com/charsets/ref_html_utf8.asp  some character codes that was supported by HTML5
            var maxDecimalForUtf8Set = 10175;
            foreach (var ch in name)
            {
                if ((decimal) ch > maxDecimalForUtf8Set)
                    return false;
            }
            return true;
        }
    }
}
