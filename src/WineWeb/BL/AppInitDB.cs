using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WineWeb.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace WineWeb.BL
{
    public class AppInitDB
    {

        //初始化数据库

        //初始化数据集

        public void InitData()
        {
            //使用
            //MongoDatabase database = Common.GetDatabase();
            //AppInitDB appInitDB = new AppInitDB();
            //appInitDB.InitData();

            MongoDatabase database = Common.GetDatabase();
            //插入数据
            var collection = database.GetCollection<Encyclopedia>("Encyclopedia");

            for (int i = 0; i < 20; i++ )
            {
                var encyclopedia = new Encyclopedia { Id = Guid.NewGuid().ToString(), thum = "userUpload/" + i + ".jpg", date = DateTime.Now, title = i + "_title", content = i + "_content" };
                collection.Insert(encyclopedia);
            }
         
        }


    }
}