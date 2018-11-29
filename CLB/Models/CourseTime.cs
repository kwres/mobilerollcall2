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
        public string CourseDate { get; set; }
        public int CourseRef { get; set; }
        public int CourseTimeNo { get; set; }
        public CourseType CourseType { get; set; }
        public Day Day { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int Duration { get; set; }
        public bool IsDeleted { get; set; }
        public string Desc
        {
            get
            {
                string r = "";
                if (r == "")
                {
                    r = String.Format("No : {0} - {1}", CourseTimeNo, CourseType == CourseType.Practical ? "Pratik" : "Teorik");
                }
                return r;

            }
        }
        public string CourseTimeDesc
        {
            get
            {
                string r = "";
                if (r == "")
                {
                    r = String.Format("Saatleri : {0} - {1}", StartTime.Hour, EndTime.Hour);
                }
                return r;

            }
        }


        public int Delete()
        {
            using (MySqlConnection cn = DAL.getCn())
            {
                this.IsDeleted = true;
                cn.Update(this);
            }
            return this.Id;
        }


        public void Update()
        {
            using (MySqlConnection cn = DAL.getCn())
            {
                cn.Update(this);
            }
        }


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
        public List<CourseTime> getCourseTimeList(Course course)
        {
            List<CourseTime> returnValue = new List<CourseTime>();
            int courseTimeNo = 1;
            for (int i = 0; i < course.Theorical; i++)
            {
                returnValue.Add(new CourseTime()
                {
                    CourseRef = course.Id,
                    CourseType = CourseType.Teorical,
                    CourseTimeNo = courseTimeNo

                });
                courseTimeNo++;
            }


            for (int i = 0; i < course.Practical; i++)
            {
                returnValue.Add(new CourseTime()
                {
                    CourseRef = course.Id,
                    CourseType = CourseType.Practical,
                    CourseTimeNo = courseTimeNo
                });
                courseTimeNo++;
            }

            List<CourseTime> fromDatabase = new List<CourseTime>();
            using (MySqlConnection cn = DAL.getCn())
            {
                fromDatabase = cn.Query<CourseTime>("SELECT * FROM CourseTime WHERE CourseRef = @courseRef", new { @courseRef = course.Id }).ToList();
            }

            List<CourseTime> r = new List<CourseTime>();
            foreach (var courseTime in returnValue)
            {
                var control = fromDatabase.FirstOrDefault(p => p.CourseTimeNo == courseTime.CourseTimeNo);
                if (control == null)
                {
                    r.Add(courseTime);
                }
                else
                {
                    r.Add(control);
                }
            }

            return r;
        }



        public CourseTime get()
        {
            DapperExtensions.DapperExtensions.SqlDialect = new MySqlDialect();
            CourseTime returnValue = new CourseTime();
            using (MySqlConnection cn = DAL.getCn())
            {
                returnValue = cn.Get<CourseTime>(this.Id);
            }

            return returnValue;
        }



        //        public List<CourseTime> getRollBackList(Course course)
        //        {
        //            List<CourseTime> returnValue = new List<CourseTime>();
        //            int courseTimeNo = 1;
        //            //for (int i = 0; i < course.Theorical; i++)
        //            //{
        //            //    for (DateTime date = course.StartDate; date <= course.EndDate; date = date.AddDays(1))
        //            //    {
        //            //        if (date.Day == this.Day)
        //            //        {
        //            //            returnValue.Add(new CourseTime()
        //            //            {
        //            //                CourseDate = date.ToShortDateString(),
        //            //                Id = course.Id,
        //            //                CourseType = CourseType.Teorical
        //            //            });
        //            //        }
        //            //    }
        //                //returnValue.Add(new CourseTime()
        //                //{
        //                //    CourseRef = course.Id,
        //                //    CourseType = CourseType.Teorical,
        //                //    CourseTimeNo = courseTimeNo

        //                //});
        //                //courseTimeNo++;
        //            }


        //            for (int i = 0; i < course.Practical; i++)
        //            {
        //                for (DateTime date = course.StartDate; date <= course.EndDate; date = date.AddDays(1))
        //                {
        //                    if (date.DayOfWeek == this.Day)
        //                    {
        //                        returnValue.Add(new CourseTime()
        //                        {
        //                            CourseDate = date.ToShortDateString(),
        //                            Id = course.Id,
        //                            CourseType = CourseType.Practical
        //                        });
        //                    }

        //                    //returnValue.Add(new CourseTime()
        //                    //{
        //                    //    CourseRef = course.Id,
        //                    //    CourseType = CourseType.Practical,
        //                    //    CourseTimeNo = courseTimeNo
        //                    //});
        //                    //courseTimeNo++;
        //                }
        //            }

        //            //List<string> days_list = new List<string>();
        //            //for (DateTime date = course.StartDate; date <= course.EndDate; date = date.AddDays(1))
        //            //{
        //            //    if (date.DayOfWeek == this.Day)
        //            //        days_list.Add(date.ToShortDateString());
        //            //}


        //            return returnValue;
        //        }
    }
}

