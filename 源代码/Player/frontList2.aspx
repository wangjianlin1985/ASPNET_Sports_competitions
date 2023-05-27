<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frontList2.aspx.cs" Inherits="Player_frontList" %>
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
<title>球员查询</title>
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
  			<li><a href="frontList2.aspx">球员信息列表</a></li>
  			<li class="active">查询结果显示</li>
  			<a class="pull-right" href="frontAdd.aspx" style="display:none;">添加球员</a>
		</ul>
		<div class="row">
			<asp:Repeater ID="RpPlayer" runat="server">
			<ItemTemplate>
			<div class="col-md-3 bottom15" <%#(((Container.ItemIndex+0)%4==0)?"style='clear:left;'":"") %>>
			  <a href="frontshow.aspx?playerId=<%#Eval("playerId")%>"><img class="img-responsive" src="../<%#Eval("playerPhoto")%>" /></a>
			     <div class="showFields">
			     	 
			     	<div class="field">
	            		球员姓名: <%#Eval("playerName")%>
			     	</div>
			     	<div class="field">
	            		英文: <%#Eval("playerEnglishName")%>
			     	</div>
			     	<div class="field">
	            		所在球队:<%#GetTeamteamObj(Eval("teamObj").ToString())%>
			     	</div>
			     	<div class="field">
	            		球员号码: <%#Eval("playerNumber")%>
			     	</div>
			     	<div class="field">
	            		球员位置: <%#Eval("position")%>
			     	</div>
			     	<div class="field">
	            		身高(cm): <%#Eval("hight")%>
			     	</div>
			     	<div class="field">
	            		体重(Kg): <%#Eval("weight")%>
			     	</div>
			     	<div class="field">
	            		年龄: <%#Eval("age")%>
			     	</div>
			     	 
			        <a class="btn btn-primary top5" href="frontShow.aspx?playerId=<%#Eval("playerId")%>">详情</a>
			        <a class="btn btn-primary top5" onclick="playerEdit('<%#Eval("playerId")%>');" style="display:none;">修改</a>
			        <a class="btn btn-primary top5" onclick="playerDelete('<%#Eval("playerId")%>');" style="display:none;">删除</a>
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
    		<h1>球员查询</h1>
		</div>
			<div class="form-group">
				<label for="playerName">球员姓名:</label>
				<asp:TextBox ID="playerName" runat="server"  CssClass="form-control" placeholder="请输入球员姓名"></asp:TextBox>
			</div>
            <div class="form-group">
            	<label for="teamObj_teamId">所在球队：</label>
                <asp:DropDownList ID="teamObj" runat="server"  CssClass="form-control" placeholder="请选择所在球队"></asp:DropDownList>
            </div>
			<div class="form-group" style="display:none;">
				<label for="superStarFlag">是否是巨星:</label>
				<asp:TextBox ID="superStarFlag" runat="server"  CssClass="form-control" placeholder="请输入是否是巨星"></asp:TextBox>
			</div>
			<div class="form-group">
				<label for="addTime">录入时间:</label>
				<asp:TextBox ID="addTime"  runat="server" CssClass="form-control" placeholder="请选择录入时间" onclick="SelectDate(this,'yyyy-MM-dd');"></asp:TextBox>
			</div>
        <asp:Button ID="btnSearch" CssClass="btn btn-primary" runat="server" Text="查询" onclick="btnSearch_Click" />
	</div>
  </form>
</div>
<div id="playerEditDialog" class="modal fade" tabindex="-1" role="dialog">
  <div class="modal-dialog" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
        <h4 class="modal-title"><i class="fa fa-edit"></i>&nbsp;球员信息编辑</h4>
      </div>
      <div class="modal-body" style="height:450px; overflow: scroll;">
      	<form class="form-horizontal" name="playerEditForm" id="playerEditForm" enctype="multipart/form-data" method="post"  class="mar_t15">
		  <div class="form-group">
			 <label for="player_playerId_edit" class="col-md-3 text-right">球员id:</label>
			 <div class="col-md-9"> 
			 	<input type="text" id="player_playerId_edit" name="player.playerId" class="form-control" placeholder="请输入球员id" readOnly>
			 </div>
		  </div> 
		  <div class="form-group">
		  	 <label for="player_playerName_edit" class="col-md-3 text-right">球员姓名:</label>
		  	 <div class="col-md-9">
			    <input type="text" id="player_playerName_edit" name="player.playerName" class="form-control" placeholder="请输入球员姓名">
			 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="player_playerEnglishName_edit" class="col-md-3 text-right">英文:</label>
		  	 <div class="col-md-9">
			    <input type="text" id="player_playerEnglishName_edit" name="player.playerEnglishName" class="form-control" placeholder="请输入英文">
			 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="player_teamObj_teamId_edit" class="col-md-3 text-right">所在球队:</label>
		  	 <div class="col-md-9">
			    <select id="player_teamObj_teamId_edit" name="player.teamObj.teamId" class="form-control">
			    </select>
		  	 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="player_playerPhoto_edit" class="col-md-3 text-right">球员照片:</label>
		  	 <div class="col-md-9">
			    <img  class="img-responsive" id="player_playerPhotoImg" border="0px"/><br/>
			    <input type="hidden" id="player_playerPhoto" name="player.playerPhoto"/>
			    <input id="playerPhotoFile" name="playerPhotoFile" type="file" size="50" />
		  	 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="player_playerNumber_edit" class="col-md-3 text-right">球员号码:</label>
		  	 <div class="col-md-9">
			    <input type="text" id="player_playerNumber_edit" name="player.playerNumber" class="form-control" placeholder="请输入球员号码">
			 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="player_position_edit" class="col-md-3 text-right">球员位置:</label>
		  	 <div class="col-md-9">
			    <input type="text" id="player_position_edit" name="player.position" class="form-control" placeholder="请输入球员位置">
			 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="player_hight_edit" class="col-md-3 text-right">身高(cm):</label>
		  	 <div class="col-md-9">
			    <input type="text" id="player_hight_edit" name="player.hight" class="form-control" placeholder="请输入身高(cm)">
			 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="player_weight_edit" class="col-md-3 text-right">体重(Kg):</label>
		  	 <div class="col-md-9">
			    <input type="text" id="player_weight_edit" name="player.weight" class="form-control" placeholder="请输入体重(Kg)">
			 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="player_age_edit" class="col-md-3 text-right">年龄:</label>
		  	 <div class="col-md-9">
			    <input type="text" id="player_age_edit" name="player.age" class="form-control" placeholder="请输入年龄">
			 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="player_salary_edit" class="col-md-3 text-right">薪资(万美元):</label>
		  	 <div class="col-md-9">
			    <input type="text" id="player_salary_edit" name="player.salary" class="form-control" placeholder="请输入薪资(万美元)">
			 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="player_superStarFlag_edit" class="col-md-3 text-right">是否是巨星:</label>
		  	 <div class="col-md-9">
			    <input type="text" id="player_superStarFlag_edit" name="player.superStarFlag" class="form-control" placeholder="请输入是否是巨星">
			 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="player_playerDesc_edit" class="col-md-3 text-right">球员介绍:</label>
		  	 <div class="col-md-9">
			    <textarea id="player_playerDesc_edit" name="player.playerDesc" rows="8" class="form-control" placeholder="请输入球员介绍"></textarea>
			 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="player_addTime_edit" class="col-md-3 text-right">录入时间:</label>
		  	 <div class="col-md-9">
                <div class="input-group date player_addTime_edit col-md-12" data-link-field="player_addTime_edit">
                    <input class="form-control" id="player_addTime_edit" name="player.addTime" size="16" type="text" value="" placeholder="请选择录入时间" readonly>
                    <span class="input-group-addon"><span class="glyphicon glyphicon-remove"></span></span>
                    <span class="input-group-addon"><span class="glyphicon glyphicon-calendar"></span></span>
                </div>
		  	 </div>
		  </div>
		</form> 
	    <style>#playerEditForm .form-group {margin-bottom:5px;}  </style>
      </div>
      <div class="modal-footer"> 
      	<button type="button" class="btn btn-default" data-dismiss="modal">关闭</button>
      	<button type="button" class="btn btn-primary" onclick="ajaxPlayerModify();">提交</button>
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
/*弹出修改球员界面并初始化数据*/
function playerEdit(playerId) {
	$.ajax({
		url :  basePath + "Player/PlayerController.aspx?action=getPlayer&playerId=" + playerId,
		type : "get",
		dataType: "json",
		success : function (player, response, status) {
			if (player) {
				$("#player_playerId_edit").val(player.playerId);
				$("#player_playerName_edit").val(player.playerName);
				$("#player_playerEnglishName_edit").val(player.playerEnglishName);
				$.ajax({
					url: basePath + "Team/TeamController.aspx?action=listAll",
					type: "get",
					dataType: "json",
					success: function(teams,response,status) { 
						$("#player_teamObj_teamId_edit").empty();
						var html="";
		        		$(teams).each(function(i,team){
		        			html += "<option value='" + team.teamId + "'>" + team.teamName + "</option>";
		        		});
		        		$("#player_teamObj_teamId_edit").html(html);
		        		$("#player_teamObj_teamId_edit").val(player.teamObjPri);
					}
				});
				$("#player_playerPhoto").val(player.playerPhoto);
				$("#player_playerPhotoImg").attr("src", basePath +　player.playerPhoto);
				$("#player_playerNumber_edit").val(player.playerNumber);
				$("#player_position_edit").val(player.position);
				$("#player_hight_edit").val(player.hight);
				$("#player_weight_edit").val(player.weight);
				$("#player_age_edit").val(player.age);
				$("#player_salary_edit").val(player.salary);
				$("#player_superStarFlag_edit").val(player.superStarFlag);
				$("#player_playerDesc_edit").val(player.playerDesc);
				$("#player_addTime_edit").val(player.addTime);
				$('#playerEditDialog').modal('show');
			} else {
				alert("获取信息失败！");
			}
		}
	});
}

/*删除球员信息*/
function playerDelete(playerId) {
	if(confirm("确认删除这个记录")) {
		$.ajax({
			type : "POST",
			url : basePath + "Player/PlayerController.aspx?action=delete",
			data : {
				playerId : playerId,
			},
			dataType: "json",
			success : function (obj) {
				if (obj.success) {
					alert("删除成功");
                    $("#btnSearch").click();
					//location.href= basePath + "Player/frontList.aspx";
				}
				else 
					alert(obj.message);
			},
		});
	}
}

/*ajax方式提交球员信息表单给服务器端修改*/
function ajaxPlayerModify() {
	$.ajax({
		url :  basePath + "Player/PlayerController.aspx?action=update",
		type : "post",
		dataType: "json",
		data: new FormData($("#playerEditForm")[0]),
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

    /*录入时间组件*/
    $('.player_addTime_edit').datetimepicker({
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

