using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;
using MongoDB.Driver;

namespace WineWeb.BL
{
    public class Common
    {
        //默认数据库名称
        static public string defaultDatabaseName
        {
            get { return "testdb"; }
        }

        //获取数据库实体
        static public MongoDatabase GetDatabase()
        {
            return GetDatabase(Common.defaultDatabaseName);
        }
        //获取数据库实体
        static public MongoDatabase GetDatabase(string databaseName)
        {
            //  MongoDB连接串，以[mongodb: // ]开头。这里，我们连接的是本机的服务 默认端口27017
            //string connectionString = "mongodb://localhost";
            string connectionString = "mongodb://61.147.124.16";
            //  连接到一个MongoServer上 
            MongoServer server = MongoServer.Create(connectionString);
            //  打开数据库testdb 
            return server.GetDatabase("testdb");
        }

        //字符串长度处理
        public static string HandleStringLength(string str, int len)
        {
            if (str == null)
            {
                return "";
            }

            else if (str.Length > len)
            {
                return str.Substring(0, len - 1) + "...";
            }
            else
            { return str; }
        }
    }
}