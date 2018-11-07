<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" %>
<%@ Register Assembly="DevExpress.Web.v13.1" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v13.1" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
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
					<input type="button" onclick="grid.PerformCallback('up')" value="Move up" />
					<input type="button" onclick="grid.PerformCallback('down')" value="Move down" />
				</StatusBar>
			</Templates>
		</dx:ASPxGridView>
		
    </form>
</body>
</html>
