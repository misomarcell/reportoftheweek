using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content.Res;
using Android.Views;
using Android.Media;

namespace RunningOnEmpty
{
    [Activity(Label = "RunningOnEmpty", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        int state = 1;
        
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            RequestWindowFeature(WindowFeatures.NoTitle);
            SetContentView (Resource.Layout.Main);

            TextView label = (TextView)FindViewById(Resource.Id.textView1);
            label.Click += Label_Click;
        }

        private void Label_Click(object sender, System.EventArgs e)
        {
            TextView t = (TextView)sender;
            MediaPlayer player;

            if (state == 0)
            {
                state = 1;
                t.Text = "This is";
                player = MediaPlayer.Create(this, Resource.Raw.thisis);
                player.Start();
            }
            else if (state == 1)
            {
                state = 2;
                t.Text = "Running on empty";
                player = MediaPlayer.Create(this, Resource.Raw.runningonempty);
                player.Start();
            }
            else if (state == 2)
            {
                state = 0;
                t.Text = "Fooooood review.";
                player = MediaPlayer.Create(this, Resource.Raw.foodreview);
                player.Start();
            }
        }


 
    }
}

