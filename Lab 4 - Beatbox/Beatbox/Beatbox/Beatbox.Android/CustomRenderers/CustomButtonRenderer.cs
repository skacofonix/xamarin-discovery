using Android.Content;
using Android.Views;
using Beatbox.Controls;
using Beatbox.Droid.CustomRenderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Button = Android.Widget.Button;
using ButtonRenderer = Xamarin.Forms.Platform.Android.AppCompat.ButtonRenderer;

[assembly: ExportRenderer(typeof(CustomButton), typeof(CustomButtonRenderer))]
namespace Beatbox.Droid.CustomRenderers
{
    public class CustomButtonRenderer : ButtonRenderer
    {
        private CustomButton _customButton;

        public CustomButtonRenderer(Context context) : base(context)
        { }

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Button> e)
        {
            base.OnElementChanged(e);
            _customButton = e.NewElement as CustomButton;
            var button = Control as Button;
            button.Touch += ThisButtonOnTouch;
        }

        private void ThisButtonOnTouch(object sender, TouchEventArgs args)
        {
            switch (args.Event.Action)
            {
                case MotionEventActions.Down:
                    _customButton.OnPressed();
                    break;
                case MotionEventActions.Up:
                    _customButton.OnReleased();
                    break;
            }
        }
    }
}