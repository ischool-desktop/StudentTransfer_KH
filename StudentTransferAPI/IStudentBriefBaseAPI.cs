using FISCA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StudentTransferAPI
{
    /// <summary>
    /// 線上轉學-學生基本資料輸入
    /// </summary>
    public interface IStudentBriefBaseAPI
    {
        WizardForm CreateForm(ArgDictionary ars);
    }
}
