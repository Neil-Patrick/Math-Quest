using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Media;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text.RegularExpressions;



namespace MathQuest_final
{
    public partial class Gameplay : Form
    {
    	 private string basePath = Path.Combine(Application.StartupPath, @"C:\Users\Pat\Documents\SharpDevelop Projects\MathQuest_final(true copy)-20240605T005710Z-001\MathQuest_final(true copy)\MathQuest_final\Images");
    	public event EventHandler<PlayerScoreEventArgs> PlayerScoreSaved;
    	 public event EventHandler<PlayerScoreEventArgs> GameFinished;
    	private SoundPlayer sounds2;
    	private SoundPlayer clicked;
    	private SoundPlayer gameOverSoundPlayer;    	
        // Player variables
        private int playerX = 420;
        private int playerY = 370;
        private int playerHP = 3;
        
        // Settings
        private bool start = false;
        private bool Help = false;
        private bool isColliding = false;
        private bool settingswitch = true;
        private bool isMuted = false;
        
        // Operation
        private Random rnd = new Random();
        private int Num1, Num2;
        private int max, min;
        private int CorrectAnswer;
        private char SelectedOperator;
        private int round = 1;
        private int score = 0;
        private List<int> Results = new List<int>();
        private Button[] Resultlbl;
        private int i;
        private int TimerLeft = 30;
        private Panel gameOverPanel;
        private Panel settings;
       	private List<string> leaderboard = new List<string>();
		private string playerName;
		private int Digits;
		private int ChoiceOperator;
        
        public Gameplay(int digit,int Ope)
        {
            InitializeComponent();
            HelpPic.Visible = true;
            Digits = digit;
            ChoiceOperator = Ope;
            sounds2 = new SoundPlayer("Untold Journey - The Pirate King (Royalty Free Music) (320).wav");
            clicked = new SoundPlayer("mixkit-arcade-video-game-bonus-2044.wav");
            // Initialize the gameover sound player
    		gameOverSoundPlayer = new SoundPlayer("J3YL2BH-videogame-bloop-game-over.wav");
        }
       
        private void GameStarts()
        { 
        	
        	
        	// Play the first sound
		    clicked.Play();
		    
		
		    // Define a delay in milliseconds before playing the second sound
		    int delayMilliseconds = 1000; // Adjust this value as needed
		
		    // Use a Timer to delay the playback of the second sound
		    Timer delayTimer = new Timer();
		    delayTimer.Interval = delayMilliseconds;
		    delayTimer.Tick += (sender, e) =>
		    {
		        // Stop the timer
		        delayTimer.Stop();
		
		        // Play the second sound
		        sounds2.Play();
		
		        // Start the timer for the game logic or other actions
		        StartTimer();
		        start = true;
		        GeneratorQuestion(); // CalculateNShow // PossibleResult
		        
		    };
		
		    // Start the delay timer
		    delayTimer.Start();
        }

        /*--------------------------------------------------------------Question and label generator--------------------------------------------------------------------------------------*/
        private void GeneratorQuestion()
        {
        	    Num1 = rnd.Next(1, Digits);
                Num2 = rnd.Next(1, Digits);
        	switch(ChoiceOperator)
        	{
        		case 1:
        			SelectedOperator = '+';
        			break;
        		case 2:
        			SelectedOperator = '-';
        			break;
        		case 3:
        			SelectedOperator = '*';
        			break;
        		case 4:
        			SelectedOperator = '/';
        			break;
        	}
            CalculateNShow();
        }

        private void CalculateNShow()
        {
            if (Num1 < Num2) {
                min = Num1;
                max = Num2;
            }
            else
            {
                min = Num2;
                max = Num1;
            }
            switch(SelectedOperator)
            {
                case '+':
                    CorrectAnswer = max + min; 
                    break;
                case '-':
                    CorrectAnswer = max - min;
                    break;
                case '*':
                    CorrectAnswer = max * min;
                    break;
                case '/':
                    CorrectAnswer = max / min;
                    break;
            }
            Questionlbl.Text = max + " " + SelectedOperator + " " + min;
            // After show call possible result
            PossibleResult();
        }

        private void PossibleResult()
        {
            // Print possible answer while result less than three
            Results.Add(CorrectAnswer);
            while(Results.Count < 3)
            {
                int possibleAnswer = CorrectAnswer + rnd.Next(1, 11); // Generate possible answer that has a range of 10
                if (CorrectAnswer != possibleAnswer) 
                {
                    Results.Add(possibleAnswer); // Add possible answer
                }
            }
            if(playerHP != 0){
            GenerateLabel();
            }
        }

        private void ClearPreviousLabels()
		{
		    if (Resultlbl != null)
		    {
		        foreach (Button lbl in Resultlbl)
		        {
		        	lbl.Visible = false;
		            this.Controls.Remove(lbl);
		            lbl.Dispose();
		        }
		    }
		}
		private void GenerateLabel()
		{
			ClearPreviousLabels();
			
		    Resultlbl = new Button[3];
		                    
		    // Set the label size
		    int lblWidth = 60;
		    int lblHeight = 60;
		    int minDistance = 80;
		    int playerSafeDistance = 100; // Minimum distance from player's initial position
		
		    // Player's initial position
		    Point playerStartPos = new Point(playerX, playerY);
		
		    // Check for overlap
		    for (i = 0; i < 3; i++) {
		        int x, y;
		        bool overlap;
		        do {
		            overlap = false;
		            // set random location
		            x = rnd.Next(this.ClientSize.Width - lblWidth);
		            y = rnd.Next(150,500 - lblHeight);
		
		            // Check for overlapping with other labels
		            foreach (Button lbl in Resultlbl) {
		                if(lbl != null && Math.Abs(lbl.Location.X - x) < minDistance && Math.Abs(lbl.Location.Y - y) < minDistance)
		                {
		                    overlap = true;
		                    break;
		                }
		            }
		
		            // Check for proximity to the player's initial position
		            if (!overlap && Math.Abs(playerStartPos.X - x) < playerSafeDistance && Math.Abs(playerStartPos.Y - y) < playerSafeDistance)
		            {
		                overlap = true;
		            }
		
		        } while(overlap);
		
		        // Create the label
		        Resultlbl[i] = new Button
		        {
		            Size = new Size(lblWidth, lblHeight),
		            Location = new Point(x, y),
		            Font = new Font("MS UI Gothic", 14, FontStyle.Bold),
		            BackgroundImage = Image.FromFile(Path.Combine(basePath, "BGCONTAINER1.gif")),
		            BackgroundImageLayout = ImageLayout.Stretch,
		            BackColor = Color.Transparent,
		            ForeColor = Color.Snow,
		            FlatStyle = FlatStyle.Flat,
		            TextAlign = ContentAlignment.MiddleCenter,
		            Text = Results[i].ToString(),
		            Tag = Results[i] == CorrectAnswer,
		            Enabled = false,
		            Visible = true
		        };
		        this.Controls.Add(Resultlbl[i]);
		    }
		}


        /*--------------------------------------------------------settings and panels-----------------------------------------------------------------------------------------*/

		private bool CheckForControls(PictureBox player, Button result)
		{
		    Rectangle box1 = player.Bounds;
		    Rectangle box2 = result.Bounds;
		
		    return box1.IntersectsWith(box2);
		}
		
		private bool CheckForCollisions(PictureBox player, Button[] results)
		{
		    foreach (var result in results)
		    {
		        if (CheckForControls(player, result))
		        {
		            if (!isColliding)
		            {
		                // Collision detected
		                
		                isColliding = true;
		                HandleCollision(result);
		            }
		            return true;
		        }
		    }
		    // No collision detected
		    isColliding = false;
		    return false;
		}
		private async Task PlayGameOverSoundAsync()
		{
		    gameOverSoundPlayer.Play();
		    await Task.Delay(3000); // Delay for 3 seconds
		}
		
		

		
		
		private void HandleCollision(Button result)
		{
			//For Correct Answer
		    bool isCorrectAnswer = (bool)result.Tag;
		    if (!isCorrectAnswer)
		    {
		    	clicked.Play();
		    	round++;
		    	playerHP--;
		    	
		    	 
		        ResetGame();
		    }
		     
		    else
		    {
		    	clicked.Play();
		    	round++;
		    	score += round;
		    	
		    	ResetGame();
		    }
		  
		}
		
		
		    
		

		
		private void InitializedScoreAndRoundLabel()
		{
				// Set the Score and Round Text
		    	Roundlbl.Text ="Round: " + round;
		    	Scorelbl.Text = "Score: " + score;
			
		}
		
		private void InitializedGameOver()
		{
			//Initialized the game over Screen
			PlayerPic.Visible =false;
			ClearPreviousLabels();
			
		    // Base path for images
		    gameOverPanel = new Panel
		    {
		        Size = new Size(650, 400),
		        BackColor = Color.Transparent,
		        Visible = true
		    };
		    // Center the panel on the form
		    gameOverPanel.Location = new Point((this.ClientSize.Width - gameOverPanel.Width) / 2, (this.ClientSize.Height - gameOverPanel.Height) / 2);
		    this.Controls.Add(gameOverPanel);
		    
		    // Create and center the title PictureBox
		    PictureBox title = new PictureBox
		    {
		        Size = new Size(200, 100), 
		        Location = new Point((gameOverPanel.Width - 200) / 2, 50),
		        Image = Image.FromFile(Path.Combine(basePath, "GameOver.gif")),
		        BackColor = Color.Transparent,
		        Visible = true
		    };
		    gameOverPanel.Controls.Add(title);
			
		   // Create and center the Restart PictureBox
		    PictureBox Restart = new PictureBox
		    {
		        Size = new Size(150, 50), 
		        Location = new Point((gameOverPanel.Width - 100) / 2 - 10, 150),
		        Image = Image.FromFile(Path.Combine(basePath, "Restart.gif")),
		        BackColor = Color.Transparent,
		        Cursor = Cursors.Hand,
		        Visible = true
		        	
		    };
		   Restart.Click += RestartButton;
		
			gameOverPanel.Controls.Add(Restart);
		    
		    // Create and center the Exit PictureBox
		    PictureBox Exit = new PictureBox
		    {
		        Size = new Size(100, 50), 
		        Location = new Point((gameOverPanel.Width - 100) / 2 - 10, 200),
		        Image = Image.FromFile(Path.Combine(basePath, "Exit.gif")),
		        BackColor = Color.Transparent,
		         Cursor = Cursors.Hand,
		        Visible = true
		    };
		    Exit.Click += ExitButton;
		    
		   Exit.Click += async (sender, e) =>
			{
			    // Save the player's score
			    await SavePlayerScoreAsync();
			
			    // Close the gameplay form and open the MainForm
			    this.Hide(); // Hide the gameplay form
			    MainForm mainForm = new MainForm();
			    mainForm.Show();
			};

			
		    
		    gameOverPanel.Controls.Add(Exit);
		    
		    
		
		    Label scoreLabel = new Label
		    {
		        Text = "Score: " + score,
		        Font = new Font("MS UI Gothic", 14, FontStyle.Bold),
		        ForeColor = Color.SaddleBrown,
		        BackColor = Color.Tan,
		        AutoSize = true
		    };
		    scoreLabel.Location = new Point((gameOverPanel.Width - scoreLabel.Width) / 2, 250);
		    gameOverPanel.Controls.Add(scoreLabel);
		    
		   
		}
		private void DisplayLeaderboardInGameOverPanel()
		{
			//InitializedGameOver name prompt
		    Label title = new Label
		    {
		        Text = "Score",
		        Font = new Font("MS UI Gothic", 16, FontStyle.Bold),
		        ForeColor = Color.White,
		        BackColor = Color.Transparent,
		        AutoSize = true
		    };
		    title.Location = new Point((gameOverPanel.Width - title.Width) / 2, 250); // Adjust location to fit under other elements
		    gameOverPanel.Controls.Add(title);
		
		    int yPosition = 280;
		    foreach (string entry in leaderboard)
		    {
		        Label scoreLabel = new Label
		        {
		            Text = entry,
		            Font = new Font("MS UI Gothic", 14, FontStyle.Bold),
		            ForeColor = Color.White,
		            BackColor = Color.Transparent,
		            AutoSize = true
		        };
		        scoreLabel.Location = new Point((gameOverPanel.Width - scoreLabel.Width) / 2, yPosition);
		        gameOverPanel.Controls.Add(scoreLabel);
		        yPosition += 30;
		    }
		}
		private void InitializedSetting()
		{
		   //inittialized setting controls
		    settings = new Panel
		    {
		        Size = new Size(270, 70),
		        Location = new Point(550,12),
		        BackColor = Color.Transparent,
		        Visible = true
		    };
		    this.Controls.Add(settings);
		    // Create and center the title PictureBox
		    
		    PictureBox Resume = new PictureBox
		    {
		        Size = new Size(50, 50), 
		        Location = new Point((settings.Width - 70), 10),
		        Image = Image.FromFile(Path.Combine(basePath, "resumebutton.gif")),
		        SizeMode = PictureBoxSizeMode.CenterImage,
		        BackColor = Color.Transparent,
		        Cursor = Cursors.Hand,
		        Visible = true
		    };
		    Resume.Click += resumebutton;
		    settings.Controls.Add(Resume);
			
		   // Create and center the Restart PictureBox
		    PictureBox Mute = new PictureBox
		    {
		        Size = new Size(50, 50), 
		        Location = new Point((settings.Width - 130), 10),
		        Image = Image.FromFile(Path.Combine(basePath, "mutebutton.gif")),
		        SizeMode = PictureBoxSizeMode.StretchImage,
		        BackColor = Color.Transparent,
		         Cursor = Cursors.Hand,
		        Visible = true
		    };
		    Mute.Click += mutebutton;
		    settings.Controls.Add(Mute);
		    
		    // Create and center the Exit PictureBox
		    PictureBox Exit = new PictureBox
		    {
		        Size = new Size(50, 50), 
		        Location = new Point((settings.Width - 270 ), 10),
		        Image = Image.FromFile(Path.Combine(basePath, "exitbutton.gif")),
		        BackColor = Color.Transparent,
		         Cursor = Cursors.Hand,
		        Visible = playerHP > 0
		    };
		    Exit.Click += ExitButton;
		    settings.Controls.Add(Exit);
		    
		    PictureBox Help = new PictureBox
		    {
		        Size = new Size(50, 50), 
		        Location = new Point((settings.Width - 210 ), 10),
		        Image = Image.FromFile(Path.Combine(basePath, "Helpbutton.gif")),
		        BackColor = Color.Transparent,
		         Cursor = Cursors.Hand,
		        Visible = true
		    };
		    Help.Click += Helpbutton;
		    settings.Controls.Add(Help);
		    
		}
		
        void StartbuttonClick(object sender, EventArgs e)
        {
        	//check for startbutton
        	sounds2.Stop();
        	
            if (start == false) {
                start = true;
                Startbutton.Visible = false;
                HelpPic.Visible = false;
                
                GameStarts();
            }
            else
            {
                start = false;
                Startbutton.Visible = true;
            }
        }    
        private void PictureBoxClick(object sender, EventArgs e)
		{
		    clicked.Play(); // Play the sound when the PictureBox is clicked
		}

        /*------------------------------------------------------------------------------Player----------------------------------------------------------------------------------*/        
        void PlayerMovement(object sender, KeyEventArgs e)
        {
        	//Inittilized the Playermovement 
            string basePath = Path.Combine(Application.StartupPath, @"C:\Users\Pat\Documents\SharpDevelop Projects\MathQuest_final(true copy)-20240605T005710Z-001\MathQuest_final(true copy)\MathQuest_final\Images\Movement");
            Image PlayerLeft = Image.FromFile(Path.Combine(basePath, "Left_key.gif"));
            Image PlayerRight = Image.FromFile(Path.Combine(basePath, "Right_key.gif"));
            Image PlayerUp = Image.FromFile(Path.Combine(basePath, "Up_key.gif"));
            Image PlayerDown = Image.FromFile(Path.Combine(basePath, "Down_key.gif"));
            Image CurrentImage;
            int multiplier = 0;
            int step = 2;
            for(int i = 0;i < round; i++)
            {
            	multiplier =+ 1;
            }
            //limit step multiplier
            if(multiplier < 15){
            	 step += multiplier / 2;
            }
            switch(e.KeyCode)
            {
                case Keys.Right:
                    if(playerX + step <= this.ClientSize.Width - PlayerPic.Width)
                    {
                        CurrentImage  = PlayerRight;
                        PlayerPic.Image = CurrentImage;
                        playerX += step;
                    }
                    break;
                case Keys.Up:
                    if(playerY - step >= 150)
                    { 
                        CurrentImage  = PlayerUp;
                        PlayerPic.Image = CurrentImage;
                        playerY -= step;
                    }
                    break;
                case Keys.Left:
                    if(playerX - step >= 0)
                    {
                        CurrentImage  = PlayerLeft;
                        PlayerPic.Image = CurrentImage;
                        playerX -= step;
                    }
                    break;
                case Keys.Down:
                    if(playerY + step <= this.ClientSize.Height - PlayerPic.Width)
                    {
                        CurrentImage  = PlayerDown;
                        PlayerPic.Image = CurrentImage;
                        playerY += step;
                    }
                    break;
                    case Keys.D:
                    if(playerX + step <= this.ClientSize.Width - PlayerPic.Width)
                    {
                        CurrentImage  = PlayerRight;
                        PlayerPic.Image = CurrentImage;
                        playerX += step;
                    }
                    break;
                case Keys.W:
                    if(playerY - step >= 150)
                    { 
                        CurrentImage  = PlayerUp;
                        PlayerPic.Image = CurrentImage;
                        playerY -= step;
                    }
                    break;
                case Keys.A:
                    if(playerX - step >= 0)
                    {
                        CurrentImage  = PlayerLeft;
                        PlayerPic.Image = CurrentImage;
                        playerX -= step;
                    }
                    break;
                case Keys.S:
                    if(playerY + step <= this.ClientSize.Height - PlayerPic.Width)
                    {
                        CurrentImage  = PlayerDown;
                        PlayerPic.Image = CurrentImage;
                        playerY += step;
                    }
                    break;
            }
            PlayerPic.Location = new Point(playerX, playerY);

            // Check for collision with any result label
            CheckForCollisions(PlayerPic,Resultlbl);
        }
       private void playerHealth()
		{
		    if (playerHP == 2)
		    {
		        Heart1.Visible = false;
		    }
		    else if (playerHP == 1)
		    {
		        Heart2.Visible = false;
		    }
		    else if (playerHP == 0)
		    {
		        Heart3.Visible = false;
		        // Handle game over logic here, e.g., display a message and reset the game
		        InitializedGameOver();
		        PlayGameOverSoundAsync();
		        
		    }
		}
		
		private void ResetGame()
		{
		    // Reset player health and position, clear labels, and reset other game states
		    ClearPreviousLabels();
		    Results.Clear();
		    playerHealth();
		    InitializedScoreAndRoundLabel();
		    GeneratorQuestion();
		    TimerLeft = 30;
		}
		
		private void RestartGame()
		{
		    // Reset player health and position, clear labels, and reset other game 
		    sounds2.Play();
		    playerHP = 3;
		    playerX = 420;
		    playerY = 370;
		    Heart1.Visible = true;
		    Heart2.Visible = true;
		    Heart3.Visible = true;
		    ClearPreviousLabels();
		    Results.Clear();		   
		    round = 1;
		    score = 0;
		    InitializedScoreAndRoundLabel();
		    TimerLeft = 30; 
		    Questionlbl.Text = " ";
		    start = false;
		    Startbutton.Visible = true;
		    PlayerPic.Visible = true;
		    PlayerPic.Location = new Point(playerX, playerY);
		}
		void RestartButton(object sender, EventArgs e)
		{
			gameOverPanel.Visible = false;
			RestartGame();
		}
		void ExitButton(object sender, EventArgs e)
		{
			sounds2.Stop();
			gameOverSoundPlayer.Stop();
			MainForm enter = new MainForm();
			enter.Show();
			this.Hide();
		}
		
		
		
		void resumebutton(object sender, EventArgs e)
		{
			settings.Visible = false;
			settingswitch = true;
		}
		
		void mutebutton(object sender, EventArgs e)
		{
			if(isMuted)
			{
				sounds2.Stop();
				isMuted = false;
			}
			else
			{
				sounds2.Play();
				isMuted = true;
			}
		}
		private void StartTimer()
		{
			
			GameTimer.Interval = 1000;
			
			GameTimer.Start();
		}
		void GameTimerTick(object sender, EventArgs e)
		{
		    if (TimerLeft > 0 && playerHP != 0)
		    { 
		    	
		        TimerLeft--;
		       
		        Timerlbl.Text = " " + TimerLeft + "s";
		    }
		    else if (TimerLeft == 0 && playerHP != 0)
		    {
		        playerHP--; 
		        TimerLeft = 30;
		        round++;		       
		        ResetGame();
		    }
		    else
		    {
		        GameTimer.Stop();
		    }
		}
		
		
		private async Task SavePlayerScoreAsync()
		{
		    if (string.IsNullOrEmpty(playerName))
		    {
		        playerName = PromptForPlayerName();
		    }
		    if (!string.IsNullOrEmpty(playerName))
		    {
		        OnPlayerScoreSaved(playerName, score);
		        await SaveScoreToFileAsync(playerName, score);
		    }
		}
		
		private string PromptForPlayerName()
		{
		    // Prompt the player for their name
		    string playerName = "";
		    using (var form = new Form())
		    using (var textBox = new TextBox())
		    using (var button = new Button())
		    using (var label = new Label())
		    {
		        form.Text = "Enter Your Name";
		        form.Size = new Size(300, 150); // Set form size
		        form.BackColor = Color.Tan;
		        form.ControlBox = false;
		     
		        form.StartPosition = FormStartPosition.CenterScreen; // Center form on screen
		
		        textBox.Location = new Point(20, 20);
		        textBox.Font = new Font ("MS UI Gothic", 10, FontStyle.Bold);
		        textBox.Size = new Size(200, 20);
		
		        button.Text = "OK";
		        button.DialogResult = DialogResult.OK;
		        button.BackColor = Color.SaddleBrown;
		        button.ForeColor = Color.White;
		        button.Location = new Point(20, 50);
		
		        label.Text = "Name should be max 10 characters and contain only letters or numbers.";
		        label.ForeColor = Color.Red;
		        label.Location = new Point(20, 80);
		        label.Size = new Size(260, 20); // Set label size to fit the text
		        label.Visible = false;
		
		        form.Controls.AddRange(new Control[] { textBox, button, label });
		
		        while (form.ShowDialog() == DialogResult.OK)
		        {
		            playerName = textBox.Text.Trim();
		            if (playerName.Length > 10 || !IsValidName(playerName))
		            {
		                label.Visible = true;
		                continue; // Prompt user again
		            }
		            break; // Exit loop if name length and format are valid
		        }
		    }
		    return playerName;
		}
		
		private bool IsValidName(string name)
		{
		    // Regular expression to validate the name (only letters or numbers)
		    string pattern = "^[a-zA-Z0-9]+$";
		    return Regex.IsMatch(name, pattern);
		}

		
		    protected virtual void OnPlayerScoreSaved(string playerName, int score)
        {
		    	
		    	if (PlayerScoreSaved != null)
		    	{
		    		PlayerScoreSaved.Invoke(this, new PlayerScoreEventArgs (playerName, score ));
		    	}
        }

        

		 private async Task SaveScoreToFileAsync(string playerName, int score)
		{
		    string filePath = "leaderboard.txt";
		     try
            {
                using (StreamWriter writer = new StreamWriter(filePath, true))
                {
		        await writer.WriteLineAsync(playerName + ":" + score);
		        }
            }
            catch (Exception ex)
            {
                // Handle file I/O error
                Console.WriteLine("Error saving score to file: " + ex.Message);
            
		    }
		}
		private async Task SaveAndDisplayScoreAsync()
        {
            try
            {
                if (GameFinished != null)
                {
                    // Raise the GameFinished event with the player's name and score
                    GameFinished.Invoke(this, new PlayerScoreEventArgs(playerName, score));
                }
                else
                {
                    // Handle the case where the GameFinished event is not subscribed
                    Console.WriteLine("GameFinished event is not subscribed to any event handler.");
                }

                // Save score to file asynchronously
                await SaveScoreToFileAsync(playerName, score);
            }
            catch (Exception ex)
            {
                // Handle exception
                Console.WriteLine("Error saving and displaying score: " + ex.Message);
            }

            // Close the gameplay form
            this.Close();
        }
		
		void Helpbutton(object sender, EventArgs e)
		{
			if (settingswitch == false )
			{
				if (Help == false) 
				{
	                Help = true;
	                HelpPic.Visible = false;
	                
	            }
	            else
	            {
	                Help = false;
	                HelpPic.Visible = true;
	            }
			}
		}
		
		void HelpPicClick(object sender, EventArgs e)
		{
			
		}
		
		void Settingbutton2Click(object sender, EventArgs e)
		{
			if(settingswitch == true)
			{
				InitializedSetting();
				settingswitch = false;
			}
		}
    }
}
