using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using com.force.json;

public partial class NewsComment_NewsCommentController : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string action = Request.QueryString["action"];
        if (action == "add") addNewsComment();
        if (action == "userAdd") userAddNewsComment();
        if (action == "delete") deleteNewsComment();
        if (action == "update") updateNewsComment();
        if (action == "getNewsComment") getNewsComment();
        if (action == "listAll") listAll();
    }

    //处理添加资讯评论控制层方法
    protected void addNewsComment()
    {
        int success = 0;
        string message = "";
        ENTITY.NewsComment newsComment = new ENTITY.NewsComment();
        newsComment.newsObj = int.Parse(Request["newsComment.newsObj.newsId"]);
        newsComment.content = Request["newsComment.content"];
        newsComment.userObj = Request["newsComment.userObj.user_name"];
        newsComment.commentTime = Request["newsComment.commentTime"];
        if (!BLL.bllNewsComment.AddNewsComment(newsComment))
        {
            message = "添加资讯评论发生错误!";
            writeResult(success, message);
            return;
        }
        success = 1;
        writeResult(success, message);
    }


    //处理添加资讯评论控制层方法
    protected void userAddNewsComment()
    {
        int success = 0;
        string message = "";
        if (Session["user_name"] == null)
        {
            message = "请先登录网站!";
            writeResult(success, message);
            return;
        }

        ENTITY.NewsComment newsComment = new ENTITY.NewsComment();
        newsComment.newsObj = int.Parse(Request["newsComment.newsObj.newsId"]);
        newsComment.content = Request["newsComment.content"];
        newsComment.userObj = Session["user_name"].ToString();
        newsComment.commentTime = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString();

        if (!BLL.bllNewsComment.AddNewsComment(newsComment))
        {
            message = "添加资讯评论发生错误!";
            writeResult(success, message);
            return;
        }
        success = 1;
        writeResult(success, message);
    }


    //处理删除资讯评论控制层方法
    protected void deleteNewsComment()
    {
        int success = 0;
        string message = "";
        string commentId = Request["commentId"];
        try {
            BLL.bllNewsComment.DelNewsComment(commentId);
            success = 1;
        } catch {
            message = "资讯评论删除失败";
        }
        writeResult(success, message);
    }

    //处理更新资讯评论控制层方法
    protected void updateNewsComment()
    {
        int success = 0;
        string message = "";
        ENTITY.NewsComment newsComment = new ENTITY.NewsComment();
        newsComment.commentId = int.Parse(Request["NewsComment.commentId"]);
        newsComment.newsObj = int.Parse(Request["newsComment.newsObj.newsId"]);
        newsComment.content = Request["newsComment.content"];
        newsComment.userObj = Request["newsComment.userObj.user_name"];
        newsComment.commentTime = Request["newsComment.commentTime"];
        if (!BLL.bllNewsComment.EditNewsComment(newsComment))
        {
            message = "更新资讯评论发生错误!";
            writeResult(success, message);
            return;
        }
        success = 1;
        writeResult(success, message);
    }

    //获取单个资讯评论对象，返回json格式
    protected void getNewsComment()
    {
        int commentId = int.Parse(Request.QueryString["commentId"]);
        ENTITY.NewsComment newsComment = BLL.bllNewsComment.getSomeNewsComment(commentId);
        JSONObject jsonNewsComment = new JSONObject();
        jsonNewsComment.Put("commentId", newsComment.commentId);
        jsonNewsComment.Put("newsObj", BLL.bllNews.getSomeNews(newsComment.newsObj).title);
        jsonNewsComment.Put("newsObjPri", newsComment.newsObj);
        jsonNewsComment.Put("content", newsComment.content);
        jsonNewsComment.Put("userObj", BLL.bllUserInfo.getSomeUserInfo(newsComment.userObj).name);
        jsonNewsComment.Put("userObjPri", newsComment.userObj);
        jsonNewsComment.Put("commentTime", newsComment.commentTime);
        Response.Write(jsonNewsComment.ToString());
    }

    protected void listAll()
    {
        DataSet newsCommentDs = BLL.bllNewsComment.getAllNewsComment();
        JSONArray newsCommentArray = new JSONArray();
        for (int i = 0; i < newsCommentDs.Tables[0].Rows.Count; i++)
        {
            DataRow dr = newsCommentDs.Tables[0].Rows[i];
            JSONObject jsonNewsComment = new JSONObject();
            jsonNewsComment.Put("commentId", Convert.ToInt32(dr["commentId"]));
            jsonNewsComment.Put("content", dr["content"].ToString());
            newsCommentArray.Put(jsonNewsComment);
        }
        Response.Write(newsCommentArray.ToString());
    }

    //把处理结果返回给界面层
    protected void writeResult(int success, string message)
    {
        JSONObject resultObj = new JSONObject();
        resultObj.Put("success", success);
        resultObj.Put("message", message);
        Response.Write(resultObj.ToString());
    }

}
