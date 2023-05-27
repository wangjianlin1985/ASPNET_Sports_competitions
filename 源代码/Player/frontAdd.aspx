<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frontAdd.aspx.cs" Inherits="Player_frontAdd" %>
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
<title>球员添加</title>
<link href="<%=basePath %>plugins/bootstrap.css" rel="stylesheet">
<link href="<%=basePath %>plugins/bootstrap-dashen.css" rel="stylesheet">
<link href="<%=basePath %>plugins/font-awesome.css" rel="stylesheet">
<link href="<%=basePath %>plugins/animate.css" rel="stylesheet">
<link href="<%=basePath %>plugins/bootstrap-datetimepicker.min.css" rel="stylesheet" media="screen">
</head>
<body style="margin-top:70px;">
<div class="container">
<uc:header ID="header" runat="server" />
	<div class="col-md-12 wow fadeInLeft">
		<ul class="breadcrumb">
  			<li><a href="<%=basePath %>index.aspx">首页</a></li>
  			<li><a href="<%=basePath %>Player/frontList.aspx">球员管理</a></li>
  			<li class="active">添加球员</li>
		</ul>
		<div class="row">
			<div class="col-md-10">
		      	<form class="form-horizontal" name="playerAddForm" id="playerAddForm" enctype="multipart/form-data" method="post"  class="mar_t15">
				  <div class="form-group">
				  	 <label for="player_playerName" class="col-md-2 text-right">球员姓名:</label>
				  	 <div class="col-md-8">
					    <input type="text" id="player_playerName" name="player.playerName" class="form-control" placeholder="请输入球员姓名">
					 </div>
				  </div>
				  <div class="form-group">
				  	 <label for="player_playerEnglishName" class="col-md-2 text-right">英文:</label>
				  	 <div class="col-md-8">
					    <input type="text" id="player_playerEnglishName" name="player.playerEnglishName" class="form-control" placeholder="请输入英文">
					 </div>
				  </div>
				  <div class="form-group">
				  	 <label for="player_teamObj_teamId" class="col-md-2 text-right">所在球队:</label>
				  	 <div class="col-md-8">
					    <select id="player_teamObj_teamId" name="player.teamObj.teamId" class="form-control">
					    </select>
				  	 </div>
				  </div>
				  <div class="form-group">
				  	 <label for="player_playerPhoto" class="col-md-2 text-right">球员照片:</label>
				  	 <div class="col-md-8">
					    <img  class="img-responsive" id="player_playerPhotoImg" border="0px"/><br/>
					    <input type="hidden" id="player_playerPhoto" name="player.playerPhoto"/>
					    <input id="playerPhotoFile" name="playerPhotoFile" type="file" size="50" />
				  	 </div>
				  </div>
				  <div class="form-group">
				  	 <label for="player_playerNumber" class="col-md-2 text-right">球员号码:</label>
				  	 <div class="col-md-8">
					    <input type="text" id="player_playerNumber" name="player.playerNumber" class="form-control" placeholder="请输入球员号码">
					 </div>
				  </div>
				  <div class="form-group">
				  	 <label for="player_position" class="col-md-2 text-right">球员位置:</label>
				  	 <div class="col-md-8">
					    <input type="text" id="player_position" name="player.position" class="form-control" placeholder="请输入球员位置">
					 </div>
				  </div>
				  <div class="form-group">
				  	 <label for="player_hight" class="col-md-2 text-right">身高(cm):</label>
				  	 <div class="col-md-8">
					    <input type="text" id="player_hight" name="player.hight" class="form-control" placeholder="请输入身高(cm)">
					 </div>
				  </div>
				  <div class="form-group">
				  	 <label for="player_weight" class="col-md-2 text-right">体重(Kg):</label>
				  	 <div class="col-md-8">
					    <input type="text" id="player_weight" name="player.weight" class="form-control" placeholder="请输入体重(Kg)">
					 </div>
				  </div>
				  <div class="form-group">
				  	 <label for="player_age" class="col-md-2 text-right">年龄:</label>
				  	 <div class="col-md-8">
					    <input type="text" id="player_age" name="player.age" class="form-control" placeholder="请输入年龄">
					 </div>
				  </div>
				  <div class="form-group">
				  	 <label for="player_salary" class="col-md-2 text-right">薪资(万美元):</label>
				  	 <div class="col-md-8">
					    <input type="text" id="player_salary" name="player.salary" class="form-control" placeholder="请输入薪资(万美元)">
					 </div>
				  </div>
				  <div class="form-group">
				  	 <label for="player_superStarFlag" class="col-md-2 text-right">是否是巨星:</label>
				  	 <div class="col-md-8">
					    <input type="text" id="player_superStarFlag" name="player.superStarFlag" class="form-control" placeholder="请输入是否是巨星">
					 </div>
				  </div>
				  <div class="form-group">
				  	 <label for="player_playerDesc" class="col-md-2 text-right">球员介绍:</label>
				  	 <div class="col-md-8">
					    <textarea id="player_playerDesc" name="player.playerDesc" rows="8" class="form-control" placeholder="请输入球员介绍"></textarea>
					 </div>
				  </div>
				  <div class="form-group">
				  	 <label for="player_addTimeDiv" class="col-md-2 text-right">录入时间:</label>
				  	 <div class="col-md-8">
		                <div id="player_addTimeDiv" class="input-group date player_addTime col-md-12" data-link-field="player_addTime">
		                    <input class="form-control" id="player_addTime" name="player.addTime" size="16" type="text" value="" placeholder="请选择录入时间" readonly>
		                    <span class="input-group-addon"><span class="glyphicon glyphicon-remove"></span></span>
		                    <span class="input-group-addon"><span class="glyphicon glyphicon-calendar"></span></span>
		                </div>
				  	 </div>
				  </div>
		          <div class="form-group">
		             <span class="col-md-2""></span>
		             <span onclick="ajaxPlayerAdd();" class="btn btn-primary bottom5 top5">添加</span>
		          </div> 
		          <style>#playerAddForm .form-group {margin:5px;}  </style>  
				</form> 
			</div>
			<div class="col-md-2"></div> 
	    </div>
	</div>
</div>
<uc:footer ID="footer" runat="server" />
<script src="<%=basePath %>plugins/jquery.min.js"></script>
<script src="<%=basePath %>plugins/bootstrap.js"></script>
<script src="<%=basePath %>plugins/wow.min.js"></script>
<script src="<%=basePath %>plugins/bootstrapvalidator/js/bootstrapValidator.min.js"></script>
<script type="text/javascript" src="<%=basePath %>plugins/bootstrap-datetimepicker.min.js" charset="UTF-8"></script>
<script type="text/javascript" src="<%=basePath %>plugins/locales/bootstrap-datetimepicker.zh-CN.js" charset="UTF-8"></script>
<script>
var basePath = "<%=basePath%>";
	//提交添加球员信息
	function ajaxPlayerAdd() { 
		//提交之前先验证表单
		$("#playerAddForm").data('bootstrapValidator').validate();
		if(!$("#playerAddForm").data('bootstrapValidator').isValid()){
			return;
		}
		jQuery.ajax({
			type : "post",
			url : basePath + "Player/PlayerController.aspx?action=add",
			dataType : "json" , 
			data: new FormData($("#playerAddForm")[0]),
			success : function(obj) {
				if(obj.success){ 
					alert("保存成功！");
					$("#playerAddForm").find("input").val("");
					$("#playerAddForm").find("textarea").val("");
				} else {
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
	//验证球员添加表单字段
	$('#playerAddForm').bootstrapValidator({
		feedbackIcons: {
			valid: 'glyphicon glyphicon-ok',
			invalid: 'glyphicon glyphicon-remove',
			validating: 'glyphicon glyphicon-refresh'
		},
		fields: {
			"player.playerName": {
				validators: {
					notEmpty: {
						message: "球员姓名不能为空",
					}
				}
			},
			"player.playerEnglishName": {
				validators: {
					notEmpty: {
						message: "英文不能为空",
					}
				}
			},
			"player.playerNumber": {
				validators: {
					notEmpty: {
						message: "球员号码不能为空",
					}
				}
			},
			"player.position": {
				validators: {
					notEmpty: {
						message: "球员位置不能为空",
					}
				}
			},
			"player.hight": {
				validators: {
					notEmpty: {
						message: "身高(cm)不能为空",
					},
					integer: {
						message: "身高(cm)不正确"
					}
				}
			},
			"player.weight": {
				validators: {
					notEmpty: {
						message: "体重(Kg)不能为空",
					},
					numeric: {
						message: "体重(Kg)不正确"
					}
				}
			},
			"player.age": {
				validators: {
					notEmpty: {
						message: "年龄不能为空",
					},
					integer: {
						message: "年龄不正确"
					}
				}
			},
			"player.salary": {
				validators: {
					notEmpty: {
						message: "薪资(万美元)不能为空",
					},
					numeric: {
						message: "薪资(万美元)不正确"
					}
				}
			},
			"player.superStarFlag": {
				validators: {
					notEmpty: {
						message: "是否是巨星不能为空",
					}
				}
			},
			"player.addTime": {
				validators: {
					notEmpty: {
						message: "录入时间不能为空",
					}
				}
			},
		}
	}); 
	//初始化所在球队下拉框值 
	$.ajax({
		url: basePath + "Team/TeamController.aspx?action=listAll",
		type: "get",
		dataType: "json",
		success: function(teams,response,status) { 
			$("#player_teamObj_teamId").empty();
			var html="";
    		$(teams).each(function(i,team){
    			html += "<option value='" + team.teamId + "'>" + team.teamName + "</option>";
    		});
    		$("#player_teamObj_teamId").html(html);
    	}
	});
	//录入时间组件
	$('#player_addTimeDiv').datetimepicker({
		language:  'zh-CN',  //显示语言
		format: 'yyyy-mm-dd hh:ii:ss',
		weekStart: 1,
		todayBtn:  1,
		autoclose: 1,
		minuteStep: 1,
		todayHighlight: 1,
		startView: 2,
		forceParse: 0
	}).on('hide',function(e) {
		//下面这行代码解决日期组件改变日期后不验证的问题
		$('#playerAddForm').data('bootstrapValidator').updateStatus('player.addTime', 'NOT_VALIDATED',null).validateField('player.addTime');
	});
})
</script>
</body>
</html>
