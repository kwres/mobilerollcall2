<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CourseList.aspx.cs" Inherits="BackEnd.CourseList" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <ext:ResourceManager runat="server"></ext:ResourceManager>
    <form id="form1" runat="server">
    <ext:GridPanel runat="server" ID="grdList" Flex="1" Title="Ders Listesi" ForceFit="true">
        <TopBar>
            <ext:Toolbar runat="server">
                <Items>
                    <ext:Button runat="server" ID="btnAddNew" Icon="Add" OnDirectClick="btnAddNew_DirectClick"></ext:Button>
                    <ext:TextField runat="server" ID="txtFilter" FieldLabel="Filtre">
                        <RightButtons>
                            <ext:Button runat="server" ID="btnGetList" Icon="Find" OnDirectClick="btnGetList_DirectClick">
                            <DirectEvents>
                                <Click>
                                    <EventMask Msg="Lütfen bekleyiniz" ShowMask="true"></EventMask>                            
                                </Click>
                            </DirectEvents>
                        </ext:Button>
                        </RightButtons>
                    </ext:TextField>
                    
                </Items>
            </ext:Toolbar>
        </TopBar>
        <Store>
            <ext:Store runat="server">
                <Fields>
                    <ext:ModelField Name="Id"></ext:ModelField>
                    <ext:ModelField Name="CourseName"></ext:ModelField>
                    <ext:ModelField Name="Theorical"></ext:ModelField>
                    <ext:ModelField Name="Practical"></ext:ModelField>
                    <ext:ModelField Name="StartDate" Type="Date"></ext:ModelField>
                    <ext:ModelField Name="EndDate" Type="Date"></ext:ModelField>
                    <ext:ModelField Name="Day"></ext:ModelField>
                    <ext:ModelField Name="StartTime"></ext:ModelField>
                    <ext:ModelField Name="EndTime"></ext:ModelField>
                    <ext:ModelField Name="Duration"></ext:ModelField>
                    <ext:ModelField Name="CourseType"></ext:ModelField>
                    <ext:ModelField Name="CourseRef"></ext:ModelField>
                    <ext:ModelField Name="StudentNumber"></ext:ModelField>
                    <ext:ModelField Name="StudentNameSurname"></ext:ModelField>
                    <ext:ModelField Name="UserRef"></ext:ModelField>
                    <ext:ModelField Name="Week"></ext:ModelField>
                    <ext:ModelField Name="CourseTimeRef"></ext:ModelField>
                    <ext:ModelField Name="CourseTimeStudent"></ext:ModelField>
                    <ext:ModelField Name="Location"></ext:ModelField>
                </Fields>
            </ext:Store>
        </Store>
        <ColumnModel>
            <Columns>
                <ext:RowNumbererColumn runat="server" Text="Sıra No"></ext:RowNumbererColumn>
                <ext:Column runat="server" DataIndex="CourseName" Text="Ders Adı" Flex="1"></ext:Column>
                <ext:Column runat="server" DataIndex="Theorical" Text="Teorik" Flex="1"></ext:Column>
                <ext:Column runat="server" DataIndex="Practical" Text="Pratik" Flex="1"></ext:Column>
                <ext:DateColumn runat="server" DataIndex="StartDate" Text="Başlangıç Tarihi" Format="dd/MM/yyyy" Width="120"></ext:DateColumn>
                <ext:DateColumn runat="server" DataIndex="EndDate" Text="Bitiş Tarihi" Format="dd/MM/yyyy" Width="120"></ext:DateColumn>
                <ext:CommandColumn runat="server" Width="135">
                   <Commands>
                        <ext:GridCommand CommandName="Update" Icon="ApplicationEdit" ToolTip-Text="Güncelle"></ext:GridCommand>
                        <ext:GridCommand CommandName="CourseTimes" Icon="ClockLink" ToolTip-Text="Ders Saatleri"   > </ext:GridCommand>
                        <ext:GridCommand CommandName="StudentList" Icon="Vcard" ToolTip-Text="Öğrenci Listesi"></ext:GridCommand>
                        <ext:GridCommand CommandName="RollCallList" Icon="UserTick" ToolTip-Text="Yoklama Listesi"></ext:GridCommand>
                    </Commands>
                    <DirectEvents>
                        <Command OnEvent="Command">
                            <EventMask ShowMask="true" Msg="Lütfen bekleyiniz.."></EventMask>
                            <ExtraParams>
                                <ext:Parameter Mode="Raw" Name="command" Value="command"></ext:Parameter>
                                <ext:Parameter Mode="Raw" Name="Id" Value="record.data.Id"></ext:Parameter>
                                <ext:Parameter Mode="Raw" Name="coursename" Value="record.data.CourseName"></ext:Parameter>
                            </ExtraParams>
                        </Command>
                    </DirectEvents>
                    
                </ext:CommandColumn>
            </Columns>
        </ColumnModel>
    </ext:GridPanel>

    <ext:Window runat="server" ID="wndNew" Title="Ders Kartı" Modal="true" Hidden="true" Width="460">
        <Items>
            <ext:Hidden runat="server" ID="hdnID"></ext:Hidden>
            <ext:TextField runat="server" ID="txtCourseName" FieldLabel="Ders Adı" Padding="3" LabelWidth="150" Width="450"></ext:TextField>
            <ext:NumberField runat="server" ID="txtTheorical" FieldLabel="Teorik Ders Saati" Padding="3" LabelWidth="150" Width="300" MinValue="0"></ext:NumberField>
            <ext:NumberField runat="server" ID="txtPractical" FieldLabel="Pratik Ders Saati" Padding="3" LabelWidth="150" Width="300" MinValue="0"></ext:NumberField>
            <ext:DateField runat="server" ID="txtStartDate"  FieldLabel="Başlangıç Tarihi" Padding="3" LabelWidth="150" Width="300"  OnDirectSelect="txtStartDate_DirectSelect"></ext:DateField>
            <ext:DateField runat="server" ID="txtEndDate"  FieldLabel="Bitiş Tarihi" Padding="3" LabelWidth="150" Width="300" OnDirectChange="txtStartDate_DirectSelect"></ext:DateField>
            <ext:NumberField runat="server" ID="txtTotalWeeks" FieldLabel="Toplam Hafta" Disabled="true" Padding="3" LabelWidth="150"></ext:NumberField>
        </Items>
        
        <Buttons>
            <ext:Button runat="server" ID="btnSave" Icon="DatabaseSave" Text="Kaydet" OnDirectClick="btnSave_DirectClick">
                <DirectEvents>
                    <Click>
                        <EventMask ShowMask="true" Msg="Lütfen bekleyiniz..."></EventMask>
                    </Click>
                </DirectEvents>
            </ext:Button>
            <ext:Button runat="server" ID="btnClose" Icon="Delete" Text="Vazgeç" OnDirectClick="btnClose_DirectClick" ></ext:Button>
        </Buttons>
    </ext:Window>


        <ext:Window runat="server" ID="winCourseTime" Title="Ders Saatleri" Modal="true" Hidden="true" Width="800">
            <Items>
           <ext:GridPanel runat="server" ID="gridPanelCourseTime" Flex="1">
          <Store>
            <ext:Store runat="server">
                <Fields>
                    <ext:ModelField Name="Id"></ext:ModelField>
                    <ext:ModelField Name="CourseTimeDesc"></ext:ModelField>
                    <ext:ModelField Name="CourseName"></ext:ModelField>
                    <ext:ModelField Name="Theorical"></ext:ModelField>
                    <ext:ModelField Name="Practical"></ext:ModelField>
                    <ext:ModelField Name="StartDate" Type="Date"></ext:ModelField>
                    <ext:ModelField Name="EndDate" Type="Date"></ext:ModelField>
                    <ext:ModelField Name="Day"></ext:ModelField>
                    <ext:ModelField Name="StartTime"></ext:ModelField>
                    <ext:ModelField Name="EndTime"></ext:ModelField>
                    <ext:ModelField Name="Duration"></ext:ModelField>
                    <ext:ModelField Name="Week"></ext:ModelField>
                </Fields>
            </ext:Store>
        </Store>
        <Items>
            <ext:Hidden runat="server" ID="hdnCoursetime"></ext:Hidden>     

        </Items>
        <ColumnModel>
            <Columns>
                <ext:Column runat="server" DataIndex="Desc" Text="Ders Saati" Flex="2"></ext:Column>
                <ext:Column runat="server" DataIndex="Day" Text="Gün" Flex="2"></ext:Column>
                <ext:Column runat="server" DataIndex="CourseTimeDesc" Text="Başlangıç ve Bitiş Saatleri" Flex="2"></ext:Column>
                <ext:Column runat="server" DataIndex="Duration" Text="Süre" Flex="1"></ext:Column>
                <ext:CommandColumn runat="server" Width="135">
                   <Commands>
                        <ext:GridCommand CommandName="UpdateCourseTime" Icon="ApplicationEdit" ToolTip-Text="Güncelle"></ext:GridCommand>
                        <ext:GridCommand CommandName="DeleteCourseTime" Icon="Delete" ToolTip-Text="Sil"></ext:GridCommand>
                    </Commands>
                    <DirectEvents>
                        <Command OnEvent="Command">
                            <EventMask ShowMask="true" Msg="Lütfen bekleyiniz.."></EventMask>
                            <ExtraParams>
                                <ext:Parameter Mode="Raw" Name="command" Value="command"></ext:Parameter>
                                <ext:Parameter Mode="Raw" Name="Id" Value="record.data.Id"></ext:Parameter>
                                <ext:Parameter Mode="Raw" Name="coursename" Value="record.data.CourseName"></ext:Parameter>
                                <ext:Parameter Mode="Raw" Name="desc" Value="record.data.Desc"></ext:Parameter>
                                <ext:Parameter Mode="Raw" Name="coursetimedesc" Value="record.data.CourseTimeDesc"></ext:Parameter>
                                <ext:Parameter Mode="Raw" Name="duration" Value="record.data.Duration"></ext:Parameter>

                            </ExtraParams>
                        </Command>
                    </DirectEvents>
                </ext:CommandColumn>
            </Columns>
        </ColumnModel>

    </ext:GridPanel>
            </Items>
            <Buttons>
            <ext:Button runat="server" ID="btnCourseTimeSave" Icon="DatabaseSave" Text="Kaydet" OnDirectClick="btnSave_DirectClick">
                <DirectEvents>
                    <Click>
                        <EventMask ShowMask="true" Msg="Lütfen bekleyiniz..."></EventMask>
                    </Click>
                </DirectEvents>
            </ext:Button>
            <ext:Button runat="server" ID="btnKapatCourseTime" Icon="Delete" Text="Vazgeç" OnDirectClick="btnKapatCourseTime_DirectClick" ></ext:Button>
        </Buttons>
        </ext:Window>


        <ext:Window runat="server" ID="windeleteYesNo" Title="Silinsin Mi?" Modal="true" Hidden="true" Width="180">
            <Items>
                <ext:Hidden runat="server" ID="hdnDeleteYesNoId"></ext:Hidden>
            </Items>
            <Buttons>
            <ext:Button runat="server" ID="btnDeleteYes" Icon="Accept" Text="Sil" OnDirectClick="btnDeleteYes_DirectClick">
                <DirectEvents>
                    <Click>
                        <EventMask ShowMask="true" Msg="Lütfen bekleyiniz..."></EventMask>
                    </Click>
                </DirectEvents>
            </ext:Button>
            <ext:Button runat="server" ID="btnDeleteNo" Icon="Delete" Text="Vazgeç" OnDirectClick="btnDeleteNo_DirectClick" ></ext:Button>
        </Buttons>
        </ext:Window>


    <ext:Window runat="server" ID="winUpdateCourseTime" Title="Ders Bilgisi Değişikliği" Modal="true" Hidden="true" Width="400">
        <Items>
        <ext:Hidden runat="server" ID="hdnUpdateCourseTime"></ext:Hidden>
            <ext:TextField runat="server" ID="txtCourseNameUpdate" DataIndex="Desc" FieldLabel="Ders Bilgisi" Padding="3" LabelWidth="150" Width="300"></ext:TextField>
             <ext:ComboBox runat="server" ID="cbDayUpdate" FieldLabel="Gün" Editable="false"  Width="300">
                <Items>
                    <ext:ListItem Text="Pazartesi" Value="0"></ext:ListItem>
                    <ext:ListItem Text="Salı" Value="1"></ext:ListItem>
                    <ext:ListItem Text="Çarşamba" Value="2"></ext:ListItem>
                    <ext:ListItem Text="Perşembe" Value="3"></ext:ListItem>
                    <ext:ListItem Text="Cuma" Value="4"></ext:ListItem>
                </Items>
               </ext:ComboBox>
            <ext:TextField runat="server" ID="txtStartTime" DataIndex="StartTime" FieldLabel="Başlangıç Saati" Padding="3" LabelWidth="150" Width="300"  OnDirectSelect="timeSelectTİme"></ext:TextField>
            <ext:TextField runat="server" ID="txtEndTime" DataIndex="EndTime" FieldLabel="Bitiş Saati" Padding="3" LabelWidth="150" Width="300" OnDirectChange="timeSelectTİme"></ext:TextField>
            <ext:TextField runat="server" ID="txtDurationTime"  FieldLabel="Süre" Padding="3" LabelWidth="150" Width="300"></ext:TextField>

        </Items>
        <Buttons>
            <ext:Button runat="server" ID="btnUpdateSave" Icon="DatabaseSave" Text="Kaydet" OnDirectClick="btnUpdateSave_DirectClick">
                <DirectEvents>
                    <Click>
                        <EventMask ShowMask="true" Msg="Lütfen bekleyiniz..."></EventMask>
                    </Click>
                </DirectEvents>
            </ext:Button>
            <ext:Button runat="server" ID="btnKapat" Icon="Delete" Text="Vazgeç" OnDirectClick="btnKapatUpdate_DirectClick" ></ext:Button>
        </Buttons>
    </ext:Window>


      <ext:Window runat="server" ID="winStudentList" Title="Öğrenci Listesi" Modal="true" Hidden="true" Width="800">
        <Items>
            <ext:Hidden runat="server" ID="hdnStudent"></ext:Hidden> 

        </Items>
          <Items>
        <ext:GridPanel runat="server" ID="grdStudentList" Flex="1">
        <TopBar>
            <ext:Toolbar runat="server">
                <Items>
                    <ext:Button runat="server" ID="btnStudentAdd" Icon="Add" OnDirectClick="btnStudentAdd_DirectClick"></ext:Button>
                    <ext:Button runat="server" ID="btnExcel" Icon="Page" OnDirectClick="btnExcel_DirectClick"></ext:Button>                  
                </Items>
            </ext:Toolbar>
        </TopBar>
        <Store>
            <ext:Store runat="server">
                <Fields>
                    <ext:ModelField Name="Id"></ext:ModelField>
                    <ext:ModelField Name="CourseRef"></ext:ModelField>
                    <ext:ModelField Name="StudentNameSurname"></ext:ModelField>
                    <ext:ModelField Name="StudentNumber"></ext:ModelField>
                </Fields>
            </ext:Store>
        </Store>
        <ColumnModel>
            <Columns>
                <ext:Column runat="server" DataIndex="StudentNameSurname" Text="Öğrenci Adı" Flex="2"></ext:Column>
                <ext:Column runat="server" DataIndex="StudentNumber" Text="Öğrenci Numarası" Flex="1"></ext:Column>
            </Columns>
        </ColumnModel>
    </ext:GridPanel>
     </Items>

        <Buttons>
            <ext:Button runat="server" ID="btnSaveStudent" Icon="DatabaseSave" Text="Kaydet" OnDirectClick="btnStudentSave_DirectClick">
                <DirectEvents>
                    <Click>
                        <EventMask ShowMask="true" Msg="Lütfen bekleyiniz..."></EventMask>
                    </Click>
                </DirectEvents>
            </ext:Button>
            <ext:Button runat="server" ID="btnKapatStudentList" Icon="Delete" Text="Vazgeç" OnDirectClick="btnKapatStudentList_DirectClick" ></ext:Button>
        </Buttons>
    </ext:Window>


     <ext:Window runat="server" ID="winAddStudent" Title="Öğrenci Kaydı" Modal="true" Hidden="true" Width="460">
        <Items>
            <ext:Hidden runat="server" ID="studentID" DataIndex="Id"></ext:Hidden>
            <ext:Hidden runat="server" ID="hdnCourseRef" DataIndex="CourseRef"></ext:Hidden>
            <ext:TextField runat="server" ID="txtStudentName" FieldLabel="Öğrenci Adı Soyadı" Padding="3" LabelWidth="150" Width="300" MinValue="0"></ext:TextField>
            <ext:TextField runat="server" ID="txtStudentNumber" FieldLabel="Öğrenci Numarası" Padding="3" LabelWidth="150" Width="300" MinValue="0"></ext:TextField>
        </Items>
        <Buttons>
            <ext:Button runat="server" ID="btnStudentSave" Icon="DatabaseSave" Text="Kaydet" OnDirectClick="btnStudentSave_DirectClick">
                <DirectEvents>
                    <Click>
                        <EventMask ShowMask="true" Msg="Lütfen bekleyiniz..."></EventMask>
                    </Click>
                </DirectEvents>
            </ext:Button>
            <ext:Button runat="server" ID="btnKapatOgrEkle" Icon="Delete" Text="Vazgeç" OnDirectClick="btnKapatOgrEkle_DirectClick" ></ext:Button>
        </Buttons>
    </ext:Window>



    <ext:Window runat="server" ID="winRollBack" Title="Yoklama Listesi" Modal="true" Hidden="true" Width="460">
        <Items>
            <ext:Hidden runat="server" ID="rollBackId"></ext:Hidden>
            <ext:GridPanel runat="server" ID="gridRollBack" Flex="1">
          <Store>
            <ext:Store runat="server">
                <Fields>
                    <ext:ModelField Name="Id"></ext:ModelField>
                    <ext:ModelField Name="StartDate" Type="Date"></ext:ModelField>   
                    <ext:ModelField Name="CourseName"></ext:ModelField>
                    <ext:ModelField Name="StartTime"></ext:ModelField>
                </Fields>
            </ext:Store>
        </Store>
        <ColumnModel>
            <Columns>
                <ext:Column runat="server" DataIndex="StartDate" Text="Tarih" Flex="2"></ext:Column>
                <ext:Column runat="server" DataIndex="CourseName" Text="Ders" Flex="2"></ext:Column>
                <ext:Column runat="server" DataIndex="StartTime" Text="Başlangıç Saati" Flex="2"></ext:Column>
            </Columns>
        </ColumnModel>
    </ext:GridPanel>
        </Items>
        <Buttons>
            <ext:Button runat="server" ID="btnSaveRollBack" Icon="DatabaseSave" Text="Kaydet" OnDirectClick="btnSaveRollBack_DirectClick">
                <DirectEvents>
                    <Click>
                        <EventMask ShowMask="true" Msg="Lütfen bekleyiniz..."></EventMask>
                    </Click>
                </DirectEvents>
            </ext:Button>
            <ext:Button runat="server" ID="btnKapatRollBack" Icon="Delete" Text="Vazgeç" OnDirectClick="btnKapatRollBack_DirectClick" ></ext:Button>
        </Buttons>
    </ext:Window>


   <ext:Window runat="server" ID="winCourseTimeUpdate" Title="Öğrenci Kaydı" Modal="true" Hidden="true" Width="460">
        <Items>
            <ext:Hidden runat="server" ID="courseTimeUpdateId"></ext:Hidden>
              <ext:ComboBox runat="server" ID="cbDay" FieldLabel="Gün" Editable="false">
                        <Items>
                            <ext:ListItem Text="Pazartesi" Value="0"></ext:ListItem>
                            <ext:ListItem Text="Salı" Value="1"></ext:ListItem>
                            <ext:ListItem Text="Çarşamba" Value="2"></ext:ListItem>
                            <ext:ListItem Text="Perşembe" Value="3"></ext:ListItem>
                            <ext:ListItem Text="Cuma" Value="4"></ext:ListItem>
                        </Items>
                 
               </ext:ComboBox>
           <ext:TimeField runat="server" ID="txtStart" MinTime="9:00" MaxTime="18:00" Increment="30" SelectedTime="10:00"  Format="hh:mm tt" OnDirectSelect="timeSelect"/>
            <ext:TimeField runat="server" ID="txtEnd" MinTime="9:00" MaxTime="18:00" Increment="30" SelectedTime="10:00"  Format="hh:mm tt" OnDirectSelect="timeSelect"/>
            <ext:TextField runat="server" ID="txtDuration"></ext:TextField>
        </Items>
        <Buttons>
            <ext:Button runat="server" ID="Button6" Icon="DatabaseSave" Text="Kaydet" OnDirectClick="btnSaveRollBack_DirectClick">
                <DirectEvents>
                    <Click>
                        <EventMask ShowMask="true" Msg="Lütfen bekleyiniz..."></EventMask>
                    </Click>
                </DirectEvents>
            </ext:Button>
            <ext:Button runat="server" ID="btnWinCourseTimeUpdate" Icon="Delete" Text="Vazgeç" OnDirectClick="btnWinCourseTimeUpdate_DirectClick" ></ext:Button>
        </Buttons>
    </ext:Window>
    </form>
</body>
</html>