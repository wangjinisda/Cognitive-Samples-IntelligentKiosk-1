﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceHelpers.Add
{
    public class Configurations
    {
        public static string StorageConnectionStr = "DefaultEndpointsProtocol=https;AccountName=opgstorage;AccountKey=TC1sqyL2QKoyfpMNikhE81w2l9BmZecUEuUjYg5c79zmDN1kjkTVbUnXPLiUuAkbRlyMPsOKdBHVhKBrl1Fxaw==;EndpointSuffix=core.chinacloudapi.cn";

        public static string ContainerName = "opg01";

        public static string QueueName = "queue";

        public static string DbConnectionStr = "Server=tcp:opgdb.database.chinacloudapi.cn,1433;Database=OpgDB;User ID=opgdb@opgdb;Password=password!123;Trusted_Connection=False;Encrypt=True;Connection Timeout=30;";

        public static string FaceApiKey1 = "9973f591df194468832e2111b3d4c9ca";

        public static string Endpoint = "https://api.cognitive.azure.cn/face/v1.0";

        public static string PersonGroup = "jiwag";

        public static CognitiveFace[] FaceApiArray =
        {
            new CognitiveFace
            {
                ApiKey = "11cdf058aead4f25951f34d2b631300e",
                ApiRoot = "https://api.cognitive.azure.cn/face/v1.0"
            },
            new CognitiveFace
            {
                ApiKey = "e7ef8ba082cc4d36b656b1d35c1b99b4",
                ApiRoot = "https://api.cognitive.azure.cn/face/v1.0"
            },
            new CognitiveFace
            {
                ApiKey = "4f568584a3454dff90c6c05bdd6e14fc",
                ApiRoot = "https://api.cognitive.azure.cn/face/v1.0"
            },
            new CognitiveFace
            {
                ApiKey = "72cb1752e4914e8eaf7c9c3be5713e0a",
                ApiRoot = "https://api.cognitive.azure.cn/face/v1.0"
            },
            new CognitiveFace
            {
                ApiKey = "a4d66095bab34fa58e741c046837b23e",
                ApiRoot = "https://api.cognitive.azure.cn/face/v1.0"
            },

        };
    }
}
