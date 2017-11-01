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

            SetAlarm();
        }

        public void SetAlarm()
        {
            Intent intent = new Intent(this, typeof(MyTestReceiver));
            PendingIntent pendingIntent = PendingIntent.GetBroadcast(this, 0, intent, PendingIntentFlags.CancelCurrent);
            AlarmManager alarmManager = (AlarmManager)this.GetSystemService(Context.AlarmService);
            alarmManager.Set(AlarmType.ElapsedRealtime, SystemClock.ElapsedRealtime() +  5 * 1000, pendingIntent);
        }
    }

    [BroadcastReceiver(Enabled = true)]
    public class MyTestReceiver : BroadcastReceiver
    {
        public override void OnReceive(Context context, Intent intent)
        {
            Toast toast = Toast.MakeText(Application.Context, "Hello", ToastLength.Long);
            toast.Show();
        }
    }

}