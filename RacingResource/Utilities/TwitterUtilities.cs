using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using LinqToTwitter;

namespace RacingResource.Utilities
{
    public class TwitterUtilities
    {
        public static SingleUserAuthorizer GetAuthorizer()
        {
            var auth = new SingleUserAuthorizer
            {
                Credentials = new InMemoryCredentials
                {
                    ConsumerKey = ConfigurationManager.AppSettings["twitterConsumerKey"],
                    ConsumerSecret = ConfigurationManager.AppSettings["twitterConsumerSecret"],
                    OAuthToken = ConfigurationManager.AppSettings["twitterOAuthToken"],
                    AccessToken = ConfigurationManager.AppSettings["twitterAccessToken"]
                }
            };
            return auth;
        }


    }
}