<%@ Page Title="Fruits" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Fruits.aspx.cs" Inherits="WebFormsExample.Fruits" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h4>All fruits:</h4>
    <ul>
        <asp:ListView runat="server" ID="FruitsLV" SelectMethod="FruitsLV_GetData">
            <ItemTemplate>
                <li>
                    <%# Eval("Title") %>
                    <%# Eval("Price") %> AZN
                    <asp:LinkButton ID="deleteFruit" OnClick="deleteFruit_Click" CommandArgument='<%# Eval("Id") %>' runat="server">Delete</asp:LinkButton>
                </li>
            </ItemTemplate>
        </asp:ListView>
    </ul>
    <br />
    <h4>New fruit:</h4>
    <asp:FormView runat="server" ID="fruitForm" SelectMethod="fruitForm_GetItem" InsertMethod="fruitForm_InsertItem" DefaultMode="Insert">
        <InsertItemTemplate>
            <label>Title:</label>
            <asp:TextBox runat="server" ID="Title" Text='<%# Bind("Title") %>'></asp:TextBox>
            <br />
            <label>Price:</label>
            <asp:TextBox runat="server" ID="Price" Text='<%# Bind("Price") %>'></asp:TextBox>
            <br />
            <asp:Button runat="server" ID="InsertButton" Text="Insert" CommandName="Insert"></asp:Button>
            
        </InsertItemTemplate>
    </asp:FormView>

</asp:Content>
