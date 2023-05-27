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
                alert("��������Ѷ����...");
                document.getElementById("title").focus();
                return false;
            }

            var content = document.getElementById("content").value;
            if (content == "") {
                alert("��������Ѷ����...");
                document.getElementById("content").focus();
                return false;
            }

            var showFlag = document.getElementById("showFlag").value;
            if (showFlag == "") {
                alert("�������Ƿ���ʾ...");
                document.getElementById("showFlag").focus();
                return false;
            }

            var publishDate = document.getElementById("publishDate").value;
            if (publishDate == "") {
                alert("�����뷢��ʱ��...");
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
    <div class="Body_Title">������Ѷ���� �����༭������Ѷ</div>
        <hr />
        <table cellspacing="1" cellpadding="2">
                 <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   ��ѶͼƬ��</td>
                    <td width="650px;">
                       <table cellpadding="0px" cellspacing="0px" width="90%">
                        <tr><td width="400px">
                         ͼƬ·����<asp:TextBox ID="newsPhoto" runat="server" ReadOnly="True" Width="228px" Enabled="False"></asp:TextBox> &nbsp; &nbsp; &nbsp
                         <br />
                         <br />
                         �ϴ�ͼƬ��<asp:FileUpload ID="NewsPhotoUpload" runat="server" Width="237px" />&nbsp;
                         <asp:Button ID="Btn_NewsPhotoUpload" runat="server" Text="�ϴ�" OnClick="Btn_NewsPhotoUpload_Click" /></td><td>
                         <asp:Image ID="NewsPhotoImage" runat="server" Height="90px" Width="99px" />
                         </td></tr>
                       </table>
                    </td>
                </tr>

                 <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   ��Ѷ���⣺</td>
                    <td width="650px;">
                         <input id="title" type="text"   style="width:800px;" runat="server" maxlength="25"/><span class="WarnMes">*</span>��������Ѷ���⣡</td>
                </tr>

                <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                    ��Ѷ���</td>
                    <td width="650px;">
                         <asp:DropDownList ID="newsTypeObj" runat="server" AutoPostBack="true">
                </asp:DropDownList></td>
                </tr>

                 <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   ��Ѷ���ݣ�</td>
                    <td width="650px;">
                        <textarea id="content" rows=6 cols=80 runat="server"></textarea><span class="WarnMes">*</span>��������Ѷ���ݣ�</td>
                </tr>

                 <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   �Ƿ���ʾ��</td>
                    <td width="650px;">
                          <select id="showFlag" runat="server">
                            <option value="��">��</option>
                            <option value="��">��</option>
                        </select>

                </tr>

                  <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                  ����ʱ�䣺</td>
                    <td width="650px;">
                          <asp:TextBox ID="publishDate"  runat="server" Width="150px"
                              onclick="javascript:SelectDate(this,'yyyy-MM-dd hh:mm:ss');"></asp:TextBox></td>
                </tr>

                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="BtnNewsSave" runat="server" Text=" ������Ϣ "
                            OnClientClick="return CheckIn()" onclick="BtnNewsSave_Click"  />
                        <asp:Button ID="Button1" runat="server" Text="ȡ��" onclick="Button1_Click" /></td>
                </tr>
            </table>
    </div>
    </form>
</body>
</html>

