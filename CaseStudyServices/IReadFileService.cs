using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CaseStudyServices
{
    public interface IReadFileService
    {
        IList ReadFile(string path, bool hasHeaders = true);
    }
}
