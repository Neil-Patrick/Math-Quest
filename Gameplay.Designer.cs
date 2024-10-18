namespace MathQuest_final
{
	partial class Gameplay
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Gameplay));
			this.Startbutton = new System.Windows.Forms.PictureBox();
			this.PlayerPic = new System.Windows.Forms.PictureBox();
			this.Heart1 = new System.Windows.Forms.PictureBox();
			this.Heart2 = new System.Windows.Forms.PictureBox();
			this.Heart3 = new System.Windows.Forms.PictureBox();
			this.GameTimer = new System.Windows.Forms.Timer(this.components);
			this.Scorelbl = new System.Windows.Forms.Button();
			this.Roundlbl = new System.Windows.Forms.Button();
			this.Timerlbl = new System.Windows.Forms.Button();
			this.Questionlbl = new System.Windows.Forms.Button();
			this.HelpPic = new System.Windows.Forms.PictureBox();
			this.label1 = new System.Windows.Forms.Label();
			this.settingbutton2 = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.Startbutton)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.PlayerPic)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.Heart1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.Heart2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.Heart3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.HelpPic)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.settingbutton2)).BeginInit();
			this.SuspendLayout();
			// 
			// Startbutton
			// 
			this.Startbutton.BackColor = System.Drawing.Color.Transparent;
			this.Startbutton.Cursor = System.Windows.Forms.Cursors.Default;
			this.Startbutton.Image = ((System.Drawing.Image)(resources.GetObject("Startbutton.Image")));
			this.Startbutton.Location = new System.Drawing.Point(400, 300);
			this.Startbutton.Name = "Startbutton";
			this.Startbutton.Size = new System.Drawing.Size(100, 50);
			this.Startbutton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.Startbutton.TabIndex = 1;
			this.Startbutton.TabStop = false;
			this.Startbutton.Click += new System.EventHandler(this.StartbuttonClick);
			// 
			// PlayerPic
			// 
			this.PlayerPic.BackColor = System.Drawing.Color.Transparent;
			this.PlayerPic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.PlayerPic.Image = ((System.Drawing.Image)(resources.GetObject("PlayerPic.Image")));
			this.PlayerPic.Location = new System.Drawing.Point(420, 370);
			this.PlayerPic.Name = "PlayerPic";
			this.PlayerPic.Size = new System.Drawing.Size(60, 60);
			this.PlayerPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.PlayerPic.TabIndex = 3;
			this.PlayerPic.TabStop = false;
			this.PlayerPic.WaitOnLoad = true;
			// 
			// Heart1
			// 
			this.Heart1.BackColor = System.Drawing.Color.Transparent;
			this.Heart1.Image = ((System.Drawing.Image)(resources.GetObject("Heart1.Image")));
			this.Heart1.Location = new System.Drawing.Point(185, 23);
			this.Heart1.Name = "Heart1";
			this.Heart1.Size = new System.Drawing.Size(56, 50);
			this.Heart1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.Heart1.TabIndex = 6;
			this.Heart1.TabStop = false;
			// 
			// Heart2
			// 
			this.Heart2.BackColor = System.Drawing.Color.Transparent;
			this.Heart2.Image = ((System.Drawing.Image)(resources.GetObject("Heart2.Image")));
			this.Heart2.Location = new System.Drawing.Point(257, 23);
			this.Heart2.Name = "Heart2";
			this.Heart2.Size = new System.Drawing.Size(56, 50);
			this.Heart2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.Heart2.TabIndex = 7;
			this.Heart2.TabStop = false;
			// 
			// Heart3
			// 
			this.Heart3.BackColor = System.Drawing.Color.Transparent;
			this.Heart3.Image = ((System.Drawing.Image)(resources.GetObject("Heart3.Image")));
			this.Heart3.Location = new System.Drawing.Point(328, 23);
			this.Heart3.Name = "Heart3";
			this.Heart3.Size = new System.Drawing.Size(56, 50);
			this.Heart3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.Heart3.TabIndex = 8;
			this.Heart3.TabStop = false;
			// 
			// GameTimer
			// 
			this.GameTimer.Interval = 1000;
			this.GameTimer.Tick += new System.EventHandler(this.GameTimerTick);
			// 
			// Scorelbl
			// 
			this.Scorelbl.BackColor = System.Drawing.Color.Transparent;
			this.Scorelbl.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Scorelbl.BackgroundImage")));
			this.Scorelbl.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.Scorelbl.Enabled = false;
			this.Scorelbl.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.Scorelbl.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Scorelbl.ForeColor = System.Drawing.Color.SaddleBrown;
			this.Scorelbl.Location = new System.Drawing.Point(12, 72);
			this.Scorelbl.Name = "Scorelbl";
			this.Scorelbl.Size = new System.Drawing.Size(200, 50);
			this.Scorelbl.TabIndex = 11;
			this.Scorelbl.Text = "Score : ";
			this.Scorelbl.UseVisualStyleBackColor = false;
			// 
			// Roundlbl
			// 
			this.Roundlbl.BackColor = System.Drawing.Color.Transparent;
			this.Roundlbl.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Roundlbl.BackgroundImage")));
			this.Roundlbl.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.Roundlbl.Enabled = false;
			this.Roundlbl.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.Roundlbl.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Roundlbl.ForeColor = System.Drawing.Color.SaddleBrown;
			this.Roundlbl.Location = new System.Drawing.Point(12, 12);
			this.Roundlbl.Name = "Roundlbl";
			this.Roundlbl.Size = new System.Drawing.Size(100, 50);
			this.Roundlbl.TabIndex = 12;
			this.Roundlbl.Text = "Round: 1";
			this.Roundlbl.UseVisualStyleBackColor = false;
			// 
			// Timerlbl
			// 
			this.Timerlbl.BackColor = System.Drawing.Color.Transparent;
			this.Timerlbl.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Timerlbl.BackgroundImage")));
			this.Timerlbl.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.Timerlbl.Enabled = false;
			this.Timerlbl.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.Timerlbl.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Timerlbl.ForeColor = System.Drawing.Color.SaddleBrown;
			this.Timerlbl.Location = new System.Drawing.Point(400, 86);
			this.Timerlbl.Name = "Timerlbl";
			this.Timerlbl.Size = new System.Drawing.Size(108, 36);
			this.Timerlbl.TabIndex = 13;
			this.Timerlbl.UseVisualStyleBackColor = false;
			// 
			// Questionlbl
			// 
			this.Questionlbl.BackColor = System.Drawing.Color.Transparent;
			this.Questionlbl.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Questionlbl.BackgroundImage")));
			this.Questionlbl.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.Questionlbl.Enabled = false;
			this.Questionlbl.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.Questionlbl.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Questionlbl.ForeColor = System.Drawing.Color.SaddleBrown;
			this.Questionlbl.Location = new System.Drawing.Point(400, 23);
			this.Questionlbl.Name = "Questionlbl";
			this.Questionlbl.Size = new System.Drawing.Size(108, 50);
			this.Questionlbl.TabIndex = 14;
			this.Questionlbl.UseVisualStyleBackColor = false;
			// 
			// HelpPic
			// 
			this.HelpPic.BackColor = System.Drawing.Color.Transparent;
			this.HelpPic.Image = ((System.Drawing.Image)(resources.GetObject("HelpPic.Image")));
			this.HelpPic.Location = new System.Drawing.Point(552, 341);
			this.HelpPic.Name = "HelpPic";
			this.HelpPic.Size = new System.Drawing.Size(285, 99);
			this.HelpPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.HelpPic.TabIndex = 15;
			this.HelpPic.TabStop = false;
			this.HelpPic.Visible = false;
			this.HelpPic.Click += new System.EventHandler(this.HelpPicClick);
			// 
			// label1
			// 
			this.label1.BackColor = System.Drawing.Color.Gray;
			this.label1.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.ForeColor = System.Drawing.Color.White;
			this.label1.Location = new System.Drawing.Point(798, 86);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(74, 23);
			this.label1.TabIndex = 16;
			this.label1.Text = "Settings";
			// 
			// settingbutton2
			// 
			this.settingbutton2.BackColor = System.Drawing.Color.Transparent;
			this.settingbutton2.Image = ((System.Drawing.Image)(resources.GetObject("settingbutton2.Image")));
			this.settingbutton2.Location = new System.Drawing.Point(798, 19);
			this.settingbutton2.Name = "settingbutton2";
			this.settingbutton2.Size = new System.Drawing.Size(74, 64);
			this.settingbutton2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.settingbutton2.TabIndex = 18;
			this.settingbutton2.TabStop = false;
			this.settingbutton2.Click += new System.EventHandler(this.Settingbutton2Click);
			// 
			// Gameplay
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.ClientSize = new System.Drawing.Size(884, 711);
			this.ControlBox = false;
			this.Controls.Add(this.settingbutton2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.HelpPic);
			this.Controls.Add(this.Questionlbl);
			this.Controls.Add(this.Timerlbl);
			this.Controls.Add(this.Roundlbl);
			this.Controls.Add(this.Scorelbl);
			this.Controls.Add(this.Heart3);
			this.Controls.Add(this.Heart2);
			this.Controls.Add(this.Heart1);
			this.Controls.Add(this.PlayerPic);
			this.Controls.Add(this.Startbutton);
			this.DoubleBuffered = true;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "Gameplay";
			this.ShowIcon = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Gameplay";
			this.Click += new System.EventHandler(this.Helpbutton);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PlayerMovement);
			((System.ComponentModel.ISupportInitialize)(this.Startbutton)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.PlayerPic)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.Heart1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.Heart2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.Heart3)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.HelpPic)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.settingbutton2)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.PictureBox settingbutton2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.PictureBox HelpPic;
		private System.Windows.Forms.Button Timerlbl;
		private System.Windows.Forms.Timer GameTimer;
		
		private System.Windows.Forms.PictureBox Heart3;
		private System.Windows.Forms.PictureBox Heart2;
		private System.Windows.Forms.PictureBox Heart1;
		private System.Windows.Forms.Button Roundlbl;
		private System.Windows.Forms.Button Scorelbl;
		private System.Windows.Forms.PictureBox PlayerPic;
		private System.Windows.Forms.Button Questionlbl;
		private System.Windows.Forms.PictureBox Startbutton;
	}
}
