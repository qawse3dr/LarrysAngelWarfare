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
    //this will add obj to make stuff easier
    class Demon : Objects
    {   //sets the pos of the obj
        public int x;
        public int y;
        //this will set the rect of the obj.
        public Rectangle rect = new Rectangle();
        //these will be used for the walk animation
        private byte walkingTimer = 0;
        private byte walkAnimation = 0;
        private byte walkAnimationSide = 0;
        //this will draw the image
        public override void draw(SpriteBatch spriteBatch)
        {
            
         
            spriteBatch.Draw(image, new Vector2(x - Player.moveScreenX, y - Player.moveScreenY), new Rectangle(64 * walkAnimation + walkAnimation + 1, 64 * walkAnimationSide + walkAnimationSide + 1, 64, 64), new Color(light, light, light));
        } 
        public override Rectangle getRect()
        {
            return rect;
        }
        public override int getx()
        {
            return x;
        }
        public override int getY()
        {
            return y;
        }
        /// <summary>
        /// this will be called when a obj will be created
        /// </summary>
        /// <param name="spriteBatch"></param>
        /// <param name="Content"></param>
        public override void init(SpriteBatch spriteBatch, ContentManager Content)
        {   //this will create the rect
            this.rect = new Rectangle(x, y, 64, 64);
            //this will set the image
            image = Images.DemonSpriteSheet;
            //this will be the health of the player
            this.health = 20;
            this.knockBack = false;
            //sets it to emit light
            emitLight = true;
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

        public override void setx(int x)
        {
            this.x = x;
        }
        public override void sety(int y)
        {
            this.y = y;
        }
        /// <summary>
        /// this will be called for ever tick
        /// </summary>
        public override void update()
        {
            //resets the x and y
            rect.X = x;
            rect.Y = y;
            //add one to the walktimer
            walkingTimer++;
            //this will find what sprite they are on
            if (walkingTimer < 15)
            {
                walkAnimation = 0;
            }
            else
            {
                walkAnimation = 1;
                if (walkingTimer >= 30)
                {
                    walkingTimer = 0;
                }}
            //this will only move if its near the player
            if (x - 600 < ObjectsList.playerx && x + 600 > ObjectsList.playerx && y - 300 < ObjectsList.playerx && y + 300 > ObjectsList.playery)
                if (x != ObjectsList.playerx) {
                    if (x > ObjectsList.playerx)
                    {
                        // this will move the rect and see if the can move
                        rect.X -= 8;
                        walkAnimationSide = 2;
                        if (!ObjectsList.collision(this))
                        {
                            x -= 8;
                        }
                        rect.X += 8;
                    }
                    else
                    {// this will move the rect and see if the can move
                        rect.X += 8;
                        walkAnimationSide = 1;
                        if (!ObjectsList.collision(this))
                        {
                            x += 8;
                        }
                        rect.X -= 8;
                    }
                }// this will move the rect and see if the can move
            if (y != ObjectsList.playery)
                    if (y< ObjectsList.playery)
                {        
                        walkAnimationSide = 0;
                        rect.Y += 8;
                        if (!ObjectsList.collision(this))
                        {
                            y += 8;
                        }
                        rect.Y -= 8;
                }// this will move the rect and see if the can move
                else
                {
                        rect.Y -= 8;
                        walkAnimationSide = 0;
                        if (!ObjectsList.collision(this))
                        {
                            y -= 8;
                        }
                        rect.Y += 8;
                }    
            if (health < 1)
            {
                //this will check if they are dead and if kill them if they are dead
                this.kill = true;
            }
            //do knock back if its true
            if (this.knockBack == true)
            {
                ObjectsList.knockBack(this);
                
                    }}}}
            
    

