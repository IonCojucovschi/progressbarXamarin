using Android.App;
using Android.Widget;
using Android.OS;
using System.Threading;

namespace ProgressBarExample
{
    [Activity(Label = "ProgressBarExample", MainLauncher = true)]
    public class MainActivity : Activity
    {

        public Button buttonShow;
        public int progressBarStatus;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            buttonShow = FindViewById<Button>(Resource.Id.btnShow);

            buttonShow.Click += ButtonShow_Click;

        }

        private void ButtonShow_Click(object sender, System.EventArgs e)
        {
            ///create and display new progress  bar
            ProgressDialog progressBar = new ProgressDialog(this);
            progressBar.SetCancelable(true);
            progressBar.SetMessage("File is downloading...");

            progressBar.SetProgressStyle(ProgressDialogStyle.Horizontal);
            progressBar.Progress = 0;
            progressBar.Max = 100;
            progressBar.Show();

            progressBarStatus = 0;

            ///run thread for increase progress bar
            new Thread(new ThreadStart(delegate {
                int i = 0;

                    while (i< 100)
                    {
                    i++;
                        while (progressBarStatus<100) {
                            progressBarStatus += 1;
                            progressBar.Progress += progressBarStatus;
                            Thread.Sleep(100);//// slep foe 100 ms
                        }
                    progressBarStatus = 0;
                    progressBar.Progress = 0;
                    }
                    RunOnUiThread(() => { progressBar.SetMessage("File IS DOWNLOADED."); });
                    /// Toast.MakeText(this,"File is downloaded.",ToastLength.Long);
                
            })).Start();

  

        }
    }
}

