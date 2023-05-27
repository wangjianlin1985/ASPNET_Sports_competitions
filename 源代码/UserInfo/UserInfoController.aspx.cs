using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using com.force.json;

public partial class UserInfo_UserInfoController : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string action = Request.QueryString["action"];
        if (action == "add") addUserInfo();
        if (action == "delete") deleteUserInfo();
        if (action == "update") updateUserInfo();
        if (action == "getUserInfo") getUserInfo();
        if (action == "listAll") listAll();
    }
    //处理添加用户控制层方法
    protected void addUserInfo()
    {
        int success = 0;
        string message = "";
        ENTITY.UserInfo userInfo = new ENTITY.UserInfo();
        userInfo.user_name = Request["userInfo.user_name"];
        if (BLL.bllUserInfo.getSomeUserInfo(userInfo.user_name) != null)
        {
            message = "该用户名已经存在！";
            writeResult(success, message);
            return;
        }
        userInfo.password = Request["userInfo.password"];
        userInfo.name = Request["userInfo.name"];
        userInfo.gender = Request["userInfo.gender"];
        userInfo.birthDate = Convert.ToDateTime(Request["userInfo.birthDate"]);
        try {
            userInfo.userPhoto = handleImageUpload("userPhotoFile");
        } catch {
            message = "图片格式不正确！";
            writeResult(success, message);
            return;
        }
        userInfo.telephone = Request["userInfo.telephone"];
        userInfo.email = Request["userInfo.email"];
        userInfo.address = Request["userInfo.address"];
        userInfo.regTime = Convert.ToDateTime(DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString());
        if (!BLL.bllUserInfo.AddUserInfo(userInfo))
        {
            message = "添加用户发生错误!";
            writeResult(success, message);
            return;
        }
        success = 1;
        writeResult(success, message);
    }

    //处理删除用户控制层方法
    protected void deleteUserInfo()
    {
        int success = 0;
        string message = "";
        string user_name = Request["user_name"];
        try {
            BLL.bllUserInfo.DelUserInfo(user_name);
            success = 1;
        } catch {
            message = "用户删除失败";
        }
        writeResult(success, message);
    }

    //处理更新用户控制层方法
    protected void updateUserInfo()
    {
        int success = 0;
        string message = "";
        ENTITY.UserInfo userInfo = new ENTITY.UserInfo();
        userInfo.user_name = Request["UserInfo.user_name"];
        userInfo.password = Request["userInfo.password"];
        userInfo.name = Request["userInfo.name"];
        userInfo.gender = Request["userInfo.gender"];
        userInfo.birthDate = Convert.ToDateTime(Request["userInfo.birthDate"]);
        userInfo.userPhoto = Request["userInfo.userPhoto"];
        string userPhotoPath = handleImageUpload("userPhotoFile");
        if (userPhotoPath != "FileUpload/NoImage.jpg") userInfo.userPhoto = userPhotoPath;
        userInfo.telephone = Request["userInfo.telephone"];
        userInfo.email = Request["userInfo.email"];
        userInfo.address = Request["userInfo.address"];
        userInfo.regTime = Convert.ToDateTime(Request["userInfo.regTime"]);
        if (!BLL.bllUserInfo.EditUserInfo(userInfo))
        {
            message = "更新用户发生错误!";
            writeResult(success, message);
            return;
        }
        success = 1;
        writeResult(success, message);
    }

    //获取单个用户对象，返回json格式
    protected void getUserInfo()
    {
        String user_name = Request.QueryString["user_name"];
        ENTITY.UserInfo userInfo = BLL.bllUserInfo.getSomeUserInfo(user_name);
        JSONObject jsonUserInfo = new JSONObject();
        jsonUserInfo.Put("user_name", userInfo.user_name);
        jsonUserInfo.Put("password", userInfo.password);
        jsonUserInfo.Put("name", userInfo.name);
        jsonUserInfo.Put("gender", userInfo.gender);
        jsonUserInfo.Put("birthDate", userInfo.birthDate.ToShortDateString());
        jsonUserInfo.Put("userPhoto", userInfo.userPhoto);
        jsonUserInfo.Put("telephone", userInfo.telephone);
        jsonUserInfo.Put("email", userInfo.email);
        jsonUserInfo.Put("address", userInfo.address);
        jsonUserInfo.Put("regTime", userInfo.regTime.ToShortDateString() + " " + userInfo.regTime.ToLongTimeString());
        Response.Write(jsonUserInfo.ToString());
    }

    protected void listAll()
    {
        DataSet userInfoDs = BLL.bllUserInfo.getAllUserInfo();
        JSONArray userInfoArray = new JSONArray();
        for (int i = 0; i < userInfoDs.Tables[0].Rows.Count; i++)
        {
            DataRow dr = userInfoDs.Tables[0].Rows[i];
            JSONObject jsonUserInfo = new JSONObject();
            jsonUserInfo.Put("user_name", dr["user_name"].ToString());
            jsonUserInfo.Put("name", dr["name"].ToString());
            userInfoArray.Put(jsonUserInfo);
        }
        Response.Write(userInfoArray.ToString());
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
