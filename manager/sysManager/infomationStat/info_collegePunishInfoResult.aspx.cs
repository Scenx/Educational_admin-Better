﻿using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Text;
using System.IO;
using System.Drawing;
/// <summary>
/// 哈尔滨师范大学教务系统开发
/// 作者:易继勇
/// 邮箱:yijiyong100@163.com
/// qq:610068468
/// 哈尔滨师范大学教务平台图片展示地址:http://photo.sina.com.cn/yijiyong100
/// 如果您有什么问题,将您的问题发送至邮箱yijiyong100@163.com,欢迎大家和我交流讨论,多多希望您提出您宝贵的意见!
/// </summary>
public partial class manager_sysManager_infomationStat_info_collegePunishInfoResult : System.Web.UI.Page
{
    BaseClass bc = new BaseClass();
    int currentPageNumber;
    int pageTotalNumber = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Convert.ToString(Session["manName"]) == "")
        {
            Response.Write("<script language=javascript>location='../../../TS_ManagerLogin.aspx'</script>");
            return;
        }
        if (!IsPostBack)
        {
            this.bind();
            if (pageTotalNumber != 0)
            {
                int pageSize = GridView1.PageCount;
                this.totalNumber.Text = Convert.ToString(pageSize);
                for (int i = 0; i < pageSize; i++)
                {

                    this.pageNumber.Items.Add(new ListItem(Convert.ToString(i + 1)));
                }
                this.Label1.Text = "1";
                currentPageNumber = 1;
                if (pageSize == 1)
                {
                    this.firstPage.Enabled = false;
                    this.upPage.Enabled = false;
                    this.lastPage.Enabled = false;
                    this.downPage.Enabled = false;
                }
                else if (pageSize > 1)
                {
                    if (currentPageNumber == 1)
                    {
                        this.firstPage.Enabled = false;
                        this.upPage.Enabled = false;
                        this.lastPage.Enabled = true;
                        this.downPage.Enabled = true;
                    }
                    else if (currentPageNumber == pageSize)
                    {
                        this.lastPage.Enabled = false;
                        this.downPage.Enabled = false;
                        this.upPage.Enabled = true;
                        this.firstPage.Enabled = true;
                    }
                    else
                    {
                        this.lastPage.Enabled = true;
                        this.upPage.Enabled = true;
                        this.downPage.Enabled = true;
                        this.firstPage.Enabled = true;
                    }
                }

            }
        }
    }

    protected void bind()
    {
        if (Convert.ToString(Session["punishSearchTag"]) == "")
        {
            Response.Write("<script language=javascript>location='../../../TS_ManagerLogin.aspx'</script>");
            return;
        }
        string Sql = "";
        if (Session["punishSearchTag"].ToString() == "1")
        {
            if (Session["punishStdStatInfoSQL"].ToString() != "" && Session["punishStdStatGrade"].ToString() != "")
            {

                Sql = "select * from ts_xs_stdPunishInfo where grade ='" + Math.Abs(Convert.ToInt32(Session["punishStdStatGrade"].ToString())) + "' " + Session["punishStdStatInfoSQL"].ToString() + " order by id desc";
            }
        }
        else if (Session["punishSearchTag"].ToString() == "0")
        {
            if (Session["fastpunishStdStatInfoSQL"].ToString() != "")
            {
                Sql = "select * from ts_xs_stdPunishInfo " + Session["fastpunishStdStatInfoSQL"] + " order by id desc";
            }
        }
        DataSet ds = new DataSet();
        ds = bc.GetDataSet(Sql, "ts_xs_stdPunishInfo");

        GridView1.DataSource = ds.Tables["ts_xs_stdPunishInfo"];
        pageTotalNumber = ds.Tables["ts_xs_stdPunishInfo"].Rows.Count;
        GridView1.DataKeyNames = new string[] { "id" };
        GridView1.DataBind();
        int pageSize = GridView1.PageCount;
        this.totalNumber.Text = Convert.ToString(pageSize);
        this.pageNumber.Items.Clear();
        for (int i = 0; i < pageSize; i++)
        {

            this.pageNumber.Items.Add(new ListItem(Convert.ToString(i + 1)));
        }
        //this.pageNumber.Text = Convert.ToString(currentPageNumber);
        if (GridView1.Rows.Count > 0)
        {
            int pageSize1 = GridView1.PageCount;
            this.search.Text = "一共搜索到" + pageTotalNumber + "条受处分的学生信息.   共" + pageSize1 + "页";
        }
        else
        {
            this.Label1.Text = "0";
            this.lastPage.Enabled = false;
            this.upPage.Enabled = false;
            this.downPage.Enabled = false;
            this.firstPage.Enabled = false;
            this.jump.Enabled = false;
            this.export.Enabled = false;
            this.selectAll.Enabled = false;
            this.delete.Enabled = false;
        }
    }
    protected void export_Click(object sender, EventArgs e)
    {
        Export("application/ms-excel", "学生处罚信息报表.xls");

    }

    private void Export(string FileType, string FileName)
    {
        if (Session["punishSearchTag"].ToString() == "")
        {
            Response.Write("<script language=javascript>location='../../../TS_ManagerLogin.aspx'</script>");
            return;
        }
        this.bind();
        SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["strcon"]);
        con.Open();
        string Sql = "";
        if (Session["punishSearchTag"].ToString() == "1")
        {
            if (Session["punishStdStatInfoSQL"].ToString() != "" && Session["punishStdStatGrade"].ToString() != "")
            {

                Sql = "select * from ts_xs_stdPunishInfo where grade ='" + Math.Abs(Convert.ToInt32(Session["punishStdStatGrade"].ToString())) + "' " + Session["punishStdStatInfoSQL"].ToString() + " order by id desc";
            }
        }
        else if (Session["punishSearchTag"].ToString() == "0")
        {
            if (Session["fastpunishStdStatInfoSQL"].ToString() != "")
            {
                Sql = "select * from ts_xs_stdPunishInfo " + Session["fastpunishStdStatInfoSQL"] + " order by id desc";
            }
        }
        DataSet ds = new DataSet();
        ds = bc.GetDataSet(Sql, "ts_xs_stdPunishInfo");
        DataTable dt = ds.Tables["ts_xs_stdPunishInfo"];
        StringBuilder sb = new StringBuilder();
        sb.Append("学号\t身份证号\t姓名\t学院\t专业\t处罚单位\t处罚名称\t处罚日期");
        StringWriter sw = new StringWriter();
        sw.WriteLine(sb.ToString());

        foreach (DataRow r in dt.Rows)
        {
            sb = new StringBuilder();
            sb.Append(r["studyNumber"].ToString());
            sb.Append("\t" + r["IDcardNumber"].ToString());
            sb.Append("\t" + r["studentName"].ToString());
            sb.Append("\t" + r["college"].ToString());
            sb.Append("\t" + r["speciality"].ToString());
            sb.Append("\t" + r["punishUnit"].ToString());
            sb.Append("\t" + r["punishName"].ToString());
            sb.Append("\t" + r["punishDate"]);
            sw.WriteLine(sb.ToString());
        }
        sw.Close();
        Response.Clear();
        Response.AddHeader("Content-Disposition", "attachment; filename=" + HttpUtility.UrlEncode(FileName, Encoding.UTF8).ToString());
        Response.ContentType = FileType;// 指定返回的是一个不能被客户端读取的流，必须被下载 
        Response.ContentEncoding = System.Text.Encoding.Default;//.GetEncoding("GB2312");
        Response.Write(sw);// 把流发送到客户端 
        Response.End();
        con.Close();

    }
    public override void VerifyRenderingInServerForm(Control control)
    {
    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        this.GridView1.PageIndex = e.NewPageIndex;
        this.Label1.Text = Convert.ToString(e.NewPageIndex + 1);
        this.bind();
        int pageSize = GridView1.PageCount;
        currentPageNumber = e.NewPageIndex + 1;
        if (pageSize == 1)
        {
            this.firstPage.Enabled = false;
            this.upPage.Enabled = false;
            this.lastPage.Enabled = false;
            this.downPage.Enabled = false;
        }
        else if (pageSize > 1)
        {
            if (currentPageNumber == 1)
            {
                this.firstPage.Enabled = false;
                this.upPage.Enabled = false;
                this.lastPage.Enabled = true;
                this.downPage.Enabled = true;
            }
            else if (currentPageNumber == pageSize)
            {
                this.lastPage.Enabled = false;
                this.downPage.Enabled = false;
                this.upPage.Enabled = true;
                this.firstPage.Enabled = true;
            }
            else
            {
                this.lastPage.Enabled = true;
                this.upPage.Enabled = true;
                this.downPage.Enabled = true;
                this.firstPage.Enabled = true;
            }
        }
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        int i;
        //执行循环，保证每条数据都可以更新
        for (i = 0; i < GridView1.Rows.Count; i++)
        {
            //首先判断是否是数据行
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //当鼠标停留时更改背景色
                e.Row.Attributes.Add("onmouseover", "c=this.style.backgroundColor;this.style.backgroundColor='#dee9f9'");
                //当鼠标移开时还原背景色
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=c");
            }
        }

        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            if (e.Row.RowState == DataControlRowState.Normal || e.Row.RowState == DataControlRowState.Alternate)
            {
                ((LinkButton)e.Row.Cells[12].Controls[0]).Attributes.Add("onclick", "javascript:return confirm('你确认要删除学号为： \"" + e.Row.Cells[3].Text + "\" 姓名为 \"" + e.Row.Cells[4].Text + "\" 的处罚信息吗?')");
            }
        }
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["strcon"]);
        con.Open();
        string id = GridView1.DataKeys[e.RowIndex].Value.ToString();
        SqlCommand scd = new SqlCommand("delete  from ts_xs_stdPunishInfo where id='" + id + "'", con);
        scd.ExecuteNonQuery();
        con.Close();
        this.bind();
    }
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        string id = GridView1.DataKeys[e.NewEditIndex].Value.ToString();
        Response.Write("<script>window.open('../studentManage/std_addPunishInfoList.aspx?id=" + id + "','','width=740,height=405')</script>");
        Response.Write("<script>location='javascript:history.go(-1)'</script>");
    }
    protected void selectAll_CheckedChanged(object sender, EventArgs e)
    {
        for (int i = 0; i <= GridView1.Rows.Count - 1; i++)
        {
            CheckBox cbox = (CheckBox)GridView1.Rows[i].FindControl("CheckBox1");
            if (this.selectAll.Checked == true)
            {
                cbox.Checked = true;
            }
            else
            {
                cbox.Checked = false;
            }
        }
    }
    protected void delete_Click(object sender, EventArgs e)
    {
        int number = 0;
        ArrayList AL = new ArrayList();
        for (int i = 0; i <= GridView1.Rows.Count - 1; i++)
        {
            CheckBox cbox = (CheckBox)GridView1.Rows[i].FindControl("CheckBox1");
            if (cbox.Checked == true)
            {
                AL.Add(i);
            }
        }
        if (AL.Count > 0)
        {
            for (int i = 0; i < AL.Count - 1; i++)
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["strcon"]);
                con.Open();
                string id = GridView1.DataKeys[(int)AL[i]].Value.ToString();

                string SQL = "delete from ts_xs_stdPunishInfo where id ='" + id + "'";
                bool ss = bc.ExecSQL(SQL);
                if (bc.ExecSQL(SQL))
                {
                    number++;
                }
                else
                {
                    Response.Write(bc.MessageBox("数据提交失败,网络忙！请稍后再试！"));
                }
                con.Close();


            }
            this.bind();

            if (number == AL.Count)
            {
                Response.Write(bc.MessageBox("删除成功！"));
            }
        }
        else
        {
            Response.Write(bc.MessageBox("请您选择要删除的项！"));
        }
    }
    protected void firstPage_Click(object sender, EventArgs e)
    {
        this.GridView1.PageIndex = 0;
        this.Label1.Text = "1";
        this.bind();
        this.pageNumber.Text = "1";
        currentPageNumber = 1;
        int pageSize = GridView1.PageCount;
        if (pageSize == 1)
        {
            this.firstPage.Enabled = false;
            this.upPage.Enabled = false;
            this.lastPage.Enabled = false;
            this.downPage.Enabled = false;
        }
        else if (pageSize > 1)
        {
            if (currentPageNumber == 1)
            {
                this.firstPage.Enabled = false;
                this.upPage.Enabled = false;
                this.lastPage.Enabled = true;
                this.downPage.Enabled = true;
            }
            else if (currentPageNumber == pageSize)
            {
                this.lastPage.Enabled = false;
                this.downPage.Enabled = false;
                this.upPage.Enabled = true;
                this.firstPage.Enabled = true;
            }
            else
            {
                this.lastPage.Enabled = true;
                this.upPage.Enabled = true;
                this.downPage.Enabled = true;
                this.firstPage.Enabled = true;
            }
        }
    }
    protected void upPage_Click(object sender, EventArgs e)
    {
        string size1 = this.Label1.Text;
        int size = Convert.ToInt32(size1);
        currentPageNumber = size - 1;
        this.GridView1.PageIndex = currentPageNumber - 1;
        this.Label1.Text = Convert.ToString(currentPageNumber);
        this.bind();
        int pageSize = GridView1.PageCount;
        if (pageSize == 1)
        {
            this.firstPage.Enabled = false;
            this.upPage.Enabled = false;
            this.lastPage.Enabled = false;
            this.downPage.Enabled = false;
        }
        else if (pageSize > 1)
        {
            if (currentPageNumber == 1)
            {
                this.firstPage.Enabled = false;
                this.upPage.Enabled = false;
                this.lastPage.Enabled = true;
                this.downPage.Enabled = true;
            }
            else if (currentPageNumber == pageSize)
            {
                this.lastPage.Enabled = false;
                this.downPage.Enabled = false;
                this.upPage.Enabled = true;
                this.firstPage.Enabled = true;
            }
            else
            {
                this.lastPage.Enabled = true;
                this.upPage.Enabled = true;
                this.downPage.Enabled = true;
                this.firstPage.Enabled = true;
            }
        }
    }
    protected void downPage_Click(object sender, EventArgs e)
    {
        string size1 = this.Label1.Text;
        int size = Convert.ToInt32(size1);
        currentPageNumber = size + 1;
        this.GridView1.PageIndex = currentPageNumber - 1;
        this.Label1.Text = Convert.ToString(currentPageNumber);
        this.bind();
        int pageSize = GridView1.PageCount;
        if (pageSize == 1)
        {
            this.firstPage.Enabled = false;
            this.upPage.Enabled = false;
            this.lastPage.Enabled = false;
            this.downPage.Enabled = false;
        }
        else if (pageSize > 1)
        {
            if (currentPageNumber == 1)
            {
                this.firstPage.Enabled = false;
                this.upPage.Enabled = false;
                this.lastPage.Enabled = true;
                this.downPage.Enabled = true;
            }
            else if (currentPageNumber == pageSize)
            {
                this.lastPage.Enabled = false;
                this.downPage.Enabled = false;
                this.upPage.Enabled = true;
                this.firstPage.Enabled = true;
            }
            else
            {
                this.lastPage.Enabled = true;
                this.upPage.Enabled = true;
                this.downPage.Enabled = true;
                this.firstPage.Enabled = true;
            }
        }
    }
    protected void lastPage_Click(object sender, EventArgs e)
    {
        int pageSize = GridView1.PageCount;
        this.GridView1.PageIndex = pageSize - 1;
        this.Label1.Text = Convert.ToString(pageSize);
        this.bind();
        this.pageNumber.Text = Convert.ToString(pageSize);
        currentPageNumber = pageSize;

        if (pageSize == 1)
        {
            this.firstPage.Enabled = false;
            this.upPage.Enabled = false;
            this.lastPage.Enabled = false;
            this.downPage.Enabled = false;
        }
        else if (pageSize > 1)
        {
            if (currentPageNumber == 1)
            {
                this.firstPage.Enabled = false;
                this.upPage.Enabled = false;
                this.lastPage.Enabled = true;
                this.downPage.Enabled = true;
            }
            else if (currentPageNumber == pageSize)
            {
                this.lastPage.Enabled = false;
                this.downPage.Enabled = false;
                this.upPage.Enabled = true;
                this.firstPage.Enabled = true;
            }
            else
            {
                this.lastPage.Enabled = true;
                this.upPage.Enabled = true;
                this.downPage.Enabled = true;
                this.firstPage.Enabled = true;
            }
        }
    }
    protected void jump_Click(object sender, EventArgs e)
    {
        string size1 = this.pageNumber.Text;
        int size = Convert.ToInt32(size1);
        this.GridView1.PageIndex = size - 1;
        this.Label1.Text = size1;
        this.bind();
        currentPageNumber = size;
        int pageSize = GridView1.PageCount;
        if (pageSize == 1)
        {
            this.firstPage.Enabled = false;
            this.upPage.Enabled = false;
            this.lastPage.Enabled = false;
            this.downPage.Enabled = false;
        }
        else if (pageSize > 1)
        {
            if (currentPageNumber == 1)
            {
                this.firstPage.Enabled = false;
                this.upPage.Enabled = false;
                this.lastPage.Enabled = true;
                this.downPage.Enabled = true;
            }
            else if (currentPageNumber == pageSize)
            {
                this.lastPage.Enabled = false;
                this.downPage.Enabled = false;
                this.upPage.Enabled = true;
                this.firstPage.Enabled = true;
            }
            else
            {
                this.lastPage.Enabled = true;
                this.upPage.Enabled = true;
                this.downPage.Enabled = true;
                this.firstPage.Enabled = true;
            }
        }
    }
}
