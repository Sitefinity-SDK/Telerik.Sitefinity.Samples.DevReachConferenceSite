<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MySessions.ascx.cs" Inherits="SitefinityWebApp.MySessions" %>
<%@ Import Namespace="System.Data.Common" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="Telerik.Sitefinity.RelatedData" %>

<table class="list-sessions">
    <asp:Repeater runat="server" ID="SessionsRepeater">
        <ItemTemplate>
            <tr>
                <td>
                    <h3>
                        <%# Eval("Title")%>
                        <span>
                            <asp:Repeater runat="server" ID="speakers" DataSource='<%# Eval("Speakers")%>'>
                                <ItemTemplate>
                                    <%# Eval("Title") %>, 
                                </ItemTemplate>
                            </asp:Repeater>
                        </span>
                    </h3>
                </td>
                <td><%# Eval("Location.Title")%></td>
                <td class="attended">Attended by <span runat="server"><%# Eval("CurrentAttendees")%></span></td>
                <td>
                    <asp:Button ID="click" class='<%# CheckIsAttended(Container.DataItem)?"small positive":"small negative" %>' runat="server"
                        Text='<%# CheckIsAttended(Container.DataItem)?"Attending":"Will Attend" %>'
                        CommandName='<%# CheckIsAttended(Container.DataItem)?"NotAttend":"Attend" %>'
                        OnCommand="CommandBtn_Click"
                        CommandArgument='<%# Eval("OriginalContentId") %>' />
                <td>
            </tr>
        </ItemTemplate>
    </asp:Repeater>
</table>