<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CourseList.aspx.cs" Inherits="BackEnd.CourseList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <ext:ResourceManager runat="server"></ext:ResourceManager>
    <form id="form1" runat="server">
 <%-- Dersleri listeleyen ekran --%>
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
                                <ext:Parameter Mode="Raw" Name="CourseStudentRef" Value="record.data.CourseStudentRef"></ext:Parameter>
                            </ExtraParams>
                        </Command>
                    </DirectEvents>
                </ext:CommandColumn>
            </Columns>
        </ColumnModel>
    </ext:GridPanel>

    <%-- Ders Ekleme Ekranı --%>
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
            <ext:Button runat="server" ID="btnSave" Icon="DatabaseSave" Text="Kaydet" OnDirectClick="btnNewSave_DirectClick">
                <DirectEvents>
                    <Click>
                        <EventMask ShowMask="true" Msg="Lütfen bekleyiniz..."></EventMask>
                    </Click>
                </DirectEvents>
            </ext:Button>
            <ext:Button runat="server" ID="btnClose" Icon="Delete" Text="Vazgeç" OnDirectClick="btnClose_DirectClick" ></ext:Button>
        </Buttons>
    </ext:Window>
    <%-- Ders Saatleri Değişikliği Ekranı --%>
    <ext:Window runat="server" ID="winCourseTime" Title="Ders Saatleri" Modal="true" Hidden="true" Width="800">
      <items>
       <ext:Hidden runat="server" ID="hdnUpdateCourseTime"></ext:Hidden>
       <ext:GridPanel runat="server" ID="gridPanelCourseTime" Flex="1">
       
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
                    <ext:ModelField Name="Week"></ext:ModelField>
                    <ext:ModelField Name="CourseTimeNo"></ext:ModelField>
                    <ext:ModelField Name="CourseType"></ext:ModelField>
                    <ext:ModelField Name="CourseTimeRef"></ext:ModelField>
                    <ext:ModelField Name="CourseRef"></ext:ModelField>

                </Fields>
            </ext:Store>
        </Store>

        <ColumnModel>
            <Columns>
                <ext:Column runat="server" DataIndex="CourseTimeNo" Text="Ders Bilgisi" Flex="1"></ext:Column>
                <ext:Column runat="server" DataIndex="CourseType" Text="Ders Bilgisi" Flex="1"></ext:Column>
                <ext:Column runat="server" DataIndex="Day" Text="Gün" Flex="2"></ext:Column>
                <ext:Column runat="server" DataIndex="StartTime" Text="Başlangıç Saati" Flex="2" Format="hh:mm:tt"></ext:Column>
                <ext:Column runat="server" DataIndex="EndTime" Text="Bitiş Saati" Flex="2" Format="hh:mm:tt"></ext:Column>
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
                                <ext:Parameter Mode="Raw" Name="CourseTimeRef" Value="record.data.CourseTimeRef"></ext:Parameter> 
                                <ext:Parameter Mode="Raw" Name="CourseTimeNo" Value="record.data.CourseTimeNo"></ext:Parameter> 
                                <ext:Parameter Mode="Raw" Name="CourseRef" Value="record.data.CourseRef"></ext:Parameter> 

  
                            </ExtraParams>
                        </Command>
                    </DirectEvents>
                </ext:CommandColumn>
            </Columns>
        </ColumnModel>
    </ext:GridPanel>
    </items>
         <Buttons>
            <ext:Button runat="server" ID="btnCloseCourseTime" Icon="Delete" Text="Vazgeç" OnDirectClick="btnClose_DirectClick" ></ext:Button>
        </Buttons>
    </ext:Window>

          <%-- Ders Saatleri Değşiklik Güncelleme Ekranı --%>
    <ext:Window runat="server" ID="winUpdateCourseTime" Title="Ders Bilgisi Değişikliği" Modal="true" Hidden="true" Width="400">
        <Items>
            <ext:Hidden runat="server" ID="hdnCourseTimeNo"></ext:Hidden>
             <ext:Hidden runat="server" ID="hdnUpdate"></ext:Hidden>
             <ext:ComboBox runat="server" ID="cbType" FieldLabel="Ders Tipi" Editable="false"  Width="300">
                <Items>
                    <ext:ListItem Text="Theorical" Value="0"></ext:ListItem>
                    <ext:ListItem Text="Practical" Value="1"></ext:ListItem>
                </Items>
               </ext:ComboBox>
             <ext:ComboBox runat="server" ID="cbDay" FieldLabel="Gün" Editable="false"  Width="300">
                <Items>
                    <ext:ListItem Text="Pazartesi" Value="0"></ext:ListItem>
                    <ext:ListItem Text="Salı" Value="1"></ext:ListItem>
                    <ext:ListItem Text="Çarşamba" Value="2"></ext:ListItem>
                    <ext:ListItem Text="Perşembe" Value="3"></ext:ListItem>
                    <ext:ListItem Text="Cuma" Value="4"></ext:ListItem>
                </Items>
               </ext:ComboBox>
            <ext:Hidden runat="server" ID="courseTimeNo" DataIndex="CourseTimeNo"></ext:Hidden>
            <ext:Hidden runat="server" ID="hdnCourseRef" DataIndex="Id"></ext:Hidden>     
            <ext:Hidden runat="server" ID="hdnCoursetime" DataIndex="Id"></ext:Hidden>     
            <ext:TimeField runat="server" ID="txtStartTime" DataIndex="StartTime" FieldLabel="Başlangıç Saati" Padding="3" LabelWidth="150" Width="300" Format="hh\:mm\:ss"    ></ext:TimeField>
            <ext:TimeField runat="server" ID="txtEndTime" DataIndex="EndTime" FieldLabel="Bitiş Saati" Padding="3" LabelWidth="150" Width="300" Format="hh\:mm\:ss"    ></ext:TimeField>

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
            <ext:Button runat="server" ID="btnKapatUpdate" Icon="Delete" Text="Vazgeç" OnDirectClick="btnKapatUpdate_DirectClick" ></ext:Button>
        </Buttons>
    </ext:Window>

       <%-- Öğrenci Listeleme --%>
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
                    <ext:Button runat="server" ID="btnExcel" Icon="Page"></ext:Button>                  
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
        <Items>
            <ext:Button runat="server" ID="btnStudentListClose" Icon="Delete" Text="Kapat" OnDirectClick="btnStudentListClose_DirectClick">
            </ext:Button>
        </Items>
    </ext:Window>
    <%-- Öğrenci Ekleme --%>
    <ext:Window runat="server" ID="winAddStudent" Title="Öğrenci Kaydı" Modal="true" Hidden="true" Width="460">
        <Items>
            <ext:Hidden runat="server" ID="hdnStudentId" DataIndex="Id"></ext:Hidden>
            <ext:Hidden runat="server" ID="hdnCourseStudentRef" DataIndex="CourseRef"></ext:Hidden>
            <ext:TextField runat="server" ID="txtStudentName" FieldLabel="Öğrenci Adı Soyadı" Padding="3" LabelWidth="150" Width="300" MinValue="0"></ext:TextField>
            <ext:TextField runat="server" ID="txtStudentNumber" FieldLabel="Öğrenci Numarası" Padding="3" LabelWidth="150" Width="300" MinValue="0"></ext:TextField>
        </Items>
        <Buttons>
            <ext:Button runat="server" ID="btnStudentSave" Icon="Database" Text="Kaydet" OnDirectClick="btnStudentSave_DirectClick">
            <DirectEvents>
                    <Click>
                        <EventMask ShowMask="true" Msg="Lütfen bekleyiniz..."></EventMask>
                    </Click>
                </DirectEvents>
             </ext:Button>
            <ext:Button runat="server" ID="btnStudentClose" Icon="Delete" Text="Kapat" OnDirectClick="btnStudentClose_DirectClick">

            </ext:Button>
        </Buttons>
     </ext:Window>
  <%-- Yoklama Listemele --%>
          <ext:Window runat="server" ID="wndRollcall" Title="Yoklama Listesi" Modal="true" Hidden="true" Width="800">
        <Items>
            <ext:Hidden runat="server" ID="hdnRollBack"></ext:Hidden> 
        </Items>
          <Items>
        <ext:GridPanel runat="server" ID="GridPnlRollBack" Flex="1">
        <Store>
            <ext:Store runat="server">
                <Fields>
                    <ext:ModelField Name="Id"></ext:ModelField>
                    <ext:ModelField Name="CourseRef"></ext:ModelField>
                    <ext:ModelField Name="Week"></ext:ModelField>
                    <ext:ModelField Name="CourseTimeRef"></ext:ModelField>
                    <ext:ModelField Name="Location"></ext:ModelField>
                    <ext:ModelField Name="CourseStudentRef"></ext:ModelField>
                </Fields>
            </ext:Store>
        </Store>
        <ColumnModel>
            <Columns>
                <ext:Column runat="server" DataIndex="Week" Text="Hafta" Flex="2"></ext:Column>
            </Columns>
        </ColumnModel>
    </ext:GridPanel>
     </Items>
        <Items>
            <ext:Button runat="server" ID="Button3" Icon="Delete" Text="Kapat" OnDirectClick="btnStudentListClose_DirectClick">
            </ext:Button>
        </Items>
    </ext:Window>

    </form>
</body>
</html>
