﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="iBatisNetTest.Index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        提示信息： <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        <br />
        <asp:Button ID="BtnAddUser" runat="server" OnClick="BtnAddUser_Click" Text="添加用户" />
    
        <asp:Button ID="BtnUpdateUser" runat="server" OnClick="BtnUpdateUser_Click" Text="修改用户" />
    
        <asp:Button ID="BtnQuery" runat="server" OnClick="BtnQuery_Click" Text="查询用户" />
        <asp:Button ID="BtnDelete" runat="server" OnClick="BtnDelete_Click" Text="删除用户" />
        <br />
    </div>
    </form>
</body>
</html>
