using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace Star_Trooper
{
    public partial class Form1 : Form
    {
        Random RandomNumber;  // create a new random number generator
        Bitmap OGUserImage; // create a new variable as the orignal ship image incase ship image is damaged during rotation
        Bitmap UserImage; // create a new variable as the ship image 
        User myUser; // create new variable called my ship
        Bitmap OGEnemyImage; // create a new vairable called original Enemy image incase Enemy image gets damaged during rotation
        Bitmap OGMissileImage; // create a new variable called original bullet image incse bullet image gets damaged during rotation
        List<Enemy> EnemyList; // create a new list variable called Enemylist ( this is to hold the many Enemies used on the form)
        List<Missile> MissileList; // create a new list for the bullets on the game panel and call it bullet list

        int EnemySpeed;

        int Points, lives;

        const int maxEnemies = 3;

        public Form1()
        {
            InitializeComponent();
            // Secondary image provides as a base for the computer to reference while the image rotates and pixelates 

            OGUserImage = GetResourceByImageName("Ship");
            OGUserImage.MakeTransparent(Color.Black);

            OGEnemyImage = GetResourceByImageName("Enemy");
            OGEnemyImage.MakeTransparent(Color.Black);

            OGMissileImage = GetResourceByImageName("Missile");
            OGMissileImage.MakeTransparent(Color.Black);

            //create and set the variables for the moving components
            myUser = new User();
            myUser.X = 50;
            myUser.Y = 140;
            myUser.Angle = 0;
            UserImage = RotateImage(OGUserImage, myUser.Angle);

            //Make the enemy list
            EnemyList = new List<Enemy>();

            //make the Bullet List
            MissileList = new List<Missile>();

            //create the enemy and set up the position
            RandomNumber = new Random(); // set it as a random spawn function depending on the angle the enemy is spawned in at 

        }
        public Bitmap GetResourceByImageName(string imageName) // collect the resource using its name as a reference
        {
            System.Reflection.Assembly asm = System.Reflection.Assembly.GetExecutingAssembly();
            string resourceName = asm.GetName().Name + ".properties.Resources";
            var rm = new System.Resources.ResourceManager(resourceName, asm);
            return (Bitmap)rm.GetObject(imageName);
        }
        private Bitmap RotateImage(Bitmap bmp, float angle)
        {
            Bitmap rotatedImage = new Bitmap(bmp.Width, bmp.Height); //create a new bitmap as a rotated image
            using (Graphics g = Graphics.FromImage(rotatedImage)) // create the new image using graphics
            {
                // Set the rotation point to the center in the matrix
                g.TranslateTransform(bmp.Width / 2, bmp.Height / 2);
                // Rotate
                g.RotateTransform(angle);
                // Restore rotation point in the matrix
                g.TranslateTransform(-bmp.Width / 2, -bmp.Height / 2);
                // Draw the image on the bitmap
                g.DrawImage(bmp, new Point(0, 0));
            }

            return rotatedImage;
        }

        private void TmrGame_Tick(object sender, EventArgs e)
        {
            // check for player ky press and exicute order
            byte[] keys = new byte[256];
            GetKeyboardState(keys);

            if (((keys[(int)Keys.A]) & 128) == 128)
            {
                if (myUser.X > 0)
                {
                 myUser.MoveLeft(); // use the sequence of move left in the ships class
                    pictureBox1.Invalidate(); //Update the picture box with the new sequence
                }
            }
            if (((keys[(int)Keys.D]) & 128) == 128)
            {
                if (myUser.X < 708)
                {
                    myUser.MoveRight(); // change the position of the ship using the sequence described as move right in the ships class
                    pictureBox1.Invalidate(); // invalidate the picture box with the new image of the moved images and label
                }
            }
            if (((keys[(int)Keys.W]) & 128) == 128)
            {
                if (myUser.Y > 0)
                {
                    myUser.MoveUp(); // change position of the ship using the sequence described as move up in the ships class
                    pictureBox1.Invalidate(); // invalidate the picture box with the new image of the moved images and label
                }
            }
            if (((keys[(int)Keys.S]) & 128) == 128)
            {
                if (myUser.Y < 392)
                {
                    myUser.MoveDown(); // change position of the ship using the sequence described as move down in the ships class                
                    pictureBox1.Invalidate(); // invalidate the picture box with the new image of the moved images and label
                }
            }
            if (((keys[(int)Keys.Left]) & 128) == 128)
            {
                myUser.RotateLeft();
                UserImage = RotateImage(OGUserImage, myUser.Angle); // rotate the image to the required angle.              
                pictureBox1.Invalidate(); // invalidate the picture box with the new image of the moved images and label
            }
            if (((keys[(int)Keys.Right]) & 128) == 128)
            {
                myUser.RotateRight();
                UserImage = RotateImage(OGUserImage, myUser.Angle); // rotate the image to the required angle.              
                pictureBox1.Invalidate(); // invalidate the picture box with the new image of the moved images and label
            }
            if (((keys[(int)Keys.Space]) & 128) == 128)
            {
                if (MissileList.Count < 25)
                {
                    Missile myMissile;

                    myMissile = new Missile(); // create and instantiate the Bullet
                    myMissile.X = myUser.X + 112;// set the x value to the same as the ship
                    myMissile.Y = myUser.Y + 48; // set the bullets y value to be in line with the ship 
                    myMissile.Angle = myUser.Angle; // set the bullets angle to the same as the shaip
                    myMissile.Image = RotateImage(OGMissileImage, myMissile.Angle); // rotate the image to the required angle. using the OG image as a reference 

                    MissileList.Add(myMissile); // add my bullet to the list named bulletlist

                }

            }
            // move all of the birds images naturally  
            for (int i = 0; i < EnemyList.Count; i++)
            {
                Enemy myEnemy = EnemyList[i];
                myEnemy.Move(); // take the value of the bird from the list and enable it to move 

                if (
                    // off the top
                    (myEnemy.Y < -74)
                    // off the bottom
                    || (myEnemy.Y > pictureBox1.Height + 10)
                    // off the left
                    || (myEnemy.X < -74)
                    // off the right
                    || (myEnemy.X > pictureBox1.Width + 10)

                )
                { // then reset the birds position on the y and x axis and give it a new random angle 
                    ResetEnemy(myEnemy);
                }
            }
            // move all of the bullets images naturally 
            for (int i = 0; i < MissileList.Count; i++)
            {
                Missile myMissile = MissileList[i];
                myMissile.Move(); // take the value of the bullet from the list and enable it to move 

                // if the bullet has gone off the screen
                if (myMissile.X > pictureBox1.Width
                    || myMissile.Y > pictureBox1.Height
                    || myMissile.X < 0
                    || myMissile.Y < 0
                     )
                {
                    // delete the bullet
                    MissileList.Remove(myMissile);
                }

            }
            // check for colisions between the bullets and the birds
            for (int i = MissileList.Count - 1; i >= 0; i--)
            {
                Missile myMissile = MissileList[i];
                for (int j = EnemyList.Count - 1; j >= 0; j--)
                {
                    Enemy myEnemy = EnemyList[j];

                    Rectangle birdRec = new Rectangle(myEnemy.X, myEnemy.Y, 59, 51);
                    Rectangle bulletRec = new Rectangle(myMissile.X, myMissile.Y, 32, 32);


                    if (bulletRec.IntersectsWith(birdRec)) // if the bullet intersects with the bird then remove the bullet and the bird 
                    {
                        MissileList.Remove(myMissile);
                        ResetEnemy(myEnemy);

                        Points = Points + 1; // add oneto the points value and display it on the game panel
                        LblPoints.Text = Points.ToString();

                        CheckPoints();
                    }
                }
            }
            // check for collisions between the ship and the Enemy
            for (int i = EnemyList.Count - 1; i >= 0; i--)
            {
                Enemy myEnemy = EnemyList[i];

                Rectangle birdRec = new Rectangle(myEnemy.X, myEnemy.Y, 59, 51); // set the rectangle for the bird 
                Rectangle shipRec = new Rectangle(myUser.X, myUser.Y, 118, 128); // set the rectangle for the ship

                if (shipRec.IntersectsWith(birdRec))
                {
                    // ship has collided with a bird, lose a life, reset the bird
                    lives = lives - 1;
                    TxtLives.Text = lives.ToString();
                    ResetEnemy(myEnemy);

                    if (lives == 0) // if the lives value is equal to 0 then tell the timer to stop and say the game is over 
                    {
                        TmrGame.Enabled = false;
                        MessageBox.Show("Game Over");
                        startToolStripMenuItem.Enabled = false;
                        stopToolStripMenuItem.Enabled = false;

                    }


                }

            }
        }
        void CheckPoints()
        {
            // check point value and introduce increased difficulty
            if (Points == 20)
            {
                // if points = 20 increase the speed of the birds
                IncreaseEnemySpeed();
                // max bird = +1
                IncreaseEnemyCount();
            }
        }

            private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            for (int i = 0; i < EnemyList.Count; i++)
            {
                Enemy myEnemy = EnemyList[i]; // collect information of the bird from the list
                e.Graphics.DrawImage(myEnemy.Image, myEnemy.X, myEnemy.Y); // draw the bird image in the picturebox at the set x and y values 
            }

            for (int i = 0; i < MissileList.Count; i++)
            {
                Missile myMissile = MissileList[i]; // collect information of the bullet from the list
                e.Graphics.DrawImage(myMissile.Image, myMissile.X, myMissile.Y);
            }

            e.Graphics.DrawImage(UserImage, myUser.X, myUser.Y); // draw the ship image in the picturebox at x value and y value.

        }

        // example stolen from https://stackoverflow.com/questions/709540/capture-multiple-key-downs-in-c-sharp
        // this enables me to read multiple key presses simultaneously 
        [DllImport("user32.dll")]
        public static extern int GetKeyboardState(byte[] keystate);
        // end of example  

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        void ResetEnemy(Enemy myEnemy)
        {
            myEnemy.X = myEnemy.SpawnX; // set the spawn points for the bird using the x, y and angle of the my bird as it spawns 
            myEnemy.Y = myEnemy.SpawnY;
            myEnemy.Angle = myEnemy.SpawnAngle;
        }
        void IncreaseEnemySpeed()
        {
            EnemySpeed = EnemySpeed + 1;
            for (int i = EnemyList.Count - 1; i >= 0; i--) // for every bird in the list increase the speed by one 
            {
                Enemy myEnemy = EnemyList[i];
                myEnemy.MoveRate = EnemySpeed;
            }
        }
        void IncreaseShipSpeed()
        {

            myUser.UserMoveRate = myUser.UserMoveRate + 1;

        }
        void IncreaseEnemyCount()
        {
            Enemy myEnemy;

            myEnemy = new Enemy(); // create and instantiate the bird 
            myEnemy.SpawnX = pictureBox1.Width + 10;// set its x value to the full width of the picturebox to which it is displayed plus ten so it does not stat visable to the player 
            myEnemy.SpawnY = RandomNumber.Next(0, pictureBox1.Height); // set the birds y to a random number on the y axis within the paraeters of 0 and the top of the picturebox 
            myEnemy.X = myEnemy.SpawnX;
            myEnemy.Y = myEnemy.SpawnY;

            myEnemy.SpawnAngle = RandomNumber.Next(-45, 45); // set the birds angle to a random variable using the random number generator 
            myEnemy.Angle = myEnemy.SpawnAngle;
            myEnemy.Image = RotateImage(OGEnemyImage, myEnemy.Angle); // rotate the image to the required angle. using the OG image as a reference 
            myEnemy.MoveRate = EnemySpeed;

            EnemyList.Add(myEnemy); // add my bird to the list named birdlist 

        }
        void IncreaseEnemyCountTop()
        {
            Enemy myEnemy;

            myEnemy = new Enemy(); // create and instantiate the bird 
            myEnemy.SpawnX = RandomNumber.Next(10, pictureBox1.Width);// set its x value to the widthof the picturebox to which it is displayed between a number of the width of the picture box and ten so it does not start visable to the player 
            myEnemy.SpawnY = -64 - 10; // set the birds y axis to start at the top of the picturebox not visable by the player  
            myEnemy.X = myEnemy.SpawnX;
            myEnemy.Y = myEnemy.SpawnY;
            myEnemy.SpawnAngle = RandomNumber.Next(-150, -60); // set the birds angle to a random variable using the random number generator 
            myEnemy.Angle = myEnemy.SpawnAngle;

            myEnemy.Image = (Bitmap)OGEnemyImage.Clone();
            if (myEnemy.Angle >= -90)
            {
                myEnemy.Image = RotateImage(myEnemy.Image, myEnemy.Angle); // rotate the image to the required angle. using the OG image as a reference 
            }
            else
            {
                myEnemy.Image.RotateFlip(RotateFlipType.RotateNoneFlipX); // flip it on the x axis and then display it 
                myEnemy.Image = RotateImage(myEnemy.Image, myEnemy.Angle); // rotate to the  required angle 
            }
            myEnemy.MoveRate = EnemySpeed;

            EnemyList.Add(myEnemy); // add my bird to the list named birdlist 

        }

        void IncreaseBirdCountBottom()
        {
            Enemy myEnemy;

            myEnemy = new Enemy(); // create and instantiate the bird 
            myEnemy.SpawnX = RandomNumber.Next(1, pictureBox1.Width);// set its x value to the full width of the picturebox to which it is displayed plus ten so it does not stat visable to the player 
            myEnemy.SpawnY = pictureBox1.Height; // set the birds y to a random number on the y axis within the parameters of 0 and the top of the picturebox 
            myEnemy.X = myEnemy.SpawnX; // set a x position spawn point
            myEnemy.Y = myEnemy.SpawnY; // set a y position spawn point 

            myEnemy.SpawnAngle = RandomNumber.Next(80, 170); // set the birds angle to a random variable using the random number generator 
            myEnemy.Angle = myEnemy.SpawnAngle; // tell that the spawn point is equal to the given angle 
            myEnemy.Image = (Bitmap)OGEnemyImage.Clone();
            if (myEnemy.Angle <= 90)
            {
                myEnemy.Image = RotateImage(myEnemy.Image, myEnemy.Angle); // rotate the image to the required angle. using the OG image as a reference 
            }
            else
            {
                myEnemy.Image.RotateFlip(RotateFlipType.RotateNoneFlipX);
                myEnemy.Image = RotateImage(myEnemy.Image, myEnemy.Angle - 180);
            }
            myEnemy.MoveRate = EnemySpeed; // tell that the bird speed is the new move rate 

            EnemyList.Add(myEnemy); // add my bird to the list named birdlist 
        }

        void IncreaseBirdCountLeft()
        {
            Enemy myEnemy;

            myEnemy = new Enemy(); // create and instantiate the bird 
            myEnemy.SpawnX = 0 - 10;// set its x value to the left side of the picturebox to which it is displayed minus ten so it does not start visable to the player 
            myEnemy.SpawnY = RandomNumber.Next(1, pictureBox1.Height); // set the birds y to a random number on the y axis within the parameters of 0 and the top of the picturebox 
            myEnemy.X = myEnemy.SpawnX; // set a x position spawn point
            myEnemy.Y = myEnemy.SpawnY; // set a y position spawn point 

            myEnemy.SpawnAngle = RandomNumber.Next(135, 225); // set the birds angle to a random variable using the random number generator 
            myEnemy.Angle = myEnemy.SpawnAngle; // tell that the spawn point is equal to the given angle 
            myEnemy.Image = (Bitmap)OGEnemyImage.Clone();
            myEnemy.Image.RotateFlip(RotateFlipType.RotateNoneFlipX);
            myEnemy.Image = RotateImage(myEnemy.Image, myEnemy.Angle - 180); // rotate the image to the required angle. using the OG image as a reference 
            myEnemy.MoveRate = EnemySpeed; // tell that the bird speed is the new move rate 

            EnemyList.Add(myEnemy); // add my bird to the list named birdlist 
        }
    }
}
