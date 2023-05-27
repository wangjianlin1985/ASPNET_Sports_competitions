using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using com.force.json;

public partial class NewsType_NewsTypeController : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string action = Request.QueryString["action"];
        if (action == "add") addNewsType();
        if (action == "delete") deleteNewsType();
        if (action == "update") updateNewsType();
        if (action == "getNewsType") getNewsType();
        if (action == "listAll") listAll();
    }
    //处理添加资讯类别控制层方法
    protected void addNewsType()
    {
        int success = 0;
        string message = "";
        ENTITY.NewsType newsType = new ENTITY.NewsType();
        newsType.typeName = Request["newsType.typeName"];
        if (!BLL.bllNewsType.AddNewsType(newsType))
        {
            message = "添加资讯类别发生错误!";
            writeResult(success, message);
            return;
        }
        success = 1;
        writeResult(success, message);
    }

    //处理删除资讯类别控制层方法
    protected void deleteNewsType()
    {
        int success = 0;
        string message = "";
        string typeId = Request["typeId"];
        try {
            BLL.bllNewsType.DelNewsType(typeId);
            success = 1;
        } catch {
            message = "资讯类别删除失败";
        }
        writeResult(success, message);
    }

    //处理更新资讯类别控制层方法
    protected void updateNewsType()
    {
        int success = 0;
        string message = "";
        ENTITY.NewsType newsType = new ENTITY.NewsType();
        newsType.typeId = int.Parse(Request["NewsType.typeId"]);
        newsType.typeName = Request["newsType.typeName"];
        if (!BLL.bllNewsType.EditNewsType(newsType))
        {
            message = "更新资讯类别发生错误!";
            writeResult(success, message);
            return;
        }
        success = 1;
        writeResult(success, message);
    }

    //获取单个资讯类别对象，返回json格式
    protected void getNewsType()
    {
        int typeId = int.Parse(Request.QueryString["typeId"]);
        ENTITY.NewsType newsType = BLL.bllNewsType.getSomeNewsType(typeId);
        JSONObject jsonNewsType = new JSONObject();
        jsonNewsType.Put("typeId", newsType.typeId);
        jsonNewsType.Put("typeName", newsType.typeName);
        Response.Write(jsonNewsType.ToString());
    }

    protected void listAll()
    {
        DataSet newsTypeDs = BLL.bllNewsType.getAllNewsType();
        JSONArray newsTypeArray = new JSONArray();
        for (int i = 0; i < newsTypeDs.Tables[0].Rows.Count; i++)
        {
            DataRow dr = newsTypeDs.Tables[0].Rows[i];
            JSONObject jsonNewsType = new JSONObject();
            jsonNewsType.Put("typeId", Convert.ToInt32(dr["typeId"]));
            jsonNewsType.Put("typeName", dr["typeName"].ToString());
            newsTypeArray.Put(jsonNewsType);
        }
        Response.Write(newsTypeArray.ToString());
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
