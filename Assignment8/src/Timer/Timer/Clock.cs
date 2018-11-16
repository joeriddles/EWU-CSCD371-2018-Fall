using System;
using System.Windows.Threading;

namespace Timer
{
	/*
	 CANNOT TEST DUE TO CLASS BEING IN A WPF PROJECT AND MSTEST WILL NOT WORK IN WPF PROJECT
	 THIS CLASS NEEDS TO BE IN THE WPF PROJECT TO USE System.Windows.Threading ACCORDING TO MY TESTING
	 THIS CLASS CAN BE VISUALLY TESTED WITHIN THE MainWindow
	*/
	public class Clock
	{
		private DateTime.DateTime DateTime { get; }
		private DispatcherTimer Timer { get; }
		public string CurrentTime { get; set; }

		public Clock()
		{
			DateTime = new DateTime.DateTime();
			Timer = new DispatcherTimer { Interval = TimeSpan.FromMilliseconds(100) };
			Timer.Tick += TimerTick;
			Timer.Start();
		}

		public void Add(EventHandler eventHandler)
		{
			Timer.Tick += eventHandler;
		}

		private void TimerTick(object sender, EventArgs args)
		{
			CurrentTime = DateTime.Now();
		}
	}
}
