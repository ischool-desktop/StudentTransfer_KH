using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FISCA.UDT;
using System.Xml;

namespace K12.Behavior.TheCadre
{
    [TableName("Behavior.TheCadre")]
    public class SchoolObject : ActiveRecord
    {
        /// <summary>
        /// 學生ID
        /// </summary>
        [Field(Field = "StudentID", Indexed = true)]
        public string StudentID { get; set; }

        /// <summary>
        /// 學年度
        /// </summary>
        [Field(Field = "SchoolYear", Indexed = false)]
        public string SchoolYear { get; set; }

        /// <summary>
        /// 學期
        /// </summary>
        [Field(Field = "Semester", Indexed = false)]
        public string Semester { get; set; }

        /// <summary>
        /// 幹部類別(學校幹部,班級幹部.社團幹部,其他)
        /// </summary>
        [Field(Field = "ReferenceType", Indexed = false)]
        public string ReferenceType { get; set; }

        /// <summary>
        /// 幹部參考(空字串為學校,班級ID,課程ID)
        /// </summary>
        [Field(Field = "ReferenceID", Indexed = false)]
        public string ReferenceID { get; set; }

        /// <summary>
        /// 幹部名稱
        /// </summary>
        [Field(Field = "CadreName", Indexed = false)]
        public string CadreName { get; set; }

        /// <summary>
        /// 註解
        /// </summary>
        [Field(Field = "Text", Indexed = false)]
        public string Text { get; set; }
    }
}
