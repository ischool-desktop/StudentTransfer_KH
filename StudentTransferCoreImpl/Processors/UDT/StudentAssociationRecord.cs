using FISCA.UDT;

namespace StudentTransferCoreImpl
{
    [TableName("JHSchool.Association.UDT")]
    public class StudentAssociationRecord : ActiveRecord
    {
        //Key ID
        /// <summary>
        /// ID
        /// </summary>
        [Field(Field = "StudentID", Indexed = true)]
        public string StudentID { get; set; }

        /// <summary>
        /// Key 學年度
        /// </summary>
        [Field(Field = "SchoolYear", Indexed = false)]
        public string SchoolYear { get; set; }

        /// <summary>
        /// Key 學期
        /// </summary>
        [Field(Field = "Semester", Indexed = false)]
        public string Semester { get; set; }

        /// <summary>
        /// 課程成績相關資訊
        /// </summary>
        [Field(Field = "Scores", Indexed = false)]
        public string Scores { get; set; }

        ///// <summary>
        ///// 成績
        ///// </summary>
        //[Field(Field = "Score", Indexed = false)]
        //public string Score { get; set; }

        ///// <summary>
        ///// 努力程度
        ///// </summary>
        //[Field(Field = "Effort", Indexed = false)]
        //public string Effort { get; set; }

        ///// <summary>
        ///// 文字描述
        ///// </summary>
        //[Field(Field = "Text", Indexed = false)]
        //public string Text { get; set; }
    }
}
