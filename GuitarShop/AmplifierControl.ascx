<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AmplifierControl.ascx.cs" Inherits="GuitarShop.AmplifierControl" %>
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
            <asp:CustomValidator ID="IDA" ControlToValidate="InputID"
                Display="Dynamic" ForeColor="Red" OnServerValidate="ValidateID" runat="server" />
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
            <asp:Label ID="labelModel" runat="server" AssociatedControlID="InputModel">Модел:</asp:Label>
        </td>    
        <td class="auto-style1">
            <asp:TextBox ID="InputModel" runat="server" MaxLength="20"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ErrorMessage="* Задължително поле" ControlToValidate="InputModel"
                ForeColor="Red" Display="Dynamic" runat="server" />
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
            <asp:CustomValidator ID="PA" ControlToValidate="InputPrice"
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
    <tr>
        <td class="auto-style6">
            <asp:Label ID="labelInputPower" runat="server" AssociatedControlID="InputType">Мощност:</asp:Label>
        </td> 
        <td class="auto-style7">
            <asp:TextBox ID="InputPower" runat="server" TextMode="Number"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ErrorMessage="* Задължително поле" ControlToValidate="InputPower"
                ForeColor="Red" Display="Dynamic" runat="server" />
            <asp:CustomValidator ID="CVP" ControlToValidate="InputPower"
                Display="Dynamic" ForeColor="Red" OnServerValidate="ValidatePower" runat="server" />
        </td>
        <td class="auto-style6">
            <asp:DropDownList ID="InputPowerUnit" runat="server">
                <asp:ListItem>Watt</asp:ListItem>
                <asp:ListItem>kW</asp:ListItem>
                <asp:ListItem>MW</asp:ListItem>
            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ErrorMessage="* Задължително поле" ControlToValidate="InputCurrency"
                ForeColor="Red" Display="Dynamic" runat="server" />            
        </td>
    </tr>
    <tr>
        <td class="auto-style6">
            <asp:Label ID="labelInputType" runat="server" AssociatedControlID="InputType">Вид/Тип усилвател:</asp:Label>
        </td> 
        <td class="auto-style6">
            <asp:DropDownList ID="InputType" runat="server">
                <asp:ListItem>vacuum_tube</asp:ListItem>
                <asp:ListItem>solid-state</asp:ListItem>
                <asp:ListItem>hybrid</asp:ListItem>
            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" ErrorMessage="* Задължително поле" ControlToValidate="InputType"
                ForeColor="Red" Display="Dynamic" runat="server" />            
        </td>
    </tr>
</Table>