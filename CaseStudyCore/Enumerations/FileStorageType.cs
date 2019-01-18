using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace CaseStudyCore.Enumerations
{
    public enum FileStorageType
    {
        [Description(".json")]
        Json=1,
        [Description(".xml")]
        XML,
        [Description(".xlsx")]
        Excel
    }
}
