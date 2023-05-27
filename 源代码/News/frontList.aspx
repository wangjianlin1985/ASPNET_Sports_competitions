<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frontList.aspx.cs" Inherits="News_frontList" %>
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
<title>新闻资讯查询</title>
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
  			<li><a href="frontList.aspx">新闻资讯信息列表</a></li>
  			<li class="active">查询结果显示</li>
  			<a class="pull-right" href="frontAdd.aspx" style="display:none;">添加新闻资讯</a>
		</ul>
		<div class="row">
			<asp:Repeater ID="RpNews" runat="server">
			<ItemTemplate>
			<div class="col-md-3 bottom15" <%#(((Container.ItemIndex+0)%4==0)?"style='clear:left;'":"") %>>
			  <a href="frontshow.aspx?newsId=<%#Eval("newsId")%>"><img class="img-responsive" src="../<%#Eval("newsPhoto")%>" /></a>
			     <div class="showFields">
			     	<div class="field">
	            		资讯id: <%#Eval("newsId")%>
			     	</div>
			     	<div class="field">
	            		资讯标题: <%#Eval("title")%>
			     	</div>
			     	<div class="field">
	            		资讯类别:<%#GetNewsTypenewsTypeObj(Eval("newsTypeObj").ToString())%>
			     	</div>
			     	<div class="field">
	            		是否显示: <%#Eval("showFlag")%>
			     	</div>
			     	<div class="field">
	            		发布时间: <%#Eval("publishDate")%>
			     	</div>
			        <a class="btn btn-primary top5" href="frontShow.aspx?newsId=<%#Eval("newsId")%>">详情</a>
			        <a class="btn btn-primary top5" onclick="newsEdit('<%#Eval("newsId")%>');" style="display:none;">修改</a>
			        <a class="btn btn-primary top5" onclick="newsDelete('<%#Eval("newsId")%>');" style="display:none;">删除</a>
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
    		<h1>新闻资讯查询</h1>
		</div>
			<div class="form-group">
				<label for="title">资讯标题:</label>
				<asp:TextBox ID="title" runat="server"  CssClass="form-control" placeholder="请输入资讯标题"></asp:TextBox>
			</div>
            <div class="form-group" style="display:none;">
            	<label for="newsTypeObj_typeId">资讯类别：</label>
                <asp:DropDownList ID="newsTypeObj" runat="server"  CssClass="form-control" placeholder="请选择资讯类别"></asp:DropDownList>
            </div>
			<div class="form-group" style="display:none;">
				<label for="showFlag">是否显示:</label>
				<asp:TextBox ID="showFlag" runat="server"  CssClass="form-control" placeholder="请输入是否显示"></asp:TextBox>
			</div>
			<div class="form-group">
				<label for="publishDate">发布时间:</label>
				<asp:TextBox ID="publishDate"  runat="server" CssClass="form-control" placeholder="请选择发布时间" onclick="SelectDate(this,'yyyy-MM-dd');"></asp:TextBox>
			</div>
        <asp:Button ID="btnSearch" CssClass="btn btn-primary" runat="server" Text="查询" onclick="btnSearch_Click" />
	</div>
  </form>
</div>
<div id="newsEditDialog" class="modal fade" tabindex="-1" role="dialog">
  <div class="modal-dialog" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
        <h4 class="modal-title"><i class="fa fa-edit"></i>&nbsp;新闻资讯信息编辑</h4>
      </div>
      <div class="modal-body" style="height:450px; overflow: scroll;">
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
			    <textarea id="news_content_edit" name="news.content" rows="8" class="form-control" placeholder="请输入资讯内容"></textarea>
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
		</form> 
	    <style>#newsEditForm .form-group {margin-bottom:5px;}  </style>
      </div>
      <div class="modal-footer"> 
      	<button type="button" class="btn btn-default" data-dismiss="modal">关闭</button>
      	<button type="button" class="btn btn-primary" onclick="ajaxNewsModify();">提交</button>
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
				$('#newsEditDialog').modal('show');
			} else {
				alert("获取信息失败！");
			}
		}
	});
}

/*删除新闻资讯信息*/
function newsDelete(newsId) {
	if(confirm("确认删除这个记录")) {
		$.ajax({
			type : "POST",
			url : basePath + "News/NewsController.aspx?action=delete",
			data : {
				newsId : newsId,
			},
			dataType: "json",
			success : function (obj) {
				if (obj.success) {
					alert("删除成功");
                    $("#btnSearch").click();
					//location.href= basePath + "News/frontList.aspx";
				}
				else 
					alert(obj.message);
			},
		});
	}
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
})
</script>
</body>
</html>

