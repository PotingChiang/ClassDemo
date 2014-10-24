using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
#region Additional Namespaces
using eRestaurantSystem.BLL;
using eRestaurantSystem.Entities;
using  EatIn.UI;
#endregion

public partial class DemoPages_WaiterCRUD : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        HiredDate.Text = DateTime.Today.ToShortDateString();
    }

    protected void FetchWaiter_Click(object sender, EventArgs e)
    {
        if (WaiterList.SelectedIndex == 0)
            MessageUserControl.ShowInfo("Please select a waiter before clicking Show Waiter.");
        else
            MessageUserControl.TryRun((ProcessRequest)GetWaiterInfo);
    }
    public void GetWaiterInfo()
    {
        eRestaurantController controller = new eRestaurantController();
        var waiter = controller.GetWaiter(int.Parse(WaiterList.SelectedValue));
        WaiterID.Text = waiter.WaiterID.ToString();
        FirstName.Text = waiter.FirstName;
        LastName.Text = waiter.LastName;
        Phone.Text = waiter.Phone;
        Address.Text = waiter.Address;
        HiredDate.Text = waiter.HireDate.ToShortDateString();
        if (waiter.ReleaseDate.HasValue)
            ReleaseDate.Text = waiter.ReleaseDate.Value.ToShortDateString();
    }
    protected void HiredDateCalendarButton_Click(object sender, ImageClickEventArgs e)
    {
        HiredCalendar.Visible = true;
        HiredCalendar.SelectedDate = DateTime.Today;
    }
    protected void ReleaseDateCalendarButton_Click(object sender, ImageClickEventArgs e)
    {
        ReleaseCalendar.Visible = true;
        if (string.IsNullOrEmpty(ReleaseDate.Text))
        {
            ReleaseCalendar.SelectedDate = DateTime.Today;
        }
        else
        {
            ReleaseCalendar.SelectedDate = DateTime.Parse(ReleaseDate.Text);
        }
    }
    protected void HiredCalendar_SelectionChanged(object sender, EventArgs e)
    {
        HiredDate.Text = HiredCalendar.SelectedDate.ToShortDateString();
        HiredCalendar.Visible = false;
    }
    protected void ReleaseCalendar_SelectionChanged(object sender, EventArgs e)
    {
        ReleaseDate.Text = ReleaseCalendar.SelectedDate.ToShortDateString();
        ReleaseCalendar.Visible = false;
    }
    protected void InsertWaiter_Click(object sender, EventArgs e)
    {
        MessageUserControl.TryRun((ProcessRequest)InsertWaiterInfo);
    }
    public void InsertWaiterInfo()
    {
        //the code that exists within this method
        //is a standard CRUD insert which you learned in AppDev 1
        eRestaurantController controller = new eRestaurantController();

        //load an instance of Waiter
        Waiter item = new Waiter();
        item.WaiterID = 0; //identity field on SQL therefore set to 0
        item.FirstName = FirstName.Text;
        item.LastName = LastName.Text;
        item.Phone = Phone.Text;
        item.Address = Address.Text;
        item.HireDate = DateTime.Parse(HiredDate.Text);
        if (string.IsNullOrEmpty(ReleaseDate.Text))
        {
            item.ReleaseDate = null;
        }
        else
        {
            item.ReleaseDate = DateTime.Parse(ReleaseDate.Text);
        }

        //call the controller's Add method for the Waiter
        controller.Waiter_Add(item);

        //rebind the drop down list (WaiterList) so the new
        //waiter will appear in the list
        WaiterList.DataBind();
    }
    protected void UpdateWaiter_Click(object sender, EventArgs e)
    {

    }
}