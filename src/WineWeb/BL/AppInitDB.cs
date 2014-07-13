using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WineWeb.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace WineWeb.BL
{
    public class AppInitDB
    {
        MongoDatabase database = Common.GetDatabase();

        public void InitData()
        {
            //酒事百科
            EncyclopediaCollectionInit();

            //推荐产品分类
            ProductCategoCollectionInit();

            //初始化推荐产品
            ProductCollectionInit();


        }

        //初始化酒事百科collection
        private void EncyclopediaCollectionInit()
        {
            database.Drop();
            //新建集合Encyclopedia并插入初始化数据
            var encyclopediaCollection = database.GetCollection<Encyclopedia>("Encyclopedia");

            for (int i = 0; i < 20; i++)
            {
                var encyclopedia = new Encyclopedia { Id = Guid.NewGuid().ToString(), thum = "userUpload/baikeListThum.jpg", date = DateTime.Now, title = i + "_title", content = i + "_content" };
                encyclopediaCollection.Insert(encyclopedia);
            }
        }
        //初始化推荐产品分类collection
        private void ProductCategoCollectionInit()
        {
            var productCategoryCollection = database.GetCollection<ProductCategory>("ProductCategory");

            var productCategory1 = new ProductCategory { Id = "1", name = "红葡萄酒", index = 3 };
            var productCategory2 = new ProductCategory { Id = "2", name = "白葡萄酒", index = 2 };
            var productCategory3 = new ProductCategory { Id = "3", name = "气泡酒及其他", index = 1 };
            productCategoryCollection.Insert(productCategory1);
            productCategoryCollection.Insert(productCategory2);
            productCategoryCollection.Insert(productCategory3);

        }
        //初始化推荐产品
        private void ProductCollectionInit()
        {
            var productCollection = database.GetCollection<Product>("ProductCategory");
            var category = productCollection.AsQueryable<ProductCategory>().ToList();

            //查询产品的分类
            var collection = database.GetCollection<Product>("Product");


            for (int c = 1; c <= 3; c++)
            {
                for (int i = 0; i < 20; i++)
                {
                    if (i % 2 == 0)
                    {
                        var product = new Product
                        {
                            Id = Guid.NewGuid().ToString(),
                            thum = "images/goods_01.jpg",
                            date = DateTime.Now,
                            title1 = i + "_Cabernet Franc",
                            title2 = i + "_品丽珠",
                            content = i + "_别名卡门耐特，原种解百纳，原产法国，为法国古老的酿酒品种，世界各地均有栽培，是赤霞珠蛇龙珠的.......",
                            category = category.SingleOrDefault(t => t.Id == c.ToString())
                        };
                        collection.Insert(product);
                    }
                    else
                    {
                        var product = new Product
                        {
                            Id = Guid.NewGuid().ToString(),
                            thum = "images/goods_02.jpg",
                            date = DateTime.Now,
                            title1 = i + "拉哥杰古堡",
                            title2 = i + "_优级酿制2010佳酿",
                            content = i + "_别名卡门耐特，原种解百纳，原产法国，为法国古老的酿酒品种，世界各地均有栽培，是赤霞珠蛇龙珠的.......",
                            category = category.SingleOrDefault(t => t.Id == c.ToString())
                        };
                        collection.Insert(product);
                    }

                }
            }
        }
    }
}