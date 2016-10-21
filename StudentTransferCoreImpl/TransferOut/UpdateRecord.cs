using System;
using System.Collections.Generic;
using System.Windows.Forms;
using FISCA;
using K12.Data;
using K12.Data.Configuration;
using StudentTransferAPI;

namespace StudentTransferCoreImpl.TransferOut
{
    //轉出異動代碼：4
    /// <summary>
    /// 
    /// </summary>
    public partial class UpdateRecord : WizardForm
    {
        private ConfigData cd;          //異動原因的組態物件
        private string updateConfigKey = "UpdateReasons";   //紀錄異動原因清單的組態值的Key
        private string transferOutConfigKey = "TransferOutReason";    //紀錄轉入原因清單的組態值的Key
        private StudentRecord studentRecord = null;
        private AddressRecord addressRecord = null;

        public UpdateRecord(ArgDictionary args)
            : base(args)
        {
            InitializeComponent();
        }

        private void UpdateRecord_Load(object sender, EventArgs e)
        {
            try
            {
                intSchoolYear.Text = School.DefaultSchoolYear;
                intSemester.Text = School.DefaultSemester;

                InitUpdateDescriptionItems();

                string stuid = Arguments[Consts.StudentID] + "";

                ListStudentRecord(stuid);

                ListADUpdateRecord(stuid);
            }
            catch (Exception ex)
            {
                RTOut.WriteError(ex);
            }
        }

        /// <summary>
        /// 列出學生基本資料
        /// </summary>
        /// <param name="stuid"></param>
        private void ListStudentRecord(string stuid)
        {
            studentRecord = Student.SelectByID(stuid);
            addressRecord = Address.SelectByStudentID(stuid);           

            //姓名
            txtName.Text = studentRecord.Name;
            //班級
            txtClass.Text = studentRecord.Class != null ? studentRecord.Class.Name : string.Empty;
            //性別
            cmbGender.Text = studentRecord.Gender;
            //學號
            txtStudentNumber.Text = studentRecord.StudentNumber;
            //座號
            txtSeatNo.Text = K12.Data.Int.GetString(studentRecord.SeatNo);
            //生日
            if (studentRecord.Birthday.HasValue)
                dateBirthDate.Value = studentRecord.Birthday.Value;
            //身分證號
            txtIDNumber.Text = studentRecord.IDNumber;
            //地址
            txtAddress.Text = addressRecord.PermanentAddress;
        }

        /// <summary>
        /// 列出所有已經有核準文號的異動記錄
        /// </summary>
        /// <param name="stuid"></param>
        private void ListADUpdateRecord(string stuid)
        {
            //將學生目前所有已經有核準文號的異動跳出來選。
            List<UpdateRecordRecord> records = K12.Data.UpdateRecord.SelectByStudentID(stuid);
            foreach (UpdateRecordRecord record in new List<UpdateRecordRecord>(records))
            {
                if (string.IsNullOrWhiteSpace(record.ADDate) || string.IsNullOrWhiteSpace(record.ADNumber))
                    records.Remove(record);
            }

            records.Sort((x, y) =>
            {
                DateTime X, Y;
                DateTime.TryParse(x.UpdateDate, out X);
                DateTime.TryParse(y.UpdateDate, out Y);

                return Y.CompareTo(X);
            });

            foreach (UpdateRecordRecord each in records)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(dgvLastUpdate, each.UpdateDate, GetUpdateDescription(each), each.ADNumber);
                row.Tag = each;
                dgvLastUpdate.Rows.Add(row);
            }

            if (dgvLastUpdate.Rows.Count > 0)
                dgvLastUpdate.Rows[0].Selected = true; //選擇第一筆。
        }

        private string GetUpdateDescription(UpdateRecordRecord each)
        {
            if (string.IsNullOrWhiteSpace(each.UpdateDescription))
            {
                switch (each.UpdateCode)
                {
                    case "1":
                        return "新生";
                    case "2":
                        return "畢業";
                    case "3":
                        return "轉入";
                    case "4":
                        return "轉出";
                    case "5":
                        return "休學";
                    case "6":
                        return "復學";
                    case "7":
                        return "中輟";
                    case "8":
                        return "續讀";
                    case "9":
                        return "更正學籍";
                    default:
                        return "";
                }
            }
            else
                return each.UpdateDescription;
        }

        protected override ContinueDirection? OnNextButtonClick()
        {
            int SeatNo;

            if (!string.IsNullOrEmpty(txtSeatNo.Text) &&  !int.TryParse(txtSeatNo.Text, out SeatNo))
            {
                MessageBox.Show("座號必須為數字！");
                return null;
            }

            // 檢查異動日期輸入
            if (dtUpdateDate.IsEmpty)
            {
                MessageBox.Show("異動日期必填！");
                return null;
            }

            try
            {
                string stuid = Arguments[Consts.StudentID] + "";

                UpdateRecordRecord r = new UpdateRecordRecord();

                r.StudentID = studentRecord.ID;
                //姓名
                r.StudentName = studentRecord.Name;
                //性別
                r.Gender = ""+cmbGender.SelectedItem;
                //生日
                r.Birthdate = dateBirthDate.Value.ToString("yyyy/MM/dd");
                //年級
                r.GradeYear = studentRecord.Class != null ? K12.Data.Int.GetString(studentRecord.Class.GradeYear) : string.Empty;
                //身分證號
                r.IDNumber = txtIDNumber.Text;
                //姓名
                r.StudentName = txtName.Text;
                //學號
                r.StudentNumber = txtStudentNumber.Text;                
                r.UpdateDate = dtUpdateDate.Text;
                r.UpdateDescription = cboUpdateDescription.Text;
                r.Comment = txtComment.Text;
                r.UpdateCode = "4";
                r.SchoolYear = intSchoolYear.Value;
                r.Semester = intSemester.Value;
                r.Attributes["ImportExportSchool"] = txtImportSchool.Text;
                //座號
                r.Attributes["SeatNo"] = txtSeatNo.Text;
                //班級
                r.Attributes["OriginClassName"] = txtClass.Text;
                //地址
                r.Attributes["OriginAddress"] = txtAddress.Text;

                if (dgvLastUpdate.SelectedRows.Count > 0)
                {
                    UpdateRecordRecord previousr = dgvLastUpdate.SelectedRows[0].Tag as UpdateRecordRecord;
                    r.LastADDate = previousr.ADDate;
                    r.LastADNumber = previousr.ADNumber;
                }

                Arguments[Consts.UpdateRecordRecord] = r;

                return ContinueDirection.Next;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        private void InitUpdateDescriptionItems()
        {
            //將轉入紀錄清單的key輸入至list cd中
            cd = School.Configuration[updateConfigKey];
            if (!cd.Contains(transferOutConfigKey))
            {
                cd[transferOutConfigKey] = "遷居;出國;其他";
                cd.Save();
            }
            string[] reasons = cd[transferOutConfigKey].Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            List<string> reasonList = new List<string>(reasons);
            foreach (string reason in reasons)
            {
                this.cboUpdateDescription.Items.Add(reason);
            }
            foreach (string defaultreason in new string[] { "遷居", "出國", "其他" })
            {
                if (!reasonList.Contains(defaultreason))
                    this.cboUpdateDescription.Items.Add(defaultreason);
            }
        }

        private void UpdateRecord_FormClosed(object sender, FormClosedEventArgs e)
        {
            //判斷是否輸入任何數值
            if (!string.IsNullOrEmpty(cboUpdateDescription.Text))
            {
                string reasonlist = cd[transferOutConfigKey];

                string newReasonList = "";

                //判斷是否有寫入新的轉出原因
                if (reasonlist.IndexOf(cboUpdateDescription.Text + ";") == -1)
                {
                    string[] reasons = reasonlist.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

                    for (int i = 0; i < reasons.Length; i++)
                    {
                        newReasonList += reasons[i] + ";";
                    }
                    newReasonList += cboUpdateDescription.Text + ";";
                    //newReasonList += reasons[reasons.Length];
                }
                //把新的原因自串寫回Config裡
                cd[transferOutConfigKey] = newReasonList;
                cd.Save();
            }
        }

        private void btnGetSchoolList_Click(object sender, EventArgs e)
        {
            GetJHSchoolNames form = new GetJHSchoolNames();
            if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                txtImportSchool.Text = form.SchoolName;
        }

        public override ContinueDirection ShowWizardDialog()
        {
            if (Arguments.ContainsKey(Consts.UpdateRecordAction))
                return (ContinueDirection)Arguments[Consts.UpdateRecordAction];
            else
                return base.ShowWizardDialog();
        }
    }
}
