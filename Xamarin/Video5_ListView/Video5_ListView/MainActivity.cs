using Android.App;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;

namespace Video5_ListView
{
    [Activity(Label = "Video5_ListView", MainLauncher = true)]
    public class MainActivity : Activity
    {
        private List<string> list;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Main);

            /*
             * Modelo = Datos
             * Vista = Contenedor de los datos
             * ModeloVista = Actividad
            */

            ListView listView = FindViewById<ListView>(Resource.Id.lvLista);
            list = new List<string>();

            list.Add("Android");
            list.Add("iOS");
            list.Add("Windows Form");
            list.Add("Mozilla SO");

            listView.Adapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleListItem1, list);

            listView.ItemClick += ListView_ItemClick;
        }

        void ListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            string sistemaOperativo = list[e.Position];
            Toast.MakeText(this, sistemaOperativo, ToastLength.Short).Show();
        }
    }
}

