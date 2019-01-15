using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebFormsExample.Services;

namespace WebFormsExample
{
    public partial class Fruits : System.Web.UI.Page
    {
        private FruitService fruitService = new FruitService();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) // при перезагрузке данной странице становится true
            {

            }
        }

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IEnumerable<Fruit> FruitsLV_GetData()
        {
            return fruitService.GetFruits();
        }

        protected void deleteFruit_Click(object sender, EventArgs e)
        {
            LinkButton btn = sender as LinkButton;
            int id = Int32.Parse(btn.CommandArgument);
            fruitService.Remove(id);
            Response.Redirect(Page.Request.Url.ToString(), true);
        }

        // The id parameter should match the DataKeyNames value set on the control
        // or be decorated with a value provider attribute, e.g. [QueryString]int id
        public object fruitForm_GetItem(int id)
        {
            return new Fruit();
        }

        public void fruitForm_InsertItem(Fruit fruit)
        {
            if (ModelState.IsValid)
            {
                fruitService.Add(fruit);
                Response.Redirect(Page.Request.Url.ToString(), true);
            }
        }
    }
}