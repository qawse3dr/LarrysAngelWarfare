using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace LarrysAngelWarfare
{
    class Blob : Objects
    {   //this is used for the hit boxs
        public Rectangle rect;
        //this is the pos of the emeny
        public int x;
        public int y;


        //this is used to draw the enemy
        public override void draw(SpriteBatch spriteBatch)
        {
          
                spriteBatch.Draw(image, new Vector2(x - Player.moveScreenX, y - Player.moveScreenY), new Color(light, light, light));
            } 
        //this returns the rect
        public override Rectangle getRect()
        {
            return rect;
        }
        //this returns the x
        public override int getx()
        {
            return x;
        }
        //returns the y
        public override int getY()
        {
            return y;
        }

        public override void init(SpriteBatch spriteBatch, ContentManager Content)
        {
            //this is be used to display the enemy
            image = Content.Load<Texture2D>("Blob");
            //this is the hitbox of the enemy
            rect = new Rectangle(x, y, 64, 64);
            //this is the health of the enemy
            this.health = 40;
            //this will be used for knockBack of the enemy
            this.knockBack = false;
            //this will be used for the y movement
            slope = 8;
            //this will make it no emit light
        }
        //set the rect
        public override void setRect(Rectangle rect)
        {
            this.rect = rect;
        }

        public override void setRect(int x, int y)
        {
            rect.X = x;
            rect.Y = y;
        }

        //set the x
        public override void setx(int x)
        {
            this.x = x;
        }
        //set the y
        public override void sety(int y)
        {
            this.y = y;
        }
        //runs every time update is called in the main program
        //this will handle any changes to the obj
        public override void update()
        {

            //resets the x and the y 
            rect.X = x;
            rect.Y = y;
            //checks if the player is dead
            if (health < 1)
            {
                kill = true;
            }
            //knocks back the enemy
            if (this.knockBack == true)
            {
                ObjectsList.knockBack(this);

            }

                //checks if the player is the same x as enemy and if so do nothing

                if (ObjectsList.playerx == x) ;
                //checks if its greater and if so try to go right
                else if (ObjectsList.playerx > x)
                {
                    //checks if i am going to hit a wall and if i dont move
                    rect.X += 2;
                    if (!ObjectsList.collision(this))
                    {
                        x += 2;
                    }
                    rect.X -= 2;
                }
                //trys to go left
                else
                {
                    //checks if I would hit a wall
                    rect.X -= 2;
                    if (!ObjectsList.collision(this))
                    {
                        x -= 2;
                    }
                    rect.X += 2;
                }
                //trys to move up or down and if i hit a wall change dirrects

                rect.Y += (int)slope;
                if (!ObjectsList.collision(this)) {
                    y += (int)slope; } else { slope *= -1; }


            }
        }
    }
