using Android.App;
using Android.Widget;
using Android.OS;

namespace Video7_CustomizeList
{
    [Activity(Label = "Video7_CustomizeList", MainLauncher = true)]
    public class MainActivity : Activity
    {
        private UserModel model; // Clase donde se obtiene el repositorio de usuarios.
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            ListView listView = FindViewById<ListView>(Resource.Id.mainListItems);
            model = new UserModel(); //Se inicializa la clase y se cargan los usuarios del repositorio.
            //UserAdapter hereda de ArrayAdapter. Ahì se inicializa la clase UserAdapter y se infla el layout ItemList y se enlazan sus atributos 
            listView.Adapter = new UserAdapter(this, Resource.Layout.ItemList, model.usuarios);
            listView.ItemClick += ListView_ItemClick;
        }

        /*
         * Funcion que muestra a traves de un Toast el nombre del usuario de la lista seleccionado.
        */
        void ListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            User usuario = model.usuarios[e.Position];
            Toast.MakeText(this, usuario.nombre, ToastLength.Short).Show();
        }
    }
}

