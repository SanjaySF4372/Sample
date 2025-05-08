using Microsoft.Maui.Graphics;

namespace CustomSample
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

    }

    public class CustomClass:ContentView,IDrawable
    {
        public CustomClass()
        {
            var graphicsView = new GraphicsView
            {
                Drawable = this,
                HeightRequest = 60,
                WidthRequest = 60
            };

            Content = graphicsView;
        }

        private Rect fillRect = new Rect(3, 1,  48, 48);
        public void Draw(ICanvas canvas, RectF dirtyRect)
        {
            canvas.SaveState();
            var outerRect = new RectF((float)fillRect.X, (float)fillRect.Y,(float)fillRect.Width,(float)fillRect.Height);
            Color color = Colors.Transparent;
           // Color color = Color.FromArgb("#F3EDF7");
            canvas.SetFillPaint(color.AsPaint(), outerRect);
            canvas.SetShadow(new SizeF(0, 2), DeviceInfo.Platform == DevicePlatform.Android ? 4 : 3, Color.FromArgb("#59000000"));
            canvas.FillEllipse(outerRect.X, outerRect.Y, outerRect.Width, outerRect.Height);

            float arcSize = 24f;
            float arcX = outerRect.X + (outerRect.Width - arcSize) / 2;
            float arcY = outerRect.Y + (outerRect.Height - arcSize) / 2;

            canvas.FillColor = Colors.Blue;
            canvas.DrawArc(arcX, arcY, arcSize, arcSize, 45, 90, true, false);

            canvas.RestoreState();
        }
    }

    
    
}
