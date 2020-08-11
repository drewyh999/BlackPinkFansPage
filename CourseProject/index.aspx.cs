using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CourseProject
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if(this.MasterPageFile == "~/Nocturnal.Master")
            {
                this.MasterPageFile = "~/Diournal.Master";
            }
            else
            {
                this.MasterPageFile = "~/Nocturnal.Master";
            }
        }
    }
}