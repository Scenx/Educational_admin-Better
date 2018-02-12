﻿/// <summary>
/// 哈尔滨师范大学教务系统开发
/// 作者:易继勇
/// 邮箱:yijiyong100@163.com
/// qq:610068468
/// 哈尔滨师范大学教务平台图片展示地址:http://photo.sina.com.cn/yijiyong100
/// 如果您有什么问题,将您的问题发送至邮箱yijiyong100@163.com,欢迎大家和我交流讨论,多多希望您提出您宝贵的意见!
using System;
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

public partial class student_student_pastyearMark : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Convert.ToString(Session["stdUserName"]) == "")
        {
            Response.Write("<script language=javascript>location='../TS_login.aspx'</script>");
            return;
        }
        if (Session["stdUserName"].ToString() == "")
        {
            Response.Write("<script language=javascript>alert('请登录');location='../TS_login.aspx'</script>");
        }
        else
        {
            if (!IsPostBack)
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["strcon"]);
                con.Open();
                SqlDataAdapter sda3 = new SqlDataAdapter("select studyYear from ts_xs_studyYear ", con);

                DataSet ds3 = new DataSet();
                sda3.Fill(ds3, "ts_xs_studyYear");
                this.studyYear.DataSource = ds3.Tables["ts_xs_studyYear"];
                this.studyYear.DataTextField = "studyYear";
                this.studyYear.DataBind();
                this.studyYear.Text = Session["currentlyStudyYear"].ToString();
                this.studyNumber.Text = Session["stdUserName"].ToString();
                this.studentname.Text = Session["stdName"].ToString();
                this.speciality.Text = Session["stdSpeciality"].ToString();
                this.college.Text = Session["stdCollege"].ToString();
                this.teachedClass.Text = Session["stdTeachedClass"].ToString();
                this.adminClass.Text = Session["stdAdminClass"].ToString();
                this.studyYear.Items.Insert(0, new ListItem(""));
                con.Close();
                this.bind();

                int index = GridView1.Rows.Count;
                this.search.Text = "一共搜索到" + index + "条成绩信息.";
            }
        }
        
        
    }
    protected void studyYearMark_Click(object sender, EventArgs e)
    {
        Response.Redirect("student_studyYearMark.aspx",false);
    }

    protected void semesterMark_Click(object sender, EventArgs e)
    {
        Response.Redirect("student_semesterMark.aspx",false);
    }

    protected void tiptopMark_Click(object sender, EventArgs e)
    {
        Response.Redirect("student_tiptopMark.aspx",false);
    }

    protected void unpassMark_Click(object sender, EventArgs e)
    {
        Response.Redirect("student_unpassMark.aspx",false);
    }

    public void bind()
    {
        SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["strcon"]);
        con.Open();
        SqlDataAdapter sda = new SqlDataAdapter("select * from ts_xs_Mark where studyNumber='"+ Session["stdUserName"].ToString() +"' order by id", con);
        DataSet ds = new DataSet();
        sda.Fill(ds, "ts_xs_Mark");
        GridView1.DataSource = ds.Tables["ts_xs_Mark"];
        GridView1.DataKeyNames = new string[] { "id" };
        GridView1.DataBind();
        con.Close();
    }

}
