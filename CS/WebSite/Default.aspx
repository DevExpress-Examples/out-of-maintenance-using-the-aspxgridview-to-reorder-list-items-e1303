<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" %>
<%@ Register Assembly="DevExpress.Web.v14.1" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v14.1" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
		<dx:ASPxGridView runat="server" ID="grid" ClientInstanceName="grid" KeyFieldName="Pk" OnCustomCallback="grid_CustomCallback">
			<Columns>
				<dx:GridViewDataTextColumn FieldName="Title" />
				<dx:GridViewDataTextColumn FieldName="Quantity" />
			</Columns>			
			<Settings ShowStatusBar="Visible" />
			<SettingsBehavior AllowMultiSelection="true" AllowSort="false" />
			<SettingsPager Mode="ShowAllRecords" />
			<SettingsLoadingPanel Mode="Disabled" />
			<Templates>
				<StatusBar>
					<dx:ASPxButton ID="ASPxButton1" runat="server" Text="MoveUp" AutoPostBack="false">
                        <ClientSideEvents Click="function(){ grid.PerformCallback('up');}" />
                    </dx:ASPxButton>
					<dx:ASPxButton ID="ASPxButton2" runat="server" Text="MoveDown" AutoPostBack="false">
						<ClientSideEvents Click="function(){ grid.PerformCallback('down');}" />
					</dx:ASPxButton>
				</StatusBar>
			</Templates>
		</dx:ASPxGridView>
		
    </form>
</body>
</html>
