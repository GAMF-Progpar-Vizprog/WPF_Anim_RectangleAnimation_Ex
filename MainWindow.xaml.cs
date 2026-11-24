using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace WPF_Anim_RectangleAnimation_Ex
{
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}

		private void btStart_Click(object sender, RoutedEventArgs e)
		{
			Duration dur = TimeSpan.FromSeconds(2);
			DoubleAnimation da = new()
			{
				From = 1,
				To = 0.1,
				Duration = dur,
				AutoReverse = true
			};
			da.Completed += (a, b) => MessageBox.Show("End animation!");
			rcSqare.BeginAnimation(Rectangle.OpacityProperty, da);

			RotateTransform rtRotation =
				new RotateTransform(0, rcSqare.Width / 2, 
				rcSqare.Height / 2);
			ScaleTransform stReduceSize =
				new ScaleTransform(0, 0, rcSqare.Width / 2, rcSqare.Width / 2);
			TransformGroup tgTransform = new TransformGroup();
			tgTransform.Children.Add(rtRotation);
			tgTransform.Children.Add(stReduceSize);
			rcSqare.RenderTransform = tgTransform;

			DoubleAnimation dr = new()
			{
				From = 0,
				To = 360,
				Duration = dur,
				AutoReverse = true
			};
			rtRotation.BeginAnimation(RotateTransform.AngleProperty, dr);

			DoubleAnimation ds = new()
			{
				From = 1.0,
				To = 0.1,
				Duration = dur,
				AutoReverse = true
			};

			stReduceSize.BeginAnimation(ScaleTransform.ScaleXProperty, ds);
			stReduceSize.BeginAnimation(ScaleTransform.ScaleYProperty, ds);
		}
	}

}
