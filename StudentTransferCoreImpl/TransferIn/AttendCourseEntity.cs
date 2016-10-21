using K12.Data;

namespace StudentTransferCoreImpl.TransferIn
{
    public class AttendCourseEntity
    {
        public enum AttendType { 學生未修, 學生本身已修, 學生修課與班級相同 }
        public string CourseID { get; set; }
        public string CourseName { get; set; }
        public string Credit { get; set; }
        public string SubjectName { get; set; }
        public CourseRecord CourseRec { get; set; }
        public AttendType CousreAttendType { get; set; }
    }
}