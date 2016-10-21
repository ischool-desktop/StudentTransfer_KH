//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Drawing;
//using System.Windows.Forms;
//using K12.Data;
//using StudentTransferCoreImpl.TransferIn;

//namespace StudentTransferCoreImpl
//{
//    public partial class AddTransStudCourseScore : FISCA.Presentation.Controls.BaseForm
//    {
//        private StudentRecord studRec;
//        private List<ExamScoreEntity> ExamScoreEntityList;

//        private List<ExamScoreEntity> _CheckExamScoreEntityList;
//        private string DefaultExamName = "";
//        private bool checkDGErrorText = false;
//        // 努力程度對照表
//        private Dictionary<decimal, int> EffortScoreDic;
//        private List<decimal> EffortScoreList;
//        int SchoolYear = K12.Data.Int.Parse(K12.Data.School.DefaultSchoolYear);
//        int Semester = K12.Data.Int.Parse(K12.Data.School.DefaultSemester);
//        private DGValueManager dgValueManager;
//        //JHSchool.PermRecLogProcess prlp;
//        private BackgroundWorker _BGWorker;


//        private DALTransfer.ScoreType _ScoreType;

//        public AddTransStudCourseScore(StudentRecord studentRec)
//        {
//            InitializeComponent();
//            if (JHSchool.Permrec.Program.ModuleType == JHSchool.Permrec.Program.ModuleFlag.NULL)
//                return;

//            //if (JHSchool.Permrec.Program.ModuleType == JHSchool.Permrec.Program.ModuleFlag.HsinChu)
            
//            // 預設用新竹
//                _ScoreType = DAL.DALTransfer.ScoreType.HsinChu;

//            if (JHSchool.Permrec.Program.ModuleType == JHSchool.Permrec.Program.ModuleFlag.KaoHsiung)
//                _ScoreType = DAL.DALTransfer.ScoreType.KaoHsiung;

//            prlp = new JHSchool.PermRecLogProcess();
            
//            studRec = studentRec;
//            dgValueManager = new DGValueManager();
//            ExamScoreEntityList = new List<JHPermrec.UpdateRecord.DAL.ExamScoreEntity>();
//            _CheckExamScoreEntityList = new List<JHPermrec.UpdateRecord.DAL.ExamScoreEntity>();
//            EffortScoreDic = new Dictionary<decimal, int>();
//            EffortScoreList = new List<decimal>();

//            _BGWorker = new BackgroundWorker();
//            _BGWorker.DoWork += new DoWorkEventHandler(_BGWorker_DoWork);
//            _BGWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(_BGWorker_RunWorkerCompleted);
            

//            AddTransBackgroundManager.AddTransStudCourseScoreObj = this;
//        }

//        void _BGWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
//        {
//            LoadExamNameToForm();
//            lblMsg.Text = "";
//            cboExam.Enabled = true;
//            btnSave.Enabled = true;
//        }

//        void _BGWorker_DoWork(object sender, DoWorkEventArgs e)
//        {
//            GetStudCourseScore();
//            GetEffortScore();            
//        }

//        // 取得努力程度對照
//        private void GetEffortScore()
//        {
//            EffortScoreDic.Clear();
//            EffortScoreList.Clear();
//            EffortScoreDic = DAL.DALTransfer.getEffortScore();
//            foreach (decimal score in EffortScoreDic.Keys)
//                EffortScoreList.Add(score);
//            EffortScoreList.Sort();
//        }

//        // 讀取學生課程成績
//        private void GetStudCourseScore()
//        {
//            // 檢查 SCTakeID NULL
//            _CheckExamScoreEntityList = DAL.DALTransfer.GetStudExamScore(studRec.ID, SchoolYear, Semester, _ScoreType);
//            List<DAL.ExamScoreEntity> nullData = new List<JHPermrec.UpdateRecord.DAL.ExamScoreEntity>();
                        
//            foreach (DAL.ExamScoreEntity ese in _CheckExamScoreEntityList)
//            {
//                if (ese.HC_JHSCETakeRecord != null)
//                    if(string.IsNullOrEmpty(ese.HC_JHSCETakeRecord.SCTakeID ))
//                        nullData.Add(ese);

//                if (ese.KH_JHSCETakeRecord != null)
//                    if(string.IsNullOrEmpty(ese.KH_JHSCETakeRecord.SCTakeID ))
//                        nullData.Add(ese);

//            }

//            if (nullData.Count > 0)
//                DAL.DALTransfer.AddNullSCTakeRecord(nullData);


//            ExamScoreEntityList = DAL.DALTransfer.GetStudExamScore(studRec.ID, SchoolYear, Semester,_ScoreType);
//        }

//        private void checkDGScoreErrorText()
//        {
//            checkDGErrorText = false;
//            // 檢查畫面分數是否有 Errro!
//            foreach (DataGridViewRow drv in dgScore.Rows)
//            {
//                if (drv.IsNewRow)
//                    continue;
//                if (drv.Cells[colScore.Index].ErrorText.Length > 0 || drv.Cells[colEffort.Index].ErrorText.Length > 0)
//                {
//                    checkDGErrorText = true;
//                    break;
//                }

//            }
//            if (checkDGErrorText == true)
//            {
//                MessageBox.Show("分數評量或努力程度資料驗證有錯誤，請檢查畫面上資料.");
//                return;
//            }        
//        }

//        // 回寫學生課程成績
//        private void SetStudCourseScore()
//        {
//            //SaveExamScoreExtityList = new List<JHPermrec.UpdateRecord.DAL.ExamScoreEntity>();
//            foreach (DataGridViewRow drv in dgScore.Rows)
//            {
//                decimal score  , assScore;
//                int effort=0;
//                if (drv.IsNewRow)
//                    continue;
//                string SCTakeID="";
//                if (drv.Cells[colSCETakeID.Index].Value != null)
//                    SCTakeID = drv.Cells[colSCETakeID.Index].Value+"";

//                foreach (DAL.ExamScoreEntity ese in ExamScoreEntityList)
//                {
//                    // 新竹
//                    if (_ScoreType == JHPermrec.UpdateRecord.DAL.DALTransfer.ScoreType.HsinChu)
//                    {
//                        if (SCTakeID == ese.HC_JHSCETakeRecord.SCTakeID)
//                        {
//                            if (drv.Cells[colScore.Index].Value != null)
//                                if (decimal.TryParse(drv.Cells[colScore.Index].Value.ToString(), out score))
//                                    ese.HC_JHSCETakeRecord.Score = score;

//                            if(drv.Cells[colAssignmentScore.Index].Value!=null )
//                                if(decimal.TryParse(drv.Cells[colAssignmentScore.Index].Value.ToString (),out assScore ))
//                                    ese.HC_JHSCETakeRecord.AssignmentScore =assScore;

//                            if (drv.Cells[colTextDescription.Index].Value != null)
//                                ese.HC_JHSCETakeRecord.Text = drv.Cells[colTextDescription.Index].Value + "";
//                        }
//                    }

//                    // 高雄
//                    if (_ScoreType == JHPermrec.UpdateRecord.DAL.DALTransfer.ScoreType.KaoHsiung)
//                    {
//                        if (SCTakeID == ese.KH_JHSCETakeRecord.SCTakeID)
//                        {
//                            if (drv.Cells[colScore.Index].Value != null)
//                                if (decimal.TryParse(drv.Cells[colScore.Index].Value.ToString(), out score))
//                                    ese.KH_JHSCETakeRecord.Score = score;
//                            if (drv.Cells[colEffort.Index].Value != null)
//                                if (int.TryParse(drv.Cells[colEffort.Index].Value.ToString(), out effort))
//                                    ese.KH_JHSCETakeRecord.Effort = effort;

//                            if (drv.Cells[colTextDescription.Index].Value != null)
//                                ese.KH_JHSCETakeRecord.Text = drv.Cells[colTextDescription.Index].Value + "";
//                        }
//                    }
//                }
//           }

//            // Save log
//            SaveLog();
//            DAL.DALTransfer.SetStudExamScore(ExamScoreEntityList);
//            // 回寫 cache
//            WriteDgScoreToExamScoreEntityListCache();
//        }
        
//        // 載入試別到畫面
//        private void LoadExamNameToForm()
//        {
//            List<string> exNameList = new List<string>();
//            cboExam.Items.Clear();
//            foreach (DAL.ExamScoreEntity ese in ExamScoreEntityList)
//                if (!exNameList.Contains(ese.ExamName))
//                    exNameList.Add(ese.ExamName);
//            exNameList.Sort();

//            cboExam.Items.AddRange(exNameList.ToArray());
            
//            cboExam.DropDownStyle = ComboBoxStyle.DropDownList;
//        }

//        private void WriteDgScoreToExamScoreEntityListCache()
//        {
//            foreach (DataGridViewRow drv in dgScore.Rows)
//            {
//                if (drv.IsNewRow)
//                    continue;
//                int index;
//                int.TryParse(drv.Cells[cacheIndex.Index].Value.ToString (),out index );

//                foreach (DAL.ExamScoreEntity ese in ExamScoreEntityList )
//                {
//                    if (index ==ese.cacheIndex )
//                    {

//                        if (ese.ScoreType == JHPermrec.UpdateRecord.DAL.DALTransfer.ScoreType.HsinChu)
//                        {
//                            decimal score;                            
//                            if (drv.Cells[colScore.Index].Value != null)
//                                if (decimal.TryParse(drv.Cells[colScore.Index].Value.ToString(), out score))
//                                    ese.HC_JHSCETakeRecord.Score = score;
                            
//                            if (drv.Cells[colTextDescription.Index].Value != null)
//                                ese.HC_JHSCETakeRecord.Text = drv.Cells[colTextDescription.Index].Value + "";                        
                        
//                        }

//                        if (ese.ScoreType == JHPermrec.UpdateRecord.DAL.DALTransfer.ScoreType.KaoHsiung)
//                        {
//                            decimal score;
//                            int Effort;
//                            if (drv.Cells[colScore.Index].Value != null)
//                                if (decimal.TryParse(drv.Cells[colScore.Index].Value.ToString(), out score))
//                                    ese.KH_JHSCETakeRecord.Score = score;
//                            if (drv.Cells[colEffort.Index].Value != null)
//                                if (int.TryParse(drv.Cells[colEffort.Index].Value.ToString(), out Effort))
//                                    ese.KH_JHSCETakeRecord.Effort = Effort;


//                            if (drv.Cells[colTextDescription.Index].Value != null)
//                                ese.KH_JHSCETakeRecord.Text  = drv.Cells[colTextDescription.Index].Value+"";
                            
//                        }
//                    }
//                }
//            }
        
//        }

//        // 載入試別成績到畫面
//        private void LoadExamScoreToForm(string ExamName)
//        {            
//            dgScore.Rows.Clear();
//            dgValueManager.Clear();
//            DefaultExamName = cboExam.Text;
//            // 載入 Log
//            LoadLog();
//            foreach (DAL.ExamScoreEntity ese in ExamScoreEntityList)
//            {
//                if (ese.ExamName == ExamName)
//                {
//                    int rowIdx = dgScore.Rows.Add();

//                    if (ese.ScoreType == JHPermrec.UpdateRecord.DAL.DALTransfer.ScoreType.HsinChu)
//                    {                 
//                            dgScore.Rows[rowIdx].Cells[colSCETakeID.Index].Value = ese.HC_JHSCETakeRecord.SCTakeID + "";
                        

//                        dgScore.Rows[rowIdx].Cells[colCourseName.Index].Value = "" + ese.CourseName;

//                        // 平時
//                        if (ese.HC_JHSCETakeRecord.AssignmentScore.HasValue)
//                        {
//                            dgScore.Rows[rowIdx].Cells[colAssignmentScore.Index].Value = "" + ese.HC_JHSCETakeRecord.AssignmentScore;
                            
//                            dgValueManager.AddCellValue(rowIdx, colAssignmentScore.Index, ese.HC_JHSCETakeRecord.AssignmentScore.Value + "");
//                        }

//                        if (ese.AssScoreCanInput == false)
//                        {
//                            dgScore.Rows[rowIdx].Cells[colAssignmentScore.Index].ReadOnly = true;
//                            dgScore.Rows[rowIdx].Cells[colAssignmentScore.Index].Style.BackColor = Color.Yellow;
//                        }

//                        if (ese.HC_JHSCETakeRecord.Score.HasValue)
//                        {
//                            dgScore.Rows[rowIdx].Cells[colScore.Index].Value = "" + ese.HC_JHSCETakeRecord.Score.Value;

//                            dgValueManager.AddCellValue(rowIdx, colScore.Index, ese.HC_JHSCETakeRecord.Score.Value+"");
//                        }

//                        if (ese.ScoreCanInput == false)
//                        {
//                            dgScore.Rows[rowIdx].Cells[colScore.Index].ReadOnly = true;
//                            dgScore.Rows[rowIdx].Cells[colScore.Index].Style.BackColor = Color.Yellow;
//                        }

//                        dgScore.Rows[rowIdx].Cells[colTextDescription.Index].Value = ese.HC_JHSCETakeRecord.Text;
                        
//                        dgValueManager.AddCellValue(rowIdx, colTextDescription.Index, ese.HC_JHSCETakeRecord.Text);

//                        if (ese.TextDescriptionCanInput == false)
//                        {
//                            dgScore.Rows[rowIdx].Cells[colTextDescription.Index].ReadOnly = true;
//                            dgScore.Rows[rowIdx].Cells[colTextDescription.Index].Style.BackColor = Color.Yellow;
//                        }

//                        dgScore.Rows[rowIdx].Cells[cacheIndex.Index].Value = "" + ese.cacheIndex;
//                    }

//                    if (ese.ScoreType == JHPermrec.UpdateRecord.DAL.DALTransfer.ScoreType.KaoHsiung)
//                    {
//                        dgScore.Rows[rowIdx].Cells[colSCETakeID.Index].Value = ese.KH_JHSCETakeRecord.SCTakeID + "";
                        

//                        dgScore.Rows[rowIdx].Cells[colCourseName.Index].Value = "" + ese.CourseName;

//                        if (ese.KH_JHSCETakeRecord.Score.HasValue)
//                        {

//                            dgScore.Rows[rowIdx].Cells[colScore.Index].Value = "" + ese.KH_JHSCETakeRecord.Score.Value;
//                            dgValueManager.AddCellValue(rowIdx, colScore.Index, ese.KH_JHSCETakeRecord.Score.Value + "");

//                        }

//                        if (ese.ScoreCanInput == false)
//                        {
//                            dgScore.Rows[rowIdx].Cells[colScore.Index].ReadOnly = true;
//                            dgScore.Rows[rowIdx].Cells[colScore.Index].Style.BackColor = Color.Yellow;
//                        }


//                        if (ese.KH_JHSCETakeRecord.Effort.HasValue)
//                        {
//                            dgScore.Rows[rowIdx].Cells[colEffort.Index].Value = "" + ese.KH_JHSCETakeRecord.Effort.Value;
//                            dgValueManager.AddCellValue(rowIdx, colEffort.Index, ese.KH_JHSCETakeRecord.Effort.Value + "");
//                        }

//                        if (ese.EffortCanInput == false)
//                        {
//                            dgScore.Rows[rowIdx].Cells[colEffort.Index].ReadOnly = true;
//                            dgScore.Rows[rowIdx].Cells[colEffort.Index].Style.BackColor = Color.Yellow;
//                        }

//                        dgScore.Rows[rowIdx].Cells[colTextDescription.Index].Value = ese.KH_JHSCETakeRecord.Text;
//                        dgValueManager.AddCellValue(rowIdx, colTextDescription.Index, ese.KH_JHSCETakeRecord.Text);

//                        if (ese.TextDescriptionCanInput == false)
//                        {
//                            dgScore.Rows[rowIdx].Cells[colTextDescription.Index].ReadOnly = true;
//                            dgScore.Rows[rowIdx].Cells[colTextDescription.Index].Style.BackColor = Color.Yellow;
//                        }

//                    }


//                    dgScore.Rows[rowIdx].Cells[cacheIndex.Index].Value = "" + ese.cacheIndex;  

//                }
//            }
//        }

//        private void btnSave_Click(object sender, EventArgs e)
//        {
//            if (dgScore.Rows.Count < 1)
//                return;
//            checkDGScoreErrorText();
//            SetStudCourseScore();

//            if(checkDGErrorText ==false )
//                this.Close();
//        }

//        private void cboExam_SelectedIndexChanged(object sender, EventArgs e)
//        {
//            checkDGScoreErrorText();
            
//            if (dgValueManager.IsDirty())
//            {
//                if (MessageBox.Show("資料已修改，請問是否儲存?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
//                {
//                    // 儲存資料
//                    SetStudCourseScore();
                    
//                    GetStudCourseScore();                    
//                }
            
//            }               

//            LoadExamScoreToForm(cboExam.Text);
//        }

//        private void dgScore_CellEndEdit(object sender, DataGridViewCellEventArgs e)
//        {
//            if (dgScore.CurrentCell.Value != null)
//                dgValueManager.SetCellValue(dgScore.CurrentCell.RowIndex, dgScore.CurrentCell.ColumnIndex, dgScore.CurrentCell.Value.ToString());

//            // 轉換分數努力程度與驗證
//            if (dgScore.CurrentCell.ColumnIndex == colScore.Index)
//            {
//                int Effort = 0;
//                decimal currentCellValue = 0;
//                bool IsNumberCellValue=false ;
//                if(dgScore.Rows[dgScore.CurrentCell.RowIndex].Cells[dgScore.CurrentCell.ColumnIndex].Value!=null)
//                {                    
                    
//                   IsNumberCellValue= decimal.TryParse(dgScore.Rows[dgScore.CurrentCell.RowIndex].Cells[dgScore.CurrentCell.ColumnIndex].Value.ToString(), out currentCellValue);
//                }

//                foreach (decimal score in EffortScoreList)
//                {
//                    if (currentCellValue >= score)
//                    {
//                        Effort = EffortScoreDic[score];                        
//                    }                
//                }

//                if (IsNumberCellValue)
//                    dgScore.Rows[dgScore.CurrentCell.RowIndex].Cells[dgScore.CurrentCell.ColumnIndex].ErrorText = "";
//                else
//                    dgScore.Rows[dgScore.CurrentCell.RowIndex].Cells[dgScore.CurrentCell.ColumnIndex].ErrorText = "非數字資料!";                
                                   

//                dgScore.Rows[dgScore.CurrentCell.RowIndex].Cells[dgScore.CurrentCell.ColumnIndex+1].Value = ""+Effort;
//            }

//            // 努力程度驗證
//            if (dgScore.CurrentCell.ColumnIndex == colEffort.Index)
//            {
//                int Effort = 0;
//                bool IsIntegerCellValue=false ;
//                if (dgScore.Rows[dgScore.CurrentCell.RowIndex].Cells[dgScore.CurrentCell.ColumnIndex].Value != null)
//                {
//                    IsIntegerCellValue = int.TryParse(dgScore.Rows[dgScore.CurrentCell.RowIndex].Cells[dgScore.CurrentCell.ColumnIndex].Value.ToString(), out Effort);
//                }

//                if(IsIntegerCellValue)
//                    dgScore.Rows[dgScore.CurrentCell.RowIndex].Cells[dgScore.CurrentCell.ColumnIndex].ErrorText = "";
//                else
//                    dgScore.Rows[dgScore.CurrentCell.RowIndex].Cells[dgScore.CurrentCell.ColumnIndex].ErrorText = "非整數!";
//            }
//        }

//        private void AddTransStudCourseScore_Load(object sender, EventArgs e)
//        {

//            if (studRec.Class != null)
//                lblStudMsg.Text = "班級:" + studRec.Class.Name + ", 座號:" + studRec.SeatNo + ", 姓名:" + studRec.Name + ", 學號:" + studRec.StudentNumber;
//            else
//                lblStudMsg.Text = "未設定班級";
//            lblSchoolYearSemester.Text = SchoolYear + " 學年度 第 " + Semester + " 學期";
//            lblMsg.Text = "";

//            if (_ScoreType == JHPermrec.UpdateRecord.DAL.DALTransfer.ScoreType.HsinChu)
//            {
//                dgScore.Columns[colEffort.Index].Visible = false;
//                dgScore.Columns[colAssignmentScore.Index].Visible = true;
//                dgScore.Columns[colScore.Index].HeaderText = "定期分數";
//                dgScore.Columns[colAssignmentScore.Index].HeaderText = "平時分數";
//            }
//            else
//            {
//                dgScore.Columns[colAssignmentScore.Index].Visible = false;
//                dgScore.Columns[colEffort.Index].Visible = true;
//            }
//            lblMsg.Text = "資料讀取中請稍候..";
//            cboExam.Enabled = false;
//            btnSave.Enabled = false;
//            _BGWorker.RunWorkerAsync();
//        }


//        // 載入 Log
//        private void LoadLog()
//        {
//            foreach (DAL.ExamScoreEntity ese in ExamScoreEntityList)
//            {
//                string Key = ese.ExamName + "_" + ese.CourseName + "_";
//                if(_ScoreType == JHPermrec.UpdateRecord.DAL.DALTransfer.ScoreType.HsinChu )
//                {
//                    if(ese.HC_JHSCETakeRecord !=null )
//                    {
//                        if (ese.HC_JHSCETakeRecord.Score.HasValue)
//                            prlp.SetBeforeSaveText(Key + "定期分數", ese.HC_JHSCETakeRecord.Score.Value + "");

//                        if (ese.HC_JHSCETakeRecord.AssignmentScore.HasValue)
//                            prlp.SetBeforeSaveText(Key + "平時分數", ese.HC_JHSCETakeRecord.AssignmentScore.Value + "");

//                        prlp.SetBeforeSaveText(Key + "文字描述", ese.HC_JHSCETakeRecord.Text);
//                    }
//                }

//                if (_ScoreType == JHPermrec.UpdateRecord.DAL.DALTransfer.ScoreType.KaoHsiung)
//                {
//                    if (ese.KH_JHSCETakeRecord != null)
//                    {
//                        if (ese.KH_JHSCETakeRecord.Score.HasValue)
//                            prlp.SetBeforeSaveText(Key + "分數評量", ese.KH_JHSCETakeRecord.Score.Value + "");

//                        if (ese.KH_JHSCETakeRecord.Effort.HasValue)
//                            prlp.SetBeforeSaveText(Key + "努力程度", ese.KH_JHSCETakeRecord.Effort.Value + "");

//                        prlp.SetBeforeSaveText(Key + "文字描述", ese.KH_JHSCETakeRecord.Text);
//                    }
//                }
//            }
//        }

//        // 儲存 log
//        private void SaveLog()
//        {
//            foreach (DAL.ExamScoreEntity ese in ExamScoreEntityList)
//            {
//                string Key = ese.ExamName + "_" + ese.CourseName + "_";
//                if (_ScoreType == JHPermrec.UpdateRecord.DAL.DALTransfer.ScoreType.HsinChu)
//                {
//                    if (ese.HC_JHSCETakeRecord != null)
//                    {
//                        if (ese.HC_JHSCETakeRecord.Score.HasValue)
//                            prlp.SetAfterSaveText(Key + "定期分數", ese.HC_JHSCETakeRecord.Score.Value + "");

//                        if (ese.HC_JHSCETakeRecord.AssignmentScore.HasValue)
//                            prlp.SetAfterSaveText(Key + "平時分數", ese.HC_JHSCETakeRecord.AssignmentScore.Value + "");

//                        prlp.SetAfterSaveText(Key + "文字描述", ese.HC_JHSCETakeRecord.Text);
//                    }
//                }

//                if (_ScoreType == JHPermrec.UpdateRecord.DAL.DALTransfer.ScoreType.KaoHsiung)
//                {
//                    if (ese.KH_JHSCETakeRecord != null)
//                    {
//                        if (ese.KH_JHSCETakeRecord.Score.HasValue)
//                            prlp.SetAfterSaveText(Key + "分數評量", ese.KH_JHSCETakeRecord.Score.Value + "");

//                        if (ese.KH_JHSCETakeRecord.Effort.HasValue)
//                            prlp.SetAfterSaveText(Key + "努力程度", ese.KH_JHSCETakeRecord.Effort.Value + "");

//                        prlp.SetAfterSaveText(Key + "文字描述", ese.KH_JHSCETakeRecord.Text);
//                    }
//                }                
//            }
//            prlp.SetActionBy("學籍", "學生學期課程成績輸入");
//            prlp.SetAction("修改學生學期課程成績," + lblStudMsg.Text);
//            prlp.SaveLog("", "", "student", studRec.ID);
//        }
//    }
//}
