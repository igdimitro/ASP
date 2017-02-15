<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.Master" CodeBehind="DataInput.aspx.cs" Inherits="GuitarShop.DataInput" %>

<asp:Content ContentPlaceHolderID="head" runat="server">
    <title>Въвеждане на данни</title>
        <style type="text/css">
        .InpEmail
        {
            margin-left: 150px;
        }
        .InpPhNumber
        {
            margin-left: 76px;
        }
        .InpPhCode
        {
            margin-left: 95px;
        }
            .auto-style1 {
                width: 154px;
            }
            .auto-style2 {
                height: 1px;
            }
            .auto-style3 {
                height: 30px;
            }
    </style>
</asp:Content>

<asp:Content ContentPlaceHolderID="body" runat="server" >
    <asp:LinkButton ID="LinkButton1" Text="Назад" runat="server" PostBackUrl="~/Default.aspx" CausesValidation="false" />
    <div style="width: 550px; margin-left: auto; margin-right: auto">
    <div runat="server" id="DivSuccess" visible="false">
        <p style="color: Blue">
            Операцията завърши успешно!
        </p>
        <asp:Button ID="btnShowForm" Text="Покажи изпратената форма" runat="server" OnClick="showSubmForm_Click" />
        <asp:Button ID="btnAddNew" Text="Добави нов магазин за китари" runat="server" OnClick="LBtnAddMore_Click" />
   </div>
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <div runat="server" id="DivForm">
        <table>
            <colgroup>
                <col width="208px" />
                <col />
            </colgroup>
            <tr>
                <td>
                    <asp:Label ID="labelGuitarShopID" runat="server" AssociatedControlID="InputGuitarShopID">ID на магазин: *</asp:Label>
                </td>
                <td>
                    <asp:TextBox runat="server" ID="InputGuitarShopID" />
                    <asp:RequiredFieldValidator ID="rfvBsID" ErrorMessage="* Задължително поле" ControlToValidate="InputGuitarShopID"
                        ForeColor="Red" Display="Dynamic" runat="server" />
                    <asp:CustomValidator ID="CustomValidatorGuitarShopID" ControlToValidate="InputGuitarShopID"
                        Display="Dynamic" ForeColor="Red" OnServerValidate="ValidateGuitarShopID" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="labelGuitarShopName" runat="server" AssociatedControlID="InputGuitarShopName">Име на магазин: *</asp:Label>
                </td>
                <td>
                    <asp:TextBox runat="server" ID="InputGuitarShopName" MaxLength="128"/>
                    <asp:RequiredFieldValidator ID="rfvBsName" ErrorMessage="* Задължително поле" ControlToValidate="InputGuitarShopName"
                        ForeColor="Red" Display="Dynamic" runat="server" />
                    <asp:CustomValidator ID="CustomValidatorGuitarShopName" ErrorMessage="* Невалидни символи . / \ + , ; ' : &quot; " ControlToValidate="InputGuitarShopName"
                        OnServerValidate="ValidateGuitarShopName" Display="Dynamic" ForeColor="Red" runat="server" />
                </td>
            </tr>
        </table>
        <fieldset>
            <legend>Контакти</legend>
            <table>
                <colgroup>
                    <col width="202px" />
                    <col />
                </colgroup>
                <tbody>
                    <tr>
                        <td>
                            <asp:Label ID="labelAdress" runat="server" AssociatedControlID="InputAdress">Адрес: </asp:Label>
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="InputAdress" MaxLength="256" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="labelPhone" runat="server" AssociatedControlID="InputPhone">Телефон: *</asp:Label>
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="InputPhone" MaxLength="12"/>
                            <asp:RequiredFieldValidator ID="rfvPhone" ErrorMessage="* Задължително поле" ControlToValidate="InputPhone"
                                ForeColor="Red" Display="Dynamic" runat="server" />
                            <asp:CustomValidator ID="CVInputPhone" ErrorMessage="* Телефонът може да съдържа не повече от 12 цифри! &quot; " ControlToValidate="InputPhone"
                        OnServerValidate="ValidatePhone" Display="Dynamic" ForeColor="Red" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="labelEmail" runat="server" AssociatedControlID="InputEmail">Имейл: *</asp:Label>
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="InputEmail" MaxLength="32" />
                            <asp:RequiredFieldValidator ID="rfvEmail" ErrorMessage="* Задължително поле" ControlToValidate="InputEmail"
                                ForeColor="Red" Display="Dynamic" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style3">
                            <asp:Label ID="labelWebsite" runat="server" AssociatedControlID="InputWebsite">Уебсайт: *</asp:Label>
                        </td>
                        <td class="auto-style3">
                            <asp:TextBox runat="server" ID="InputWebsite" MaxLength="128" />
                            <asp:RequiredFieldValidator ID="rfvWebsite" ErrorMessage="* Задължително поле" ControlToValidate="InputWebsite"
                                ForeColor="Red" Display="Dynamic" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style2">
                        </td>
                        <td class="auto-style2">
                        </td>
                    </tr>
                </tbody>
            </table>
        </fieldset> 
        <fieldset>
            <legend>Електрически китари</legend>
            <asp:UpdatePanel ID="up1" runat="server" style="width: 230px">
                <ContentTemplate>
                    <asp:PlaceHolder runat="server" ID="ElectricGuitarsPlaceHolder"></asp:PlaceHolder>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="btnAddElectricGuitar" EventName="Click" />
                </Triggers>
            </asp:UpdatePanel>
            <br />
            <asp:Button ID="btnAddElectricGuitar" runat="server" Text="Добави полета за нова електрическа китара" OnClick="btnAddElectricGuitar_Click"
                CausesValidation="false" Width="261px" />
        </fieldset>
        <fieldset>
            <legend>Акустични китари</legend>
            <asp:UpdatePanel ID="up2" runat="server" style="width: 230px">
                <ContentTemplate>
                    <asp:PlaceHolder runat="server" ID="AcousticGuitarsPlaceHolder"></asp:PlaceHolder>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="btnAddAcousticGuitar" EventName="Click" />                    
                </Triggers>
            </asp:UpdatePanel>
            <br />
            <asp:Button ID="btnAddAcousticGuitar" runat="server" Text="Добави полета за нова акустична китара" OnClick="btnAddAcousticGuitar_Click"
                CausesValidation="false" Width="261px" />
            <br />
        </fieldset>
        <fieldset>
            <legend>Класически китари</legend>
            <asp:UpdatePanel ID="up3" runat="server" style="width: 230px">
                <ContentTemplate>
                    <asp:PlaceHolder runat="server" ID="ClassicalGuitarsPlaceHolder"></asp:PlaceHolder>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="btnAddClassicalGuitar" EventName="Click" />
                </Triggers>
            </asp:UpdatePanel>
            <br />
            <asp:Button ID="btnAddClassicalGuitar" runat="server" Text="Добави полета за нова класическа китара" OnClick="btnAddClassicalGuitar_Click"
                CausesValidation="false" Width="261px" />
            <br />
        </fieldset>
        <fieldset>
            <legend>Усилватели</legend>
            <asp:UpdatePanel ID="up4" runat="server" style="width: 230px">
                <ContentTemplate>
                    <asp:PlaceHolder runat="server" ID="AmplifiersPlaceHolder"></asp:PlaceHolder>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="btnAddAmplifier" EventName="Click" />
                </Triggers>
            </asp:UpdatePanel>
            <br />
            <asp:Button ID="btnAddAmplifier" runat="server" Text="Добави полета за нов усилвател" OnClick="btnAddAmplifier_Click"
                CausesValidation="false" Width="261px" />
        </fieldset>
        <fieldset>
            <legend>Струни</legend>
            <asp:UpdatePanel ID="up5" runat="server" style="width: 230px">
                <ContentTemplate>
                    <asp:PlaceHolder runat="server" ID="StringsPlaceHolder"></asp:PlaceHolder>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="btnAddStrings" EventName="Click" />
                </Triggers>
            </asp:UpdatePanel>
            <br />
            <asp:Button ID="btnAddStrings" runat="server" Text="Добави полета за нови струни за китара" OnClick="btnAddStrings_Click"
                CausesValidation="false" Width="261px" />
            <br />

        </fieldset>
        <div style="text-align: right">
            <asp:Button ID="BtnSubmit" Text="Запиши магазина" runat="server" OnClick="BtnSubmit_Click" />
        </div>
        <p>
            Изпращането на формата ще създаде XML файл и ще вкара информацията в БД.</p>
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" />
        <%--<asp:Label ID="dssr" runat="server" />--%>
    </div>
</div>
</asp:Content>
