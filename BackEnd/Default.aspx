<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="BackEnd.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <ext:ResourceManager runat="server"></ext:ResourceManager>
    <form id="form1" runat="server">
        <ext:Window runat="server" Modal="true" Title="Kullanıcı Girişi" Width="400">
        <Items>
            <ext:TextField runat="server" ID="txtMail"  FieldLabel="Username" Padding="3"> </ext:TextField>
            <ext:TextField runat="server" ID="txtPassword" FieldLabel="Password" Vtype="password" Padding="3" InputType="Password"></ext:TextField>
        </Items>
        <Buttons>
             <ext:Button runat="server" Text="Login" OnDirectClick="LoginClick">
                 <DirectEvents>
                     <Click>
                         <EventMask Msg="Lütfen Bekleyiniz..." ShowMask="true"></EventMask>
                     </Click>
                 </DirectEvents>
             </ext:Button>
        </Buttons>
    </ext:Window>
    </form>
</body>
</html>
