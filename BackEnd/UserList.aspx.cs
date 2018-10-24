using CLB.Models;
using Ext.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BackEnd
{
    public partial class UserList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ///first time page load
            if (!X.IsAjaxRequest)
            {
                cbUserType.SetValue("-1");
            }
        }

        protected void btnGetList_DirectClick(object sender, Ext.Net.DirectEventArgs e)
        {
           
            Store str = grdList.GetStore();
            str.DataSource = new User().getList(txtFilter.Text,Convert.ToInt32(cbUserType.Value), -1);
            str.DataBind();
        }

        protected void btnAddNew_DirectClick(object sender, DirectEventArgs e)
        {
            //X.Msg.Alert("UYARI", "Mesajın içeriği").Show();
            wndNew.Show();
        }

        protected void btnCreateNewCourse_DirectClick(object sender, DirectEventArgs e)
        {
            Course course = new Course()
            {
                CourseName = "Mobil I",
                Theorical = 1,
                Practical = 2,
                UserRef = 1,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(98),
                TotalWeeks = 14,

                CourseTimes = new List<CourseTime>() {
                    new CourseTime(){
                        Day =Day.Monday,
                        StartTime =DateTime.Now.Date + new TimeSpan(14,0,0),
                        EndTime =DateTime.Now.Date + new TimeSpan(14,45,0),
                        Duration=45,
                        CourseType=CourseType.Teorical
                    },
                     new CourseTime(){
                        Day =Day.Monday,
                        StartTime =DateTime.Now.Date + new TimeSpan(15,0,0),
                        EndTime =DateTime.Now.Date + new TimeSpan(15,45,0),
                        Duration=45,
                        CourseType=CourseType.Practical
                    }, new CourseTime(){
                        Day =Day.Monday,
                        StartTime =DateTime.Now.Date + new TimeSpan(16,0,0),
                        EndTime =DateTime.Now.Date + new TimeSpan(16,45,0),
                        Duration=45,
                        CourseType=CourseType.Practical
                    }
                }
            };

            int control = course.save();
        }
    }
}