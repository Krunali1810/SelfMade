using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.Expressions;
using System.Data;
using System.Web.UI.DataVisualization.Charting;


namespace CystalReportExample
{
    public partial class ChartExample : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                MakingChart();
            }
        }

        protected void MakingChart()
        {
            DataTable dt = GetData();
            GridView1.DataSource = dt;
            //GridView1.AutoGenerateColumns = true;
            GridView1.DataBind();

            DataTable dtRate = new DataTable("dtRate");
            foreach (TableCell cell in GridView1.HeaderRow.Cells)
            {
                dtRate.Columns.Add(cell.Text.Trim());
            }

            foreach (GridViewRow row in GridView1.Rows)
            {
                dtRate.Rows.Add();
                for (int i = 0; i < row.Cells.Count; i++)
                {
                    dtRate.Rows[row.RowIndex][i] = row.Cells[i].Text.Trim();
                }
            }

            List<string> countries = (from p in dtRate.AsEnumerable()
                                      select p.Field<string>("DepartmentC")).Distinct().ToList();

            if (Chart1.Series.Count() == 1)
                Chart1.Series.Remove(Chart1.Series[0]);
                foreach (string country in countries)
                 {
                    int[] x = (from p in dtRate.AsEnumerable()
                           where p.Field<string>("DepartmentC") == country
                           orderby p.Field<string>("Period_Shown")
                           select Convert.ToInt32(p.Field<string>("Period_Shown"))).ToArray();
                    decimal[] y = (from p in dtRate.AsEnumerable()
                               where p.Field<string>("DepartmentC") == country
                               orderby p.Field<string>("Period_Shown")
                               select Convert.ToDecimal(p.Field<string>("PAR %"))).ToArray();
                Chart1.Series.Add(new Series(country));
                Chart1.Series[country].IsValueShownAsLabel = true;
                Chart1.Series[country].BorderWidth = 3;
                Chart1.Series[country].ChartType = SeriesChartType.FastLine;
                Chart1.Series[country].Points.DataBindXY(x, y);
            }
            Chart1.Legends[0].Enabled = true;
        }

        private DataTable GetData()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("DepartmentC", typeof(string));
            dt.Columns.Add("Period_Shown", typeof(int));
            dt.Columns.Add("PAR %", typeof(decimal));
            dt.Rows.Add("EMW", 2018, 7.98);
            dt.Rows.Add("EMW", 2019, 6.58);
            dt.Rows.Add("ACH", 2015, 5.89);
            dt.Rows.Add("ACH", 2016, 9.87);
            dt.Rows.Add("ACH", 2017, 6.47);
            dt.Rows.Add("ACH", 2018, 7.47);
            dt.Rows.Add("ACH", 2019, 6.77);
            return dt;
        }
    }
}