using CLB.Infrastructure;
using Dapper;
using DapperExtensions;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLB.Models
{
    public enum Day
    {
        Monday,
        Tuesday,
        Wednesday,
        Thursday,
        Friday,
        Saturday,
        Sunday
    
    }
    public enum CourseType
    {
        Teorical,
        Practical
    }

    public class CourseTime
    {
        public int Id { get; set; }
        public int CourseRef { get; set; }
        public CourseType CourseType { get; set; }
        public Day Day { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int Duration  { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="courseReff"></param>
        /// <returns></returns>
        public int save(int courseRef)
        {
            using (MySqlConnection cn = DAL.getCn())
            {
                this.CourseRef = courseRef;
                this.Id = cn.Insert(this);
            }
            return this.Id;
        }
        public List<CourseTime> getCourseTimeList(int courseRef)
        {
            List<CourseTime> returnValue = new List<CourseTime>();
            using (MySqlConnection cn = DAL.getCn())
            {
                returnValue = cn.Query<CourseTime>("SELECT * FROM CourseTime WHERE CourseRef = @courseRef", new { @courseRef = courseRef }).ToList();
            }

            return returnValue;
        }


    }
}
