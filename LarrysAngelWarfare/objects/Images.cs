using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LarrysAngelWarfare
{   //this class will hold all of the images
    class Images
    {   //define all the objs
        public static Texture2D playerSpriteSheet;
        public static Texture2D DemonSpriteSheet;
        public static Texture2D Bullet;
        public static Texture2D wall;
        public static Texture2D healthBar;
        public static Texture2D BloodFountainSmall;
        public static Texture2D BloodFountainBig;
        public static Texture2D darkWall;
        public static Texture2D stoneWall;
        public static Texture2D Torch;
        public static Texture2D menuBackground;
        //this function will be called when you wanna load all the objs
        public static void LoadImages(ContentManager Content)
        {
            //define all the objs
            playerSpriteSheet =  Content.Load<Texture2D>("playerSpriteSheet");
            DemonSpriteSheet = Content.Load<Texture2D>("DemonSpriteSheet");
            Bullet = Content.Load<Texture2D>("bullet");
            wall = Content.Load<Texture2D>("wall");
            darkWall = Content.Load<Texture2D>("StoneBlock");
            stoneWall = Content.Load<Texture2D>("LightStoneWall");
            healthBar = Content.Load<Texture2D>("healthBar");
            BloodFountainSmall = Content.Load<Texture2D>("blood fountain small");
            BloodFountainBig= Content.Load<Texture2D>("blood fountain big");
            Torch = Content.Load<Texture2D>("torch");
            menuBackground = Content.Load<Texture2D>("background");

        }
    }
}
