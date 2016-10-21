using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using K12.Data;
using StudentTransferCoreImpl.TransferIn;

namespace StudentTransferCoreImpl.TransferIn
{
    class DALTransfer
    {
        /// <summary>
        /// 儲存學生選課(Insert)
        /// </summary>
        /// <param name="StudentID"></param>
        /// <param name="CourseList"></param>
        public static void SetStudentAttendCourse(string StudentID, List<CourseRecord> InesrtCourseList)
        {
            List<SCAttendRecord> SCAttendList = new List<SCAttendRecord>();
            foreach (CourseRecord cor in InesrtCourseList)
            {
                SCAttendRecord scattend = new SCAttendRecord();
                scattend.RefCourseID = cor.ID;
                scattend.RefStudentID = StudentID;
                SCAttendList.Add(scattend);
            }

            SCAttend.Insert(SCAttendList);
        }

        /// <summary>
        /// 取得某學年度學期某位學生修課狀況
        /// </summary>
        /// <param name="SchoolYear"></param>
        /// <param name="Semester"></param>
        /// <param name="studRec"></param>
        /// <param name="classRec"></param>
        /// <returns></returns>
        public static List<AttendCourseEntity> getStudAttendCourseBySchoolYearSemester(int SchoolYear, int Semester, StudentRecord studRec,ClassRecord classRec)
        {
            List<AttendCourseEntity> ClassAttendCourseRec = new List<AttendCourseEntity>();
            List<AttendCourseEntity> StudAttendCourseRec = new List<AttendCourseEntity>();
            List<AttendCourseEntity> returnAttendCourseRecs = new List<AttendCourseEntity>();

            // 取得該班課程
            List<CourseRecord> _ClassCoursesList = Course.SelectByClass(SchoolYear, Semester, classRec.ID);


            // 取得學生設定班級當學年度學期的課程
            foreach (CourseRecord cor in _ClassCoursesList)
                if (cor.SchoolYear == SchoolYear && cor.Semester == Semester)
                {
                    AttendCourseEntity ace = new AttendCourseEntity();
                    ace.CourseID = cor.ID;
                    ace.CourseName = cor.Name;
                    ace.CourseRec = cor;
                    if (cor.Credit.HasValue)
                        ace.Credit = cor.Credit.Value + "";
                    ace.SubjectName = cor.Subject;
                    ace.CousreAttendType = AttendCourseEntity.AttendType.學生未修;
                    ClassAttendCourseRec.Add(ace);
                    ace = null;
                }

            List<SCAttendRecord> studSCAttendList = SCAttend.SelectByStudentID(studRec.ID);

            List<CourseRecord> StudAttendCourseList = new List<CourseRecord>();
            foreach (SCAttendRecord attend in studSCAttendList)
                StudAttendCourseList.Add(attend.Course);

            // 取得學生當學年度學期修課名稱
            foreach (CourseRecord cor in StudAttendCourseList)
                if (cor.SchoolYear == SchoolYear && cor.Semester == Semester)
                {
                    AttendCourseEntity ace = new AttendCourseEntity();
                    ace.CourseID = cor.ID;
                    ace.CourseName = cor.Name;
                    ace.CourseRec = cor;
                    if (cor.Credit.HasValue)
                        ace.Credit = cor.Credit.Value + "";
                    ace.SubjectName = cor.Subject;
                    ace.CousreAttendType = AttendCourseEntity.AttendType.學生本身已修;
                    StudAttendCourseRec.Add(ace);
                    ace = null;
                }

            bool chkAttend = false;
            foreach (AttendCourseEntity aceClass in ClassAttendCourseRec)
            {
                AttendCourseEntity removeItem = null;
                chkAttend = false;
                foreach (AttendCourseEntity aceStud in StudAttendCourseRec)
                    if (aceClass.CourseName == aceStud.CourseName)
                    {
                        chkAttend = true;
                        removeItem = aceStud;
                        break;
                    }

                // 當班級與學生修課相同
                if (chkAttend == true)
                {
                    StudAttendCourseRec.Remove(removeItem);
                    aceClass.CousreAttendType = AttendCourseEntity.AttendType.學生修課與班級相同;
                    returnAttendCourseRecs.Add(aceClass);
                }
                else
                    returnAttendCourseRecs.Add(aceClass);
            }

            foreach (AttendCourseEntity ace in StudAttendCourseRec)
                returnAttendCourseRecs.Add(ace);

            return returnAttendCourseRecs;
        }
    }
}