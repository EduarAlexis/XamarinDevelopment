using System;
using System.Collections.Generic;
using Android.Content;
using Android.Views;
using Android.Widget;
using Square.Picasso;

namespace Video7_CustomizeList
{
    public class UserAdapter : Android.Widget.ArrayAdapter<User>
    {
        public UserAdapter(Context context, int resource, List<User> users) : base(context, resource, users)
        {

        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            LayoutInflater layout = LayoutInflater.From(Context);
            convertView = layout.Inflate(Resource.Layout.ItemList, null);
            User item = GetItem(position);
            ImageView image = convertView.FindViewById<ImageView>(Resource.Id.itemListImageView);
            TextView text = convertView.FindViewById<TextView>(Resource.Id.listItemTextView);
            text.Text = item.nombre;
            Picasso.With(Context)
                   .Load(item.imagen)
                   .Into(image);
            return convertView;
        }
    }

    public class User
    {
        public string imagen
        {
            set;
            get;
        }

        public string nombre
        {
            set;
            get;
        }
    }

    public class UserModel
    {

        public List<User> usuarios
        {
            get;
            set;
        }

        public UserModel()
        {
            loadModel();
        }

        private void loadModel()
        {
            usuarios = new List<User>();
            usuarios.Add(new User { imagen = "https://st3.depositphotos.com/1674582/18186/i/450/depositphotos_181869690-stock-photo-atlanta-usa-october-2017-brazilian.jpg", nombre = "Sara Garota" });
            usuarios.Add(new User { nombre = "Mar caribe", imagen = "https://st3.depositphotos.com/4028173/17354/i/450/depositphotos_173541574-stock-photo-aerial-view-to-tropical-sandy.jpg" });
            usuarios.Add(new User { nombre = "Esquina", imagen = "https://st3.depositphotos.com/1663343/18101/i/450/depositphotos_181010296-stock-photo-york-england-july-2017-shambles.jpg" });
            usuarios.Add(new User { nombre = "Madrid", imagen = "https://st.depositphotos.com/1475009/5155/i/450/depositphotos_51553485-stock-photo-edinburgh-scotland-july-21-the.jpg" });
        }
    }
}
