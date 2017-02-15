<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ElectricGuitarControl.ascx.cs" Inherits="GuitarShop.ElectricGuitarControl" %>
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
            <asp:CustomValidator ID="CustomValidator10" ControlToValidate="InputID"
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
        <td>
            <asp:Label ID="labelNumStrings" runat="server" AssociatedControlID="InputNumStrings">Брой струни:</asp:Label>       
       </td>
        <td class="auto-style1">
            <asp:DropDownList ID="InputNumStrings" runat="server">
                <asp:ListItem>6</asp:ListItem>
                <asp:ListItem>7</asp:ListItem>
                <asp:ListItem>8</asp:ListItem>
                <asp:ListItem>9</asp:ListItem>
                <asp:ListItem>10</asp:ListItem>
                <asp:ListItem>12</asp:ListItem>
            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ErrorMessage="* Задължително поле" ControlToValidate="InputNumStrings"
                ForeColor="Red" Display="Dynamic" runat="server" />      
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="labeNumFrets" runat="server" AssociatedControlID="InputNumFrets">Брой прагчета:</asp:Label>       
       </td>
        <td class="auto-style1">
            <asp:DropDownList ID="InputNumFrets" runat="server">
                <asp:ListItem>21</asp:ListItem>
                <asp:ListItem>22</asp:ListItem>
                <asp:ListItem>24</asp:ListItem>
            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ErrorMessage="* Задължително поле" ControlToValidate="InputNumFrets"
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
        <td class="auto-style6">
            <asp:Label ID="labelPrice" runat="server" AssociatedControlID="InputPrice">Цена:</asp:Label>
        </td> 
        <td class="auto-style7">
            <asp:TextBox ID="InputPrice" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ErrorMessage="* Задължително поле" ControlToValidate="InputPrice"
                ForeColor="Red" Display="Dynamic" runat="server" />
            <asp:CustomValidator ID="CustomValidator5" ControlToValidate="InputPrice"
                Display="Dynamic" ForeColor="Red" OnServerValidate="ValidatePrice" runat="server" />
        </td>
        <td class="auto-style6">
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
        <td>
            <asp:Label ID="labelBody" runat="server" AssociatedControlID="InputBody">Тип тяло:</asp:Label>       
       </td>
        <td class="auto-style1">
            <asp:DropDownList ID="InputBody" runat="server">
                <asp:ListItem>Telecaster</asp:ListItem>
                <asp:ListItem>Stratocaster</asp:ListItem>
                <asp:ListItem>SG</asp:ListItem>
                <asp:ListItem>Les_Paul</asp:ListItem>
                <asp:ListItem>Jazzmaster</asp:ListItem>
                <asp:ListItem>Explorer</asp:ListItem>
                <asp:ListItem>Flying_V</asp:ListItem>
                <asp:ListItem>Fully_Hollow</asp:ListItem>
                <asp:ListItem>Thinline_Hollow</asp:ListItem>
                <asp:ListItem>Semi_Hollow</asp:ListItem>
                <asp:ListItem>Other</asp:ListItem>
            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" ErrorMessage="* Задължително поле" ControlToValidate="InputBody"
                ForeColor="Red" Display="Dynamic" runat="server" />            
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="labelInputNeckPickup" runat="server" AssociatedControlID="InputNeckPickup">Адаптер гриф:</asp:Label>
        </td>    
        <td class="auto-style1">
            <asp:DropDownList ID="InputNeckPickup" runat="server">
                <asp:ListItem>single-coil</asp:ListItem>
                <asp:ListItem>humbucker</asp:ListItem>
                <asp:ListItem>piezoelectric</asp:ListItem>
                <asp:ListItem>optical</asp:ListItem>
            </asp:DropDownList>           
            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" ErrorMessage="* Задължително поле" ControlToValidate="InputNeckPickup"
                ForeColor="Red" Display="Dynamic" runat="server" />            
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="labelInputMiddlePickup" runat="server" AssociatedControlID="InputMiddlePickup">Среден адаптер:</asp:Label>
        </td>    
        <td class="auto-style1">
            <asp:DropDownList ID="InputMiddlePickup" runat="server">
                <asp:ListItem>none</asp:ListItem>
                <asp:ListItem>single-coil</asp:ListItem>
                <asp:ListItem>humbucker</asp:ListItem>
                <asp:ListItem>piezoelectric</asp:ListItem>
                <asp:ListItem>optical</asp:ListItem>                
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="labelInputBridgePickup" runat="server" AssociatedControlID="InputBridgePickup">Адаптер мост:</asp:Label>
        </td>    
        <td class="auto-style1">
            <asp:DropDownList ID="InputBridgePickup" runat="server">
                <asp:ListItem>single-coil</asp:ListItem>
                <asp:ListItem>humbucker</asp:ListItem>
                <asp:ListItem>piezoelectric</asp:ListItem>
                <asp:ListItem>optical</asp:ListItem>
            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" ErrorMessage="* Задължително поле" ControlToValidate="InputBridgePickup"
                ForeColor="Red" Display="Dynamic" runat="server" />            
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="labelInputPickguard" runat="server" AssociatedControlID="InputPickguard">Пикгард:</asp:Label>
        </td>    
        <td class="auto-style1">
            <asp:DropDownList ID="InputPickguard" runat="server">
                <asp:ListItem>No</asp:ListItem>
                <asp:ListItem>Yes</asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>
     <tr>
        <td>
            <asp:Label ID="labelInputTremolo" runat="server" AssociatedControlID="InputTremolo">Тремоло:</asp:Label>
        </td>    
        <td class="auto-style1">
            <asp:DropDownList ID="InputTremolo" runat="server">
                <asp:ListItem>No</asp:ListItem>
                <asp:ListItem>Yes</asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>
</Table>





