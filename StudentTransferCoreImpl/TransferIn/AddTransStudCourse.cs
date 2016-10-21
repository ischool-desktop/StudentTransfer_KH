using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using FISCA;
using K12.Data;
using StudentTransferAPI;

namespace StudentTransferCoreImpl.TransferIn
{
    public partial class AddTransStudCourse : WizardForm
    {
        private StudentRecord  studRec;
        private ClassRecord studClassRec;
        private Dictionary<string, ClassRecord> classRecIdx;

        private List<AttendCourseEntity> studAttendCourseEntitys = new List<AttendCourseEntity>();
        int SchoolYear = K12.Data.Int.Parse(K12.Data.School.DefaultSchoolYear);
        int Semester = K12.Data.Int.Parse(K12.Data.School.DefaultSemester);

        public AddTransStudCourse(ArgDictionary args)
            : base(args)
        {
            InitializeComponent();

        }

        private void AddTransStudCourse_Load(object sender, EventArgs e)
        {
            cboSelectClass.Items.Clear();

            classRecIdx = new Dictionary<string, ClassRecord>();

            foreach (ClassRecord cr in Class.SelectAll())
            {
                if (cr != null)
                {
                    cboSelectClass.Items.Add(cr.Name);
                    if (!classRecIdx.ContainsKey(cr.Name))
                        classRecIdx.Add(cr.Name, cr);
                }
            }

            chkSaveYes.Checked = true;

            string stuid = Arguments[Consts.StudentID] + "";

            studRec = Student.SelectByID(stuid);

            if (studRec.Class != null)
            {
                lblStudMsg.Text = "班級:" + studRec.Class.Name + ", 座號:" + studRec.SeatNo + ", 姓名:" + studRec.Name + ", 學號:" + studRec.StudentNumber;
                cboSelectClass.Text = studRec.Class.Name;
                studClassRec = studRec.Class;

            }
            else
                lblStudMsg.Text = "未設定班級";

            //AddTransBackgroundManager.AddTransStudCourseObj = this;

            getCourseToForm();
        }

        private void getCourseToForm()
        {
            lstView.Items.Clear();
            getStudAttendCourses();
            int hAtndCot = 0, hNAtnCot = 0, hQAtnCot = 0;
            foreach (AttendCourseEntity ace in studAttendCourseEntitys)
            {
                ListViewItem lvi = new ListViewItem();
                lvi.SubItems[0].Text = ace.CourseID;
                lvi.SubItems.Add(ace.CourseName);
                lvi.SubItems.Add(ace.SubjectName);
                lvi.SubItems.Add(ace.Credit);
                if (ace.CousreAttendType == AttendCourseEntity.AttendType.學生修課與班級相同)
                {
                    lvi.SubItems.Add("已修");

                    foreach (ListViewItem.ListViewSubItem lvs in lvi.SubItems)
                        lvs.ForeColor = Color.Black;
                    hAtndCot++;
                }
                if (ace.CousreAttendType == AttendCourseEntity.AttendType.學生未修)
                {
                    lvi.SubItems.Add("未修");
                    foreach (ListViewItem.ListViewSubItem lvs in lvi.SubItems)
                        lvs.ForeColor = Color.Blue;
                    hNAtnCot++;
                }

                if (ace.CousreAttendType == AttendCourseEntity.AttendType.學生本身已修)
                {
                    lvi.SubItems.Add("已修非該班課程");
                    foreach (ListViewItem.ListViewSubItem lvs in lvi.SubItems)
                        lvs.ForeColor = Color.Red;
                    hQAtnCot++;
                }

                lstView.Items.Add(lvi);
            }
            lblmsg.Text = "已修課程:" + hAtndCot + ", 未修課程:" + hNAtnCot + ", 已修非該班課程:" + hQAtnCot;
            this.Text = SchoolYear + "學年度 第" + Semester + "學期 學生修課";
        
        }

        private void getStudAttendCourses()
        {            
            studAttendCourseEntitys.Clear();
            if (studRec.Class != null)
                studAttendCourseEntitys = DALTransfer.getStudAttendCourseBySchoolYearSemester(SchoolYear, Semester, studRec, studClassRec);
            else
                MessageBox.Show("沒有設定班級,無法取得修課.");
        }

        protected override ContinueDirection? OnNextButtonClick()
        {
            try
            {
                if (chkSaveYes.Checked == true)
                {
                    List<CourseRecord> courseRecs = new List<CourseRecord>();
                    foreach (AttendCourseEntity ace in studAttendCourseEntitys)
                        if (ace.CousreAttendType == AttendCourseEntity.AttendType.學生未修)
                            courseRecs.Add(ace.CourseRec);
                    // 待加入儲存            
                    if (courseRecs.Count > 0)
                    {
                        DALTransfer.SetStudentAttendCourse(studRec.ID, courseRecs);

                        string CourseName = "";

                        foreach (CourseRecord cor in courseRecs)
                            CourseName += cor.Name + ",";
                    }
                }

                //如果下次進入這個畫面，就直接跳過，因為已經加入過學生修課了。
                Arguments[Consts.StudentCourseAction] = ContinueDirection.Skip;

                return ContinueDirection.Next;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        public override ContinueDirection ShowWizardDialog()
        {
            if (Arguments.ContainsKey(Consts.StudentCourseAction))
                return (ContinueDirection)Arguments[Consts.StudentCourseAction];
            else
                return base.ShowWizardDialog();
        }

        private void AddStuCourse()
        {


        }

        private void btnSave1_Click(object sender, EventArgs e)
        {
            if (chkSaveYes.Checked == true)
            {
                List<CourseRecord> courseRecs = new List<CourseRecord>();
                foreach (AttendCourseEntity ace in studAttendCourseEntitys)
                    if (ace.CousreAttendType == AttendCourseEntity.AttendType.學生未修)
                        courseRecs.Add(ace.CourseRec);
                // 待加入儲存            
                if (courseRecs.Count > 0)
                {
                    DALTransfer.SetStudentAttendCourse(studRec.ID, courseRecs);

                    string CourseName = "";

                    foreach (CourseRecord cor in courseRecs)
                        CourseName += cor.Name + ",";

                    // log
                    //PermRecLogProcess prlp = new PermRecLogProcess();
                    //prlp.SaveLog("學籍.學生轉入異動", "新增學生課程", "新增學生" + studRec.Name + "的課程,課程名稱：" + CourseName);
                }
            }
            this.Close();

        }

        private void cboSelectClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (!string.IsNullOrEmpty(cboSelectClass.Text))
            {
                // 更新所選班級時更換相對班級，給載入班課程使用
                if (classRecIdx.ContainsKey(cboSelectClass.Text))
                    studClassRec = classRecIdx[cboSelectClass.Text];

                getCourseToForm();
            }
        }
    }
}
