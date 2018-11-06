using System;
using Android.App;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;

namespace HelloDroid
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private EditText _firstnameTextView;
        private EditText _lastnameTextView;
        private TextView _fullnameTextView;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            var toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);

            var fab = FindViewById<FloatingActionButton>(Resource.Id.fab);
            fab.Click += FabOnClick;

            _firstnameTextView = FindViewById<EditText>(Resource.Id.firstname);
            _lastnameTextView = FindViewById<EditText>(Resource.Id.lastname);
            _fullnameTextView = FindViewById<TextView>(Resource.Id.fullname);

            _firstnameTextView.TextChanged += (sender, args) => RefreshFullname();
            _lastnameTextView.TextChanged += (sender, args) => RefreshFullname();
        }

        private void RefreshFullname()
        {
            _fullnameTextView.Text = string.Join(" ", _firstnameTextView.Text, _lastnameTextView.Text);
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            var id = item.ItemId;
            if (id == Resource.Id.action_settings)
            {
                return true;
            }

            return base.OnOptionsItemSelected(item);
        }

        private static void FabOnClick(object sender, EventArgs eventArgs)
        {
            var view = (View) sender;
            Snackbar.Make(view, "Replace with your own action", Snackbar.LengthLong)
                    .SetAction("Action", (Android.Views.View.IOnClickListener)null).Show();
        }
	}
}