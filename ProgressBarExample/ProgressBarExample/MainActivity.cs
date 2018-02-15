using Android.App;
using Android.Widget;
using Android.OS;
using System.Threading;
using Android.Support.V7.App;

namespace ProgressBarExample
{
    [Activity(Label = "ProgressBarExample", MainLauncher = true,Theme ="@style/Theme.AppCompat.Light.NoActionBar")]
    public class MainActivity : AppCompatActivity
    {

        public Button buttonShow;
        ProgressBar progressBar;
        bool StopCondition=true;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            progressBar = FindViewById<ProgressBar>(Resource.Id.progressBar);

            buttonShow = FindViewById<Button>(Resource.Id.btnShow);

            buttonShow.Click += ButtonShow_Click;

        }

        private void ButtonShow_Click(object sender, System.EventArgs e)
        {
            int progressBarStatus = 0;

            ///run thread for increase progress bar
            new Thread(new ThreadStart(delegate {
                
                
                    while (StopCondition)
                    {
                        if (progressBarStatus == 100) progressBarStatus = 0;

                        progressBarStatus++;
                        progressBar.Progress =progressBarStatus;
                        progressBar.SecondaryProgress = 2*progressBarStatus;

                        Thread.Sleep(10);//// slep foe 100 ms
                        
                    }
                                 
            })).Start();

  

        }
    }
}

