
namespace TimerToysShared.Model
{
	public class Timer
	{
		public string PageKey { get; set; }
		public string PageName { get; set; }
		public string TimerKey { get; set; }
		public string TimerDescription { get; set; }
		public bool IsRunning { get; set; }
		public int SortIndex { get; set; }
		public int ElapsedTime { get; set; }
	}
}
