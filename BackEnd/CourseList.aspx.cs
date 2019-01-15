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
    public partial class CourseList : System.Web.UI.Page
    {
        public Course Course
        {
            get
            {
                Course r = new Course();
                r.Id = Convert.ToInt32(hdnID.Value);
                r.CourseName = txtCourseName.Text;
                r.Theorical = Convert.ToInt32(txtTheorical.Value);
                r.Practical = Convert.ToInt32(txtPractical.Value);
                r.StartDate = Convert.ToDateTime(txtStartDate.Value);
                r.EndDate = Convert.ToDateTime(txtEndDate.Value);
                r.TotalWeeks = Convert.ToInt32(txtTotalWeeks.Value);
                r.UserRef = 1;
                return r;
            }
            set
            {
                hdnID.SetValue(value.Id);
                txtCourseName.SetValue(value.CourseName);
                txtTheorical.SetValue(value.Theorical);
                txtPractical.SetValue(value.Practical);
                txtStartDate.SetValue(value.StartDate);
                txtEndDate.SetValue(value.EndDate);
                txtTotalWeeks.SetValue(value.TotalWeeks);
            }
        }
        public CourseTime CourseTime
        {
            get
            {
                CourseTime r = new CourseTime();
                
                try
                {
                    r.Id = Convert.ToInt32(hdnCoursetime.Value);
                    r.StartTime = Convert.ToDateTime(txtStartTime.Text);
                    r.EndTime = Convert.ToDateTime(txtEndTime.Text);
                    r.Day = (Day)Convert.ToInt32(cbDay.Value);
                    r.CourseType = (CourseType)Convert.ToByte(cbType.Value);
                    r.Duration = Convert.ToInt32(txtDurationTime.Value);
                    r.CourseRef = Convert.ToInt32(hdnCourseRef.Value);
                    r.CourseTimeNo  = Convert.ToInt32(courseTimeNo.Value);
                }
                catch { }

                return r;
            }
            set
            {
                try
                {
                    hdnCoursetime.SetValue(value.Id);
                    txtStartTime.SetValue(value.StartTime);
                    txtEndTime.SetValue(value.EndTime);
                    txtDurationTime.SetValue(value.Duration);
                    hdnCourseRef.SetValue(value.CourseRef);
                    cbDay.SetValue(value.Day);
                    cbType.SetValue(value.CourseType);
                    courseTimeNo.SetValue(value.CourseTimeNo);
                    
                }
                catch {}
            }
        }
        public CourseStudent CourseStudent
        {
            get
            {
                CourseStudent student = new CourseStudent();
                try
                {
                    student.Id = Convert.ToInt32(hdnStudentId.Value);                   
                }
                catch { }
                student.StudentNameSurname = Convert.ToString(txtStudentName.Value);
                student.StudentNumber = Convert.ToString(txtStudentNumber.Value);
                student.UserRef = 1;
                student.CourseRef = Convert.ToInt32(hdnCourseRef.Value);

                return student;
            }
            set
            {
                try
                {
                    hdnStudentId.SetValue(value.Id);
                    txtStudentName.SetValue(value.StudentNameSurname);
                    txtStudentNumber.SetValue(value.StudentNumber);
                    // hdnCourseRef.SetValue(value.CourseRef);

                }
                catch { }
            }
        }

        public void Command(object sender, Ext.Net.DirectEventArgs e)
        {
            string commanName = e.ExtraParams["command"];
            int Id = Convert.ToInt32(e.ExtraParams["Id"]);
            int CourseTimeRef = Convert.ToInt32(e.ExtraParams["CourseTimeRef"]);
            int courseRef = Convert.ToInt32(e.ExtraParams["CourseRef"]);
            int courseTimeNo = Convert.ToInt32(e.ExtraParams["CourseTimeNo"]);
            int courseStudentRef = Convert.ToInt32(e.ExtraParams["CourseStudentRef"]);

            switch (commanName)
            {
                case "Update":
                    update(Id);
                    break;

                case "CourseTimes":
                    courseTimes(Id);
                    break;
                case "StudentList":
                    studentList(Id);
                    break;
                case "RollCallList":
                    rollBack(Id, courseRef, courseStudentRef);
                    break;
                case "UpdateCourseTime":
                    
                    updateCourseTime(Id, courseRef, courseTimeNo);
                    break;
                case "DeleteCourseTime":
                    deleteCourseTime(Id);
                    break;

            }
        }

       

        protected void Page_Load(object sender, EventArgs e)
        {
            Store str = grdList.GetStore();
            str.DataSource = new Course().getList(1, txtFilter.Text);

            str.DataBind();
        }
        private void rollBack(int Id, int CourseRef, int CourseStudentRef)
        {
            Course  = new Course() { Id = Id}.get();
            //CourseTime  = new CourseTime() { Id = Id, CourseRef = CourseRef }.get();
            //List<CourseTime> courseTimes = new CourseTime().getRollCallList(Course);
            //Store str = GridPnlRollBack.GetStore();
            //str.DataSource = courseTimes;
            //str.DataBind();
            //wndRollcall.Show();
        }

        private void update(int Id)
        {
            Course = new Course() { Id = Id }.get();
            wndNew.Show();
        }
        private void courseTimes(int Id)
        {
            Course course = new Course() { Id = Id }.get();
            
            var CourseRef = Id;
            


            List<CourseTime> courseTimes = new CourseTime().getCourseTimeList(course);
            Store str = gridPanelCourseTime.GetStore();
            str.DataSource = courseTimes;
            str.DataBind();
            hdnUpdateCourseTime.SetValue(Id);

            winCourseTime.Show();

        }


        private void updateCourseTime(int Id, int courseRef, int courseTimeNo)
        {
            CourseTime = new CourseTime() {Id=Id , CourseRef=courseRef, CourseTimeNo=courseTimeNo };
            winUpdateCourseTime.Show();
        }

        private void studentList(int Id)
        {
            Course = new Course() { Id = Id }.get();
            CourseStudent = new CourseStudent() { Id = Id }.get();
            List<CourseStudent> courseStudents = new CourseStudent().getStudentList(Course.Id);
            Store str = grdStudentList.GetStore();
            //str.DataSource = new CourseStudent().getStudentList(Id);
            str.DataSource = courseStudents;
            str.DataBind();

            hdnCourseRef.SetValue(Id);
            winStudentList.Show();
        }



        protected void deleteCourseTime(int Id)
        {
            //CourseTime = new CourseTime() { Id = Id }.Delete();

            var control = CourseTime;
            int delete = control.Delete();
            if (delete == 0)
            {

                X.Msg.Alert("UYARI", "Kayıt Silindi.").Show();
            }
            else
            {
                X.Msg.Alert("UYARI", "Kayıt Silinirken Hata Oluştu...Tekrar Deneyiniz");
            }

        }
        protected void btnAddNew_DirectClick(object sender, Ext.Net.DirectEventArgs e)
        {
            //AddCourse ekranı için
            Course = new Course();
            wndNew.Show();
        }

       protected void btnNewSave_DirectClick(object sender, Ext.Net.DirectEventArgs e)
        {
            //ders kayidi etme
            var control = Course;
            if (control.CourseName == "")
            {
                X.Msg.Alert("UYARI", "Lütfen geçerli bir ders adı giriniz").Show();
                return;
            }

            int returnValue = control.save();
            if (returnValue > 0)
            {
                X.Msg.Alert("UYARI", "Ders eklenmiştir. Yeni bir ders daha ekleyebilirsiniz").Show();
                Course = new Course();
            }
            else
            {
                X.Msg.Alert("UYARI", "Ders kayıt edilememiştir").Show();
            }
        }

        protected void btnGetList_DirectClick(object sender, Ext.Net.DirectEventArgs e)
        {
            //listCourse için
            if (CourseTime.IsDeleted !=true)
            {
                Store str = grdList.GetStore();
                str.DataSource = new Course().getList(1, txtFilter.Text);
                str.DataBind();
            }
          
        }
        protected void txtStartDate_DirectSelect(object sender, DirectEventArgs e)
        {
            //otomatik hafta hesabı yapmak
            DateTime startDate = Convert.ToDateTime(txtStartDate.Value);
            DateTime endDate = Convert.ToDateTime(txtEndDate.Value);

            var diff = endDate.Subtract(startDate).TotalDays;
            int week = Convert.ToInt32(diff / 7);
            txtTotalWeeks.SetValue(week);

        }
        //protected void txtEndTime_DirectChange(object sender, DirectEventArgs e)
        //{
        //    //otomatik süre hesabı yapmak
        //    DateTime startTime = Convert.ToDateTime(txtStartTime.Value);
        //    DateTime endTime = Convert.ToDateTime(txtStartTime.Value);

        //    var diff = endTime.Subtract(startTime).TotalHours;
        //    int Duration = Convert.ToInt32(diff);
        //    txtDurationTime.SetValue(Duration);
        //}
       

        protected void btnStudentAdd_DirectClick(object sender, DirectEventArgs e)
        {
            CourseStudent courseStudent = new CourseStudent();
            winAddStudent.Show();
        }

        protected void btnStudentSave_DirectClick(object sender, DirectEventArgs e)
        {
            //var courseRef = courseRef(Course.Id);

            CourseStudent courseStudent = new CourseStudent();

            var control = CourseStudent;

            if (control.StudentNameSurname == "")
            {
                X.Msg.Alert("UYARI", "Lütfen geçerli bir ad giriniz").Show();
                return;
            }

            int returnValue = control.save();
            if (returnValue > 0)
            {
                X.Msg.Alert("UYARI", "Öğrenci eklenmiştir. Yeni bir öğrenci daha ekleyebilirsiniz").Show();
                CourseStudent = new CourseStudent();
            }
            else
            {
                X.Msg.Alert("UYARI", "Öğrenci kayıt edilememiştir").Show();
            }
        }

        protected void btnStudentClose_DirectClick(object sender, DirectEventArgs e)
        {
            winAddStudent.Hide();
        }

        protected void btnStudentListClose_DirectClick(object sender, DirectEventArgs e)
        {
            winStudentList.Hide();
        }

        protected void btnClose_DirectClick(object sender, DirectEventArgs e)
        {
            wndNew.Hide();
            winCourseTime.Hide();
        }

        protected void btnUpdateSave_DirectClick(object sender, DirectEventArgs e)
        {
            int returnValue = CourseTime.save();
            if (returnValue > 0)
            {
                X.Msg.Alert("UYARI", "Güncelleme Yapılmıştır").Show();
                CourseTime = new CourseTime();
            }
            else
            {
                X.Msg.Alert("UYARI", "Güncelleme yapılamadı.Lütfen tekrar deneyiniz.").Show();
            }
            CourseTime courseTime = new CourseTime();
        }


        protected void btnKapatUpdate_DirectClick(object sender, DirectEventArgs e)
        {
            winUpdateCourseTime.Hide();
        }
    }
}