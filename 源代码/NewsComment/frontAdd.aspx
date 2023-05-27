<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frontAdd.aspx.cs" Inherits="NewsComment_frontAdd" %>
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
<title>资讯评论添加</title>
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
  			<li><a href="<%=basePath %>NewsComment/frontList.aspx">资讯评论管理</a></li>
  			<li class="active">添加资讯评论</li>
		</ul>
		<div class="row">
			<div class="col-md-10">
		      	<form class="form-horizontal" name="newsCommentAddForm" id="newsCommentAddForm" enctype="multipart/form-data" method="post"  class="mar_t15">
				  <div class="form-group">
				  	 <label for="newsComment_newsObj_newsId" class="col-md-2 text-right">被评资讯:</label>
				  	 <div class="col-md-8">
					    <select id="newsComment_newsObj_newsId" name="newsComment.newsObj.newsId" class="form-control">
					    </select>
				  	 </div>
				  </div>
				  <div class="form-group">
				  	 <label for="newsComment_content" class="col-md-2 text-right">评论内容:</label>
				  	 <div class="col-md-8">
					    <textarea id="newsComment_content" name="newsComment.content" rows="8" class="form-control" placeholder="请输入评论内容"></textarea>
					 </div>
				  </div>
				  <div class="form-group">
				  	 <label for="newsComment_userObj_user_name" class="col-md-2 text-right">评论用户:</label>
				  	 <div class="col-md-8">
					    <select id="newsComment_userObj_user_name" name="newsComment.userObj.user_name" class="form-control">
					    </select>
				  	 </div>
				  </div>
				  <div class="form-group">
				  	 <label for="newsComment_commentTime" class="col-md-2 text-right">评论时间:</label>
				  	 <div class="col-md-8">
					    <input type="text" id="newsComment_commentTime" name="newsComment.commentTime" class="form-control" placeholder="请输入评论时间">
					 </div>
				  </div>
		          <div class="form-group">
		             <span class="col-md-2""></span>
		             <span onclick="ajaxNewsCommentAdd();" class="btn btn-primary bottom5 top5">添加</span>
		          </div> 
		          <style>#newsCommentAddForm .form-group {margin:5px;}  </style>  
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
	//提交添加资讯评论信息
	function ajaxNewsCommentAdd() { 
		//提交之前先验证表单
		$("#newsCommentAddForm").data('bootstrapValidator').validate();
		if(!$("#newsCommentAddForm").data('bootstrapValidator').isValid()){
			return;
		}
		jQuery.ajax({
			type : "post",
			url : basePath + "NewsComment/NewsCommentController.aspx?action=add",
			dataType : "json" , 
			data: new FormData($("#newsCommentAddForm")[0]),
			success : function(obj) {
				if(obj.success){ 
					alert("保存成功！");
					$("#newsCommentAddForm").find("input").val("");
					$("#newsCommentAddForm").find("textarea").val("");
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
	//验证资讯评论添加表单字段
	$('#newsCommentAddForm').bootstrapValidator({
		feedbackIcons: {
			valid: 'glyphicon glyphicon-ok',
			invalid: 'glyphicon glyphicon-remove',
			validating: 'glyphicon glyphicon-refresh'
		},
		fields: {
			"newsComment.content": {
				validators: {
					notEmpty: {
						message: "评论内容不能为空",
					}
				}
			},
		}
	}); 
	//初始化被评资讯下拉框值 
	$.ajax({
		url: basePath + "News/NewsController.aspx?action=listAll",
		type: "get",
		dataType: "json",
		success: function(newss,response,status) { 
			$("#newsComment_newsObj_newsId").empty();
			var html="";
    		$(newss).each(function(i,news){
    			html += "<option value='" + news.newsId + "'>" + news.title + "</option>";
    		});
    		$("#newsComment_newsObj_newsId").html(html);
    	}
	});
	//初始化评论用户下拉框值 
	$.ajax({
		url: basePath + "UserInfo/UserInfoController.aspx?action=listAll",
		type: "get",
		dataType: "json",
		success: function(userInfos,response,status) { 
			$("#newsComment_userObj_user_name").empty();
			var html="";
    		$(userInfos).each(function(i,userInfo){
    			html += "<option value='" + userInfo.user_name + "'>" + userInfo.name + "</option>";
    		});
    		$("#newsComment_userObj_user_name").html(html);
    	}
	});
})
</script>
</body>
</html>
