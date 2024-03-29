﻿using SQLite;
using System;

namespace Maui_Flower_App.Helpers
{
    public static class Constants
    {
        public static class FirebaseConstants
        {
            public const string BaseUrl = "https://mauiflowerapp-default-rtdb.europe-west1.firebasedatabase.app/";
            public const string ClientsCollection = "Clients/";
            public const string FlowersCollection = "Flowers/";
            public const string JsonPostfix = ".json";
        }

        public static class AppConstants
        {
            public static class SqlLiteConstants
            {
                public const string DBFileName = "FlowerAppSqlLite.db3";
                public const SQLiteOpenFlags Flags =
                    SQLiteOpenFlags.ReadWrite |
                    SQLiteOpenFlags.Create |
                    SQLiteOpenFlags.SharedCache;

                public static string DatabasePath
                {
                    get
                    {
                        return Path.Combine(FileSystem.AppDataDirectory, DBFileName);
                    }
                }
            }

            public static class Error
            {
                public const string ErrorWord = "Error";
                public const string ErrorMessage = "Something went wrong";
            }

            public static class Message
            {
                public const string MessageWord = "Message";
                public const string UserAdded = "User was successfully added";
                public const string UserUpdated = "User was successfully updated";
                public const string UserDeleted = "Client was successfully deleted";
                public const string FlowerAdded = "Flower was successfully added";
                public const string FlowerUpdated = "Flower was successfully updated";
                public const string FlowerDeleted = "Flower was successfully deleted";
                public const string Attention = "Attention!";
                public const string DeleteClientAttentionMessage = "Are you sure you want to delete this client?";
                public const string DeleteFlowerAttentionMessage = "Are you sure you want to delete this flower?";
            }
        }
    }
}
