using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace StudentTransferAPI
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class TransferProcessor
    {
        #region Processor Management
        private static List<TransferProcessor> _processors = new List<TransferProcessor>();
        /// <summary>
        /// 
        /// </summary>
        public static IList<TransferProcessor> Processors { get { return _processors.AsReadOnly(); } }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="processor"></param>
        public static void Register(TransferProcessor processor)
        {
            _processors.Add(processor);
        }
        #endregion

        public TransferProcessor()
        {
            Optional = true;
            TransferInAdjustSupport = false;
        }

        /// <summary>
        /// 取得 Processor 標頭，用於顯示在畫面上。
        /// </summary>
        public abstract string Title { get; }

        /// <summary>
        /// 取得 Processor 識別資訊。
        /// </summary>
        public virtual string Identify { get { return GetType().Name; } }

        /// <summary>
        /// 取得或設定此流程是否為選擇性，選擇性的選項會顯示於畫面上供選擇。
        /// </summary>
        public bool Optional { get; set; }

        /// <summary>
        /// 學生編號。
        /// </summary>
        protected string StudentId { get; set; }

        /// <summary>
        /// 指定要處理的學生編號。
        /// </summary>
        /// <param name="studentId"></param>
        public virtual void SetStudentId(string studentId)
        {
            StudentId = studentId;
        }

        /// <summary>
        /// 產生轉出相關 Xml 資料。
        /// </summary>
        /// <returns></returns>
        public abstract XElement TransferOut();

        /// <summary>
        /// 取得是否支援轉入資料調整機制。
        /// </summary>
        public bool TransferInAdjustSupport { get; protected set; }

        /// <summary>
        /// 資料轉入前進行資料調整。
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public virtual XElement TransferInAdjust(XElement data)
        {
            return data;
        }

        /// <summary>
        /// 將資料轉入資料庫中。
        /// </summary>
        /// <param name="data"></param>
        public abstract void TransferIn(XElement data);
    }
}
