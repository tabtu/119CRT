using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using ttxy.BLL;

public partial class Control_UM_firemanage : System.Web.UI.UserControl
{
    private const string sqlcon = StrUtil.sqlcon;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Bind();
        }
    }

    private void Bind()
    {
        SqlConnection conn = new SqlConnection(sqlcon);
        SqlDataAdapter adq = new SqlDataAdapter("select * from U_firemanage", conn);
        DataSet dataset = new DataSet();
        adq.Fill(dataset, "U_firemanage");
        GridView1.DataSource = dataset;
        GridView1.DataKeyNames = new String[] { "id" };
        GridView1.DataBind();
    }

    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView1.EditIndex = e.NewEditIndex;
        Bind();
    }

    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        SqlConnection conn = new SqlConnection(sqlcon);
        SqlCommand comm = new SqlCommand("delete from U_firemanage where id='" + GridView1.DataKeys[e.RowIndex].Value.ToString() + "'", conn);
        conn.Open();
        try
        {
            int i = Convert.ToInt32(comm.ExecuteNonQuery());
            if (i > 0)
            {
                Response.Write("<script language=javascript>alert('删除成功！')</script>");
            }
            else
            {
                Response.Write("<script language=javascript>alert('删除失败！')</script>");
            }
            Bind();
        }
        catch (Exception erro)
        {
            Response.Write("错误信息:" + erro.Message);
        }
        finally
        {
            conn.Close();
        }
    }

    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        string id = ((TextBox)GridView1.Rows[e.RowIndex].Cells[0].Controls[0]).Text.ToString().Trim();
        string name = ((TextBox)GridView1.Rows[e.RowIndex].Cells[1].Controls[0]).Text.ToString().Trim();
        string aid = ((TextBox)GridView1.Rows[e.RowIndex].Cells[2].Controls[0]).Text.ToString().Trim();
        string des = ((TextBox)GridView1.Rows[e.RowIndex].Cells[3].Controls[0]).Text.ToString().Trim();
        string isu = ((CheckBox)GridView1.Rows[e.RowIndex].Cells[4].Controls[0]).Checked.ToString().Trim();
        SqlConnection conn = new SqlConnection(sqlcon);
        SqlCommand comm = new SqlCommand("update U_firemanage set name='" + name + "' ,aid='" + aid +  "' , description='" + des + "' , isused='" + isu + "' where id='" + GridView1.DataKeys[e.RowIndex].Value.ToString() + "'", conn);
        conn.Open();
        try
        {
            int i = Convert.ToInt32(comm.ExecuteNonQuery());
            if (i > 0)
            {
                Response.Write("<script language=javascript>alert('保存成功！')</script>");
            }
            else
            {
                Response.Write("<script language=javascript>alert('保存失败！')</script>");
            }
            GridView1.EditIndex = -1;
            Bind();
        }
        catch (Exception erro)
        {
            Response.Write("错误信息:" + erro.Message);
        }
        finally
        {
            conn.Close();
        }
    }

    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView1.EditIndex = -1;
        Bind();
    }

    protected void Button_add_Click(object sender, EventArgs e)
    {
        SqlConnection conn = new SqlConnection(sqlcon);
        SqlCommand comm = new SqlCommand("INSERT INTO U_firemanage VALUES ('0', 0, '0', 0)", conn);
        conn.Open();
        try
        {
            int i = Convert.ToInt32(comm.ExecuteNonQuery());
            Bind();
        }
        catch (Exception erro)
        {
            Response.Write("错误信息:" + erro.Message);
        }
        finally
        {
            conn.Close();
        }
    }
}