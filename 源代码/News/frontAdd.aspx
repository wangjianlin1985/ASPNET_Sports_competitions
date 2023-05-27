<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frontAdd.aspx.cs" Inherits="News_frontAdd" %>
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
<title>新闻资讯添加</title>
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
  			<li><a href="<%=basePath %>News/frontList.aspx">新闻资讯管理</a></li>
  			<li class="active">添加新闻资讯</li>
		</ul>
		<div class="row">
			<div class="col-md-10">
		      	<form class="form-horizontal" name="newsAddForm" id="newsAddForm" enctype="multipart/form-data" method="post"  class="mar_t15">
				  <div class="form-group">
				  	 <label for="news_newsPhoto" class="col-md-2 text-right">资讯图片:</label>
				  	 <div class="col-md-8">
					    <img  class="img-responsive" id="news_newsPhotoImg" border="0px"/><br/>
					    <input type="hidden" id="news_newsPhoto" name="news.newsPhoto"/>
					    <input id="newsPhotoFile" name="newsPhotoFile" type="file" size="50" />
				  	 </div>
				  </div>
				  <div class="form-group">
				  	 <label for="news_title" class="col-md-2 text-right">资讯标题:</label>
				  	 <div class="col-md-8">
					    <input type="text" id="news_title" name="news.title" class="form-control" placeholder="请输入资讯标题">
					 </div>
				  </div>
				  <div class="form-group">
				  	 <label for="news_newsTypeObj_typeId" class="col-md-2 text-right">资讯类别:</label>
				  	 <div class="col-md-8">
					    <select id="news_newsTypeObj_typeId" name="news.newsTypeObj.typeId" class="form-control">
					    </select>
				  	 </div>
				  </div>
				  <div class="form-group">
				  	 <label for="news_content" class="col-md-2 text-right">资讯内容:</label>
				  	 <div class="col-md-8">
					    <textarea id="news_content" name="news.content" rows="8" class="form-control" placeholder="请输入资讯内容"></textarea>
					 </div>
				  </div>
				  <div class="form-group">
				  	 <label for="news_showFlag" class="col-md-2 text-right">是否显示:</label>
				  	 <div class="col-md-8">
					    <input type="text" id="news_showFlag" name="news.showFlag" class="form-control" placeholder="请输入是否显示">
					 </div>
				  </div>
				  <div class="form-group">
				  	 <label for="news_publishDateDiv" class="col-md-2 text-right">发布时间:</label>
				  	 <div class="col-md-8">
		                <div id="news_publishDateDiv" class="input-group date news_publishDate col-md-12" data-link-field="news_publishDate">
		                    <input class="form-control" id="news_publishDate" name="news.publishDate" size="16" type="text" value="" placeholder="请选择发布时间" readonly>
		                    <span class="input-group-addon"><span class="glyphicon glyphicon-remove"></span></span>
		                    <span class="input-group-addon"><span class="glyphicon glyphicon-calendar"></span></span>
		                </div>
				  	 </div>
				  </div>
		          <div class="form-group">
		             <span class="col-md-2""></span>
		             <span onclick="ajaxNewsAdd();" class="btn btn-primary bottom5 top5">添加</span>
		          </div> 
		          <style>#newsAddForm .form-group {margin:5px;}  </style>  
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
	//提交添加新闻资讯信息
	function ajaxNewsAdd() { 
		//提交之前先验证表单
		$("#newsAddForm").data('bootstrapValidator').validate();
		if(!$("#newsAddForm").data('bootstrapValidator').isValid()){
			return;
		}
		jQuery.ajax({
			type : "post",
			url : basePath + "News/NewsController.aspx?action=add",
			dataType : "json" , 
			data: new FormData($("#newsAddForm")[0]),
			success : function(obj) {
				if(obj.success){ 
					alert("保存成功！");
					$("#newsAddForm").find("input").val("");
					$("#newsAddForm").find("textarea").val("");
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
	//验证新闻资讯添加表单字段
	$('#newsAddForm').bootstrapValidator({
		feedbackIcons: {
			valid: 'glyphicon glyphicon-ok',
			invalid: 'glyphicon glyphicon-remove',
			validating: 'glyphicon glyphicon-refresh'
		},
		fields: {
			"news.title": {
				validators: {
					notEmpty: {
						message: "资讯标题不能为空",
					}
				}
			},
			"news.showFlag": {
				validators: {
					notEmpty: {
						message: "是否显示不能为空",
					}
				}
			},
			"news.publishDate": {
				validators: {
					notEmpty: {
						message: "发布时间不能为空",
					}
				}
			},
		}
	}); 
	//初始化资讯类别下拉框值 
	$.ajax({
		url: basePath + "NewsType/NewsTypeController.aspx?action=listAll",
		type: "get",
		dataType: "json",
		success: function(newsTypes,response,status) { 
			$("#news_newsTypeObj_typeId").empty();
			var html="";
    		$(newsTypes).each(function(i,newsType){
    			html += "<option value='" + newsType.typeId + "'>" + newsType.typeName + "</option>";
    		});
    		$("#news_newsTypeObj_typeId").html(html);
    	}
	});
	//发布时间组件
	$('#news_publishDateDiv').datetimepicker({
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
		$('#newsAddForm').data('bootstrapValidator').updateStatus('news.publishDate', 'NOT_VALIDATED',null).validateField('news.publishDate');
	});
})
</script>
</body>
</html>
