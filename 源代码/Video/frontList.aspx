<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frontList.aspx.cs" Inherits="Video_frontList" %>
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
<title>视频查询</title>
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
  			<li><a href="frontList.aspx">视频信息列表</a></li>
  			<li class="active">查询结果显示</li>
  			<a class="pull-right" href="frontAdd.aspx" style="display:none;">添加视频</a>
		</ul>
		<div class="row">
			<asp:Repeater ID="RpVideo" runat="server">
			<ItemTemplate>
			<div class="col-md-3 bottom15" <%#(((Container.ItemIndex+0)%4==0)?"style='clear:left;'":"") %>>
			  <a href="frontshow.aspx?videoId=<%#Eval("videoId")%>"><img class="img-responsive" src="../<%#Eval("videoPhoto")%>" /></a>
			     <div class="showFields">
			     	<div class="field">
	            		视频id: <%#Eval("videoId")%>
			     	</div>
			     	<div class="field">
	            		视频标题: <%#Eval("title")%>
			     	</div>
			     	<div class="field">
	            		视频文件:<%#Eval("videoFile").ToString() == ""?"暂无文件":"<a href='../" + Eval("videoFile").ToString() + "' target='_blank'>" + Eval("videoFile").ToString() +  "</a>" %>
			     	</div>
			     	<div class="field">
	            		发布时间: <%#Eval("addTime")%>
			     	</div>
			        <a class="btn btn-primary top5" href="frontShow.aspx?videoId=<%#Eval("videoId")%>">详情</a>
			        <a class="btn btn-primary top5" onclick="videoEdit('<%#Eval("videoId")%>');" style="display:none;">修改</a>
			        <a class="btn btn-primary top5" onclick="videoDelete('<%#Eval("videoId")%>');" style="display:none;">删除</a>
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
    		<h1>视频查询</h1>
		</div>
			<div class="form-group">
				<label for="title">视频标题:</label>
				<asp:TextBox ID="title" runat="server"  CssClass="form-control" placeholder="请输入视频标题"></asp:TextBox>
			</div>
			<div class="form-group">
				<label for="addTime">发布时间:</label>
				<asp:TextBox ID="addTime"  runat="server" CssClass="form-control" placeholder="请选择发布时间" onclick="SelectDate(this,'yyyy-MM-dd');"></asp:TextBox>
			</div>
        <asp:Button ID="btnSearch" CssClass="btn btn-primary" runat="server" Text="查询" onclick="btnSearch_Click" />
	</div>
  </form>
</div>
<div id="videoEditDialog" class="modal fade" tabindex="-1" role="dialog">
  <div class="modal-dialog" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
        <h4 class="modal-title"><i class="fa fa-edit"></i>&nbsp;视频信息编辑</h4>
      </div>
      <div class="modal-body" style="height:450px; overflow: scroll;">
      	<form class="form-horizontal" name="videoEditForm" id="videoEditForm" enctype="multipart/form-data" method="post"  class="mar_t15">
		  <div class="form-group">
			 <label for="video_videoId_edit" class="col-md-3 text-right">视频id:</label>
			 <div class="col-md-9"> 
			 	<input type="text" id="video_videoId_edit" name="video.videoId" class="form-control" placeholder="请输入视频id" readOnly>
			 </div>
		  </div> 
		  <div class="form-group">
		  	 <label for="video_title_edit" class="col-md-3 text-right">视频标题:</label>
		  	 <div class="col-md-9">
			    <input type="text" id="video_title_edit" name="video.title" class="form-control" placeholder="请输入视频标题">
			 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="video_videoPhoto_edit" class="col-md-3 text-right">视频主图:</label>
		  	 <div class="col-md-9">
			    <img  class="img-responsive" id="video_videoPhotoImg" border="0px"/><br/>
			    <input type="hidden" id="video_videoPhoto" name="video.videoPhoto"/>
			    <input id="videoPhotoFile" name="videoPhotoFile" type="file" size="50" />
		  	 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="video_videoDesc_edit" class="col-md-3 text-right">视频介绍:</label>
		  	 <div class="col-md-9">
			    <textarea id="video_videoDesc_edit" name="video.videoDesc" rows="8" class="form-control" placeholder="请输入视频介绍"></textarea>
			 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="video_videoFile_edit" class="col-md-3 text-right">视频文件:</label>
		  	 <div class="col-md-9">
			    <a id="video_videoFileA" target="_blank"></a><br/>
			    <input type="hidden" id="video_videoFile" name="video.videoFile"/>
			    <input id="videoFileFile" name="videoFileFile" type="file" size="50" />
		  	 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="video_addTime_edit" class="col-md-3 text-right">发布时间:</label>
		  	 <div class="col-md-9">
                <div class="input-group date video_addTime_edit col-md-12" data-link-field="video_addTime_edit">
                    <input class="form-control" id="video_addTime_edit" name="video.addTime" size="16" type="text" value="" placeholder="请选择发布时间" readonly>
                    <span class="input-group-addon"><span class="glyphicon glyphicon-remove"></span></span>
                    <span class="input-group-addon"><span class="glyphicon glyphicon-calendar"></span></span>
                </div>
		  	 </div>
		  </div>
		</form> 
	    <style>#videoEditForm .form-group {margin-bottom:5px;}  </style>
      </div>
      <div class="modal-footer"> 
      	<button type="button" class="btn btn-default" data-dismiss="modal">关闭</button>
      	<button type="button" class="btn btn-primary" onclick="ajaxVideoModify();">提交</button>
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
/*弹出修改视频界面并初始化数据*/
function videoEdit(videoId) {
	$.ajax({
		url :  basePath + "Video/VideoController.aspx?action=getVideo&videoId=" + videoId,
		type : "get",
		dataType: "json",
		success : function (video, response, status) {
			if (video) {
				$("#video_videoId_edit").val(video.videoId);
				$("#video_title_edit").val(video.title);
				$("#video_videoPhoto").val(video.videoPhoto);
				$("#video_videoPhotoImg").attr("src", basePath +　video.videoPhoto);
				$("#video_videoDesc_edit").val(video.videoDesc);
				$("#video_videoFile").val(video.videoFile);
				$("#video_videoFileA").text(video.videoFile);
				$("#video_videoFileA").attr("href", basePath +　video.videoFile);
				$("#video_addTime_edit").val(video.addTime);
				$('#videoEditDialog').modal('show');
			} else {
				alert("获取信息失败！");
			}
		}
	});
}

/*删除视频信息*/
function videoDelete(videoId) {
	if(confirm("确认删除这个记录")) {
		$.ajax({
			type : "POST",
			url : basePath + "Video/VideoController.aspx?action=delete",
			data : {
				videoId : videoId,
			},
			dataType: "json",
			success : function (obj) {
				if (obj.success) {
					alert("删除成功");
                    $("#btnSearch").click();
					//location.href= basePath + "Video/frontList.aspx";
				}
				else 
					alert(obj.message);
			},
		});
	}
}

/*ajax方式提交视频信息表单给服务器端修改*/
function ajaxVideoModify() {
	$.ajax({
		url :  basePath + "Video/VideoController.aspx?action=update",
		type : "post",
		dataType: "json",
		data: new FormData($("#videoEditForm")[0]),
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
    $('.video_addTime_edit').datetimepicker({
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

