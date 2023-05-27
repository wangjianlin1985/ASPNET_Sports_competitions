<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frontList.aspx.cs" Inherits="Team_frontList" %>
<%@ Register Src="../header.ascx" TagName="header" TagPrefix="uc" %>
<%@ Register Src="../footer.ascx" TagName="footer" TagPrefix="uc" %>
<%
    String path = Request.ApplicationPath;
    String basePath = path + "/"; 
%>
<!DOCTYPE html>
<html>
<head>
<meta charset="utf-8">
<meta http-equiv="X-UA-Compatible" content="IE=edge">
<meta name="viewport" content="width=device-width, initial-scale=1 , user-scalable=no">
<title>球队查询</title>
<link href="<%=basePath %>plugins/bootstrap.css" rel="stylesheet">
<link href="<%=basePath %>plugins/bootstrap-dashen.css" rel="stylesheet">
<link href="<%=basePath %>plugins/font-awesome.css" rel="stylesheet">
<link href="<%=basePath %>plugins/animate.css" rel="stylesheet">
<link href="<%=basePath %>plugins/bootstrap-datetimepicker.min.css" rel="stylesheet" media="screen">
</head>
<body style="margin-top:70px;">
<div class="container">
<uc:header ID="header" runat="server" />
 <form id="form1" runat="server">
	<div class="col-md-9 wow fadeInLeft">
		<ul class="breadcrumb">
  			<li><a href="../index.aspx">首页</a></li>
  			<li><a href="frontList.aspx">球队信息列表</a></li>
  			<li class="active">查询结果显示</li>
  			<a class="pull-right" href="frontAdd.aspx" style="display:none;">添加球队</a>
		</ul>
		<div class="row">
			<asp:Repeater ID="RpTeam" runat="server">
			<ItemTemplate>
			<div class="col-md-3 bottom15" <%#(((Container.ItemIndex+0)%4==0)?"style='clear:left;'":"") %>>
			  <a href="frontshow.aspx?teamId=<%#Eval("teamId")%>"><img class="img-responsive" src="../<%#Eval("teamLogo")%>" /></a>
			     <div class="showFields">
			     	<div class="field">
	            		球队id: <%#Eval("teamId")%>
			     	</div>
			     	<div class="field">
	            		球队名称: <%#Eval("teamName")%>
			     	</div>
			     	<div class="field">
	            		所在赛区: <%#Eval("contestArea")%>
			     	</div>
			     	<div class="field">
	            		成立日期: <%#Eval("bornDate")%>
			     	</div>
			        <a class="btn btn-primary top5" href="frontShow.aspx?teamId=<%#Eval("teamId")%>">详情</a>
			        <a class="btn btn-primary top5" onclick="teamEdit('<%#Eval("teamId")%>');" style="display:none;">修改</a>
			        <a class="btn btn-primary top5" onclick="teamDelete('<%#Eval("teamId")%>');" style="display:none;">删除</a>
			     </div>
			</div>
			</ItemTemplate>
			</asp:Repeater>

			<div class="row">
				<div class="col-md-12">
					<nav class="pull-left">
						<ul class="pagination">
 						        <asp:LinkButton ID="LBHome" runat="server" CssClass="pageBtn" 
 						            onclick="LBHome_Click">[首页]</asp:LinkButton>
 						        <asp:LinkButton ID="LBUp" runat="server" CssClass="pageBtn" 
 						            onclick="LBUp_Click">[上一页]</asp:LinkButton>
 						        <asp:LinkButton ID="LBNext" runat="server" CssClass="pageBtn"
 						            onclick="LBNext_Click">[下一页]</asp:LinkButton>
 						        <asp:LinkButton ID="LBEnd" runat="server" CssClass="pageBtn" 
 						            onclick="LBEnd_Click">[尾页]</asp:LinkButton>
 						        <asp:HiddenField ID="HSelectID" runat="server" Value=""/>
 						        <asp:HiddenField ID="HWhere" runat="server" Value=""/>
 						        <asp:HiddenField ID="HNowPage" runat="server" Value="1"/>
 						        <asp:HiddenField ID="HPageSize" runat="server" Value="8"/>
 						        <asp:HiddenField ID="HAllPage" runat="server" Value="0"/>
						</ul>
					</nav>
					<div class="pull-right" style="line-height:75px;" ><asp:Label runat="server" ID="PageMes"></asp:Label></div>
				</div>
			</div>
		</div>
	</div>

	<div class="col-md-3 wow fadeInRight">
		<div class="page-header">
    		<h1>球队查询</h1>
		</div>
			<div class="form-group">
				<label for="teamName">球队名称:</label>
				<asp:TextBox ID="teamName" runat="server"  CssClass="form-control" placeholder="请输入球队名称"></asp:TextBox>
			</div>
			<div class="form-group">
				<label for="contestArea">所在赛区:</label>
				<asp:TextBox ID="contestArea" runat="server"  CssClass="form-control" placeholder="请输入所在赛区"></asp:TextBox>
			</div>
			<div class="form-group">
				<label for="bornDate">成立日期:</label>
				<asp:TextBox ID="bornDate"  runat="server" CssClass="form-control" placeholder="请选择成立日期" onclick="SelectDate(this,'yyyy-MM-dd');"></asp:TextBox>
			</div>
        <asp:Button ID="btnSearch" CssClass="btn btn-primary" runat="server" Text="查询" onclick="btnSearch_Click" />
	</div>
  </form>
</div>
<div id="teamEditDialog" class="modal fade" tabindex="-1" role="dialog">
  <div class="modal-dialog" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
        <h4 class="modal-title"><i class="fa fa-edit"></i>&nbsp;球队信息编辑</h4>
      </div>
      <div class="modal-body" style="height:450px; overflow: scroll;">
      	<form class="form-horizontal" name="teamEditForm" id="teamEditForm" enctype="multipart/form-data" method="post"  class="mar_t15">
		  <div class="form-group">
			 <label for="team_teamId_edit" class="col-md-3 text-right">球队id:</label>
			 <div class="col-md-9"> 
			 	<input type="text" id="team_teamId_edit" name="team.teamId" class="form-control" placeholder="请输入球队id" readOnly>
			 </div>
		  </div> 
		  <div class="form-group">
		  	 <label for="team_teamName_edit" class="col-md-3 text-right">球队名称:</label>
		  	 <div class="col-md-9">
			    <input type="text" id="team_teamName_edit" name="team.teamName" class="form-control" placeholder="请输入球队名称">
			 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="team_teamLogo_edit" class="col-md-3 text-right">球队logo:</label>
		  	 <div class="col-md-9">
			    <img  class="img-responsive" id="team_teamLogoImg" border="0px"/><br/>
			    <input type="hidden" id="team_teamLogo" name="team.teamLogo"/>
			    <input id="teamLogoFile" name="teamLogoFile" type="file" size="50" />
		  	 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="team_contestArea_edit" class="col-md-3 text-right">所在赛区:</label>
		  	 <div class="col-md-9">
			    <input type="text" id="team_contestArea_edit" name="team.contestArea" class="form-control" placeholder="请输入所在赛区">
			 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="team_bornDate_edit" class="col-md-3 text-right">成立日期:</label>
		  	 <div class="col-md-9">
                <div class="input-group date team_bornDate_edit col-md-12" data-link-field="team_bornDate_edit">
                    <input class="form-control" id="team_bornDate_edit" name="team.bornDate" size="16" type="text" value="" placeholder="请选择成立日期" readonly>
                    <span class="input-group-addon"><span class="glyphicon glyphicon-remove"></span></span>
                    <span class="input-group-addon"><span class="glyphicon glyphicon-calendar"></span></span>
                </div>
		  	 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="team_teamDesc_edit" class="col-md-3 text-right">球队介绍:</label>
		  	 <div class="col-md-9">
			    <textarea id="team_teamDesc_edit" name="team.teamDesc" rows="8" class="form-control" placeholder="请输入球队介绍"></textarea>
			 </div>
		  </div>
		</form> 
	    <style>#teamEditForm .form-group {margin-bottom:5px;}  </style>
      </div>
      <div class="modal-footer"> 
      	<button type="button" class="btn btn-default" data-dismiss="modal">关闭</button>
      	<button type="button" class="btn btn-primary" onclick="ajaxTeamModify();">提交</button>
      </div>
    </div><!-- /.modal-content -->
  </div><!-- /.modal-dialog -->
</div><!-- /.modal -->
<uc:footer ID="footer" runat="server" />
<script src="<%=basePath %>plugins/jquery.min.js"></script>
<script src="<%=basePath %>plugins/bootstrap.js"></script>
<script src="<%=basePath %>plugins/wow.min.js"></script>
<script src="<%=basePath %>plugins/bootstrap-datetimepicker.min.js"></script>
<script src="<%=basePath %>plugins/locales/bootstrap-datetimepicker.zh-CN.js"></script>
<script type="text/javascript" src="<%=basePath %>js/jsdate.js"></script>
<script>
var basePath = "<%=basePath%>";
/*弹出修改球队界面并初始化数据*/
function teamEdit(teamId) {
	$.ajax({
		url :  basePath + "Team/TeamController.aspx?action=getTeam&teamId=" + teamId,
		type : "get",
		dataType: "json",
		success : function (team, response, status) {
			if (team) {
				$("#team_teamId_edit").val(team.teamId);
				$("#team_teamName_edit").val(team.teamName);
				$("#team_teamLogo").val(team.teamLogo);
				$("#team_teamLogoImg").attr("src", basePath +　team.teamLogo);
				$("#team_contestArea_edit").val(team.contestArea);
				$("#team_bornDate_edit").val(team.bornDate);
				$("#team_teamDesc_edit").val(team.teamDesc);
				$('#teamEditDialog').modal('show');
			} else {
				alert("获取信息失败！");
			}
		}
	});
}

/*删除球队信息*/
function teamDelete(teamId) {
	if(confirm("确认删除这个记录")) {
		$.ajax({
			type : "POST",
			url : basePath + "Team/TeamController.aspx?action=delete",
			data : {
				teamId : teamId,
			},
			dataType: "json",
			success : function (obj) {
				if (obj.success) {
					alert("删除成功");
                    $("#btnSearch").click();
					//location.href= basePath + "Team/frontList.aspx";
				}
				else 
					alert(obj.message);
			},
		});
	}
}

/*ajax方式提交球队信息表单给服务器端修改*/
function ajaxTeamModify() {
	$.ajax({
		url :  basePath + "Team/TeamController.aspx?action=update",
		type : "post",
		dataType: "json",
		data: new FormData($("#teamEditForm")[0]),
		success : function (obj, response, status) {
            if(obj.success){
                alert("信息修改成功！");
                $("#btnSearch").click();
            }else{
                alert(obj.message);
            } 
		},
		processData: false,
		contentType: false,
	});
}

$(function(){
	/*小屏幕导航点击关闭菜单*/
    $('.navbar-collapse a').click(function(){
        $('.navbar-collapse').collapse('hide');
    });
    new WOW().init();

    /*成立日期组件*/
    $('.team_bornDate_edit').datetimepicker({
    	language:  'zh-CN',  //语言
    	format: 'yyyy-mm-dd hh:ii:ss',
    	weekStart: 1,
    	todayBtn:  1,
    	autoclose: 1,
    	minuteStep: 1,
    	todayHighlight: 1,
    	startView: 2,
    	forceParse: 0
    });
})
</script>
</body>
</html>

