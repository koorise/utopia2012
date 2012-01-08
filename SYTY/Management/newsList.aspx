<%@ Page Title="" Language="C#" MasterPageFile="~/Management/MasterPage.master" AutoEventWireup="true" CodeFile="newsList.aspx.cs" Inherits="Management_newsList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:AccessDataSource ID="AccessDataSource1" runat="server" 
        DataFile="~/App_Data/Database.mdb" 
        DeleteCommand="DELETE FROM [ty_article] WHERE [ID] = ?" 
        InsertCommand="INSERT INTO [ty_article] ([ID], [typeid], [Title], [content]) VALUES (?, ?, ?, ?)" 
        SelectCommand="SELECT ty_article.ID, ty_article.typeid, ty_article.Title, ty_article.content, sys_article_type.typename FROM (ty_article INNER JOIN sys_article_type ON ty_article.typeid = sys_article_type.ID) ORDER BY ty_article.ID DESC" 
        
        UpdateCommand="UPDATE [ty_article] SET [typeid] = ?, [Title] = ?, [content] = ? WHERE [ID] = ?">
        <DeleteParameters>
            <asp:Parameter Name="ID" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="ID" Type="Int32" />
            <asp:Parameter Name="typeid" Type="Int32" />
            <asp:Parameter Name="Title" Type="String" />
            <asp:Parameter Name="content" Type="String" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="typeid" Type="Int32" />
            <asp:Parameter Name="Title" Type="String" />
            <asp:Parameter Name="content" Type="String" />
            <asp:Parameter Name="ID" Type="Int32" />
        </UpdateParameters>
    </asp:AccessDataSource>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        CellPadding="4" DataSourceID="AccessDataSource1" EnableModelValidation="True" 
        ForeColor="#333333" GridLines="None" AllowPaging="True" 
        HorizontalAlign="Center" Width="90%">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" 
                SortExpression="ID" >
            <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
             <asp:BoundField DataField="typename" HeaderText="分类" 
                SortExpression="typename" >
            <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="Title" HeaderText="标题" SortExpression="Title" />
             <asp:HyperLinkField DataNavigateUrlFields="ID" 
                DataNavigateUrlFormatString="~/management/newsEdit.aspx?id={0}" Text="编辑" />
            <asp:HyperLinkField DataNavigateUrlFields="ID" 
                DataNavigateUrlFormatString="~/management/newsDel.aspx?id={0}" Text="删除" />
        </Columns>
        <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
        <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
    </asp:GridView>
    </asp:Content>

