<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frontModify.aspx.cs" Inherits="News_frontModify" %>
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
  <TITLE>修改新闻资讯信息</TITLE>
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
  		<li class="active">新闻资讯信息修改</li>
	</ul>
		<div class="row"> 
      	<form class="form-horizontal" name="newsEditForm" id="newsEditForm" enctype="multipart/form-data" method="post"  class="mar_t15">
		  <div class="form-group">
			 <label for="news_newsId_edit" class="col-md-3 text-right">资讯id:</label>
			 <div class="col-md-9"> 
			 	<input type="text" id="news_newsId_edit" name="news.newsId" class="form-control" placeholder="请输入资讯id" readOnly>
			 </div>
		  </div> 
		  <div class="form-group">
		  	 <label for="news_newsPhoto_edit" class="col-md-3 text-right">资讯图片:</label>
		  	 <div class="col-md-9">
			    <img  class="img-responsive" id="news_newsPhotoImg" border="0px"/><br/>
			    <input type="hidden" id="news_newsPhoto" name="news.newsPhoto"/>
			    <input id="newsPhotoFile" name="newsPhotoFile" type="file" size="50" />
		  	 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="news_title_edit" class="col-md-3 text-right">资讯标题:</label>
		  	 <div class="col-md-9">
			    <input type="text" id="news_title_edit" name="news.title" class="form-control" placeholder="请输入资讯标题">
			 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="news_newsTypeObj_typeId_edit" class="col-md-3 text-right">资讯类别:</label>
		  	 <div class="col-md-9">
			    <select id="news_newsTypeObj_typeId_edit" name="news.newsTypeObj.typeId" class="form-control">
			    </select>
		  	 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="news_content_edit" class="col-md-3 text-right">资讯内容:</label>
		  	 <div class="col-md-9">
			    <script name="news.content" id="news_content_edit" type="text/plain"   style="width:100%;height:500px;"></script>
			 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="news_showFlag_edit" class="col-md-3 text-right">是否显示:</label>
		  	 <div class="col-md-9">
			    <input type="text" id="news_showFlag_edit" name="news.showFlag" class="form-control" placeholder="请输入是否显示">
			 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="news_publishDate_edit" class="col-md-3 text-right">发布时间:</label>
		  	 <div class="col-md-9">
                <div class="input-group date news_publishDate_edit col-md-12" data-link-field="news_publishDate_edit">
                    <input class="form-control" id="news_publishDate_edit" name="news.publishDate" size="16" type="text" value="" placeholder="请选择发布时间" readonly>
                    <span class="input-group-addon"><span class="glyphicon glyphicon-remove"></span></span>
                    <span class="input-group-addon"><span class="glyphicon glyphicon-calendar"></span></span>
                </div>
		  	 </div>
		  </div>
			  <div class="form-group">
			  	<span class="col-md-3""></span>
			  	<span onclick="ajaxNewsModify();" class="btn btn-primary bottom5 top5">修改</span>
			  </div>
		</form> 
	    <style>#newsEditForm .form-group {margin-bottom:5px;}  </style>
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
/*弹出修改新闻资讯界面并初始化数据*/
function newsEdit(newsId) {
	$.ajax({
		url :  basePath + "News/NewsController.aspx?action=getNews&newsId=" + newsId,
		type : "get",
		dataType: "json",
		success : function (news, response, status) {
			if (news) {
				$("#news_newsId_edit").val(news.newsId);
				$("#news_newsPhoto").val(news.newsPhoto);
				$("#news_newsPhotoImg").attr("src", basePath +　news.newsPhoto);
				$("#news_title_edit").val(news.title);
				$.ajax({
					url: basePath + "NewsType/NewsTypeController.aspx?action=listAll",
					type: "get",
					dataType: "json",
					success: function(newsTypes,response,status) { 
						$("#news_newsTypeObj_typeId_edit").empty();
						var html="";
		        		$(newsTypes).each(function(i,newsType){
		        			html += "<option value='" + newsType.typeId + "'>" + newsType.typeName + "</option>";
		        		});
		        		$("#news_newsTypeObj_typeId_edit").html(html);
		        		$("#news_newsTypeObj_typeId_edit").val(news.newsTypeObjPri);
					}
				});
				$("#news_content_edit").val(news.content);
				$("#news_showFlag_edit").val(news.showFlag);
				$("#news_publishDate_edit").val(news.publishDate);
			} else {
				alert("获取信息失败！");
			}
		}
	});
}

/*ajax方式提交新闻资讯信息表单给服务器端修改*/
function ajaxNewsModify() {
	$.ajax({
		url :  basePath + "News/NewsController.aspx?action=update",
		type : "post",
		dataType: "json",
		data: new FormData($("#newsEditForm")[0]),
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
    /*发布时间组件*/
    $('.news_publishDate_edit').datetimepicker({
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
    newsEdit('<%=Request["newsId"] %>');
 })
 </script> 
</body>
</html>

