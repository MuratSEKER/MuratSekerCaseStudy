using System;
using System.Collections.Generic;
using System.Text;

namespace CaseStudyServices
{
    public interface IFileWriter
    {
        void WriteFile(object content, string target);
    }
}
