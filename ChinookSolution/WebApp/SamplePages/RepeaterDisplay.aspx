<%@ Page Title="Repeater Nested Query" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RepeaterDisplay.aspx.cs" Inherits="WebApp.SamplePages.RepeaterDisplay" %>
<%-- to ease working with the properties in your class on this control
    use the ItemType attribute and assign the class name of your data definition
    HeaderTemplate is top of list
    FooterTemplate is bottom of list
    
    ItemTemplate occurs once per DTO record
    AlternatingItemTemplate (every other record)--%>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Displaying a Nested Linq Query in a Repeater</h1>
    
    <asp:Repeater ID="AlbumTracksList" runat="server"
        DataSourceID="AlbumTracksListODS"
        ItemType="ChinookSystem.Data.DTOs.AlbumDTO">
        <HeaderTemplate>
            <h3>Albums and Tracks</h3>
        </HeaderTemplate>
        <ItemTemplate>
            <h5><strong>Album: <%# Item.AlbumTitle %></strong></h5>
            <p>
                <strong>Artist: <%# Item.AlbumArtist %></strong>
                <strong># of Tracks: <%# Item.TrackCount %></strong>
                <strong>Play Time: <%# Item.PlayTime %></strong>
            </p>
            <asp:GridView ID="TrackList" runat="server"
                DataSource="<%# Item.AlbumTracks %>"
                CssClass="table" GridLines="Horizontal" BorderStyle="None">
                
            </asp:GridView>
        </ItemTemplate>
        <FooterTemplate>
            &copy; DMIT 2018 NAIT Course all rights reserved.
        </FooterTemplate>
    </asp:Repeater>
    <asp:ObjectDataSource ID="AlbumTracksListODS" runat="server" 
        OldValuesParameterFormatString="original_{0}"
        SelectMethod="Album_AlbumAndTracks"
        TypeName="ChinookSystem.BLL.AlbumController">
    </asp:ObjectDataSource>

</asp:Content>
