using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Media;

namespace MathQuest_final
{
    public partial class MainForm : Form
    { 
    	private string basePath = Path.Combine(Application.StartupPath, @"C:\Users\Pat\Documents\SharpDevelop Projects\MathQuest_final(true copy)-20240605T005710Z-001\MathQuest_final(true copy)\MathQuest_final\Images");
        public List<PlayerScoreEventArgs> leaderboard = new List<PlayerScoreEventArgs>();
       private SoundPlayer sounds;
        private bool setting = false;
         private string leaderboardFilePath = "leaderboard.txt";
         private bool leaderboardVisible = false;
         private bool aboutVisible = false;
         private SoundPlayer clickSound;
         private int ChoiceOperator;
         private int ChoiceDigit;
         private bool play = false;
		private Panel  LevelScreen;
		private Button Easy;
		private Button Normal;
		private Button Hard;
		Gameplay gameplayInstance;// Initialize the gameplayInstance
       
        public MainForm()
        {
            InitializeComponent();
            gameplayInstance = new Gameplay(ChoiceDigit,ChoiceOperator);
            gameplayInstance.PlayerScoreSaved += UpdateLeaderboard;
            
		    sounds = new SoundPlayer("Pirates Of The Caribbean Theme Song (320).wav");
		    sounds.Play();
		    leaderboardlistView1.Visible = false; 
		    abtpanel1.Visible = false;
		    InitializeLeaderboardListView();
		   
            // Initialize the sound for the click event
            clickSound = new SoundPlayer("mixkit-arcade-video-game-bonus-2044.wav");

           

    	
        }
        private void hideallcontrols()
        {
        	//Hides all control
        	//ref about
        	aboutpictureBox2.Visible = false;
        	referlinkLabel2.Visible = false;
        	contrilinkLabel1.Visible = false;
        	reftextBox4.Visible = false;
        	pictureBox2.Visible = false;
            textBox1.Visible = false;
            pictureBox3.Visible = false;
            textBox2.Visible = false;
            pictureBox4.Visible = false;
            textBox3.Visible = false;
            //leaderboard
            leaderboardlistView1.Visible = false;
            leaderboardpictureBox3.Visible = false;
            //play title exit mutebutton
            pictureBox1.Visible = false;
            Playbutton.Visible = false;
            Exitbutton.Visible = false;
            Settingbutton1.Visible = false;
            MuteBox.Visible = false;
            advisor.Visible = false;
            abtpanel1.Visible = false;
            label1.Visible = false;
            label2.Visible = false;
            InitializedLevel();
            
        }
        
        private void InitializedLevel()
        {

        	LevelScreen = new Panel
        	{
        		Size = new Size(900,500 ),
        		Location = new Point(0,150),
        		BackColor = Color.NavajoWhite,
        		Visible = true
        	};
        	this.Controls.Add(LevelScreen);
        	//title
        	PictureBox LevelTitle = new PictureBox
        	{
        		Size = new Size(500,100),
        		Location = new Point(200,20),
        		Image = Image.FromFile(Path.Combine(basePath,"LevelTitle.gif")),
        		SizeMode = PictureBoxSizeMode.StretchImage,
        		BackColor = Color.Transparent,
        		Visible = true,
        		
        	};
        	LevelScreen.Controls.Add(LevelTitle);
        	
        	//level difficulties
        	Easy = new Button
        	{
        		Size = new Size(250,250),
        		Location = new Point(20,150),
        		Image = Image.FromFile(Path.Combine(basePath,"EasyButton.png")),
        		BackgroundImageLayout = ImageLayout.Center,
        		BackColor = Color.Bisque,
        		Visible = true
        	};
        	Easy.Click += EasyButton;
        	LevelScreen.Controls.Add(Easy);
        	
        	Normal = new Button
        	{
        		Size = new Size(250,250),
        		Location = new Point(Easy.Width + 60,150),
        		Image = Image.FromFile(Path.Combine(basePath,"NormalButton.png")),
        		BackgroundImageLayout = ImageLayout.Stretch,
        		BackColor = Color.Bisque,
        		Visible = true
        	};
        	Normal.Click += NormalButton;
        	LevelScreen.Controls.Add(Normal);
        	
        	Hard = new Button
        	{
        		Size = new Size(250,250),
        		Location = new Point(Normal.Width + 350,150),
        		Image = Image.FromFile(Path.Combine(basePath,"HardButton.png")),
        		BackgroundImageLayout = ImageLayout.Stretch,
        		BackColor = Color.Bisque,
        		Visible = true
        	};
        	Hard.Click += HardButton;
        	LevelScreen.Controls.Add(Hard);
        	
        	Button back = new Button
        	{
        		Size = new Size(70,30),
        		Location = new Point(30,10),
        		BackgroundImage = Image.FromFile(Path.Combine(basePath,"BackButton.gif")),
        		BackgroundImageLayout = ImageLayout.Stretch,
        		BackColor = Color.Linen,
        		Visible = true
        	};
        	back.Click += BackButton;
        	LevelScreen.Controls.Add(back);
        }
        private void InitializedOperator()
        {

        	Button Addition = new Button
        	{
        		Size = new Size(150,150),
        		Location = new Point(60,150),
        		Image = Image.FromFile(Path.Combine(basePath,"PlusSign.png")),
        		BackgroundImageLayout = ImageLayout.Center,
        		BackColor = Color.Bisque,
        		Visible = true
        	};
        	Addition.Click += PlusSign;
        	LevelScreen.Controls.Add(Addition);
        	
        	Button Subtraction = new Button
        	{
        		Size = new Size(150,150),
        		Location = new Point(Addition.Width + 120,150),
        		Image = Image.FromFile(Path.Combine(basePath,"MinusSign.png")),
        		BackgroundImageLayout = ImageLayout.Stretch,
        		BackColor = Color.Bisque,
        		Visible = true
        	};
        	Subtraction.Click += MinusSign;
        	LevelScreen.Controls.Add(Subtraction);
        	
        	Button Multiplication = new Button
        	{
        		Size = new Size(150,150),
        		Location = new Point(Subtraction.Width + 320,150),
        		Image = Image.FromFile(Path.Combine(basePath,"MultiplySign.png")),
        		BackgroundImageLayout = ImageLayout.Stretch,
        		BackColor = Color.Bisque,
        		Visible = true
        	};
        	Multiplication.Click += MultiplySign;
        	LevelScreen.Controls.Add(Multiplication);
        	
        	Button Division = new Button
        	{
        		Size = new Size(150,150),
        		Location = new Point(Subtraction.Width + 520,150),
        		Image = Image.FromFile(Path.Combine(basePath,"DivisionSign.png")),
        		BackgroundImageLayout = ImageLayout.Stretch,
        		BackColor = Color.Bisque,
        		Visible = true
        	};
        	Division.Click += DivisionSign;
        	LevelScreen.Controls.Add(Division);
        	
        	Button back = new Button
        	{
        		Size = new Size(70,30),
        		Location = new Point(30,10),
        		BackgroundImage = Image.FromFile(Path.Combine(basePath,"BackButton.gif")),
        		BackgroundImageLayout = ImageLayout.Stretch,
        		BackColor = Color.Linen,
        		Visible = true
        	};
        	back.Click += BackButton;
        	LevelScreen.Controls.Add(back);
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
		        hideallcontrols();
		    };
		
		    // Start the delay timer
		    delayTimer.Start();
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
		void EasyButton(object sender, EventArgs e)
		{
			clickSound.Play();
			play = true;
			ChoiceDigit = 10;
			Easy.Visible = false;
			Normal.Visible = false;
			Hard.Visible = false;
			InitializedOperator();
			
		}
		
		void NormalButton(object sender, EventArgs e)
		{
			clickSound.Play();
			play = true;
			ChoiceDigit = 50;
			Easy.Visible = false;
			Normal.Visible = false;
			Hard.Visible = false;
			InitializedOperator();
		}
		
		void HardButton(object sender, EventArgs e)
		{
			clickSound.Play();
			play = true;
			ChoiceDigit = 100;
			Easy.Visible = false;
			Normal.Visible = false;
			Hard.Visible = false;
			InitializedOperator();
		}
		
		void BackButton(object sender, EventArgs e)
		{
			clickSound.Play();
			LevelScreen.Visible = false;
			Playbutton.Visible = true;
			aboutpictureBox2.Visible = true;
			Exitbutton.Visible = true;
			leaderboardpictureBox3.Visible = true;
			Settingbutton1.Visible = true;
			pictureBox1.Visible = true;
			contrilinkLabel1.Visible = true;
			referlinkLabel2.Visible = true;
			label1.Visible = true;
			label2.Visible = true;
		}
		
		void PlusSign(object sender, EventArgs e)
		{
			clickSound.Play();
			if (play == true)
			{
			ChoiceOperator = 1;
			Gameplay Enter = new Gameplay(ChoiceDigit,ChoiceOperator);
			Enter.Show();
			this.Hide();
			}
			
		}
		
		void MinusSign(object sender, EventArgs e)
		{
			clickSound.Play();
			if (play == true)
			{
			ChoiceOperator = 2;
			Gameplay Enter = new Gameplay(ChoiceDigit,ChoiceOperator);
			Enter.Show();
			this.Hide();
			}
		}
		
		void MultiplySign(object sender, EventArgs e)
		{
			clickSound.Play();
			if (play == true)
			{
			ChoiceOperator = 3;
			Gameplay Enter = new Gameplay(ChoiceDigit,ChoiceOperator);
			Enter.Show();
			this.Hide();
			}
		}
		
		void DivisionSign(object sender, EventArgs e)
		{
			clickSound.Play();
			if (play == true)
			{
			ChoiceOperator = 4;
			Gameplay Enter = new Gameplay(ChoiceDigit,ChoiceOperator);
			Enter.Show();
			this.Hide();
			}
		}
		
		void MainFormLoad(object sender, EventArgs e)
		{
			
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
    }
}
