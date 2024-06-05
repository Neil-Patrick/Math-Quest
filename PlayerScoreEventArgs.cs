/*
 * Created by SharpDevelop.
 * User: Administrator
 * Date: 5/27/2024
 * Time: 8:17 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
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
