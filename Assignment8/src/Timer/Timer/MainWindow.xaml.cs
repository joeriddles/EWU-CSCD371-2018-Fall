using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using DateTime;

namespace Timer
{
	public partial class MainWindow : Window
	{
		private readonly TimeManager _manager;
		private string _startTime;
		private string _endTime;
		private int _entryCounter = 1;

		public MainWindow()
		{
			InitializeComponent();
			Clock clock = new Clock();
			clock.Add((sender, e) => { MyClock.Text = clock.CurrentTime; });
			IDateTime dateTimeInterface = new DateTime.DateTime();
			_manager = new TimeManager(dateTimeInterface);
		}

		private void StartStopTimer_OnClick(object sender, RoutedEventArgs e)
		{
			if (!_manager.Running)
			{
				_startTime = _manager.StartTimer();
				StartStopTimer.Content = "Stop Timer";
				StartStopTimer.Background = new SolidColorBrush(Colors.OrangeRed);
				StartStopTimer.BorderBrush = new SolidColorBrush(Colors.OrangeRed);
			}
			else
			{
				_endTime = _manager.EndTimer();
				TimeEntries.Items.Add(CreateEntry());
				_entryCounter++;
				StartStopTimer.Content = "Start Timer";
				StartStopTimer.Background = new SolidColorBrush(Colors.Green);
				StartStopTimer.BorderBrush = new SolidColorBrush(Colors.Green);
			}
		}

		private void Delete_OnClick(object sender, RoutedEventArgs e)
		{
			var selectedEntry = TimeEntries.SelectedItems.Cast<object>().ToList();
			if (selectedEntry.Count == 1)
				TimeEntries.Items.Remove(selectedEntry[0]);
		}

		private UIElement CreateEntry()
		{
			StackPanel vStack = new StackPanel();
			vStack.Children.Add(new TextBlock
				{Text = $"Entry #{_entryCounter} Start: {_startTime} for {_endTime} seconds.", FontSize = 16});

			StackPanel hStack = new StackPanel {Orientation = Orientation.Horizontal};
			hStack.Children.Add(new Label {Content = "Description:"});
			hStack.Children.Add(new TextBox{Text = "Describe how you spent your time here."});

			vStack.Children.Add(hStack);
			return vStack;
		}

		/* TODO: FIX LoadData()
		private void LoadData()
		{
			if (System.IO.File.Exists("data.txt"))
			{
				string xaml = System.IO.File.ReadAllText("data.txt");
				var content = ((ListBox) System.Windows.Markup.XamlReader.Parse(xaml)).Items;
				foreach (var item in content)
					TimeEntries.Items.Add(item);
			}
		}
		*/

		/* DISABLED UNTIL LoadData() is fixed.
		protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
		{
			base.OnClosing(e);
			string xaml = System.Windows.Markup.XamlWriter.Save(TimeEntries);
			System.IO.File.WriteAllText("data.txt", xaml);
		}
		*/
	}
}
