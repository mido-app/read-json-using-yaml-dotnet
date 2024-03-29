﻿using System;
using System.IO;
using System.Text;
using YamlDotNet.Serialization;

namespace ReadJsonUsingYamlDotNet
{
    class Program
    {
        static void Main(string[] args)
        {
            // デシリアライザをデフォルトの設定で生成
            var builder = new DeserializerBuilder();
            var deserializer = builder.Build();

            // ファイルの内容をSomeObjectにデシリアライズ
            SomeObject deserializedObj = null;
            string filepath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Data\Data.json");
            using (var data = new StreamReader(filepath, Encoding.UTF8))
            {
                deserializedObj = deserializer.Deserialize<SomeObject>(data);
            }

            // 結果をコンソール出力
            Console.WriteLine(string.Format("Number : {0}", deserializedObj.Number));
            Console.WriteLine(string.Format("Text1  : {0}", deserializedObj.Text1));
            Console.WriteLine(string.Format("Text2  : {0}", deserializedObj.Text2));
            Console.ReadKey();
        }
    }

    class SomeObject
    {
        public int Number { get; set; }
        public string Text1 { get; set; }
        public string Text2 { get; set; }
    }
}
