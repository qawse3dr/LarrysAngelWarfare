using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace LarrysAngelWarfare
{   //this will add the object class
    class Wall : Objects
    {
        //the pos of the player
        private int x;
        private int y;
        
        //this will be the rect of the block
        public Rectangle rect = new Rectangle();

        public override void draw(SpriteBatch spriteBatch)
        {
          
            
  
                //this will draw the block
                spriteBatch.Draw(image, new Vector2(x - Player.moveScreenX, y - Player.moveScreenY), new Color(light, light, light));
            
        }

        public override int getx()
        {
            return x;
        }

        public override int getY()
        {
            return y;
        }

        public override void init(SpriteBatch spriteBatch, ContentManager Content)
        {
            //this will set the image and get the rect bounds
            image = Images.wall;
            rect = image.Bounds;
            //sets it to not emit light
            emitLight = false;

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
            //this will reset the x and y
            rect.X = x;
            rect.Y = y;
            
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
