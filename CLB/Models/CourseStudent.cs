using CLB.Infrastructure;
using Dapper;
using DapperExtensions;
using DapperExtensions.Sql;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLB.Models
{
    public class CourseStudent
    {
        public int Id { get; set; }
        public int CourseRef { get; set; }
        public int UserRef { get; set; }
        public string StudentNameSurname { get; set; }
        public string StudentNumber { get; set;}


        public CourseStudent()
        {
            StudentNameSurname = "";
            StudentNumber = "";
        }

        public int save()
        {
            DapperExtensions.DapperExtensions.SqlDialect = new MySqlDialect();
            using (MySqlConnection cn = DAL.getCn())
            {


                if (this.Id == 0)
                {
                    this.Id = cn.Insert(this);
                }
                else
                {
                    cn.Update(this);
                }
            }

            return this.Id;
        }


        /// <summary>
        /// List of Students that attend a course
        /// </summary>
        /// <param name="courseRef">Course Id</param>
        /// <returns>Returns the List of students that are attending the course</returns>
        public List<CourseStudent> getStudentList(int courseRef)
        {
            List<CourseStudent> returnValue = new List<CourseStudent>();
            using (MySqlConnection cn = DAL.getCn())
            {
                returnValue = cn.Query<CourseStudent>("SELECT * FROM CourseStudent WHERE CourseRef = @courseRef ", new { @courseRef = courseRef }).ToList();
            }
            return returnValue;
        }


    }



}
