<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="admin.aspx.cs" Inherits="JE_Bank.admin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div><asp:Label ID="Lbadmin" runat="server"></asp:Label></div>
    <div><h4>Samtliga anställdas prov</h4></div>
    <div id="listan" runat="server"></div>
    </asp:Content>
