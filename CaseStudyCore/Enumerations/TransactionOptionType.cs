using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace CaseStudyCore.Enumerations
{
    public enum TransactionOptionType
    {
        [Description("grouping")]
        Group =1,
        [Description("sorting")]
        Sort
    }
}
