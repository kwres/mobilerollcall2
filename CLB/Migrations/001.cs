using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLB.Migrations
{
    [Migration(1)]
    public class _001 : Migration
    {
        public override void Down()
        {
            Delete.Table("Photo");
            Delete.Table("Notification");
            Delete.Table("Log");
            Delete.Table("RollBack");
            Delete.Table("CourseStudent");
            Delete.Table("CourseTime");
            Delete.Table("Course");
            Delete.Table("User");
        }

        public override void Up()
        {
            Create.Table("User")
                 .WithColumn("Id").AsInt32().Identity().PrimaryKey()
                 .WithColumn("NameSurname").AsString(256).NotNullable()
                 .WithColumn("Email").AsString(256).NotNullable()
                 .WithColumn("PasswordHash").AsString(256)
                 .WithColumn("UserType").AsByte().WithDefaultValue(0)
                 .WithColumn("Gsm").AsString(32).WithDefaultValue("")
                 .WithColumn("PhotoRef").AsInt32().WithDefaultValue(0)
                 .WithColumn("State").AsByte().NotNullable()
                 .WithColumn("GoogleProfileld").AsString(256)
                 .WithColumn("ActivationCode").AsString(4).WithDefaultValue("")
                 .WithColumn("IsDeleted").AsBoolean().WithDefaultValue(false);          
                 

            Create.Table("Course")
                 .WithColumn("Id").AsInt32().Identity().PrimaryKey()
                 .WithColumn("CourseName").AsString(128).NotNullable()
                 .WithColumn("Theorical").AsByte().WithDefaultValue(0)
                 .WithColumn("Practical").AsByte().WithDefaultValue(0)
                 .WithColumn("UserRef").AsInt32().ForeignKey("User", "Id")
                 .WithColumn("StartDate").AsDateTime().NotNullable()
                 .WithColumn("EndDate").AsDateTime().NotNullable()
                 .WithColumn("TotalWeeks").AsInt32().NotNullable()
                 .WithColumn("IsDeleted").AsBoolean().WithDefaultValue(false);

            Create.Table("CourseTime")
                 .WithColumn("Id").AsInt32().Identity().PrimaryKey()
                 .WithColumn("CourseTimeNo").AsInt32().Nullable()
                 .WithColumn("CourseRef").AsInt32().ForeignKey("Course", "Id")
                 .WithColumn("Day").AsInt32()
                 .WithColumn("StartTime").AsDateTime().Nullable()
                 .WithColumn("EndTime").AsDateTime().Nullable()
                 .WithColumn("Duration").AsInt32().Nullable()
                 .WithColumn("CourseType").AsByte().WithDefaultValue(0)
                 .WithColumn("IsDeleted").AsBoolean().WithDefaultValue(false);

            Create.Table("CourseStudent")
                 .WithColumn("Id").AsInt32().Identity().PrimaryKey()
                 .WithColumn("CourseRef").AsInt32().ForeignKey("Course", "Id")
                 .WithColumn("UserRef").AsInt32().WithDefaultValue(0)
                 .WithColumn("StudentNumber").AsString(16).NotNullable()
                 .WithColumn("StudentNameSurname").AsString(256).NotNullable()
                 .WithColumn("IsDeleted").AsBoolean().WithDefaultValue(false);

            Create.Table("RollBack")
                 .WithColumn("Id").AsInt32().Identity().PrimaryKey()
                 .WithColumn("CourseRef").AsInt32().ForeignKey("Course", "Id")
                 .WithColumn("Week").AsInt32().NotNullable()
                 .WithColumn("CourseTimeRef").AsInt32().ForeignKey("CourseTime", "Id")
                 .WithColumn("CourseStudentRef").AsInt32().ForeignKey("CourseStudent", "Id")
                 .WithColumn("Location").AsString(128).WithDefaultValue("")
                 .WithColumn("IsDeleted").AsBoolean().WithDefaultValue(false);

            Create.Table("Log")
                .WithColumn("Id").AsInt32().Identity().PrimaryKey()
                .WithColumn("UserRef").AsInt32().ForeignKey("User", "Id")
                .WithColumn("IP").AsString(128).WithDefaultValue("")
                .WithColumn("LogDate").AsDateTime()
                .WithColumn("IsDeleted").AsBoolean().WithDefaultValue(false);

            Create.Table("Notification")
                .WithColumn("Id").AsInt32().Identity().PrimaryKey()
                .WithColumn("NotificationType").AsByte().WithDefaultValue(0)
                .WithColumn("UserRef").AsInt32().ForeignKey("User", "Id")
                .WithColumn("DeviceID").AsString(128).WithDefaultValue("")
                .WithColumn("GSM").AsString(32).WithDefaultValue("")
                .WithColumn("Message").AsString(256).NotNullable()
                .WithColumn("IsDeleted").AsBoolean().WithDefaultValue(false);

            Create.Table("Photo")
                .WithColumn("Id").AsInt32().Identity().PrimaryKey()
                .WithColumn("PhotoData").AsBinary()
                .WithColumn("IsDeleted").AsBoolean().WithDefaultValue(false);

        }
    }
}
