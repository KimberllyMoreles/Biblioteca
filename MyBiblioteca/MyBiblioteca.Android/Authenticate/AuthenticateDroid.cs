﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MyBiblioteca.Droid.Authenticate;
using MyBiblioteca.Authenticate;
using Microsoft.WindowsAzure.MobileServices;
using System.Threading.Tasks;

[assembly: Xamarin.Forms.Dependency(typeof(AuthenticateDroid))]
namespace MyBiblioteca.Droid.Authenticate
{
    public class AuthenticateDroid : IAuthenticate
    {
        public async Task<MobileServiceUser> Authenticate(MobileServiceClient client, MobileServiceAuthenticationProvider provider)
        {
            try
            {
                return await client.LoginAsync(Xamarin.Forms.Forms.Context, provider);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}