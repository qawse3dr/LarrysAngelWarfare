using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using LarrysAngelWarfare;
namespace LarrysAngelWarfare
{
    //uses objects to get a bunch of the classes and get the same type
    class Player : Objects
    {
        //X and y
        public  int x;
        public int y;
        //Where the current screen is compared to blocks. this will keep track of where the blocks should be showen
        private int screenX = 0;
        private int screenY = 0;
        //this will keep track of the box the player can move in on the screen
        public static int moveScreenX = 0;
        public static int moveScreenY = 0;
        //this will keep track of the animations uses bytes to save memory 
        private byte  walkingTimer = 0;
        private byte walkAnimation = 0;
        private byte gunSpeed = 10;
        //this is used to i can make bullets from the player classs
        private ContentManager Content;
        private byte walkAnimationSide = 0;
        //this will be used to keep track of the bullets timer. aka the CD of the bullets
        private byte gunTimer = 0;
        //this i used for checking collision
        public Texture2D healthHUD;
        //this will be used for the hit boxs
        public Rectangle rect = new Rectangle();
        //So I can created bullet obj in this class
        private SpriteBatch spriteBatch;

        public override void draw(SpriteBatch spriteBatch)
        {

            //this will draw the player uses x - moveScreenx and y so it will appear on the screen even
            //when the x is off of the screen
            spriteBatch.Draw(image, new Vector2(x - moveScreenX, y - moveScreenY), new Rectangle(64* walkAnimation + walkAnimation +1, 64 * walkAnimationSide + walkAnimationSide+1 ,64,64),Color.White);
            //This is the health bar. times by 1.28 because the block is 128 pixels so its easier to keep track of health
            spriteBatch.Draw(healthHUD, new Vector2(16, 16), new Rectangle(0, 0, (int)(health * 1.28), 32), Color.White);

            
        }

        public override int getx()
        {
            return x;
        }

        public override int getY()
        {
            return y;
        }
        //i will call this when i create the player
        public override void init(SpriteBatch spriteBatch, ContentManager Content)
        {
            //this is the player image
            image = Images.playerSpriteSheet;
            //this is the image for the health bar
            healthHUD = Images.healthBar;
            //this will be used the create the bullets
            this.Content = Content;
            //this is used to display images
            this.spriteBatch = spriteBatch;
            //this will be used for hitboxs
            rect = new Rectangle(x, y, 64,64);
            //this is where the screen is being displayed
            
            //this is the box that moves the screen
            moveScreenX = x - 128;
            
            moveScreenY = y - 192;
            //this is the max health of the player
            health = 100;
            //sets it to emit light
            emitLight = true;
        }

        public override void setx(int x)
        {
            this.x = x;
            
        }

        public override void sety(int y)
        {
            this.y = y;
        }
        //this will be called every frame do things that i want to run every time
        public override void update()
        {
            //this refreshs the rect for the hit boxs
            rect.X = x;
            rect.Y = y;
            //this will be used for enemys so they know where the player is
            ObjectsList.playerx = x;
            ObjectsList.playery = y;
            //this will check if the player is dead
            if (health <= 0)
            {
                ;
                //do death screen here
            }
            //this will be used for 
            walkingTimer++;
            //This will display the first frame
            if (walkingTimer < 15)
            {
                walkAnimation = 0;
            //display the second frame
            }else
            {
                walkAnimation = 1;
                //resets the walk timer
                if (walkingTimer >= 30)
                {
                    walkingTimer = 0;
                }
            }
            //this will check if the button is getting pressed
            if (LarrysAngelWarfare.mouseState.LeftButton == ButtonState.Pressed){
                //this will add one to the CD timer
                gunTimer++;
                //this will checks if it can run 
                if (gunTimer == gunSpeed )
                {
                    //resets the gun timer
                    gunTimer = 0;
                    //creates a new bullet
                    Objects bullet = new Bullets();
                    //sets the x and why of the bullet based on your x and y
                    bullet.setx(x+32);
                    bullet.sety(y+16);
                    //finding if the bullet should go left or right
                        if ( x - moveScreenX - LarrysAngelWarfare.mouseState.X > 0)
                    {
                        bullet.moveX = -1;
                    }else
                    {
                        bullet.moveX = 1;
                    }
                        //finds the x direction (the run of the slope)
                        bullet.xdir = ( x - moveScreenX- LarrysAngelWarfare.mouseState.X);

                        //finds the rise of the slope
                        bullet.slope = (y - moveScreenY- LarrysAngelWarfare.mouseState.Y);
                    
                  
                    //this will init the bullet making 
                    bullet.init(this.spriteBatch, this.Content);
                    //this will add the bullet to the obj list
                    ObjectsList.addBullet(bullet);
                    //dels the old bullet obj
                    bullet = null;
                }
            }



            //this will move the plaeyer right
            if (Keyboard.GetState().IsKeyDown(Keys.W))
            {
                //this will check if the player can move up
                rect.Y -= 8;
                //this will change the animation side for example this will show the right frame
                walkAnimationSide = 0;
                //this will check if i collide with the wall
                if (!ObjectsList.collision(this))
                {
                    //if i dont i move the player
                    
                    if (screenY >= -192+16) { screenY -= 8; } else { moveScreenY -= 8; }
                    
                    y -= 8;
                }
                //move back the rect
                rect.Y += 8;
            }
            //checks if the player can move down
            if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                //change the animation
                walkAnimationSide = 0;
                //moves the rect obj
                rect.Y += 8;
                
                if (!ObjectsList.collision(this))
                {
                    
                    if (screenY <= 192) { screenY += 8; } else { moveScreenY += 8; }
                    y += 8;

                }
                rect.Y -= 8;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                walkAnimationSide = 2;
                rect.X -= 8;
                if (!ObjectsList.collision(this)) {
                    if (screenX >= 200) { screenX -= 8; } else { moveScreenX -= 8; }
                    x -= 8;}
                rect.X += 8;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                walkAnimationSide = 1;
                rect.X += 8;
                if (!ObjectsList.collision(this))
                {
                    //this is used to move the screen when the player moves in a box
                    if (screenX <= 300) { screenX += 8; } else { moveScreenX += 8; }
                    x += 8;
                }
            }
            rect.X -=8;
        }

        public override Rectangle getRect()
        {
            return rect;
        }

        public override void setRect(Rectangle rect)
        {
            this.rect = rect;
        }

        public override void setRect(int x, int y)
        {
            rect.X = x;
            rect.Y = y;
        }
    }
    
    }

