  using CLB.Infrastructure;
using Dapper;
using DapperExtensions;
using DapperExtensions.Mapper;
using DapperExtensions.Sql;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLB.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string CourseName { get; set; }
        public int Theorical { get; set; }
        public int Practical { get; set; }
        public int UserRef { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int TotalWeeks { get; set; }

        public List<CourseTime> CourseTimes { get; set; }
        public List<CourseStudent> CourseStudents { get; set; }


        public Course()
        {
            CourseName = "";
            StartDate = DateTime.Now;
            EndDate = DateTime.Now;
            CourseTimes = new List<CourseTime>();
            CourseStudents = new List<CourseStudent>();
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
        /// 
        /// </summary>
        /// <param name="userRef"></param>
        /// <param name="filter"></param>
        /// <returns></returns>
        public List<Course> getList(int userRef,string filter)
        {
            List<Course> returnValue = new List<Course>();
                 
            using (MySqlConnection cn = DAL.getCn())
            {
                returnValue = cn.Query<Course>("select * from Course where UserRef=@userRef and CourseName like @filter", new { @filter = "%" + filter + "%", @userRef =userRef }).ToList();
            }
            return returnValue;
        }

        public List<CourseTime> getCourseTimes()
        {
            List<CourseTime> returnValue = new List<CourseTime>();

            using (MySqlConnection cn = DAL.getCn())
            {
                if (this.Theorical != 0 ||this.Practical!=0)
                {
                    returnValue = cn.Query<CourseTime>("select day,StartTime from Course where Id=@Id ", new { }).ToList();
                }
                else
                {
                    returnValue =null;
                    return returnValue;
                }
              
                
            }
            return returnValue;
        }

        public Course get()
        {
            DapperExtensions.DapperExtensions.SqlDialect = new MySqlDialect();
            Course returnValue = new Course();
            using (MySqlConnection cn = DAL.getCn())
            {
                returnValue = cn.Get<Course>(this.Id);
            }

            return returnValue;
        }

     
    }




    public class CourseMapper : ClassMapper<Course>
    {
        public CourseMapper()
        {
            Table("Course");
            Map(p => p.CourseTimes).Ignore();
            Map(p => p.CourseStudents).Ignore();

            AutoMap();    
        }

    }
}
