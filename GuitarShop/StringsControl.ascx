<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="StringsControl.ascx.cs" Inherits="GuitarShop.StringsControl" %>
<style type="text/css">
    .auto-style1 {
        width: 323px;
    }
    .auto-style4 {
        height: 48px;
    }
    .auto-style5 {
        width: 323px;
        height: 48px;
    }
    .auto-style6 {
        height: 4px;
    }
    .auto-style7 {
        width: 323px;
        height: 4px;
    }
    .auto-style8 {
        height: 5px;
    }
    .auto-style9 {
        width: 323px;
        height: 5px;
    }
    #Table1 {
        margin-right: 117px;
    }
</style>
<Table ID="Table1" runat="server"  Width="500px" dir="ltr">
    <tr>
        <td>
            <asp:Label ID="labelID" runat="server" AssociatedControlID="InputID">Идентификационен номер:</asp:Label>
       </td>
        <td class="auto-style1">     
            <asp:TextBox ID="InputID" runat="server" MaxLength="20"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" ErrorMessage="* Задължително поле" ControlToValidate="InputID"
                ForeColor="Red" Display="Dynamic" runat="server" />
            <asp:CustomValidator ID="SID" ControlToValidate="InputID"
                Display="Dynamic" ForeColor="Red" OnServerValidate="ValidateID" runat="server" />
        </td>
    </tr>
    <tr>
        <td class="auto-style8">
            <asp:Label ID="labelInputType" runat="server" AssociatedControlID="InputType">Вид струни:</asp:Label>
        </td> 
        <td class="auto-style8">
            <asp:DropDownList ID="InputType" runat="server">
                <asp:ListItem>electric_guitar_strings</asp:ListItem>
                <asp:ListItem>acoustic_guitar_strings</asp:ListItem>
                <asp:ListItem>classical_guitar_strings</asp:ListItem>
            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ErrorMessage="* Задължително поле" ControlToValidate="InputType"
                ForeColor="Red" Display="Dynamic" runat="server" />            
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="labelManufacturer" runat="server" AssociatedControlID="InputManufacturer">Производител:</asp:Label>
       </td>
        <td class="auto-style1">     
            <asp:TextBox ID="InputManufacturer" runat="server" MaxLength="20"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvManufacturer" ErrorMessage="* Задължително поле" ControlToValidate="InputManufacturer"
                ForeColor="Red" Display="Dynamic" runat="server" />
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="labelGauge" runat="server" AssociatedControlID="InputGauge">Размер:</asp:Label>
        </td>    
        <td class="auto-style1">
            <asp:TextBox ID="InputGauge" runat="server" MaxLength="5"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ErrorMessage="* Задължително поле" ControlToValidate="InputGauge"
                ForeColor="Red" Display="Dynamic" runat="server" />
            <asp:CustomValidator ID="CVG" ControlToValidate="InputGauge"
                Display="Dynamic" ForeColor="Red" OnServerValidate="ValidateGauge" runat="server" />
        </td>
    </tr>
    <tr>
        <td class="auto-style4">
            <asp:Label ID="labelDescription" runat="server" AssociatedControlID="InputDescription">Описание:</asp:Label>
        </td>    
        <td class="auto-style5">
            <asp:TextBox ID="InputDescription" runat="server" MaxLength="400" Rows="2" TextMode="MultiLine"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ErrorMessage="* Задължително поле" ControlToValidate="InputDescription"
                ForeColor="Red" Display="Dynamic" runat="server" />
        </td>
    </tr>
    <tr>
        <td class="auto-style8">
            <asp:Label ID="labelPrice" runat="server" AssociatedControlID="InputPrice">Цена:</asp:Label>
        </td> 
        <td class="auto-style9">
            <asp:TextBox ID="InputPrice" runat="server" ></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ErrorMessage="* Задължително поле" ControlToValidate="InputPrice"
                ForeColor="Red" Display="Dynamic" runat="server" />
            <asp:CustomValidator ID="SP" ControlToValidate="InputPrice"
                Display="Dynamic" ForeColor="Red" OnServerValidate="ValidatePrice" runat="server" />
        </td>
        <td class="auto-style8">
            <asp:DropDownList ID="InputCurrency" runat="server">
                <asp:ListItem>BGN</asp:ListItem>
                <asp:ListItem>EUR</asp:ListItem>
                <asp:ListItem>USD</asp:ListItem>
            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ErrorMessage="* Задължително поле" ControlToValidate="InputCurrency"
                ForeColor="Red" Display="Dynamic" runat="server" />            
        </td>
    </tr>
</Table>