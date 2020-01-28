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
    
    /// <summary>
    /// This will create and manage the bullets
    /// </summary>
    //adds object to make thing easier 
    class Bullets : Objects
    {
        //this will set the pos of the obj
        public double x = 0;
        public double y = 0;
        //this will be how fast it moves
        private double movementx = 0;
        //this will be the y int of the bullet bc i use a linear equation to find the x an y
        public double yInt = 0;
        //the rect of the obj
        private Rectangle rect;



        
        /// <summary>
        /// Draw the image of the bullet
        /// </summary>
        /// <param name="spriteBatch"></param>
        public override void draw(SpriteBatch spriteBatch)
        {
            
            spriteBatch.Draw(image, new Vector2((int)x - Player.moveScreenX, (int)y - Player.moveScreenY), new Color(light,light,light));
        }
        
        public override Rectangle getRect()
        {
            return rect;
        }

        public override int getx()
        {
            return (int)x;
        }

        public override int getY()
        {
            return (int)y;
        }
        /// <summary>
        /// this will be used when creating a bullet
        /// </summary>
        /// <param name="spriteBatch"></param>
        /// <param name="Content"></param>
        public override void init(SpriteBatch spriteBatch, ContentManager Content)
        {
                //sets the bullets
            this.image = Images.Bullet;
            this.startX = this.x;
            this.yInt =this.y;
            //uses a try bc if it has zero it will crash
            try
            {
                //this will see if it the movementx
                this.movementx = moveX * Math.Abs(((16.0 * (double)xdir) / (double)slope));
                //make sure the bullet isnt really big
                if (this.movementx > 16 || this.movementx < -16){
                    this.movementx = 16 * moveX;
                }
            }catch
            {
                //if it crashes  just set it to 16
                this.movementx = 16* moveX;
            }
            if (movementx == 0)
            {
                movementx = 16 * moveX;
            }
            //sets the rect
            this.rect = new Rectangle((int)x, (int)y, 8, 8);
            //sets it to emit light
            emitLight = true;
        }

        public override void setRect(Rectangle rect)
        {
            this.rect = rect;
        }

        public override void setx(int x)
        {
            this.x = x;
        }

        public override void sety(int y)
        {
            this.y = y;
        }

        public override void update()
        {
            //adds the x
            this.x += movementx;
            //this will find the new y
            this.y = (double)(((((double)slope)/((double)xdir))) * (this.x - this.startX) + this.yInt);
            this.rect.Y = (int)y;
            this.rect.X = (int)x;
            //this will kill the bullet after being in the air for so long
            if (x - startX > 1000 || x - startX < -1000)
            {
                this.kill = true;
            }
            //if it collides kill it
            if (ObjectsList.collision(this))
            {
                this.kill = true;
            }


        }

        public override void setRect(int x, int y)
        {
            rect.X = x;
            rect.Y = y;
        }
    }
}
