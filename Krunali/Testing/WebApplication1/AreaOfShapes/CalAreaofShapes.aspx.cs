using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AreaOfShapes
{
    public partial class CalAreaofShapes : System.Web.UI.Page
    {
        CalArea CArea = new CalArea();
        protected void Page_Load(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;

            if (!IsPostBack)
            {
                LoadControls();
            }
        }
       public void LoadControls()
       {   
            PanelCircle.Visible = false;
            PanelRectangle.Visible = false;
            Panelsquare.Visible = false;
            PanelTriangle.Visible = false;
        }

        protected void ddlShapes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlShapes.SelectedValue.ToString () == "Rectangle")
            {
                PanelRectangle.Visible = true;
                btnsubmitRec.Visible = true;
            }

            else if (ddlShapes .SelectedValue .ToString () == "Circle")
            {
                PanelCircle.Visible = true;
                txtconstant.Text = "3.14";
                txtconstant.Enabled = false;
                btnsubmitCir.Visible = true;
            }

            else if (ddlShapes.SelectedValue.ToString() == "Square")
            {
                Panelsquare.Visible = true;
                btnsubmitSqu.Visible = true;
            }

            else if (ddlShapes.SelectedValue.ToString() == "Triangle")
            {
                PanelTriangle.Visible = true;
                btnsubmittri.Visible = true;
            }
        }

        protected void btnsubmitRec_Click(object sender, EventArgs e)
        {
            double res;
            if (txtlenght.Text != null && txtbreadth .Text != null)
            {
                res = CArea.Rectangle(Convert.ToDouble(txtlenght.Text), Convert.ToDouble(txtbreadth.Text));
                lblresult.Text = Convert.ToString(res);
                lblresult.Visible = true;
                lblres.Visible = true;
            }
        }

        protected void btnsubmitCir_Click(object sender, EventArgs e)
        {
            double res;
            if(txtradius.Text != null)
            { 
                res = CArea.Circle(Convert.ToDouble(txtradius.Text), Convert.ToDecimal(txtconstant.Text));
                lblresult.Text = Convert.ToString(res);
                lblresult.Visible = true;
                lblres.Visible = true;
            }
        }

        protected void btnsubmitSqu_Click(object sender, EventArgs e)
        {
            double res;
            if (txtside.Text != null )
            {
                res = CArea.Square(Convert.ToDouble(txtside.Text));
                lblresult.Text = Convert.ToString(res);
                lblresult.Visible = true;
                lblres.Visible = true;
            }
        }

        protected void btnsubmittri_Click(object sender, EventArgs e)
        {
            double res;
            if (txtlenght.Text != null && txtbreadth.Text != null)
            {
                res = CArea.Triangle(Convert.ToDouble(txtbreadthfortriangle.Text), Convert.ToDouble(txtheight.Text));
                lblresult.Text = Convert.ToString(res);
                lblresult.Visible = true;
                lblres.Visible = true;
            }
        }
    }
}