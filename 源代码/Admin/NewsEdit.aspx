<%@ Page Language="C#" AutoEventWireup="true" CodeFile="NewsEdit.aspx.cs" Inherits="chengxusheji.Admin.NewsEdit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
   <link href="Style/Manage.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="JavaScript/Jquery.js"></script>
    <script type="text/javascript" src="JavaScript/Admin.js"></script>
    <script type="text/javascript" src="../js/jsdate.js"></script>
    <script type="text/javascript">
        function CheckIn() {
            var re = /^[0-9]+.?[0-9]*$/;
            var resc=/^[1-9]+[0-9]*]*$/ ;
            var title = document.getElementById("title").value;
            if (title == "") {
                alert("请输入资讯标题...");
                document.getElementById("title").focus();
                return false;
            }

            var content = document.getElementById("content").value;
            if (content == "") {
                alert("请输入资讯内容...");
                document.getElementById("content").focus();
                return false;
            }

            var showFlag = document.getElementById("showFlag").value;
            if (showFlag == "") {
                alert("请输入是否显示...");
                document.getElementById("showFlag").focus();
                return false;
            }

            var publishDate = document.getElementById("publishDate").value;
            if (publishDate == "") {
                alert("请输入发布时间...");
                document.getElementById("publishDate").focus();
                return false;
            }

            return true;
       } 
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="div_All">
    <div class="Body_Title">新闻资讯管理 》》编辑新闻资讯</div>
        <hr />
        <table cellspacing="1" cellpadding="2">
                 <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   资讯图片：</td>
                    <td width="650px;">
                       <table cellpadding="0px" cellspacing="0px" width="90%">
                        <tr><td width="400px">
                         图片路径：<asp:TextBox ID="newsPhoto" runat="server" ReadOnly="True" Width="228px" Enabled="False"></asp:TextBox> &nbsp; &nbsp; &nbsp
                         <br />
                         <br />
                         上传图片：<asp:FileUpload ID="NewsPhotoUpload" runat="server" Width="237px" />&nbsp;
                         <asp:Button ID="Btn_NewsPhotoUpload" runat="server" Text="上传" OnClick="Btn_NewsPhotoUpload_Click" /></td><td>
                         <asp:Image ID="NewsPhotoImage" runat="server" Height="90px" Width="99px" />
                         </td></tr>
                       </table>
                    </td>
                </tr>

                 <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   资讯标题：</td>
                    <td width="650px;">
                         <input id="title" type="text"   style="width:800px;" runat="server" maxlength="25"/><span class="WarnMes">*</span>请输入资讯标题！</td>
                </tr>

                <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                    资讯类别：</td>
                    <td width="650px;">
                         <asp:DropDownList ID="newsTypeObj" runat="server" AutoPostBack="true">
                </asp:DropDownList></td>
                </tr>

                 <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   资讯内容：</td>
                    <td width="650px;">
                        <textarea id="content" rows=6 cols=80 runat="server"></textarea><span class="WarnMes">*</span>请输入资讯内容！</td>
                </tr>

                 <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   是否显示：</td>
                    <td width="650px;">
                          <select id="showFlag" runat="server">
                            <option value="是">是</option>
                            <option value="否">否</option>
                        </select>

                </tr>

                  <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                  发布时间：</td>
                    <td width="650px;">
                          <asp:TextBox ID="publishDate"  runat="server" Width="150px"
                              onclick="javascript:SelectDate(this,'yyyy-MM-dd hh:mm:ss');"></asp:TextBox></td>
                </tr>

                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="BtnNewsSave" runat="server" Text=" 保存信息 "
                            OnClientClick="return CheckIn()" onclick="BtnNewsSave_Click"  />
                        <asp:Button ID="Button1" runat="server" Text="取消" onclick="Button1_Click" /></td>
                </tr>
            </table>
    </div>
    </form>
</body>
</html>

