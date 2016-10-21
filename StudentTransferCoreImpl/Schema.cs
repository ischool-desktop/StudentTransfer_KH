using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FISCA.UDT;

namespace StudentTransferCoreImpl
{
    [TableName("ST_TransferOut")]
    public class TransferOutRecord : ActiveRecord
    {
        public TransferOutRecord()
        {
            CreateTime = DateTime.Now;
        }

        /// <summary>
        /// 參考學生編號。
        /// </summary>
        [Field]
        public string RefStudentID { get; set; }

        /// <summary>
        /// 學生姓名。
        /// </summary>
        [Field]
        public string StudentName { get; set; }

        /// <summary>
        /// 轉入校的 DSA 位置。
        /// </summary>
        [Field]
        public string TransferTarget { get; set; }

        /// <summary>
        /// 轉入校名稱。
        /// </summary>
        [Field]
        public string TransferTargetTitle { get; set; }

        /// <summary>
        /// 是否允許轉入校讀取資料。
        /// </summary>
        [Field]
        public bool TransferAccept { get; set; }

        /// <summary>
        /// 資料交換代符。
        /// </summary>
        [Field]
        public string TransferToken { get; set; }

        /// <summary>
        /// 申請轉出代碼，由轉入校產生並寫入。
        /// </summary>
        [Field]
        public string AcceptToken { get; set; }

        /// <summary>
        /// 學生轉出資料。
        /// </summary>
        [Field]
        public string Content { get; set; }

        /// <summary>
        /// 轉出校聯絡資訊。
        /// </summary>
        [Field]
        public string ContractInfo { get; set; }

        /// <summary>
        /// 資料處理狀態(1:New 2:RequireAccept 3:Accept 4:Success)。
        /// </summary>
        [Field]
        public int Status { get; set; }

        /// <summary>
        /// 資料建立時間。
        /// </summary>
        [Field]
        public DateTime? CreateTime { get; set; }
    }

    [TableName("ST_TransferIn")]
    public class TransferInRecord : ActiveRecord
    {
        public TransferInRecord()
        {
            CreateTime = DateTime.Now;
        }

        /// <summary>
        /// 參考學生編號。
        /// </summary>
        [Field]
        public string RefStudentID { get; set; }

        /// <summary>
        /// 學生姓名。
        /// </summary>
        [Field]
        public string StudentName { get; set; }

        /// <summary>
        /// 轉出校的 DSA 位置。
        /// </summary>
        [Field]
        public string TransferSource { get; set; }

        /// <summary>
        /// 轉出校名稱。
        /// </summary>
        [Field]
        public string TransferSourceTitle { get; set; }

        /// <summary>
        /// 資料交換代符。
        /// </summary>
        [Field]
        public string TransferToken { get; set; }

        /// <summary>
        /// 申請轉出代碼，由轉入校產生並寫入。
        /// </summary>
        [Field]
        public string AcceptToken { get; set; }

        /// <summary>
        /// 學生轉出原始資料
        /// </summary>
        [Field]
        public string OriginContent { get; set; }

        /// <summary>
        /// 學生轉出處理後資料。
        /// </summary>
        [Field]
        public string ModifiedContent { get; set; }

        /// <summary>
        /// 轉出校聯絡資訊。
        /// </summary>
        [Field]
        public string ContractInfo { get; set; }

        /// <summary>
        /// 資料處理狀態(1:WaitAccept 2:Accepted 3:Transfered 4:Success)。
        /// </summary>
        [Field]
        public int Status { get; set; }

        /// <summary>
        /// 資料建立時間。
        /// </summary>
        [Field]
        public DateTime? CreateTime { get; set; }
    }
}
