<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="prov.aspx.cs" Inherits="JE_Bank.prov" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div> <h3>Välj prov att genomföra</h3> 
    </div>
    <div> 
        <div class="box">
            <h5>Kompetensprov</h5>
            <p>Kompetensprov innehåller 25 frågor som du ska minsta ha 70% rätt på för att klara.</p>
        </div>
        <div class="box">
            <asp:Button ID="startTest" Text="Starta provet" runat="server" OnClick="startTest_Click" />
        </div>
    </div>
    <div>
        <div class="box">
            <h5>Licensprovet</h5>
            <p>Licensprov innehåller 15 frågor som du ska minsta ha 70% rätt på för att klara.</p>
        </div>
        <div class="box">
        <asp:Button ID="licensprovStart" Text="Starta provet" runat="server" OnClick="licensprovStart_Click" />
        </div>
    </div>
</asp:Content>

