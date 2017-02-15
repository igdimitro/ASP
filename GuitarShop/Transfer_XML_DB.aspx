<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.Master" CodeBehind="Transfer_XML_DB.aspx.cs" Inherits="GuitarShop.Transfer_XML_DB" %>

<asp:content runat="server" contentplaceholderid="head">

    <title>Обработка на XML файлове</title>
    <style type="text/css">
        .success {
            color: Green;
        }

        .fail {
            color: Red;
        }
    </style>

</asp:content>
<asp:Content ID="Content1" runat="server" contentplaceholderid="body">
    <div>
        <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="~/Default.aspx">Назад</asp:LinkButton>

        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <br />
        <asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="up1">
            <ContentTemplate>
                 <asp:Panel ID="PanelResults" runat="server">
                 </asp:Panel>
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="up2">
            <ContentTemplate> <!-- opravi select-a... -->
                    <asp:SqlDataSource runat="server" DataSourceMode="DataReader" ConnectionString="<%$ ConnectionStrings:GuitarShopConnectionString %>"
                        SelectCommand="SELECT * FROM [GuitarShops]" ID="sqlds">
                    </asp:SqlDataSource> <!-- opravi select-a... -->
                    <asp:GridView ID="GridView1" runat="server" DataSourceID="sqlds" AutoGenerateEditButton="True"
                        AutoGenerateColumns="False" DataKeyNames="GuitarShopID">
                        <Columns>
                            <asp:BoundField HeaderText="ID на магазин" DataField="GuitarShopID" ReadOnly="True" SortExpression="GuitarShopID" />
                            <asp:BoundField HeaderText="Име на магазин" DataField="name" SortExpression="name" />
                        </Columns>
                    </asp:GridView>
                    
                    <asp:SqlDataSource runat="server" DataSourceMode="DataReader" ConnectionString="<%$ ConnectionStrings:GuitarShopConnectionString %>"
                        SelectCommand="SELECT [guitarID], [GuitarShopID], [manufacturer], [model], [number_strings], [number_frets], [price_value], [price_currency], [body], [pickguard], [tremolo] FROM [ElectricGuitars]" ID="sqlds2">
                    </asp:SqlDataSource> <!-- opravi select-a... -->
                    <asp:GridView ID="GridView3" runat="server" DataSourceID="sqlds2" AutoGenerateEditButton="True"
                        AutoGenerateColumns="False" DataKeyNames="guitarID">
                        <Columns>
                            <asp:BoundField HeaderText="ID на китара" DataField="guitarID" ReadOnly="True" SortExpression="guitarID" InsertVisible="False" />
                            <asp:BoundField HeaderText="ID на магазин" DataField="GuitarShopID" SortExpression="GuitarShopID" />
                            <asp:BoundField DataField="manufacturer" HeaderText="Производител" SortExpression="manufacturer" />
                            <asp:BoundField DataField="model" HeaderText="Модел" SortExpression="model" />
                            <asp:BoundField DataField="number_strings" HeaderText="Брой струни" SortExpression="number_strings" />
                            <asp:BoundField DataField="number_frets" HeaderText="Брой прагчета" SortExpression="number_frets" />
                            <asp:BoundField DataField="price_value" HeaderText="Цена" SortExpression="price_value" />
                            <asp:BoundField DataField="price_currency" HeaderText="Валута" SortExpression="price_currency" />
                            <asp:BoundField DataField="body" HeaderText="Тяло" SortExpression="body" />
                            <asp:BoundField DataField="pickguard" HeaderText="Пикгард" SortExpression="pickguard" />
                            <asp:BoundField DataField="tremolo" HeaderText="Тремоло" SortExpression="tremolo" />
                        </Columns>
                    </asp:GridView>


                    <asp:Button ID="Button1" Text="Изпразни БД" runat="server" OnClick="TruncateDB" />                     
            </ContentTemplate>        
        </asp:UpdatePanel>
    </div>
</asp:Content>
