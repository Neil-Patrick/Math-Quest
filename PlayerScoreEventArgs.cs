using System;

namespace MathQuest_final
{
	/// <summary>
	/// Description of Leaderoard1.
	/// </summary>
	public class PlayerScoreEventArgs : EventArgs
	{
	    public string PlayerName { get; set; }
	    public int Score { get; set; }
	
	    // Constructor
	    public PlayerScoreEventArgs(string playerName, int score)
	    {
	        PlayerName = playerName;
	        Score = score;
	    }
	}
}
