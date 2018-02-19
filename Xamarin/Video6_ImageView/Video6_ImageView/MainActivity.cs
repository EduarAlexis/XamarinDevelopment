using Android.App;
using Android.Widget;
using Android.OS;
using Square.Picasso;

namespace Video6_ImageView
{
    [Activity(Label = "Video6_ImageView", MainLauncher = true)]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            Picasso.With(this)
               .Load("http://i.imgur.com/DvpvklR.png")
                   .Into(FindViewById<ImageView>(Resource.Id.imgPicture));
        }
    }
}

