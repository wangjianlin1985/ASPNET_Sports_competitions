<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PlayerList.aspx.cs" Inherits="chengxusheji.Admin.PlayerList" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>��Ա�б�</title>
    <link href="Style/Manage.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="JavaScript/Jquery.js"></script>
   <script src="JavaScript/Admin.js" type="text/javascript"></script>
   <script type="text/javascript" src="../js/jsdate.js"></script>
</head>
<body>
   <form id="form1" runat="server">
    <div class="div_All">
    <div class="Body_Title">��Ա���� ������Ա�б�</div>
     <div class="Body_Search">
        ��Ա����&nbsp;&nbsp;<asp:TextBox ID="playerName" runat="server" Width="123px"></asp:TextBox> &nbsp;&nbsp;
        �������&nbsp;&nbsp;<asp:DropDownList ID="teamObj" runat="server"></asp:DropDownList>  &nbsp;&nbsp;
        �Ƿ��Ǿ���&nbsp;&nbsp;<asp:TextBox ID="superStarFlag" runat="server" Width="123px"></asp:TextBox> &nbsp;&nbsp;
        ¼��ʱ��&nbsp;&nbsp; <asp:TextBox ID="addTime"  runat="server" Width="112px" onclick="SelectDate(this,'yyyy-MM-dd');"></asp:TextBox>&nbsp;&nbsp;
        <asp:Button ID="btnSearch" runat="server" Text="��ѯ" onclick="btnSearch_Click" /> 
        &nbsp;&nbsp;&nbsp;<asp:Button ID="btnExport" runat="server" Text="����excel" OnClick="btnExport_Click" />
    <asp:Repeater ID="RpPlayer" runat="server" onitemcommand="RpPlayer_ItemCommand">
        <HeaderTemplate>
            <table cellpadding="2" cellspacing="1" class="Admin_Table">
                <thead>
                    <tr class="Admin_Table_Title">
                        <th>ѡ��</th> 
                        <th>��Աid</th>
                        <th>��Ա����</th>
                        <th>Ӣ��</th>
                        <th>�������</th>
                        <th>��Ա��Ƭ</th>
                        <th>��Ա����</th>
                        <th>��Աλ��</th>
                        <th>���(cm)</th>
                        <th>����(Kg)</th>
                        <th>����</th>
                        <th>н��(����Ԫ)</th>
                        <th>�Ƿ��Ǿ���</th>
                        <th>¼��ʱ��</th>
                        <th>����</th> 
                    </tr>
                </thead>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td align="center"><input type="checkbox" value='<%#Eval("playerId") %>' name="CheckMes" id="DelChecked"/></td>
                <td align="center"><%#Eval("playerId")%> </td>
                <td align="center"><%#Eval("playerName")%> </td>
                <td align="center"><%#Eval("playerEnglishName")%> </td>
                  <td align="center"><%#GetTeamteamObj(Eval("teamObj").ToString())%></td>
                <td align="center"><img src="../<%#Eval("playerPhoto")%>" width=50 height=50 />
                <td align="center"><%#Eval("playerNumber")%> </td>
                <td align="center"><%#Eval("position")%> </td>
                <td align="center"><%#Eval("hight")%> </td>
                <td align="center"><%#Eval("weight")%> </td>
                <td align="center"><%#Eval("age")%> </td>
                <td align="center"><%#Eval("salary")%> </td>
                <td align="center"><%#Eval("superStarFlag")%> </td>
                  <td align="center"><%# Convert.ToDateTime(Eval("addTime")).ToShortDateString() + " " + Convert.ToDateTime(Eval("addTime")).ToLongTimeString() %></td>
                <td align="center"><a href="PlayerEdit.aspx?playerId=<%#Eval("playerId") %>"><img src="Images/MillMes_ICO.gif" alt="�޸���Ϣ..." /></a><asp:ImageButton class="DelClass" ID="IBDelClass" runat="server" CommandArgument='<%#Eval("playerId")%>' CommandName="Del" ImageUrl="Images/Delete.gif"  ToolTip="ɾ������Ϣ..."/></td>
             </tr>
        </ItemTemplate>
        <FooterTemplate></table></FooterTemplate>
    </asp:Repeater>

    <div class="Body_Search">
        <div class="page_Left">
            <input id="BtnAllSelect" type="button" value="ȫѡ" />&nbsp;
            <asp:Button ID="BtnAllDel" runat="server" Text=" ɾ��ѡ�� " onclick="BtnAllDel_Click" />
        </div>
        <div class="page_Right">
        <span class="pageBtn">   <asp:Label runat="server" ID="PageMes"></asp:Label></span>
            <asp:LinkButton ID="LBHome" runat="server" CssClass="pageBtn" 
                onclick="LBHome_Click">[��ҳ]</asp:LinkButton>
            <asp:LinkButton ID="LBUp" runat="server" CssClass="pageBtn" 
                onclick="LBUp_Click">[��һҳ]</asp:LinkButton>
            <asp:LinkButton ID="LBNext" runat="server" CssClass="pageBtn" 
                onclick="LBNext_Click">[��һҳ]</asp:LinkButton>
            <asp:LinkButton ID="LBEnd" runat="server" CssClass="pageBtn" 
                onclick="LBEnd_Click">[βҳ]</asp:LinkButton>
        </div>
    </div>
    </div>
    <asp:HiddenField ID="HSelectID" runat="server" Value=""/>
    <asp:HiddenField ID="HWhere" runat="server" Value=""/>
    <asp:HiddenField ID="HNowPage" runat="server" Value="1"/>
    <asp:HiddenField ID="HPageSize" runat="server" Value="5"/>
    <asp:HiddenField ID="HAllPage" runat="server" Value="0"/>
    </form>
</body>
</html>
