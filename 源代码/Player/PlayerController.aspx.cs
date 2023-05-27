using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using com.force.json;

public partial class Player_PlayerController : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string action = Request.QueryString["action"];
        if (action == "add") addPlayer();
        if (action == "delete") deletePlayer();
        if (action == "update") updatePlayer();
        if (action == "getPlayer") getPlayer();
        if (action == "listAll") listAll();
    }
    //处理添加球员控制层方法
    protected void addPlayer()
    {
        int success = 0;
        string message = "";
        ENTITY.Player player = new ENTITY.Player();
        player.playerName = Request["player.playerName"];
        player.playerEnglishName = Request["player.playerEnglishName"];
        player.teamObj = int.Parse(Request["player.teamObj.teamId"]);
        try {
            player.playerPhoto = handleImageUpload("playerPhotoFile");
        } catch {
            message = "图片格式不正确！";
            writeResult(success, message);
            return;
        }
        player.playerNumber = Request["player.playerNumber"];
        player.position = Request["player.position"];
        player.hight = int.Parse(Request["player.hight"]);
        player.weight = float.Parse(float.Parse(Request["player.weight"]).ToString("0.00"));
        player.age = int.Parse(Request["player.age"]);
        player.salary = float.Parse(float.Parse(Request["player.salary"]).ToString("0.00"));
        player.superStarFlag = Request["player.superStarFlag"];
        player.playerDesc = Request["player.playerDesc"];
        player.addTime = Convert.ToDateTime(Request["player.addTime"]);
        if (!BLL.bllPlayer.AddPlayer(player))
        {
            message = "添加球员发生错误!";
            writeResult(success, message);
            return;
        }
        success = 1;
        writeResult(success, message);
    }

    //处理删除球员控制层方法
    protected void deletePlayer()
    {
        int success = 0;
        string message = "";
        string playerId = Request["playerId"];
        try {
            BLL.bllPlayer.DelPlayer(playerId);
            success = 1;
        } catch {
            message = "球员删除失败";
        }
        writeResult(success, message);
    }

    //处理更新球员控制层方法
    protected void updatePlayer()
    {
        int success = 0;
        string message = "";
        ENTITY.Player player = new ENTITY.Player();
        player.playerId = int.Parse(Request["Player.playerId"]);
        player.playerName = Request["player.playerName"];
        player.playerEnglishName = Request["player.playerEnglishName"];
        player.teamObj = int.Parse(Request["player.teamObj.teamId"]);
        player.playerPhoto = Request["player.playerPhoto"];
        string playerPhotoPath = handleImageUpload("playerPhotoFile");
        if (playerPhotoPath != "FileUpload/NoImage.jpg") player.playerPhoto = playerPhotoPath;
        player.playerNumber = Request["player.playerNumber"];
        player.position = Request["player.position"];
        player.hight = int.Parse(Request["player.hight"]);
        player.weight = float.Parse(float.Parse(Request["player.weight"]).ToString("0.00"));
        player.age = int.Parse(Request["player.age"]);
        player.salary = float.Parse(float.Parse(Request["player.salary"]).ToString("0.00"));
        player.superStarFlag = Request["player.superStarFlag"];
        player.playerDesc = Request["player.playerDesc"];
        player.addTime = Convert.ToDateTime(Request["player.addTime"]);
        if (!BLL.bllPlayer.EditPlayer(player))
        {
            message = "更新球员发生错误!";
            writeResult(success, message);
            return;
        }
        success = 1;
        writeResult(success, message);
    }

    //获取单个球员对象，返回json格式
    protected void getPlayer()
    {
        int playerId = int.Parse(Request.QueryString["playerId"]);
        ENTITY.Player player = BLL.bllPlayer.getSomePlayer(playerId);
        JSONObject jsonPlayer = new JSONObject();
        jsonPlayer.Put("playerId", player.playerId);
        jsonPlayer.Put("playerName", player.playerName);
        jsonPlayer.Put("playerEnglishName", player.playerEnglishName);
        jsonPlayer.Put("teamObj", BLL.bllTeam.getSomeTeam(player.teamObj).teamName);
        jsonPlayer.Put("teamObjPri", player.teamObj);
        jsonPlayer.Put("playerPhoto", player.playerPhoto);
        jsonPlayer.Put("playerNumber", player.playerNumber);
        jsonPlayer.Put("position", player.position);
        jsonPlayer.Put("hight", player.hight);
        jsonPlayer.Put("weight", player.weight);
        jsonPlayer.Put("age", player.age);
        jsonPlayer.Put("salary", player.salary);
        jsonPlayer.Put("superStarFlag", player.superStarFlag);
        jsonPlayer.Put("playerDesc", player.playerDesc);
        jsonPlayer.Put("addTime", player.addTime.ToShortDateString() + " " + player.addTime.ToLongTimeString());
        Response.Write(jsonPlayer.ToString());
    }

    protected void listAll()
    {
        DataSet playerDs = BLL.bllPlayer.getAllPlayer();
        JSONArray playerArray = new JSONArray();
        for (int i = 0; i < playerDs.Tables[0].Rows.Count; i++)
        {
            DataRow dr = playerDs.Tables[0].Rows[i];
            JSONObject jsonPlayer = new JSONObject();
            jsonPlayer.Put("playerId", Convert.ToInt32(dr["playerId"]));
            jsonPlayer.Put("playerName", dr["playerName"].ToString());
            playerArray.Put(jsonPlayer);
        }
        Response.Write(playerArray.ToString());
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
