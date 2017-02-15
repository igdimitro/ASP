<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AcousticGuitarControl.ascx.cs" Inherits="GuitarShop.AcousticGuitarControl" %>

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
            <asp:CustomValidator ID="IDAG" ControlToValidate="InputID"
                Display="Dynamic" ForeColor="Red" OnServerValidate="ValidateID" runat="server" />
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="labelInputElectroAcoustic" runat="server" AssociatedControlID="InputElectroAcoustic">Електро-акустична:</asp:Label>
        </td>    
        <td class="auto-style1">
            <asp:DropDownList ID="InputElectroAcoustic" runat="server">
                <asp:ListItem>No</asp:ListItem>
                <asp:ListItem>Yes</asp:ListItem>
            </asp:DropDownList>
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
            <asp:RequiredFieldValidator ID="rfvInputModel" ErrorMessage="* Задължително поле" ControlToValidate="InputModel"
                ForeColor="Red" Display="Dynamic" runat="server" />
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="labelNumStrings" runat="server" AssociatedControlID="InputNumStrings">Брой струни:</asp:Label>       
       </td>
        <td class="auto-style1">
            <asp:DropDownList ID="InputNumStrings" runat="server">
                <asp:ListItem>6</asp:ListItem>
                <asp:ListItem>12</asp:ListItem>
            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="rfvInputNumStrings" ErrorMessage="* Задължително поле" ControlToValidate="InputNumStrings"
                ForeColor="Red" Display="Dynamic" runat="server" />            
        </td>
    </tr>
    <tr>
        <td class="auto-style4">
            <asp:Label ID="labelDescription" runat="server" AssociatedControlID="InputDescription">Описание:</asp:Label>
        </td>    
        <td class="auto-style5">
            <asp:TextBox ID="InputDescription" runat="server" MaxLength="400" Rows="2" TextMode="MultiLine"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvInputDescription" ErrorMessage="* Задължително поле" ControlToValidate="InputDescription"
                ForeColor="Red" Display="Dynamic" runat="server" />
        </td>
    </tr>
    <tr>
        <td class="auto-style6">
            <asp:Label ID="labelPrice" runat="server" AssociatedControlID="InputPrice">Цена:</asp:Label>
        </td> 
        <td class="auto-style7">
            <asp:TextBox ID="InputPrice" runat="server" ></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvPrice" ErrorMessage="* Задължително поле" ControlToValidate="InputPrice"
                ForeColor="Red" Display="Dynamic" runat="server" />
            <asp:CustomValidator ID="PAG" ControlToValidate="InputPrice"
                Display="Dynamic" ForeColor="Red" OnServerValidate="ValidatePrice" runat="server" />
        </td>
        <td class="auto-style6">
            <asp:DropDownList ID="InputCurrency" runat="server">
                <asp:ListItem>BGN</asp:ListItem>
                <asp:ListItem>EUR</asp:ListItem>
                <asp:ListItem>USD</asp:ListItem>
            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="rfvInputCurrency" ErrorMessage="* Задължително поле" ControlToValidate="InputCurrency"
                ForeColor="Red" Display="Dynamic" runat="server" />            
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="labelBody" runat="server" AssociatedControlID="InputBody">Тип тяло:</asp:Label>       
       </td>
        <td class="auto-style1">
            <asp:DropDownList ID="InputBody" runat="server">
                <asp:ListItem>Double-oh</asp:ListItem>
                <asp:ListItem>Triple-oh</asp:ListItem>
                <asp:ListItem>Dreadnought</asp:ListItem>
                <asp:ListItem>Jumbo</asp:ListItem>
            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="rfvInputBody" ErrorMessage="* Задължително поле" ControlToValidate="InputBody"
                ForeColor="Red" Display="Dynamic" runat="server" />            
        </td>
    </tr>
</Table>