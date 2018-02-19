using Android.App;
using Android.Widget;
using Android.OS;
using Video8_RestService.REST;
using System;
using System.Collections.Generic;

namespace Video8_RestService
{
    [Activity(Label = "Video8_RestService", MainLauncher = true)]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            Button callRest = FindViewById<Button>(Resource.Id.btnCallRest);
            callRest.Click += Button_Click;
        }

        private async void Button_Click(object sender, EventArgs e)
        {
            //Ojo: siempre que se utiliza await, se debe utilizar asycn, porque es un proceso asyncrono.
            //Utilizar http://json2csharp.com para crear las clases asociadas al retorno de servicio web.
            //Como el metodo GetRequest retorna un tipo T o generico. Se debe crear las clases asociadas a ese reotrno del servicio web, en este caso https://jsonplaceholder.typicode.com/users.
            List<User> list = await "https://jsonplaceholder.typicode.com/users".GetRequest<List<User>>();
            List<Company> listCompany = await "https://jsonplaceholder.typicode.com/users".GetRequest<List<Company>>();
            if (default(List<User>) != list)
            {
                foreach (User user in list)
                {
                    System.Diagnostics.Debug.WriteLine(user.company.name);
                }
            }
        }

    }
}

