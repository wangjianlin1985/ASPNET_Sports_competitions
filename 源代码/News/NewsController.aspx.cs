using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using com.force.json;

public partial class News_NewsController : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string action = Request.QueryString["action"];
        if (action == "add") addNews();
        if (action == "delete") deleteNews();
        if (action == "update") updateNews();
        if (action == "getNews") getNews();
        if (action == "listAll") listAll();
    }
    //处理添加新闻资讯控制层方法
    protected void addNews()
    {
        int success = 0;
        string message = "";
        ENTITY.News news = new ENTITY.News();
        try {
            news.newsPhoto = handleImageUpload("newsPhotoFile");
        } catch {
            message = "图片格式不正确！";
            writeResult(success, message);
            return;
        }
        news.title = Request["news.title"];
        news.newsTypeObj = int.Parse(Request["news.newsTypeObj.typeId"]);
        news.content = Request["news.content"];
        news.showFlag = Request["news.showFlag"];
        news.publishDate = Convert.ToDateTime(Request["news.publishDate"]);
        if (!BLL.bllNews.AddNews(news))
        {
            message = "添加新闻资讯发生错误!";
            writeResult(success, message);
            return;
        }
        success = 1;
        writeResult(success, message);
    }

    //处理删除新闻资讯控制层方法
    protected void deleteNews()
    {
        int success = 0;
        string message = "";
        string newsId = Request["newsId"];
        try {
            BLL.bllNews.DelNews(newsId);
            success = 1;
        } catch {
            message = "新闻资讯删除失败";
        }
        writeResult(success, message);
    }

    //处理更新新闻资讯控制层方法
    protected void updateNews()
    {
        int success = 0;
        string message = "";
        ENTITY.News news = new ENTITY.News();
        news.newsId = int.Parse(Request["News.newsId"]);
        news.newsPhoto = Request["news.newsPhoto"];
        string newsPhotoPath = handleImageUpload("newsPhotoFile");
        if (newsPhotoPath != "FileUpload/NoImage.jpg") news.newsPhoto = newsPhotoPath;
        news.title = Request["news.title"];
        news.newsTypeObj = int.Parse(Request["news.newsTypeObj.typeId"]);
        news.content = Request["news.content"];
        news.showFlag = Request["news.showFlag"];
        news.publishDate = Convert.ToDateTime(Request["news.publishDate"]);
        if (!BLL.bllNews.EditNews(news))
        {
            message = "更新新闻资讯发生错误!";
            writeResult(success, message);
            return;
        }
        success = 1;
        writeResult(success, message);
    }

    //获取单个新闻资讯对象，返回json格式
    protected void getNews()
    {
        int newsId = int.Parse(Request.QueryString["newsId"]);
        ENTITY.News news = BLL.bllNews.getSomeNews(newsId);
        JSONObject jsonNews = new JSONObject();
        jsonNews.Put("newsId", news.newsId);
        jsonNews.Put("newsPhoto", news.newsPhoto);
        jsonNews.Put("title", news.title);
        jsonNews.Put("newsTypeObj", BLL.bllNewsType.getSomeNewsType(news.newsTypeObj).typeName);
        jsonNews.Put("newsTypeObjPri", news.newsTypeObj);
        jsonNews.Put("content", news.content);
        jsonNews.Put("showFlag", news.showFlag);
        jsonNews.Put("publishDate", news.publishDate.ToShortDateString() + " " + news.publishDate.ToLongTimeString());
        Response.Write(jsonNews.ToString());
    }

    protected void listAll()
    {
        DataSet newsDs = BLL.bllNews.getAllNews();
        JSONArray newsArray = new JSONArray();
        for (int i = 0; i < newsDs.Tables[0].Rows.Count; i++)
        {
            DataRow dr = newsDs.Tables[0].Rows[i];
            JSONObject jsonNews = new JSONObject();
            jsonNews.Put("newsId", Convert.ToInt32(dr["newsId"]));
            jsonNews.Put("title", dr["title"].ToString());
            newsArray.Put(jsonNews);
        }
        Response.Write(newsArray.ToString());
    }

    //把处理结果返回给界面层
    protected void writeResult(int success, string message)
    {
        JSONObject resultObj = new JSONObject();
        resultObj.Put("success", success);
        resultObj.Put("message", message);
        Response.Write(resultObj.ToString());
    }

    //处理图片文件上传
    protected string handleImageUpload(string fileKeyName)
    {
        string imagePath = "FileUpload/NoImage.jpg";
        HttpPostedFile photoFile = Request.Files[fileKeyName];
        if (photoFile.ContentLength > 0)
        { 
            //获取文件的扩展名
            string fileExt = Path.GetExtension(photoFile.FileName);
            List<string> ExtList = new List<string>(new string[] { ".jpg", ".gif" });
            if (!ExtList.Contains(fileExt))
            {
                throw new Exception("图片格式不正确！");
            }
            string saveFileName = DAL.Function.MakeFileName(fileExt);
            imagePath = "FileUpload/" + saveFileName;/*图片路径*/
            photoFile.SaveAs(Server.MapPath("../" + imagePath));
        }
        return imagePath;
    }

}
