using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FISCA.UDT;

namespace StudentTransferCoreImpl
{
    /// <summary>
    /// 高雄自動編班-高關懷學生
    /// </summary>
    [TableName("kh.automatic.placement.high.concern")]
    public class UDT_HighConcern:ActiveRecord
    {
        ///<summary>
        /// 學生系統編號
        ///</summary>
        [Field(Field = "ref_student_id", Indexed = false)]
        public string RefStudentID { get; set; }

        ///<summary>
        /// 班級
        ///</summary>
        [Field(Field = "class_name", Indexed = false)]
        public string ClassName { get; set; }

        ///<summary>
        /// 座號
        ///</summary>
        [Field(Field = "seat_no", Indexed = false)]
        public string SeatNo { get; set; }

        ///<summary>
        /// 學號
        ///</summary>
        [Field(Field = "student_number", Indexed = false)]
        public string StudentNumber { get; set; }

        ///<summary>
        /// 高關懷特殊身分註記
        ///</summary>
        [Field(Field = "high_concern", Indexed = false)]
        public bool HighConcern { get; set; }

        ///<summary>
        /// 減免人數
        ///</summary>
        [Field(Field = "number_reduce", Indexed = false)]
        public int NumberReduce { get; set; }

        ///<summary>
        /// 文號
        ///</summary>
        [Field(Field = "doc_no", Indexed = false)]
        public string DocNo { get; set; }

        ///<summary>
        /// 相關證明文件網址
        ///</summary>
        [Field(Field = "e_doc", Indexed = false)]
        public string EDoc { get; set; }

    }
}
