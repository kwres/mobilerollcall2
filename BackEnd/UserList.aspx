<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserList.aspx.cs" Inherits="BackEnd.UserList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <ext:ResourceManager runat="server"></ext:ResourceManager>
    <form id="form1" runat="server">
       <ext:GridPanel runat="server" ID="grdList" Flex="1" Title="Kullanıcı Listesi">
        <TopBar>
            <ext:Toolbar runat="server">
                <Items>
                    <ext:Button runat="server" ID="btnAddNew" Icon="Add" OnDirectClick="btnAddNew_DirectClick"></ext:Button>
                    <ext:ComboBox runat="server" ID="cbUserType" FieldLabel="Kullanıcı Türü" Editable="false">
                        <Items>
                            <ext:ListItem Text="Hepsi" Value="-1"></ext:ListItem>
                            <ext:ListItem Text="Eğitmen" Value="0"></ext:ListItem>
                            <ext:ListItem Text="Öğrenci" Value="1"></ext:ListItem>
                            <ext:ListItem Text="Super Kullanıcı" Value="2"></ext:ListItem>
                        </Items>
                    </ext:ComboBox>
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
                    <ext:ModelField Name="Email"></ext:ModelField>
                    <ext:ModelField Name="UserType"></ext:ModelField>
                    <ext:ModelField Name="State"></ext:ModelField>
                    <ext:ModelField Name="GoogleProfileId"></ext:ModelField>
                </Fields>
            </ext:Store>
        </Store>
        <ColumnModel>
            <Columns>
                <ext:Column runat="server" DataIndex="Email" Text="E-Posta Adresi" Flex="2"></ext:Column>
                <ext:Column runat="server" DataIndex="UserType" Text="Kullanıcı Türü" Flex="1"></ext:Column>
            </Columns>
        </ColumnModel>
    </ext:GridPanel>
        <ext:Window runat="server" ID="wndAddNewUser" Title="Kişi Ekleme" Modal="true" Hidden="true" Width="460">
            <Items>
                <ext:Hidden runat="server" ID="hdnUserAddId"></ext:Hidden>

            </Items>
        </ext:Window>
    </form>
</body>
</html>
