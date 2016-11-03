<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="resultat.aspx.cs" Inherits="JE_Bank.rasultat" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <div> <h4>Resultat</h4></div>
        <div class="box"> 
            <asp:Label ID="lbresultat1" runat="server" Text="Ditt RESULTAT" Visible="false"></asp:Label>
            <div><asp:Label ID="lbresultat2" runat="server" Text="hejåhåå" Visible="false"></asp:Label></div>
            <div><asp:Label ID="lbresultat3" runat="server" Text="hejåhåå" Visible="false"></asp:Label></div>
            <div><asp:Label ID="lbresultat4" runat="server" Text="hejåhåå" Visible="false"></asp:Label></div>
            <div><asp:Label ID="lbresultat5" runat="server" Text="hejåhåå" Visible="false"></asp:Label></div>
            <div>
            <h5> Dina resultat</h5>
                <div class ="result">
                    
                    <p>Typ av prov</p>
                    <div> <asp:Label ID="lbtypav1" runat="server" Text="Kunskapsprov"></asp:Label> </div>
                    <div><asp:Label ID="lbtypav2" runat="server" Text="Licensprov"></asp:Label> </div>
                </div>
            <div class ="result"> <p> Resultat</p>
            <div><asp:Label ID="lbkunskapG" runat="server"></asp:Label></div>
            <div><asp:Label ID="lbLicensG" runat="server"></asp:Label></div>
            
             </div>
                <div class ="result">
                    <p> Datum</p>
                    <div><asp:Label ID="lbkunskapD" runat="server"></asp:Label></div>
                    <div><asp:Label ID="lbLicensD" runat="server"></asp:Label></div>
                </div>
            <br />
            
            </div>
        </div>
        <div>

        </div>

        
      
    </div>
</asp:Content>
