# progressbarXamarin


Make an indefinite=true customized progressbar in three steps.  

1) Activity must look like this:


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
        public int progressBarStatus;
        ProgressBar progressBar;

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
        
            progressBar.Progress = 0;
            progressBar.Max = 1000;

            progressBarStatus = 0;

            ///run thread for increase progress bar
            new Thread(new ThreadStart(delegate {
                int i = 0;
                
                    while (i< 100)
                    {
                    i++;
                        while (progressBarStatus<1000) {
                            progressBarStatus += 1;
                        if (progressBarStatus < 500)
                        {
                            progressBar.Progress = progressBarStatus;
                            progressBar.SecondaryProgress = 2 * progressBarStatus;
                        }
                        else
                        {
                            progressBar.SecondaryProgress += 2;
                            progressBar.Progress =progressBarStatus+1;
                        }
                        Thread.Sleep(1);//// slep foe 100 ms
                        }
                        progressBarStatus = 0;
                        progressBar.Progress = 0;
                        progressBar.SecondaryProgress = 0;
                    }
                    RunOnUiThread(() => {  });
                
            })).Start();

  

        }
    }
}



2) Set layout for this actyvity with this code:




<?xml version="1.0" encoding="utf-8"?>
<LinearLayout xmlns:android="http://schemas.android.com/apk/res/android"
    android:orientation="vertical"
    android:layout_width="match_parent"
    android:layout_height="match_parent"
              android:background="#4286f4"
    android:minWidth="25px"
    android:minHeight="25px">
    <Button
        android:text="Show progress Bar"
        android:layout_width="match_parent"
        android:layout_height="wrap_content"
        android:id="@+id/btnShow" />
    <ProgressBar
        android:layout_marginTop="40dp"
        android:id="@+id/progressBar"
        style="@style/Base.Widget.AppCompat.ProgressBar.Horizontal"
        android:layout_width="match_parent"
        android:layout_height="4dp"
        android:progressDrawable="@drawable/progress_bar" />
  
  
</LinearLayout>





3) And in folder drawable from resource a file progress_bar.xml and put this code 




<?xml version="1.0" encoding="utf-8" ?>
<layer-list
        xmlns:android="http://schemas.android.com/apk/res/android">
  <item android:id="@android:id/background">
    <shape>
        <corners android:radius="5dip" />
        <gradient
                android:startColor="#ffffff"
                android:centerColor="#ffffff"
                android:endColor="#ffffff"
        />
    </shape>
</item>
    <item
            android:id="@android:id/secondaryProgress">
      <clip>
        <shape>
           <gradient
                  android:startColor="#84b1f9"
                  android:endColor="#84b1f9"
                  android:angle="90" />
        </shape>
      </clip>
    </item>
    
      
        <item
          android:id="@android:id/progress">
    <clip>
      <shape>
        <gradient
             android:startColor="#ffffff"
             android:endColor="#ffffff" />
      </shape>
    </clip>
  </item>
</layer-list>




















