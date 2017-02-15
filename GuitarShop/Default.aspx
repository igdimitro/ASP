<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.Master"
    CodeBehind="Default.aspx.cs" Inherits="GuitarShop.Default" %>

<asp:Content runat="server" ContentPlaceHolderID="head">
    <title>ASP.NET проект</title>
</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="body">
    <div>
        <ol>
            <li>
                <asp:Button runat="server" ID="BtnXmlToDb" Text="Прехвърли XML файловете в БД" PostBackUrl="Transfer_XML_DB.aspx" /></li>
            <li>
                <asp:HyperLink ID="HLinkDataInput" NavigateUrl="DataInput.aspx" runat="server" Text="Въвеждане на данни" /></li>
        </ol>
    </div>
</asp:Content>
