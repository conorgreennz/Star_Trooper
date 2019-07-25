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
        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
