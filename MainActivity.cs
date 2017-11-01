using Android.App;
using Android.Widget;
using Android.OS;

namespace AlarmBroadcastTest {

    using Android.App;
    using Android.Widget;
    using Android.OS;
    using Android.Content;

    [Activity(Label = "AlarmBroadcastTest", MainLauncher = true)]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            //Calling function to rig alarm
            SetAlarm();
        }

        public void SetAlarm()
        {
            //"this" is context, and "MyTestReceiver" the recipient of the intent - in total: name and address!)
            Intent intent = new Intent(this, typeof(MyTestReceiver));
            PendingIntent pendingIntent = PendingIntent.GetBroadcast(this, 0, intent, PendingIntentFlags.CancelCurrent);
            AlarmManager alarmManager = (AlarmManager)this.GetSystemService(Context.AlarmService);
            //see http://sangsoonam.github.io/2017/03/01/do-not-use-curenttimemillis-for-time-interval.html
            alarmManager.Set(AlarmType.ElapsedRealtime, SystemClock.ElapsedRealtime() +  5 * 1000, pendingIntent);
        }
    }

    [BroadcastReceiver(Enabled = true)]
    //no intent filter needed here
    public class MyTestReceiver : BroadcastReceiver
    {
        public override void OnReceive(Context context, Intent intent)
        {
            //test message appearing 5 seconds after start
            Toast toast = Toast.MakeText(Application.Context, "Hello", ToastLength.Long);
            toast.Show();
        }
    }

}