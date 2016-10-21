using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace StudentTransferCoreImpl
{
    /// <summary>
    /// 代表年級、學期。
    /// </summary>
    internal struct SemesterData
    {
        static SemesterData()
        {
            SemesterCount = 2;
        }

        public static SemesterData Undefined { get { return new SemesterData(int.MinValue, int.MinValue, int.MinValue); } }

        /// <summary>
        /// 建構式。
        /// </summary>
        /// <param name="schoolyear">學年度。</param>
        /// <param name="semester">學期。</param>
        /// <remarks>參數可傳「0」。</remarks>
        public SemesterData(int schoolyear, int semester)
            : this(int.MinValue, schoolyear, semester)
        {
            ToStringFormatter = null;
        }

        /// <summary>
        /// 建構式。
        /// </summary>
        /// <param name="gradeYear">年級。</param>
        /// <param name="schoolyear">學年度。</param>
        /// <param name="semester">學期。</param>
        /// <remarks>參數可傳「0」。</remarks>
        public SemesterData(int gradeYear, int schoolyear, int semester)
            : this()
        {
            GradeYear = Normalize(gradeYear);
            SchoolYear = Normalize(schoolyear);
            Semester = Normalize(semester);
        }

        /// <summary>
        /// 學年度。
        /// </summary>
        public int SchoolYear { get; private set; }

        /// <summary>
        /// 學期。
        /// </summary>
        public int Semester { get; private set; }

        /// <summary>
        /// 年級。
        /// </summary>
        public int GradeYear { get; private set; }

        /// <summary>
        /// 順序。
        /// </summary>
        public int Order { get { return (GradeYear << 24) + (SchoolYear << 16) + Semester; } }

        /// <summary>
        /// 計算下一個學期。
        /// </summary>
        /// <param name="semester"></param>
        /// <returns></returns>
        public SemesterData Next()
        {
            int sy = SchoolYear;
            int ss = Semester;
            int gy = GradeYear;

            int nextss = NextSemesterNumber(ss);

            if (ss == SemesterCount)
            {
                if (SchoolYear >= 0) //當學年度非負數。
                    sy++;

                if (GradeYear >= 0) //當年級非負數。
                    gy++;
            }

            return new SemesterData(gy, sy, nextss);
        }

        private int NextSemesterNumber(int current)
        {
            int next = current + 1;

            if (next > SemesterCount)
                next = 1;

            return next;
        }

        /// <summary>
        /// 提供 ToString 方法呼叫。
        /// </summary>
        public Func<SemesterData, string> ToStringFormatter { get; set; }

        public static bool operator ==(SemesterData sems1, SemesterData sems2)
        {
            return sems1.Order == sems2.Order;
        }

        public static bool operator !=(SemesterData sems1, SemesterData sems2)
        {
            return sems1.Order != sems2.Order;
        }

        public static bool operator <(SemesterData sems1, SemesterData sems2)
        {
            return sems1.Order < sems2.Order;
        }

        public static bool operator <=(SemesterData sems1, SemesterData sems2)
        {
            return sems1.Order <= sems2.Order;
        }

        public static bool operator >(SemesterData sems1, SemesterData sems2)
        {
            return sems1.Order > sems2.Order;
        }

        public static bool operator >=(SemesterData sems1, SemesterData sems2)
        {
            return sems1.Order >= sems2.Order;
        }

        public override bool Equals(object obj)
        {
            return Order == ((SemesterData)obj).Order;
        }

        public override int GetHashCode()
        {
            return Order.GetHashCode();
        }

        public override string ToString()
        {
            if (ToStringFormatter == null)
                return string.Format("{0}年級, {1},{2}", GradeYear < 0 ? "無" : GradeYear.ToString(), SchoolYear, Semester);
            else
                return ToStringFormatter(this);
        }

        private int Normalize(int v)
        {
            if (v < 0)
                return -1;
            else
                return v;
        }

        /// <summary>
        /// 取得或設定系統的學期數，預設值為「2」。
        /// </summary>
        public static int SemesterCount { get; set; }

        /// <summary>
        /// 群組各年級的學期，如果有重覆學期以較新的為主(通常發生在重讀狀況)。
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// 資料：
        /// 98,1 一年級
        /// 98,2 一年級
        /// 99,2 一年級
        /// 結果：
        /// 98,1 一年級
        /// 99,2 一年級
        /// </remarks>
        public static SemesterData[] DistinctGradeYear(SemesterData[] semesters)
        {
            List<SemesterData> allsems = new List<SemesterData>(semesters);

            //以年級、學年度、學期排序。
            allsems.Sort(delegate(SemesterData x, SemesterData y) { return x.Order.CompareTo(y.Order); });

            Dictionary<int, SemesterData> gradeyears = new Dictionary<int, SemesterData>();
            foreach (SemesterData each in allsems)
            {
                int intGy = (each.GradeYear << 24) + each.Semester;
                if (!gradeyears.ContainsKey(intGy))
                    gradeyears.Add(intGy, each);
                else
                    gradeyears[intGy] = each;
            }

            return new List<SemesterData>(gradeyears.Values).ToArray();
        }

        /// <summary>
        /// 產生學年度、學期資料。
        /// </summary>
        /// <param name="schoolYears"></param>
        /// <returns></returns>
        public static SemesterData[] Generate(int startSchoolYear, int count)
        {
            List<SemesterData> result = new List<SemesterData>();

            for (int i = 0; i < count; i++)
            {
                SemesterData first = new SemesterData(startSchoolYear + i, 1);
                result.Add(first);
                for (int t = 1; t < SemesterCount; t++) //Count 是 2 的話，只跑一圈。
                    result.Add((first = first.Next()));
            }

            return result.ToArray();
        }
    }

    /// <summary>
    /// 
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    internal static class SemesterData_Extens
    {
        /// <summary>
        /// 設定每一個 SemesterData 的 ToStringFormatProvider 屬性。
        /// </summary>
        /// <param name="semesters"></param>
        /// <param name="formatter"></param>
        public static void SetToStringFormatter(this IEnumerable<SemesterData> semesters, Func<SemesterData, string> formatter)
        {
            List<SemesterData> list = new List<SemesterData>(semesters);

            for (int i = 0; i < list.Count; i++)
            {
                SemesterData semester = list[i];
                semester.ToStringFormatter = formatter;
            }
        }
    }
}
