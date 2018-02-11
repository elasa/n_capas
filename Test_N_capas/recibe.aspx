<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="recibe.aspx.cs" Inherits="Test_N_capas.recibe" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager runat="server"></asp:ScriptManager>
        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <asp:Label ID="lblId" runat="server"></asp:Label><br />
                <asp:TextBox ID="txtTelefono" runat="server"></asp:TextBox><br />
                <asp:DropDownList ID="ddlUsuarios" runat="server" OnSelectedIndexChanged="ddlUsuarios_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                <asp:Button ID="btnUpdate" Text="Actualizar" runat="server" OnClick="btnUpdate_Click" />
                <asp:Button ID="btnCancel" Text="Cancelar" runat="server" OnClick="btnCancel_Click" />
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>
