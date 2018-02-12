﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="std_addGradeTestMark.aspx.cs" Inherits="manager_sysManager_studentManage_std_addGradeTestMark" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>无标题页</title>
    <link href="../../../CSS/CSS.css" rel="stylesheet" type="text/css" />
</head>
<body style="margin-top: 0px; margin-bottom: 0px; margin-right:0px; margin-left:0px" class="css">
    <form id="form1" runat="server">
    <div>
        <table border="0" cellpadding="0" cellspacing="0" style="width: 740px; height: 490px">
            <tr style="height:25px">
                <td colspan="3" style="background-image: url(../../../image/system/main_top_bg.gif); height: 25px;">
                    &nbsp;&nbsp; 学生管理→添加等级考试成绩</td>
            </tr>
            <tr style="height: 465px">
                <td colspan="3" rowspan="2" style="vertical-align: top; background-color: #dee9f9; text-align: left">
                    <table border="1" bordercolordark="#003399" bordercolorlight="#6a82dd" cellpadding="0"
                        cellspacing="0" class="css" style="width: 735px; height: 250px; text-align: left">
                        <tr style="height: 25px">
                            <td style="width: 245px">
                                &nbsp; 学生学号：<asp:TextBox ID="studyNumber" runat="server"
                                    Width="88px"></asp:TextBox>&nbsp;
                                <asp:Button ID="infoExport" runat="server" Text="信息导入" Width="55px" class="btn3_mouseout" EnableViewState="False" OnClick="infoExport_Click" onmousedown="this.className='btn3_mousedown'"
                                    onmouseout="this.className='btn3_mouseout'" onmouseover="this.className='btn3_mouseover'"
                                    onmouseup="this.className='btn3_mouseup'"/>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="studyNumber"
                                    ErrorMessage="学生学号不能为空！">*</asp:RequiredFieldValidator></td>
                            <td style="width: 245px">
                                &nbsp; 考试名称：<asp:DropDownList ID="testName" runat="server" Width="125px">
                                    <asp:ListItem>英语四级等级考试</asp:ListItem>
                                    <asp:ListItem>英语六级等级考试</asp:ListItem>
                                </asp:DropDownList></td>
                            <td style="width: 245px">
                                &nbsp; 学生姓名：<asp:TextBox ID="studentName" runat="server" BackColor="#DEE9F9" ReadOnly="True"></asp:TextBox></td>
                        </tr>
                        <tr style="height: 25px">
                            <td style="width: 245px">
                                &nbsp; 学院名称：<asp:TextBox ID="college" runat="server" BackColor="#DEE9F9" ReadOnly="True"></asp:TextBox></td>
                            <td style="width: 245px">
                                &nbsp; 考试地点：<asp:TextBox ID="testPlace" runat="server" BackColor="#DEE9F9" ReadOnly="True"></asp:TextBox></td>
                            <td style="width: 245px">
                                &nbsp; 身份证号：<asp:TextBox ID="IDcardNumber" runat="server" BackColor="#DEE9F9" ReadOnly="True"></asp:TextBox></td>
                        </tr>
                        <tr style="height: 25px">
                            <td style="width: 245px; height: 24px">
                                &nbsp; 学生专业：<asp:TextBox ID="speciality" runat="server" BackColor="#DEE9F9" ReadOnly="True"></asp:TextBox></td>
                            <td style="width: 245px; height: 24px">
                                &nbsp; 学生年级：<asp:TextBox ID="grade" runat="server" BackColor="#DEE9F9" ReadOnly="True"></asp:TextBox></td>
                            <td style="width: 245px; height: 24px">
                                &nbsp; 考试时间：<asp:TextBox ID="testTime" runat="server" BackColor="#DEE9F9" ReadOnly="True"></asp:TextBox></td>
                        </tr>
                        <tr style="height: 25px">
                            <td style="width: 245px">
                                &nbsp; 考试成绩：<asp:TextBox ID="testMark" runat="server" ReadOnly="True" BackColor="#DEE9F9"></asp:TextBox>&nbsp;
                                <asp:RangeValidator ID="RangeValidator2" runat="server" ControlToValidate="testMark"
                                    ErrorMessage="考试成绩只能在0到710分之间！" MaximumValue="710" MinimumValue="0" Type="Integer" Enabled="False">*</asp:RangeValidator>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="testMark"
                                    ErrorMessage="考试成绩不能为空！" Enabled="False">*</asp:RequiredFieldValidator></td>
                            <td style="width: 245px; color: #000000">
                                &nbsp; 考试总分：<asp:TextBox ID="testTotalMark" runat="server" BackColor="#DEE9F9" ReadOnly="True"></asp:TextBox></td>
                            <td style="width: 245px">
                                &nbsp; 考试类型：<asp:TextBox ID="testStyle" runat="server" BackColor="#DEE9F9" ReadOnly="True"></asp:TextBox></td>
                        </tr>
                        <tr style="height: 25px">
                            <td style="width: 245px">
                                &nbsp; 考试日期：<asp:TextBox ID="testDate" runat="server" BackColor="#DEE9F9" ReadOnly="True"></asp:TextBox></td>
                            <td style="width: 245px">
                                &nbsp; 考试学期：<asp:TextBox ID="testSemester" runat="server" BackColor="#DEE9F9" ReadOnly="True"></asp:TextBox></td>
                            <td style="width: 245px">
                                &nbsp; 准考证号：<asp:TextBox ID="testProveCode" runat="server" BackColor="Transparent"
                                    ReadOnly="True"></asp:TextBox></td>
                        </tr>
                        <tr style="height: 25px">
                            <td style="width: 245px">
                                &nbsp; 考试学年：<asp:TextBox ID="testStudyYear" runat="server" BackColor="#DEE9F9" ReadOnly="True"></asp:TextBox></td>
                            <td style="width: 245px">
                                &nbsp;
                            </td>
                            <td style="width: 245px">
                                &nbsp;
                            </td>
                        </tr>
                        <tr style="height: 75px">
                            <td colspan="3">
                                &nbsp; 考试备注：<asp:TextBox ID="remark" runat="server" Height="55px"
                                    ReadOnly="True" TextMode="MultiLine" Width="636px" BackColor="#DEE9F9"></asp:TextBox>&nbsp;</td>
                        </tr>
                        <tr style="height: 25px">
                            <td colspan="3" style="text-align: center">
                                &nbsp; &nbsp;
                                &nbsp; &nbsp; &nbsp;<asp:Button ID="submit" runat="server" class="btn3_mouseout" OnClick="submit_Click" onmousedown="this.className='btn3_mousedown'"
                                    onmouseout="this.className='btn3_mouseout'" onmouseover="this.className='btn3_mouseover'"
                                    onmouseup="this.className='btn3_mouseup'" Text="提  交" Enabled="False" />
                                &nbsp; &nbsp;&nbsp;
                                <input id="Reset1" type="reset" value="重  置" class="btn3_mouseout" EnableViewState="False" OnClick="submit_Click" onmousedown="this.className='btn3_mousedown'"
                                    onmouseout="this.className='btn3_mouseout'" onmouseover="this.className='btn3_mouseover'"
                                    onmouseup="this.className='btn3_mouseup'"/></td>
                        </tr>
                    </table>
                    <br />
                    <br />
                    &nbsp;&nbsp;
                    <asp:Label ID="submitResult" runat="server" Text="Label" Visible="False" Font-Bold="False" Font-Size="11pt" ForeColor="Red"></asp:Label>
                    <br />
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                        ShowSummary="False" />
                </td>
            </tr>
            <tr>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
