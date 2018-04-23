using System;
using System.Collections.Generic;
using DevExpress.Web.ASPxGridView;

public partial class _Default : System.Web.UI.Page {

    protected override void OnInit(EventArgs e) {
        base.OnInit(e);
        grid.DataSource = Data;
        grid.DataBind();
        if(!IsPostBack) {
            grid.Selection.SelectRow(3);
            grid.Selection.SelectRow(4);
            grid.Selection.SelectRow(8);
            grid.Selection.SelectRow(10);
        }
    }

    List<SampleDataItem> Data {
        get {
            const string key = "4c92cd2e-241b-49e7-8a13-92a64132b16c";            
            if(Session[key] == null)
                Session[key] = CreateData();
            return (List<SampleDataItem>)Session[key];
        }
    }

    List<SampleDataItem> CreateData() {
        List<SampleDataItem> result = new List<SampleDataItem>();
        result.Add(new SampleDataItem("Chai", 39));
        result.Add(new SampleDataItem("Chang", 17));
        result.Add(new SampleDataItem("Aniseed Syrup", 13));
        result.Add(new SampleDataItem("Chef Anton's Cajun Seasoning", 53));
        result.Add(new SampleDataItem("Chef Anton's Gumbo Mix", 0));
        result.Add(new SampleDataItem("Grandma's Boysenberry Spread", 120));
        result.Add(new SampleDataItem("Uncle Bob's Organic Dried Pears", 15));
        result.Add(new SampleDataItem("Northwoods Cranberry Sauce", 6));
        result.Add(new SampleDataItem("Mishi Kobe Niku", 29));
        result.Add(new SampleDataItem("Ikura", 31));
        result.Add(new SampleDataItem("Queso Cabrales", 22));
        result.Add(new SampleDataItem("Queso Manchego La Pastora", 86));
        result.Add(new SampleDataItem("Konbu", 24));
        result.Add(new SampleDataItem("Tofu", 35));
        result.Add(new SampleDataItem("Genen Shouyu", 39));
        result.Add(new SampleDataItem("Pavlova", 29));
        return result;
    }

    protected void grid_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e) {
        if(e.Parameters == "up")
            MoveSelection(-1);
        if(e.Parameters == "down")
            MoveSelection(1);
    }

    void MoveSelection(int offset) {
        if(grid.Selection.Count < 1) return;
        if(!CanMoveSelection(offset)) return;

        int count = Data.Count;
        SampleDataItem[] temp = new SampleDataItem[count];        
        for(int i = 0; i < count; i++) {
            if(grid.Selection.IsRowSelected(i))
                temp[i + offset] = Data[i];
        }
        int index = 0;
        for(int i = 0; i < count; i++) {
            if(grid.Selection.IsRowSelected(i)) continue;
            while(temp[index] != null)
                index++;
            temp[index] = Data[i];
            index++;    
        }

        Data.Clear();
        Data.AddRange(temp);
        grid.DataBind();
        // Optionally persist the list
    }
    bool CanMoveSelection(int offset) {
        int minIndex = int.MaxValue;
        int maxIndex = int.MinValue;
        for(int i = 0; i < grid.VisibleRowCount; i++) {
            if(!grid.Selection.IsRowSelected(i)) continue;
            if(i < minIndex) minIndex = i;
            if(i > maxIndex) maxIndex = i;
        }
        return minIndex + offset > -1 && maxIndex + offset < grid.VisibleRowCount;
    }
}
