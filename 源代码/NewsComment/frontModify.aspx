<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frontModify.aspx.cs" Inherits="NewsComment_frontModify" %>
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
  <TITLE>修改资讯评论信息</TITLE>
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
  		<li class="active">资讯评论信息修改</li>
	</ul>
		<div class="row"> 
      	<form class="form-horizontal" name="newsCommentEditForm" id="newsCommentEditForm" enctype="multipart/form-data" method="post"  class="mar_t15">
		  <div class="form-group">
			 <label for="newsComment_commentId_edit" class="col-md-3 text-right">评论id:</label>
			 <div class="col-md-9"> 
			 	<input type="text" id="newsComment_commentId_edit" name="newsComment.commentId" class="form-control" placeholder="请输入评论id" readOnly>
			 </div>
		  </div> 
		  <div class="form-group">
		  	 <label for="newsComment_newsObj_newsId_edit" class="col-md-3 text-right">被评资讯:</label>
		  	 <div class="col-md-9">
			    <select id="newsComment_newsObj_newsId_edit" name="newsComment.newsObj.newsId" class="form-control">
			    </select>
		  	 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="newsComment_content_edit" class="col-md-3 text-right">评论内容:</label>
		  	 <div class="col-md-9">
			    <textarea id="newsComment_content_edit" name="newsComment.content" rows="8" class="form-control" placeholder="请输入评论内容"></textarea>
			 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="newsComment_userObj_user_name_edit" class="col-md-3 text-right">评论用户:</label>
		  	 <div class="col-md-9">
			    <select id="newsComment_userObj_user_name_edit" name="newsComment.userObj.user_name" class="form-control">
			    </select>
		  	 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="newsComment_commentTime_edit" class="col-md-3 text-right">评论时间:</label>
		  	 <div class="col-md-9">
			    <input type="text" id="newsComment_commentTime_edit" name="newsComment.commentTime" class="form-control" placeholder="请输入评论时间">
			 </div>
		  </div>
			  <div class="form-group">
			  	<span class="col-md-3""></span>
			  	<span onclick="ajaxNewsCommentModify();" class="btn btn-primary bottom5 top5">修改</span>
			  </div>
		</form> 
	    <style>#newsCommentEditForm .form-group {margin-bottom:5px;}  </style>
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
/*弹出修改资讯评论界面并初始化数据*/
function newsCommentEdit(commentId) {
	$.ajax({
		url :  basePath + "NewsComment/NewsCommentController.aspx?action=getNewsComment&commentId=" + commentId,
		type : "get",
		dataType: "json",
		success : function (newsComment, response, status) {
			if (newsComment) {
				$("#newsComment_commentId_edit").val(newsComment.commentId);
				$.ajax({
					url: basePath + "News/NewsController.aspx?action=listAll",
					type: "get",
					dataType: "json",
					success: function(newss,response,status) { 
						$("#newsComment_newsObj_newsId_edit").empty();
						var html="";
		        		$(newss).each(function(i,news){
		        			html += "<option value='" + news.newsId + "'>" + news.title + "</option>";
		        		});
		        		$("#newsComment_newsObj_newsId_edit").html(html);
		        		$("#newsComment_newsObj_newsId_edit").val(newsComment.newsObjPri);
					}
				});
				$("#newsComment_content_edit").val(newsComment.content);
				$.ajax({
					url: basePath + "UserInfo/UserInfoController.aspx?action=listAll",
					type: "get",
					dataType: "json",
					success: function(userInfos,response,status) { 
						$("#newsComment_userObj_user_name_edit").empty();
						var html="";
		        		$(userInfos).each(function(i,userInfo){
		        			html += "<option value='" + userInfo.user_name + "'>" + userInfo.name + "</option>";
		        		});
		        		$("#newsComment_userObj_user_name_edit").html(html);
		        		$("#newsComment_userObj_user_name_edit").val(newsComment.userObjPri);
					}
				});
				$("#newsComment_commentTime_edit").val(newsComment.commentTime);
			} else {
				alert("获取信息失败！");
			}
		}
	});
}

/*ajax方式提交资讯评论信息表单给服务器端修改*/
function ajaxNewsCommentModify() {
	$.ajax({
		url :  basePath + "NewsComment/NewsCommentController.aspx?action=update",
		type : "post",
		dataType: "json",
		data: new FormData($("#newsCommentEditForm")[0]),
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
    newsCommentEdit('<%=Request["commentId"] %>');
 })
 </script> 
</body>
</html>

