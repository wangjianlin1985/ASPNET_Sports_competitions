<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frontModify.aspx.cs" Inherits="Player_frontModify" %>
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
  <TITLE>修改球员信息</TITLE>
  <link href="<%=basePath %>plugins/bootstrap.css" rel="stylesheet">
  <link href="<%=basePath %>plugins/bootstrap-dashen.css" rel="stylesheet">
  <link href="<%=basePath %>plugins/font-awesome.css" rel="stylesheet">
  <link href="<%=basePath %>plugins/animate.css" rel="stylesheet"> 
</head>
<body style="margin-top:70px;"> 
<div class="container">
<uc:header ID="header" runat="server" />
	<div class="col-md-9 wow fadeInLeft">
	<ul class="breadcrumb">
  		<li><a href="<%=basePath %>index.aspx">首页</a></li>
  		<li class="active">球员信息修改</li>
	</ul>
		<div class="row"> 
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
			    <script name="player.playerDesc" id="player_playerDesc_edit" type="text/plain"   style="width:100%;height:500px;"></script>
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
			  <div class="form-group">
			  	<span class="col-md-3""></span>
			  	<span onclick="ajaxPlayerModify();" class="btn btn-primary bottom5 top5">修改</span>
			  </div>
		</form> 
	    <style>#playerEditForm .form-group {margin-bottom:5px;}  </style>
      </div>
   </div>
</div>


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
			} else {
				alert("获取信息失败！");
			}
		}
	});
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
                location.reload(true);
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
    playerEdit('<%=Request["playerId"] %>');
 })
 </script> 
</body>
</html>

