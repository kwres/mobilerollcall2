using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLB.Models
{
    class RollCall
    {
        public int Id { get; set; }
        public int Week { get; set; }
        public int CourseRef { get; set; }
        public int CourseTimeRef { get; set; }
        public int CourseCourseStudentRef { get; set; }
        public string Location { get; set; }








    //    public List<CourseTime> getRollBackList(Course course, CourseTime courseTime)
    //    {
    //        List<CourseTime> returnValue = new List<CourseTime>();
    //        int courseTimeNo = 1;
    //        for (int i = 0; i < course.Theorical; i++)
    //        {
    //            for (DateTime date = course.StartDate; date <= course.EndDate; date = date.AddDays(1))
    //            {
                    
    //                if (date.Day == this.Day)
    //                {
    //                    returnValue.Add(new CourseTime()
    //                    {
    //                        CourseDate = date.ToShortDateString(),
    //                        Id = course.Id,
    //                        CourseType = CourseType.Teorik
    //                    });
    //                }
    //            }
    //            returnValue.Add(new CourseTime()
    //            {
    //                CourseRef = course.Id,
    //                CourseType = CourseType.Teorik,
    //                CourseTimeNo = courseTimeNo

    //            });
    //            courseTimeNo++;
    //        }


    //        for (int i = 0; i < course.Practical; i++)
    //        {
    //            for (DateTime date = course.StartDate; date <= course.EndDate; date = date.AddDays(1))
    //            {
    //                if (date.DayOfWeek == this.Day)
    //                {
    //                    returnValue.Add(new CourseTime()
    //                    {
    //                        CourseDate = date.ToShortDateString(),
    //                        Id = course.Id,
    //                        CourseType = CourseType.Pratik
    //                    });
    //                }

    //                returnValue.Add(new CourseTime()
    //                {
    //                    CourseRef = course.Id,
    //                    CourseType = CourseType.Pratik,
    //                    CourseTimeNo = courseTimeNo
    //                });
    //                courseTimeNo++;
    //            }
    //        }

    //        List<string> days_list = new List<string>();
    //        for (DateTime date = course.StartDate; date <= course.EndDate; date = date.AddDays(1))
    //        {
    //            if (date.DayOfWeek == this.Day)
    //                days_list.Add(date.ToShortDateString());
    //        }


    //        return returnValue;
    //    }

    }
}
