//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;

//namespace StudentTransferCoreImpl
//{
//    // 考試成績
//    class ExamScoreEntity
//    {
//        ///// <summary>
//        ///// 考試成績ID
//        ///// </summary>
//        //public string SCETakeID { get; set; }
//        /// <summary>
//        /// 試別ID
//        /// </summary>
//        public string ExamID { get; set; }
//        /// <summary>
//        /// 選課ID
//        /// </summary>
//        public string SCAttendID { get; set; }
//        /// <summary>
//        /// 試別名稱
//        /// </summary>
//        public string ExamName { get; set; }
//        /// <summary>
//        /// 課程ID
//        /// </summary>
//        public string CourseID { get; set; }
//        /// <summary>
//        /// 課程名稱
//        /// </summary>
//        public string CourseName { get; set; }
//        /// <summary>
//        ///// 分數評量
//        ///// </summary>
//        //public decimal  Score { get; set; }
//        /// <summary>
//        /// 分數評量是否可輸
//        /// </summary>
//        public bool ScoreCanInput { get; set; }

//        /// <summary>
//        /// 平時分數是否可輸
//        /// </summary>
//        public bool AssScoreCanInput { get; set; }


//        ///// <summary>
//        ///// 努力程度
//        ///// </summary>
//        //public int Effort { get; set; }
//        /// <summary>
//        /// 努力程度是否可輸
//        /// </summary>
//        public bool EffortCanInput { get; set; }
//        ///// <summary>
//        ///// 文字描述
//        ///// </summary>
//        //public string TextDescription { get; set; }
//        /// <summary>
//        /// 文字描述是否可輸
//        /// </summary>
//        public bool TextDescriptionCanInput { get; set; }

//        /// <summary>
//        /// RefAssessmentSetupID
//        /// </summary>
//        public string RefAssessmentSetupID { get; set; }
//        /// <summary>
//        /// 暫存用Index
//        /// </summary>
//        public int cacheIndex { get; set; }

//        /// <summary>
//        /// 成績類別
//        /// </summary>
//        public DAL.DALTransfer.ScoreType ScoreType { get; set; }

//        /// <summary>
//        /// 新竹課程評量成績
//        /// </summary>
//        public DAL.HC.JHSCETakeRecord HC_JHSCETakeRecord { get; set; }

//        /// <summary>
//        /// 高雄課程評量成績
//        /// </summary>
//        public DAL.KH.JHSCETakeRecord KH_JHSCETakeRecord { get; set; }

//    }
//}