using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace LarrysAngelWarfare
{   //adds object to make displaying and going tho obj easier
    class BloodFountianBig : Objects
    {   //this will be teh pos of the obj
        private int x;
        private int y;
        private Rectangle rect;
        //this will draw the obj
        public override void draw(SpriteBatch spriteBatch)
        {

            spriteBatch.Draw(image, new Vector2(this.x - Player.moveScreenX, this.y - Player.moveScreenY), new Color(light,light,light));
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

        public override void init(SpriteBatch spriteBatch, ContentManager Content)
        {   //this will set the image of the obj
            image = Images.BloodFountainBig;
            //set the rect
            rect = new Rectangle(x, y, 32, 32);
            //set the health they regain
            health = 75;
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

        public override void update()
        {   //resets the x and y
            this.rect.X = x;
            this.rect.Y = y;
        }
    }
}
