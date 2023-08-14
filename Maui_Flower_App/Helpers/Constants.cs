using System;

namespace Maui_Flower_App.Helpers
{
    public static class Constants
    {
        public static class FirebaseConstants
        {
            public const string BaseUrl = "https://mauiflowerapp-default-rtdb.europe-west1.firebasedatabase.app/";
            public const string ClientsCollection = "Clients/";
            public const string JsonPostfix = ".json";
        }

        public static class AppConstants
        {
            public static class Error
            {
                public const string ErrorWord = "Error";
                public const string ErrorMessage = "Something went wrong";
            }

            public static class Message
            {
                public const string MessageWord = "Message";
                public const string UserAdded = "User was successfully added";
                public const string Attention = "Attention!";
                public const string DeleteAttentionMessage = "Are you sure you want to delete this client?";
                public const string UserDeleted = "Client was successfully deleted";
            }
        }
    }
}
