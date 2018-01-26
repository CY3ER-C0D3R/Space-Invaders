using Space_Invaders.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Speech.Synthesis;

namespace Space_Invaders
{
    public partial class Form1 : Form
    {
        #region ClassVariables

        private ComponentResourceManager resources = new ComponentResourceManager(typeof(Form1));

        private enum KeyState { Right, Left, None };
        private int numOfPlayers;
        private KeyState p_keyState;
        private KeyState p1_keyState;
        private KeyState p2_keyState;
        private bool p_canShoot, p_shot;
        private bool p1_canShoot, p1_shot;
        private bool p2_canShoot, p2_shot;
        private int p_livesLeft;
        private int p1_livesLeft;
        private int p2_livesLeft;
        private int alien1_ptsWorth;
        private int alien2_ptsWorth;
        private int alien3_ptsWorth;
        private bool ufo_creation; 
        private bool ufo_place; //true - right, false - left
        private string spaceship_ptsWorth;
        private int maxAlienShooters;
        private int numOfAlienShooters;
        private string direction;
        private int alienSpeed;
        private bool state; //true - Image state 1, false - Image state 2
        private int counter;
        private int shotsFired; //for UFO usage

        #endregion

        #region InitializeGame

        public Form1()
        {
            InitializeStartPageComponent();
        }

        private void InitializeStartPageComponent()
        {
            this.startpage = new System.Windows.Forms.TableLayoutPanel();
            this.help_label = new System.Windows.Forms.Label();
            this.multiplayer_label = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.singlePlayer_label = new System.Windows.Forms.Label();
            this.pictureBox61 = new System.Windows.Forms.PictureBox();
            this.pictureBox64 = new System.Windows.Forms.PictureBox();
            this.pictureBox63 = new System.Windows.Forms.PictureBox();
            this.pictureBox62 = new System.Windows.Forms.PictureBox();
            this.startpage.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox61)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox64)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox63)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox62)).BeginInit();
            this.SuspendLayout();
            // 
            // startpage
            // 
            this.startpage.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.startpage.BackColor = System.Drawing.Color.Black;
            this.startpage.ColumnCount = 1;
            this.startpage.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.startpage.Controls.Add(this.help_label, 0, 4);
            this.startpage.Controls.Add(this.multiplayer_label, 0, 3);
            this.startpage.Controls.Add(this.pictureBox61, 0, 0);
            this.startpage.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.startpage.Controls.Add(this.singlePlayer_label, 0, 2);
            this.startpage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.startpage.Location = new System.Drawing.Point(0, 0);
            this.startpage.Name = "startpage";
            this.startpage.RowCount = 5;
            this.startpage.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.startpage.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.startpage.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.startpage.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.startpage.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.startpage.Size = new System.Drawing.Size(765, 527);
            this.startpage.TabIndex = 63;
            // 
            // help_label
            // 
            this.help_label.AutoSize = true;
            this.help_label.BackColor = System.Drawing.Color.Black;
            this.help_label.Dock = System.Windows.Forms.DockStyle.Fill;
            this.help_label.Font = new System.Drawing.Font("Bauhaus 93", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.help_label.ForeColor = System.Drawing.Color.White;
            this.help_label.Location = new System.Drawing.Point(3, 506);
            this.help_label.Name = "help_label";
            this.help_label.Size = new System.Drawing.Size(759, 21);
            this.help_label.TabIndex = 4;
            this.help_label.Text = "Help";
            this.help_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.help_label.Click += new System.EventHandler(this.help_label_Click);
            // 
            // multiplayer_label
            // 
            this.multiplayer_label.AutoSize = true;
            this.multiplayer_label.BackColor = System.Drawing.Color.Black;
            this.multiplayer_label.Dock = System.Windows.Forms.DockStyle.Fill;
            this.multiplayer_label.Font = new System.Drawing.Font("Bauhaus 93", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.multiplayer_label.ForeColor = System.Drawing.Color.White;
            this.multiplayer_label.Location = new System.Drawing.Point(3, 486);
            this.multiplayer_label.Name = "multiplayer_label";
            this.multiplayer_label.Size = new System.Drawing.Size(759, 20);
            this.multiplayer_label.TabIndex = 3;
            this.multiplayer_label.Text = "Multiplayer";
            this.multiplayer_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.multiplayer_label.Click += new System.EventHandler(this.multiplayer_label_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel2.BackColor = System.Drawing.Color.Black;
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33423F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33453F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33123F));
            this.tableLayoutPanel2.Controls.Add(this.pictureBox64, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.pictureBox63, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.pictureBox62, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 236);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(759, 227);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // singlePlayer_label
            // 
            this.singlePlayer_label.AutoSize = true;
            this.singlePlayer_label.BackColor = System.Drawing.Color.Black;
            this.singlePlayer_label.Dock = System.Windows.Forms.DockStyle.Fill;
            this.singlePlayer_label.Font = new System.Drawing.Font("Bauhaus 93", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.singlePlayer_label.ForeColor = System.Drawing.Color.White;
            this.singlePlayer_label.Location = new System.Drawing.Point(3, 466);
            this.singlePlayer_label.Name = "singlePlayer_label";
            this.singlePlayer_label.Size = new System.Drawing.Size(759, 20);
            this.singlePlayer_label.TabIndex = 2;
            this.singlePlayer_label.Text = "Single Player";
            this.singlePlayer_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.singlePlayer_label.Click += new System.EventHandler(this.singlePlayer_label_Click);
            // 
            // pictureBox61
            // 
            this.pictureBox61.BackColor = System.Drawing.Color.Black;
            this.pictureBox61.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox61.Image = global::Space_Invaders.Properties.Resources.space_invaders_logo;
            this.pictureBox61.Location = new System.Drawing.Point(3, 3);
            this.pictureBox61.Name = "pictureBox61";
            this.pictureBox61.Size = new System.Drawing.Size(759, 227);
            this.pictureBox61.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox61.TabIndex = 0;
            this.pictureBox61.TabStop = false;
            // 
            // pictureBox64
            // 
            this.pictureBox64.BackColor = System.Drawing.Color.Black;
            this.pictureBox64.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox64.Image = global::Space_Invaders.Properties.Resources.space_invader_enemy;
            this.pictureBox64.Location = new System.Drawing.Point(509, 3);
            this.pictureBox64.Name = "pictureBox64";
            this.pictureBox64.Size = new System.Drawing.Size(247, 221);
            this.pictureBox64.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox64.TabIndex = 2;
            this.pictureBox64.TabStop = false;
            // 
            // pictureBox63
            // 
            this.pictureBox63.BackColor = System.Drawing.Color.Black;
            this.pictureBox63.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox63.Image = global::Space_Invaders.Properties.Resources.space_invader_enemy;
            this.pictureBox63.Location = new System.Drawing.Point(256, 3);
            this.pictureBox63.Name = "pictureBox63";
            this.pictureBox63.Size = new System.Drawing.Size(247, 221);
            this.pictureBox63.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox63.TabIndex = 1;
            this.pictureBox63.TabStop = false;
            // 
            // pictureBox62
            // 
            this.pictureBox62.BackColor = System.Drawing.Color.Black;
            this.pictureBox62.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox62.Image = global::Space_Invaders.Properties.Resources.space_invader_enemy;
            this.pictureBox62.Location = new System.Drawing.Point(3, 3);
            this.pictureBox62.Name = "pictureBox62";
            this.pictureBox62.Size = new System.Drawing.Size(247, 221);
            this.pictureBox62.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox62.TabIndex = 0;
            this.pictureBox62.TabStop = false;

            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(765, 527);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Controls.Add(this.startpage);

            this.startpage.ResumeLayout(false);
            this.startpage.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox61)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox64)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox63)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox62)).EndInit();
            this.ResumeLayout(false);
        }

        private void StartNewSinglePlayerGame()
        {
            this.numOfPlayers = 1;
            this.direction = "RIGHT"; //aliens start moving to the right side
            this.state = true;
            this.counter = 0;
            this.Spaceship_p.Visible = true;
            this.Spaceship_p1.Dispose();
            this.Spaceship_p2.Dispose();
            this.p_keyState = KeyState.None;
            this.p_shot = false;
            this.p_canShoot = true;
            this.p_livesLeft = 3;
            this.p_score.Text = "0";
            this.alien1_ptsWorth = 10;
            this.alien2_ptsWorth = 20;
            this.alien3_ptsWorth = 30;
            this.ufo_creation = false;
            this.ufo_place = false;
            this.maxAlienShooters = 3; //initialize with 3, later change according to the number of aliens alive
            this.numOfAlienShooters = 0;
            this.alienSpeed = 1;
            this.GameInfo.Visible = false;
            this.SingleGameInfo.Visible = true;
            this.shotsFired = 0;
            //single player game music
            this.backgroundMusic.URL = string.Format("{0}Resources\\GameMusic.wav", System.IO.Path.GetFullPath(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory)));
            this.backgroundMusic.settings.setMode("loop", true);
            this.backgroundMusic.Ctlcontrols.play();
        }

        private void StartNewMultiplayerGame()
        {
            this.numOfPlayers = 2;
            this.direction = "RIGHT"; //aliens start moving to the right side
            this.state = true;
            this.counter = 0;
            this.Spaceship_p.Dispose();
            this.Spaceship_p1.Visible = true;
            this.Spaceship_p2.Visible = true;
            this.p1_keyState = KeyState.None;
            this.p2_keyState = KeyState.None;
            this.p1_shot = false;
            this.p2_shot = false;
            this.p1_canShoot = true;
            this.p2_canShoot = true;
            this.p1_livesLeft = 3;
            this.p2_livesLeft = 3;
            this.p1_score.Text = "0";
            this.p2_score.Text = "0";
            this.alien1_ptsWorth = 10;
            this.alien2_ptsWorth = 20;
            this.alien3_ptsWorth = 30;
            this.ufo_creation = false;
            this.ufo_place = false;
            this.maxAlienShooters = 6; //initialize with 6, later change according to the number of aliens alive
            this.numOfAlienShooters = 0;
            this.alienSpeed = 1;
            this.GameInfo.Visible = true;
            this.SingleGameInfo.Visible = false;
            this.shotsFired = 0;
            //multiplayer game music
            this.backgroundMusic.URL = string.Format("{0}Resources\\GameMusic.wav", System.IO.Path.GetFullPath(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory)));
            this.backgroundMusic.settings.setMode("loop", true);
            this.backgroundMusic.Ctlcontrols.play();
        }

        private void LoadBackgroundImage()
        {
            //different images for the two modes
            Image backgroundImg;
            if (this.numOfPlayers > 1) //multiplayer
                backgroundImg = ResizeImage(global::Space_Invaders.Properties.Resources.spaces_background_earth, this.ClientSize.Width, this.ClientSize.Height);
            else // single player
                backgroundImg = ResizeImage(global::Space_Invaders.Properties.Resources.spaces_background2, this.ClientSize.Width, this.ClientSize.Height);
            this.BackgroundImage = backgroundImg;
        }

        /// <summary>
        /// Resize the image to the specified width and height.
        /// </summary>
        /// <param name="image">The image to resize.</param>
        /// <param name="width">The width to resize to.</param>
        /// <param name="height">The height to resize to.</param>
        /// <returns>The resized image.</returns>
        public static Bitmap ResizeImage(Image image, int width, int height)
        {
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }

        #endregion

        #region Sound

        private void CreateSound(string name)
        {
            SoundPlayer sound = new SoundPlayer();
            if (name == "shoot")
            {
                sound = new SoundPlayer(global::Space_Invaders.Properties.Resources.shoot);
            }
            else if (name == "UFO_explosion")
            {
                sound = new SoundPlayer(global::Space_Invaders.Properties.Resources.UFO_explosion);
            }
            else if (name == "invaderkilled")
            {
                sound = new SoundPlayer(global::Space_Invaders.Properties.Resources.invaderkilled);
            }
            else if(name == "player_death_explosion")
            {
                sound = new SoundPlayer(global::Space_Invaders.Properties.Resources.player_death_explosion);
            }
            else if (name == "Thud_Sound_Effect")
            {
                sound = new SoundPlayer(global::Space_Invaders.Properties.Resources.Thud_Sound_Effect);
            }
            else if (name == "ufo_lowpitch")
            {
                sound = new SoundPlayer(global::Space_Invaders.Properties.Resources.ufo_lowpitch);
            }
            sound.Play();
        }

        private void CreateVoiceMessage(string msg)
        {
            // Initialize a new instance of the SpeechSynthesizer.
            SpeechSynthesizer synth = new SpeechSynthesizer();
            // Speak a string
            synth.SelectVoiceByHints(VoiceGender.Neutral);
            synth.Speak(msg);
        }

        #endregion

        #region GameFunctionAndEvents

        private void tmrAppTimer_Tick(object sender, EventArgs e)
        {
            UpdateGame();
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            if(this.numOfPlayers > 1) //multiplayer
            {
                //player movment
                if (e.KeyCode == Keys.Right)
                    this.p1_keyState = KeyState.Right;
                else if (e.KeyCode == Keys.Left)
                    this.p1_keyState = KeyState.Left;
                else if (e.KeyCode == Keys.D)
                    this.p2_keyState = KeyState.Right;
                else if (e.KeyCode == Keys.A)
                    this.p2_keyState = KeyState.Left;

                //player shooting
                else if (e.KeyCode == Keys.Up && this.p1_canShoot)
                    this.p1_shot = true;
                else if (e.KeyCode == Keys.W && this.p2_canShoot)
                    this.p2_shot = true;
            }
            else //single player
            {
                //player movment
                if (e.KeyCode == Keys.Right)
                    this.p_keyState = KeyState.Right;
                else if (e.KeyCode == Keys.Left)
                    this.p_keyState = KeyState.Left;

                //player shooting
                else if (e.KeyCode == Keys.Space && this.p_canShoot)
                    this.p_shot = true;
            }
            
        }

        protected override void OnKeyUp(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                DialogResult d = MessageBox.Show("Are you sure you want to quit?", "Exit Game", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (d.ToString().Equals("Yes"))
                    ShowMainMenu();
            }

            if (this.numOfPlayers > 1)
            {
                //stop player movment
                if (e.KeyCode == Keys.Right || e.KeyCode == Keys.Left)
                    this.p1_keyState = KeyState.None;
                else if (e.KeyCode == Keys.D || e.KeyCode == Keys.A)
                    this.p2_keyState = KeyState.None;

                //stop player shooting
                else if (e.KeyCode == Keys.Up)
                    this.p1_shot = false;
                else if (e.KeyCode == Keys.W)
                    this.p2_shot = false;
            }
            else //single player
            {
                //stop player movment
                if (e.KeyCode == Keys.Right || e.KeyCode == Keys.Left)
                    this.p_keyState = KeyState.None;

                //stop player shooting
                if (e.KeyCode == Keys.Space)
                    this.p_shot = false;
            }
        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            //change the speed of the aliens according to the mouse wheel movment
            this.alienSpeed += e.Delta / 120;
            if (this.alienSpeed < 1)
                this.alienSpeed = 1;
        }

        private void UpdateGame()
        {
            this.SuspendLayout();

            UpdateAliens();
            CheckUFO();
            UpdatePlayers();
            CheckGameOver();

            this.ResumeLayout(false);
        }
     
        private void UpdateAliens()
        {
            int rightSide = this.ClientSize.Width;
            int leftSide = 0;
            bool changedDirection = false;
            this.counter++;

            foreach (Control C in this.Controls)
            {
                if (C.Tag != null && C.Tag.ToString().Substring(0, 5) == "Alien") //check if the control is an alien
                {
                    //move aliens according to direction
                    if (this.direction.Equals("RIGHT"))
                        C.Location = new Point(C.Location.X + this.alienSpeed, C.Location.Y);
                    else if (this.direction.Equals("LEFT"))
                        C.Location = new Point(C.Location.X - this.alienSpeed, C.Location.Y);
                    //check if aliens are at the end of the board
                    if (C.Location.X + C.Width >= rightSide)
                    {
                        this.direction = "LEFT";
                        changedDirection = true;
                    }
                    else if (C.Location.X <= leftSide)
                    {
                        this.direction = "RIGHT";
                        changedDirection = true;
                    }
                    //check if alien was hit and needs to be killed
                    if ((string)((PictureBox)C).Image.Tag == "alien_explosion")
                    {
                        CreateSound("invaderkilled");
                        ((PictureBox)C).Dispose();
                    }
                    //make sure maximum shooters is correct
                    int num = GetNumOfLivingAliens();
                    //change state for next time
                    if (num < 3)
                        this.maxAlienShooters = num;
                    else if (num < 20)
                        this.maxAlienShooters = num / 5;
                    else
                    {
                        if(this.numOfPlayers > 1)
                            this.maxAlienShooters = GetNumOfLivingAliens() / 15;
                        else //make it a bit easier for single player
                            this.maxAlienShooters = GetNumOfLivingAliens() / 20;
                    }
                    //decide if the alien is a "shooter" and shoot accordingly
                    if (AlienShoots((PictureBox)C))
                    {
                        this.numOfAlienShooters++;
                        CreateBullet("alien", (PictureBox)C);
                    }
                }
                else if (C.Tag != null && C.Tag.ToString() == "alienSpaceShip" && this.alien_spaceShip.Visible) //if alien spaceship is visible, move it according to the direction of movment
                {
                    if (C.Location.X >= (rightSide + this.alien_spaceShip.Width) && !this.ufo_place || C.Location.X <= (leftSide - this.alien_spaceShip.Width) && this.ufo_place) //alien spaceship is out of view
                    {
                        this.alien_spaceShip.Visible = false;
                        this.ufo_creation = false;
                        //stop space ship music
                    }
                    else if (this.ufo_place) //if ufo started from the right go left
                        C.Location = new Point(this.alien_spaceShip.Location.X - 10, this.alien_spaceShip.Location.Y); 
                    else // go right
                        C.Location = new Point(this.alien_spaceShip.Location.X + 10, this.alien_spaceShip.Location.Y); 
                }
                else if (C.Name != null && C.Name.ToString() == "UFO_pts" && C.Visible)
                {
                    C.Visible = false;
                    this.ufo_creation = false;
                    System.Threading.Thread.Sleep(50);

                    CreateSound("UFO_explosion");
                }
                else if (C.Tag != null && C.Tag.ToString() != "alien_bullet" && (string)((PictureBox)C).Image.Tag == "bullet_hit_border") //check if the control is a bullet
                {
                    System.Threading.Thread.Sleep(50);

                    CreateSound("Thud_Sound_Effect");

                    ((PictureBox)C).Dispose();
                }
                else if (C.Tag != null && C.Tag.ToString() == "alien_bullet" && ((PictureBox)C).Image != null && (string)((PictureBox)C).Image.Tag == "bullet_hit_border") //alien bullet
                {
                    ((PictureBox)C).Dispose();
                }
            }
            if (changedDirection) //aliens are at one end of the board
            {
                foreach (Control C in this.Controls)
                {
                    if (C.Tag != null && C.Tag.ToString().Substring(0, 5) == "Alien")
                        C.Location = new Point(C.Location.X, C.Location.Y + this.alienSpeed + 10); //move them down
                }
            }
            //check alien state and change pictures accordingly
            foreach (Control C in this.Controls)
            {
                if (C.Tag != null && C.Tag.ToString().Substring(0, 5) == "Alien") //check if the control is an alien
                {
                    if (this.state) // choose image 1
                    {
                        if (C.Tag.Equals("Alien1"))
                            ((PictureBox)C).Image = global::Space_Invaders.Properties.Resources.alien1;
                        else if (C.Tag.Equals("Alien2")) 
                            ((PictureBox)C).Image = global::Space_Invaders.Properties.Resources.alien2;
                        else //alien 3
                            ((PictureBox)C).Image = global::Space_Invaders.Properties.Resources.alien3;
                    }
                    else //choose image 2
                    {
                        if (C.Tag.Equals("Alien1"))
                            ((PictureBox)C).Image = global::Space_Invaders.Properties.Resources.alien1_2;
                        else if (C.Tag.Equals("Alien2"))
                            ((PictureBox)C).Image = global::Space_Invaders.Properties.Resources.alien2_2;
                        else //alien 3
                            ((PictureBox)C).Image = global::Space_Invaders.Properties.Resources.alien3_2;
                    }
                }
            }
            if (this.counter == 15)
            {
                this.state = !this.state; //change state
                this.counter = 0;
            }
        }

        /// <summary>
        /// UFO appears randomly each 30-60 seconds on one side of the board.
        /// UFO is worth randomly 50, 100 or 150 pts
        /// However, if they perform the secret of firing 22 shots, 
        /// then hitting it on the 23rd shot, then on the 15th shot thereafter, 
        /// they will receive 300 points every time. 
        /// </summary>
        private void CheckUFO()
        {
            if(!this.ufo_creation)
            {
                this.ufo_creation = true;
                this.UFO_timer.Interval = new Random().Next(10000, 30000); //10-30 seconds
                this.UFO_timer.Start();
                if (new Random().Next(2) == 0) //randomly decide the next side the ufo will appear from
                    this.ufo_place = !this.ufo_place;
                int[] x = { 50, 100, 150 };
                this.spaceship_ptsWorth = Convert.ToString(x[(new Random()).Next(3)]);
            }
            //if ufo is visible make sure he is making sound 
            if (this.alien_spaceShip.Visible && counter == 0)
                CreateSound("ufo_lowpitch");
        }

        private void UFO_timer_Tick(object sender, EventArgs e)
        {
            if(this.ufo_place) //if true start from the right
                this.alien_spaceShip.Location = new System.Drawing.Point(this.Width + this.alien_spaceShip.Width, this.GameInfo.Height+3);
            else //start from the left
                this.alien_spaceShip.Location = new System.Drawing.Point(-(this.alien_spaceShip.Width), this.GameInfo.Height+3);
            this.alien_spaceShip.Visible = true;

            CreateSound("ufo_lowpitch");

            this.UFO_timer.Stop();  
        }

        private bool AlienShoots(object sender)
        {
            //function gets an alien and decides if the alien shoots or not (randomly).
            //maximum of shooters can vary according to the number of aliens alive
            if (this.numOfAlienShooters >= this.maxAlienShooters)
                return false;
            Random rnd = new Random();
            if (rnd.Next(0, 2) == 0)
                return false;
            else
                return true;
        }

        private void UpdatePlayers()
        {
            //check movment of players
            if(this.numOfPlayers > 1)
            {
                //check player 1
                if (this.p1_keyState != KeyState.None)
                {
                    //check if player is at the end of the board and where he wants to move
                    if (this.p1_keyState == KeyState.Right && this.Spaceship_p1.Location.X + this.Spaceship_p1.Width <= (this.Right - this.Left - this.Spaceship_p1.Width / 5))
                        this.Spaceship_p1.Location = new Point(this.Spaceship_p1.Location.X + this.alienSpeed*4, this.Spaceship_p1.Location.Y);
                    else if (this.p1_keyState == KeyState.Left && this.Spaceship_p1.Location.X >= 0) //move left if possible
                        this.Spaceship_p1.Location = new Point(this.Spaceship_p1.Location.X - this.alienSpeed * 4, this.Spaceship_p1.Location.Y);
                }
                //check player 2
                if (this.p2_keyState != KeyState.None)
                {
                    if (this.p2_keyState == KeyState.Right && this.Spaceship_p2.Location.X + this.Spaceship_p2.Width <= (this.Right - this.Left - this.Spaceship_p2.Width / 5))
                        this.Spaceship_p2.Location = new Point(this.Spaceship_p2.Location.X + this.alienSpeed *4, this.Spaceship_p2.Location.Y);
                    else if (this.p2_keyState == KeyState.Left && this.Spaceship_p2.Location.X >= 0) //move left if possible and requested
                        this.Spaceship_p2.Location = new Point(this.Spaceship_p2.Location.X - this.alienSpeed * 4, this.Spaceship_p2.Location.Y);
                }

                //Update player's shots
                if ((this.p1_shot && this.p1_canShoot) || (this.p2_shot && this.p2_canShoot))
                {
                    CreateSound("shoot");

                    if (this.p1_shot && this.p1_canShoot)
                        CreateBullet("p1");
                    else if (this.p2_shot && this.p2_canShoot)
                        CreateBullet("p2");
                }

                //Update player's state if killed
                if (!this.Spaceship_p1.Enabled)
                {
                    this.Spaceship_p1.Image = global::Space_Invaders.Properties.Resources.green_defender;
                    this.Spaceship_p1.Enabled = true;
                }
                else if (!this.Spaceship_p2.Enabled)
                {
                    this.Spaceship_p2.Image = global::Space_Invaders.Properties.Resources.blue_defender;
                    this.Spaceship_p2.Enabled = true;
                }
            }
            else //single player
            {
                if(this.p_keyState != KeyState.None)
                {
                    //check if player is at the end of the board and where he wants to move
                    if (this.p_keyState == KeyState.Right && this.Spaceship_p.Location.X + this.Spaceship_p.Width <= (this.Right - this.Left - this.Spaceship_p.Width / 5))
                        this.Spaceship_p.Location = new Point(this.Spaceship_p.Location.X + this.alienSpeed * 4, this.Spaceship_p.Location.Y);
                    else if (this.p_keyState == KeyState.Left && this.Spaceship_p1.Location.X >= 0) //move left if possible
                        this.Spaceship_p.Location = new Point(this.Spaceship_p.Location.X - this.alienSpeed * 4, this.Spaceship_p.Location.Y);
                }

                //Update player shots
                if (this.p_shot && this.p_canShoot)
                {
                    CreateSound("shoot");
                    CreateBullet("p");
                }

                //Update player state if killed
                if (!this.Spaceship_p.Enabled)
                {
                    this.Spaceship_p.Image = global::Space_Invaders.Properties.Resources.black_defender;
                    this.Spaceship_p.Enabled = true;
                }
            }
        }

        private void CreateBullet(string shooter, object sender = null)
        {
            TransparentPictureBox bullet = new TransparentPictureBox();
            ((System.ComponentModel.ISupportInitialize)(bullet)).BeginInit();

            bullet.Size = new System.Drawing.Size(5, 15);
            bullet.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            bullet.TabIndex = 62;
            bullet.TabStop = false;

            if (shooter == "p1") //create a green bullet for player 1
            {
                bullet.Tag = "p1_bullet";
                bullet.Image = global::Space_Invaders.Properties.Resources.green_defender_bullet;
                bullet.Location = new Point(this.Spaceship_p1.Location.X + (this.Spaceship_p1.Width / 2) - (bullet.Width / 2), this.Spaceship_p1.Location.Y - bullet.Height);
                this.p1_canShoot = false;
            }
            else if (shooter == "p2") // create a blue bullet for player 2
            {
                bullet.Tag = "p2_bullet";
                bullet.Image = global::Space_Invaders.Properties.Resources.blue_defender_bullet;
                bullet.Location = new Point(this.Spaceship_p2.Location.X + (this.Spaceship_p2.Width / 2) - (bullet.Width / 2), this.Spaceship_p2.Location.Y - bullet.Height);
                this.p2_canShoot = false;
            }
            else if (shooter == "p") //create a black bullet for single player mode
            {
                bullet.Tag = "p_bullet";
                bullet.Image = global::Space_Invaders.Properties.Resources.black_defender_bullet;
                bullet.Location = new Point(this.Spaceship_p.Location.X + (this.Spaceship_p.Width / 2) - (bullet.Width / 2), this.Spaceship_p.Location.Y - bullet.Height);
                this.p_canShoot = false;
            }
            else //create a bullet for the aliens
            {
                bullet.Tag = "alien_bullet";
                bullet.Location = new Point(((PictureBox)sender).Location.X + (((PictureBox)sender).Width / 2) - (bullet.Width / 2), ((PictureBox)sender).Location.Y + bullet.Height);
            }

            this.Controls.Add(bullet);
            ((System.ComponentModel.ISupportInitialize)(bullet)).EndInit();

            //timer for drawing the bullet 
            Timer bulletTime = new Timer();
            bulletTime.Interval = 10;
            bulletTime.Tick += new EventHandler(MoveBullets);
            bulletTime.Tag = bullet;
            bulletTime.Start();


            //timer for limiting the time between shots 
            if (shooter == "p1" || shooter == "p2" || shooter == "p")
            {
                Timer shotTimer = new Timer();
                this.shotsFired++; //update the num of shots fired
                shotTimer.Interval = 500;
                shotTimer.Tick += new EventHandler(ChangeState);
                shotTimer.Tag = shooter;
                shotTimer.Start();
            }
        }

        private void MoveBullets(object sender, EventArgs e)
        {
            Timer t = (Timer)sender;
            PictureBox p = (PictureBox)t.Tag;
            //if bullet reached the top of the screen for player or bottom of the screen for alien delete it
            if (p.Tag.ToString() == "p1_bullet" || p.Tag.ToString() == "p2_bullet" || p.Tag.ToString() == "p_bullet")
            {
                if (p.Location.Y <= this.GameInfo.ClientSize.Height)
                {
                    t.Stop(); //stop the timer for this bullet
                    t.Dispose();
                    p.Size = new System.Drawing.Size(40, 15);
                    p.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                    //show border was hit
                    if (p.Tag.ToString() == "p1_bullet")
                        p.Image = global::Space_Invaders.Properties.Resources.bullet_hit_border_green;
                    else if (p.Tag.ToString() == "p2_bullet")
                        p.Image = global::Space_Invaders.Properties.Resources.bullet_hit_border_blue;
                    else if (p.Tag.ToString() == "p_bullet")
                        p.Image = global::Space_Invaders.Properties.Resources.bullet_hit_border;
                    p.Image.Tag = "bullet_hit_border";
                }
                else
                {
                    p.Location = new Point(p.Location.X, p.Location.Y - 10); //player bullets move up
                    UpdateHits(t, p);
                }
            }
            else  //alien bullet
            {
                if (p.Location.Y >= (this.ClientSize.Height - p.Height))
                {
                    t.Stop(); //stop the timer for this bullet
                    t.Dispose();
                    p.Size = new System.Drawing.Size(40, 15);
                    p.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                    //show border was hit
                    p.Image = global::Space_Invaders.Properties.Resources.bullet_hit_border;
                    p.Image.Tag = "bullet_hit_border";
                    this.numOfAlienShooters--;
                }
                else //move alien bullet
                {
                    if (p.Enabled) //Image 1
                        p.Image = global::Space_Invaders.Properties.Resources.alien_bullet_1;
                    else //Image 2
                        p.Image = global::Space_Invaders.Properties.Resources.alien_bullet_2;
                    //move bullet
                    p.Location = new Point(p.Location.X, p.Location.Y + 3); //alien bullets move down
                    p.Enabled = !p.Enabled;
                    UpdateHits(t, p);
                }
            }
        }

        private void ChangeState(object sender, EventArgs e)
        {
            Timer t = (Timer)sender;
            string player = (string)t.Tag;
            if (player == "p1")
                this.p1_canShoot = true;
            else if (player == "p2")
                this.p2_canShoot = true;
            else if (player == "p")
                this.p_canShoot = true;
            t.Stop();
        }

        private void UpdateHits(Timer t, PictureBox p)
        {
            //check if player bullets hit aliens
            //update game accordingly (points and aliens)

            foreach (Control C in this.Controls)
            {
                if (p.Tag.ToString() != "alien_bullet")
                {
                    if (C.Tag != null && C.Tag.ToString().Substring(0, 5) == "Alien") //check if the control is an alien
                    {
                        if (((PictureBox)C).Bounds.IntersectsWith(p.Bounds))
                        {
                            ((PictureBox)C).Image = global::Space_Invaders.Properties.Resources.alien_explosion;
                            ((PictureBox)C).Image.Tag = "alien_explosion";

                            string bullet = p.Tag.ToString();
                            UpdatePoints(bullet, (PictureBox)C);

                            p.Dispose();
                            t.Stop();
                            t.Dispose();
                        }
                    }
                    else if (C.Tag != null && C.Tag.ToString() == "alienSpaceShip" && this.alien_spaceShip.Visible) //bullet hit ufo
                    {
                        if (((PictureBox)C).Bounds.IntersectsWith(p.Bounds))
                        {
                            this.alien_spaceShip.Visible = false;
                            int pts = 0;
                            string playerBullet = p.Tag.ToString();
                            if (Math.Abs(this.shotsFired - 23) % 15 == 0)
                            {
                                this.UFO_pts.Text = "300";
                                pts = 300;
                            }
                            else
                            {
                                this.UFO_pts.Text = this.spaceship_ptsWorth;
                                pts = int.Parse(this.spaceship_ptsWorth);
                            }

                            if (playerBullet == "p1_bullet")
                            {
                                int p1_pts = int.Parse(this.p1_score.Text) + pts;
                                this.p1_score.Text = p1_pts.ToString();
                            }
                            else if (playerBullet == "p2_bullet")
                            {
                                int p2_pts = int.Parse(this.p2_score.Text) + pts;
                                this.p2_score.Text = p2_pts.ToString();
                            }
                            this.UFO_pts.Location = new Point(this.alien_spaceShip.Location.X, this.alien_spaceShip.Location.Y);
                            this.UFO_pts.Visible = true;
                        }
                    }
                }
            }
            //check if alien bullet hit player
            if (p.Tag.ToString() == "alien_bullet") //alien bullet
            {
                //check if the bullet intersects with one of the players
                if(this.numOfPlayers > 1) //multiplayer
                {
                    if (this.Spaceship_p1.Bounds.IntersectsWith(p.Bounds) || this.Spaceship_p2.Bounds.IntersectsWith(p.Bounds))
                    {
                        if (this.Spaceship_p1.Bounds.IntersectsWith(p.Bounds))
                            UpdateLives(this.Spaceship_p1);
                        else if (this.Spaceship_p2.Bounds.IntersectsWith(p.Bounds))
                            UpdateLives(this.Spaceship_p2);

                        p.Dispose();
                        t.Stop();
                        t.Dispose();
                        this.numOfAlienShooters--;
                    }
                }
                else //single player
                {
                    if (this.Spaceship_p.Bounds.IntersectsWith(p.Bounds))
                    {
                        UpdateLives(this.Spaceship_p);

                        p.Dispose();
                        t.Stop();
                        t.Dispose();
                        this.numOfAlienShooters--;
                    }
                }
            }
        }

        private void UpdatePoints(string playerBullet, object sender)
        {
            //each alien is worth different points:
            //alien1 - 10
            //alien2 - 20
            //alien3 - 30
            int pts = 0;
            PictureBox alien = (PictureBox)sender;
            if (alien.Tag.ToString() == "Alien1")
                pts = this.alien1_ptsWorth;
            else if (alien.Tag.ToString() == "Alien2")
                pts = this.alien2_ptsWorth;
            else if (alien.Tag.ToString() == "Alien3")
                pts = this.alien3_ptsWorth;

            if (playerBullet == "p1_bullet")
            {
                int p1_pts = int.Parse(this.p1_score.Text) + pts;
                this.p1_score.Text = p1_pts.ToString();
            }
            else if (playerBullet == "p2_bullet")
            {
                int p2_pts = int.Parse(this.p2_score.Text) + pts;
                this.p2_score.Text = p2_pts.ToString();
            }
            else if (playerBullet == "p_bullet")
            {
                int p_pts = int.Parse(this.p_score.Text) + pts;
                this.p_score.Text = p_pts.ToString();
            }
        }

        private void UpdateLives(object sender)
        {
            PictureBox spaceShip = (PictureBox)sender;

            //show hit space ship
            spaceShip.Image = global::Space_Invaders.Properties.Resources.defender_explosion;
            CreateSound("player_death_explosion");
            spaceShip.Enabled = false;

            //show lives
            if (spaceShip.Name.ToString() == "Spaceship_p1" && this.p1_livesLeft > 0)
            {
                this.p1_livesLeft -= 1;
                this.p1_lives.Controls.Remove(this.p1_lives.GetControlFromPosition(this.p1_livesLeft, 0));
            }
            else if (spaceShip.Name.ToString() == "Spaceship_p2" && this.p2_livesLeft > 0)
            {
                this.p2_livesLeft -= 1;
                this.p2_lives.Controls.Remove(this.p2_lives.GetControlFromPosition(this.p2_livesLeft, 0));
            }
            else if(spaceShip.Name.ToString() == "Spaceship_p" && this.p_livesLeft > 0)
            {
                this.p_livesLeft -= 1;
                this.p_lives.Controls.Remove(this.p_lives.GetControlFromPosition(this.p_livesLeft, 0));
            } 

        }

        private int GetNumOfLivingAliens()
        {
            int counter = 0;
            foreach (Control C in this.Controls)
            {
                if (C.Tag != null && C.Tag.ToString().Substring(0, 5) == "Alien") //check if the control is an alien
                    counter++;
            }
            return counter;
        }

        private void CheckGameOver()
        {
            bool endGame = false;
            //check if player killed all aliens
            if (GetNumOfLivingAliens() == 0)
            {
                endGame = true;
                CreateVoiceMessage("Great Job!! All invaders defeated.");
                if(this.numOfPlayers > 1) //multiplayer
                {
                    int p1_pts = int.Parse(this.p1_score.Text);
                    int p2_pts = int.Parse(this.p2_score.Text);
                    if (p1_pts > p2_pts)
                        CreateVoiceMessage(string.Format("Green Player won with {0} points.", p1_pts));
                    else if (p2_pts > p1_pts)
                        CreateVoiceMessage(string.Format("Blue Player won with {0} points.", p2_pts));
                    else //tie
                        CreateVoiceMessage("Both players scored equally!");
                }
                else //single player
                {
                    int p_pts = int.Parse(this.p_score.Text);
                    CreateVoiceMessage(string.Format("You finished with {0} points.", p_pts));
                }
            }

            //check if aliens killed one of the players or both of them
            else if ((this.numOfPlayers > 1 && (this.p1_livesLeft == 0 || this.p2_livesLeft == 0)) || (this.numOfPlayers == 1 && this.p_livesLeft == 0))
            {
                endGame = true;
                if (this.numOfPlayers > 1) //multiplayer
                {
                    if (this.p1_livesLeft == 0 && this.p2_livesLeft == 0)
                        CreateVoiceMessage("The aliens have destroyed both of you. Better luck next time!");
                    else if (this.p1_livesLeft == 0)
                        CreateVoiceMessage("Green player killed. Blue Player is the winner! Congratulations!!");
                    else if (this.p2_livesLeft == 0)
                        CreateVoiceMessage("Blue player killed. Green Player is the winner! Congratulations!!");
                }
                else //single player
                    CreateVoiceMessage("Too Bad. Better luck next time!");
            }

            //check if aliens got to the bottom of the screen
            else
            {
                foreach (Control C in this.Controls)
                {
                    if (C is PictureBox && C.Tag != null && C.Tag.ToString().Substring(0, 5) == "Alien")
                    {
                        if (C.Location.Y >= this.ClientSize.Height - C.Height - this.Spaceship_p1.Height) //alien reached the spaceships
                        {
                            CreateVoiceMessage("Aliens have reached our base. We lost this war...");
                            endGame = true;
                            break;
                        }
                    }
                }
            }

            if (endGame) //game ended for one of the above reasons
                ShowMainMenu();
        }

        private void ShowMainMenu()
        {
            this.tmrAppTimer.Stop();
            this.UFO_timer.Stop();
            this.backgroundMusic.Ctlcontrols.stop();
            //return to start page
            Form1 newGame = new Form1();
            newGame.Show();
            this.Dispose(false);
        }

        #endregion

        #region MainMenuFunctions

        private void singlePlayer_label_Click(object sender, EventArgs e)
        {
            //Start Single Player Game 
            InitializeComponent();
            //load background image of game
            StartNewSinglePlayerGame();
            System.Threading.Thread thread = new System.Threading.Thread(new System.Threading.ThreadStart(LoadBackgroundImage));
            thread.Start();
            this.startpage.Dispose();
        }

        private void multiplayer_label_Click(object sender, EventArgs e)
        {
            //Start Multiplayer Game
            InitializeComponent();
            //load background image of game
            StartNewMultiplayerGame();
            System.Threading.Thread thread = new System.Threading.Thread(new System.Threading.ThreadStart(LoadBackgroundImage));
            thread.Start();
            this.startpage.Dispose();
        }

        private void help_label_Click(object sender, EventArgs e)
        {
            //show help menu

            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.help_menu = new System.Windows.Forms.TableLayoutPanel();
            this.ufo_pts_label = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.a1_pictureBox1 = new System.Windows.Forms.PictureBox();
            this.a2_pictureBox2 = new System.Windows.Forms.PictureBox();
            this.a3_pictureBox3 = new System.Windows.Forms.PictureBox();
            this.a4_pictureBox4 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.back_label = new System.Windows.Forms.Label();
            this.help_menu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.a1_pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.a2_pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.a3_pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.a4_pictureBox4)).BeginInit();
            this.SuspendLayout();
            // 
            // help_menu
            // 
            this.help_menu.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.help_menu.ColumnCount = 2;
            this.help_menu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.help_menu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.help_menu.Controls.Add(this.ufo_pts_label, 1, 4);
            this.help_menu.Controls.Add(this.label3, 1, 3);
            this.help_menu.Controls.Add(this.label2, 1, 2);
            this.help_menu.Controls.Add(this.textBox1, 0, 0);
            this.help_menu.Controls.Add(this.a1_pictureBox1, 0, 1);
            this.help_menu.Controls.Add(this.a2_pictureBox2, 0, 2);
            this.help_menu.Controls.Add(this.a3_pictureBox3, 0, 3);
            this.help_menu.Controls.Add(this.a4_pictureBox4, 0, 4);
            this.help_menu.Controls.Add(this.label1, 1, 1);
            this.help_menu.Controls.Add(this.back_label, 0, 5);
            this.help_menu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.help_menu.Location = new System.Drawing.Point(0, 0);
            this.help_menu.Name = "help_menu";
            this.help_menu.RowCount = 6;
            this.help_menu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.help_menu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.help_menu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.help_menu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.help_menu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.help_menu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.help_menu.Size = new System.Drawing.Size(765, 527);
            this.help_menu.TabIndex = 0;
            // 
            // ufo_pts_label
            // 
            this.ufo_pts_label.AutoSize = true;
            this.ufo_pts_label.BackColor = System.Drawing.Color.White;
            this.ufo_pts_label.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ufo_pts_label.Font = new System.Drawing.Font("Bauhaus 93", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ufo_pts_label.ForeColor = System.Drawing.Color.Black;
            this.ufo_pts_label.Location = new System.Drawing.Point(385, 366);
            this.ufo_pts_label.Name = "ufo_pts_label";
            this.ufo_pts_label.Size = new System.Drawing.Size(377, 52);
            this.ufo_pts_label.TabIndex = 8;
            this.ufo_pts_label.Text = "  = ??? PTS";
            this.ufo_pts_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("Bauhaus 93", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(385, 314);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(377, 52);
            this.label3.TabIndex = 7;
            this.label3.Text = "= 30 PTS";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Bauhaus 93", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(385, 262);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(377, 52);
            this.label2.TabIndex = 6;
            this.label2.Text = "= 20 PTS";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.Black;
            this.help_menu.SetColumnSpan(this.textBox1, 2);
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1.Font = new System.Drawing.Font("Bauhaus 93", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.ForeColor = System.Drawing.Color.White;
            this.textBox1.Location = new System.Drawing.Point(3, 3);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(759, 204);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = resources.GetString("textBox1.Text");
            // 
            // a1_pictureBox1
            // 
            this.a1_pictureBox1.BackColor = System.Drawing.Color.White;
            this.a1_pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.a1_pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.a1_pictureBox1.Image = global::Space_Invaders.Properties.Resources.alien1;
            this.a1_pictureBox1.Location = new System.Drawing.Point(3, 213);
            this.a1_pictureBox1.Name = "a1_pictureBox1";
            this.a1_pictureBox1.Size = new System.Drawing.Size(376, 46);
            this.a1_pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.a1_pictureBox1.TabIndex = 1;
            this.a1_pictureBox1.TabStop = false;
            // 
            // a2_pictureBox2
            // 
            this.a2_pictureBox2.BackColor = System.Drawing.Color.White;
            this.a2_pictureBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.a2_pictureBox2.Image = global::Space_Invaders.Properties.Resources.alien2;
            this.a2_pictureBox2.Location = new System.Drawing.Point(3, 265);
            this.a2_pictureBox2.Name = "a2_pictureBox2";
            this.a2_pictureBox2.Size = new System.Drawing.Size(376, 46);
            this.a2_pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.a2_pictureBox2.TabIndex = 2;
            this.a2_pictureBox2.TabStop = false;
            // 
            // a3_pictureBox3
            // 
            this.a3_pictureBox3.BackColor = System.Drawing.Color.White;
            this.a3_pictureBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.a3_pictureBox3.Image = global::Space_Invaders.Properties.Resources.alien3;
            this.a3_pictureBox3.Location = new System.Drawing.Point(3, 317);
            this.a3_pictureBox3.Name = "a3_pictureBox3";
            this.a3_pictureBox3.Size = new System.Drawing.Size(376, 46);
            this.a3_pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.a3_pictureBox3.TabIndex = 3;
            this.a3_pictureBox3.TabStop = false;
            // 
            // a4_pictureBox4
            // 
            this.a4_pictureBox4.BackColor = System.Drawing.Color.White;
            this.a4_pictureBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.a4_pictureBox4.Image = global::Space_Invaders.Properties.Resources.alien_spaceship;
            this.a4_pictureBox4.Location = new System.Drawing.Point(3, 369);
            this.a4_pictureBox4.Name = "a4_pictureBox4";
            this.a4_pictureBox4.Size = new System.Drawing.Size(376, 46);
            this.a4_pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.a4_pictureBox4.TabIndex = 4;
            this.a4_pictureBox4.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Bauhaus 93", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(385, 210);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(377, 52);
            this.label1.TabIndex = 5;
            this.label1.Text = "= 10 PTS";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // back_label
            // 
            this.help_menu.SetColumnSpan(this.back_label, 2);
            this.back_label.Dock = System.Windows.Forms.DockStyle.Fill;
            this.back_label.Font = new System.Drawing.Font("Bauhaus 93", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.back_label.Location = new System.Drawing.Point(3, 418);
            this.back_label.Name = "back_label";
            this.back_label.Size = new System.Drawing.Size(759, 109);
            this.back_label.TabIndex = 9;
            this.back_label.Text = "Back";
            this.back_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.back_label.Click += new System.EventHandler(this.back_label_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(765, 527);
            this.Controls.Add(this.help_menu);
            this.help_menu.BringToFront();
            this.ForeColor = System.Drawing.Color.White;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.help_menu.ResumeLayout(false);
            this.help_menu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.a1_pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.a2_pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.a3_pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.a4_pictureBox4)).EndInit();
            this.ResumeLayout(false);

        }

        private void back_label_Click(object sender, EventArgs e)
        {
            this.help_menu.Dispose();
        }

        #endregion
    }
}
