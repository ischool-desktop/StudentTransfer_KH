using FISCA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StudentTransferAPI
{
    public interface IStudentTransferStudentBriefAPI
    {
        WizardForm CreateWizardForm(ArgDictionary args);
    }
}
