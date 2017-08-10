using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content.Res;
using Android.Views;
using Android.Media;
using System;

namespace RunningOnEmpty
{
    [Activity(Label = "RunningOnEmpty", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        int state = 0;
        MediaPlayer player;
        TextView label;
        LinearLayout layout;
        ImageView image;

        int screenWidth = 0;
        int screenHeight = 0;
        int lastX = 0, lastY = 0;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            RequestWindowFeature(WindowFeatures.NoTitle);
            SetContentView (Resource.Layout.Main);

            label = (TextView)FindViewById(Resource.Id.textView1);
            layout = (LinearLayout)FindViewById(Resource.Id.relativeLayout1);
            image = (ImageView)FindViewById(Resource.Id.imageView1);

            label.Click += Click;
            label.LongClick += LongClick; ;
            layout.Click += Click;
            layout.LongClick += LongClick;
            image.Touch += Image_Touch;
        }

        private void Image_Touch(object sender, View.TouchEventArgs e)
        {
          
        }

        private void LongClick(object sender, View.LongClickEventArgs e)
        {
            player = MediaPlayer.Create(this, Resource.Raw.thankyou);
            label.Text = "Please rate 5 stars :)";
            player.Start();
        }

        private void Click(object sender, System.EventArgs e)
        {
            label = (TextView)FindViewById(Resource.Id.textView1);
            if ( player != null ) { player.Release(); }

            if (state == 0)
            {
                state = 1;
                label.Text = "This is";
                player = MediaPlayer.Create(this, Resource.Raw.thisis);
                player.Start();
            }
            else if (state == 1)
            {
                state = 2;
                label.Text = "Running on empty";
                player = MediaPlayer.Create(this, Resource.Raw.runningonempty);
                image.SetImageResource(Resource.Drawable.closed);
                player.Start();
            }
            else if (state == 2)
            {
                state = 0;
                label.Text = "Fooooood review.";
                player = MediaPlayer.Create(this, Resource.Raw.foodreview);
                image.SetImageResource(Resource.Drawable.normal);
                player.Start();
            }
        }
    }
}

