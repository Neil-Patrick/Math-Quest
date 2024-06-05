using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Media;
using System.Threading.Tasks;

namespace MathQuest_final
{
    public partial class MainForm : Form
    { 
    	
        public List<PlayerScoreEventArgs> leaderboard = new List<PlayerScoreEventArgs>();
       private SoundPlayer sounds;
        private bool setting = false;
         private string leaderboardFilePath = "leaderboard.txt";
         private bool leaderboardVisible = false;
         private bool aboutVisible = false;
         private SoundPlayer clickSound;

       
        public MainForm()
        {
            InitializeComponent();
            // Subscribe to the PlayerScoreSaved event
		  	Gameplay gameplayInstance = new Gameplay(); // Initialize the gameplayInstance
            gameplayInstance.PlayerScoreSaved += UpdateLeaderboard;
            
		    sounds = new SoundPlayer("Pirates Of The Caribbean Theme Song (320).wav");
		    sounds.Play();
		    leaderboardlistView1.Visible = false; 
		    abtpanel1.Visible = false;
		    InitializeLeaderboardListView();
		   
            // Initialize the sound for the click event
            clickSound = new SoundPlayer("mixkit-arcade-video-game-bonus-2044.wav");

           

    	
        }
        
	private void InitializeLeaderboardListView()
        {
            // Add columns to the ListView
            leaderboardlistView1.Columns.Add("Player Name", 150);
            leaderboardlistView1.Columns.Add("Score", 100);
            LoadLeaderboardFromFile();
        }

        private void LoadLeaderboardFromFile()
        {
            // Load leaderboard from file if it exists
            if (File.Exists(leaderboardFilePath))
            {
                leaderboard.Clear();
                string[] lines = File.ReadAllLines(leaderboardFilePath);
                foreach (string line in lines)
                {
                    string[] parts = line.Split(':');
                    if (parts.Length == 2)
                    {
                        string playerName = parts[0].Trim();
                        int score;
                        if (int.TryParse(parts[1].Trim(), out score))
                        {
                            leaderboard.Add(new PlayerScoreEventArgs(playerName, score));
                        }
                    }
                }
                UpdateLeaderboardListView();
            }
        }

        private void UpdateLeaderboardListView()
        {
            // Clear existing items
            leaderboardlistView1.Items.Clear();

            // Sort the leaderboard list by score (descending order)
            leaderboard.Sort((x, y) => y.Score.CompareTo(x.Score));

            // Add players to the leaderboard ListView
            foreach (var player in leaderboard)
            {
                // Create a ListViewItem for each player
                ListViewItem item = new ListViewItem(player.PlayerName); // Player Name as the first column
                item.SubItems.Add(player.Score.ToString()); // Score as the second column
                leaderboardlistView1.Items.Add(item); // Add the item to the ListView
            }
        }

        // Method to handle the PlayerScoreSaved event
        public void UpdateLeaderboard(object sender, PlayerScoreEventArgs e)
        {
            // Add the player's info to the leaderboard
            leaderboard.Add(new PlayerScoreEventArgs(e.PlayerName, e.Score));

            // Update the leaderboard ListView
            UpdateLeaderboardListView();

            // Save the updated leaderboard to file
            SaveLeaderboardToFile();
        }

        private void SaveLeaderboardToFile()
		{
		    // Save leaderboard to file
		    using (StreamWriter writer = new StreamWriter(leaderboardFilePath, false))
		    {
		        foreach (var player in leaderboard)
		        {
		            writer.WriteLine(player.PlayerName + ":" + player.Score);
		        }
		    }
		}


        void PlaybuttonClick(object sender, EventArgs e)
		{
		    // Play the click sound
		    clickSound.Play();
		
		    int delayMilliseconds = 1000; // Adjust this value as needed
		
		    // Use a Timer to delay the playback of the second sound
		    Timer delayTimer = new Timer();
		    delayTimer.Interval = delayMilliseconds;
		    delayTimer.Tick += (timerSender, args) =>
		    {
		        // Stop the timer
		        delayTimer.Stop();
		
		        
		
		        // Proceed to show the Gameplay form
		        ShowGameplayForm();
		    };
		
		    // Start the delay timer
		    delayTimer.Start();
		}
		
		void ShowGameplayForm()
		{
		    Gameplay enter = new Gameplay();
		    enter.Show();
		    this.Hide();
		}

        void ExitbuttonClick(object sender, EventArgs e)
        {
        	Application.Exit();
        }

        void MuteBoxCheckedChanged(object sender, EventArgs e)
        {
            if (MuteBox.Checked)
            {
                MuteBox.Text = "Unmute";
                sounds.Stop();
            }
            else
            {
                MuteBox.Text = "Mute";
                sounds.Play();
            }
        }

        void Settingbutton1Click(object sender, EventArgs e)
        {
            if (setting == false)
            {
                MuteBox.Visible = true;
                setting = true;
            }
            else
            {
                MuteBox.Visible = false;
                setting = false;
            }
        }
		
	


        void LeaderboardpictureBox3Click(object sender, EventArgs e)
		{
		    leaderboardlistView1.Visible = !leaderboardVisible; // Toggle visibility
		    leaderboardVisible = !leaderboardVisible; // Update visibility state
		}
		
		void Leaderpanel1Paint(object sender, PaintEventArgs e)
		{
			
		}
		
		void LeaderboardlistView1SelectedIndexChanged(object sender, EventArgs e)
		{
			
		}
		
		void AboutpictureBox2Click(object sender, EventArgs e)
		{
			abtpanel1.Visible = !aboutVisible;
			aboutVisible = !aboutVisible;
			
			 pictureBox2.Visible = true;
            textBox1.Visible = true;
            pictureBox3.Visible = true;
            textBox2.Visible = true;
            pictureBox4.Visible = true;
            textBox3.Visible = true;
            
            reftextBox4.Visible = false;
			advisor.Visible = false;
			// Set contrilinkLabel1 to always underline and change its color to white
            contrilinkLabel1.LinkBehavior = LinkBehavior.AlwaysUnderline;
            contrilinkLabel1.LinkColor = Color.LemonChiffon;
            
            referlinkLabel2.LinkBehavior = LinkBehavior.HoverUnderline;
            referlinkLabel2.LinkColor = Color.White;
            
		}
		
		void Abtpanel1Paint(object sender, PaintEventArgs e)
		{
			
		}
		
		void LinkLabel1LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			
			reftextBox4.Visible = false;
			advisor.Visible = false;
            // Set contrilinkLabel1 to hover underline and change its color to white
            contrilinkLabel1.LinkBehavior = LinkBehavior.AlwaysUnderline;
            contrilinkLabel1.LinkColor = Color.LemonChiffon;
			
			
			 // Set referlinkLabel2 to always underline and change its color
            referlinkLabel2.LinkBehavior = LinkBehavior.HoverUnderline;
            referlinkLabel2.LinkColor = Color.White;
			
			 
			
			 // Hide the connected controls
            pictureBox2.Visible = true;
            textBox1.Visible = true;
            pictureBox3.Visible = true;
            textBox2.Visible = true;
            pictureBox4.Visible = true;
            textBox3.Visible = true;
           
		}
		
		void ReferlinkLabel2LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			 // Set referlinkLabel2 to always underline and change its color
            referlinkLabel2.LinkBehavior = LinkBehavior.AlwaysUnderline;
            referlinkLabel2.LinkColor = Color.LemonChiffon;

            // Set contrilinkLabel1 to hover underline and change its color to white
            contrilinkLabel1.LinkBehavior = LinkBehavior.HoverUnderline;
            contrilinkLabel1.LinkColor = Color.White;

            // Hide the connected controls
            pictureBox2.Visible = false;
            textBox1.Visible = false;
            pictureBox3.Visible = false;
            textBox2.Visible = false;
            pictureBox4.Visible = false;
            textBox3.Visible = false;
            reftextBox4.Controls.Add(advisor);
            advisor.Location = new Point(reftextBox4.Width -140,reftextBox4.Height - 125);
            
           
            
            reftextBox4.Visible = true;
            advisor.Visible = true;
            
		}
		void TextBox4TextChanged(object sender, EventArgs e)
		{
			
		}
    }
}
