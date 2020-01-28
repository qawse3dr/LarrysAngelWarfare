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
    //this i will make using obj easier
    class BloodFountianSmall : Objects
    {   //this will set the x and y
        private int x;
        private int y;
        //this is the rect of the obj
        private Rectangle rect;
        /// <summary>
        /// this will display the image of the fountain
        /// </summary>
        /// <param name="spriteBatch"></param>
        public override void draw(SpriteBatch spriteBatch)
        {
       
            spriteBatch.Draw(image,new Vector2(this.x - Player.moveScreenX, this.y - Player.moveScreenY),new Color(light,light,light));
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
        /// this will set all the info about the fountain
        /// </summary>
        /// <param name="spriteBatch"></param>
        /// <param name="Content"></param>
        public override void init(SpriteBatch spriteBatch, ContentManager Content)
        {
            //sets the image and rect
            image = Images.BloodFountainSmall;
            rect = new Rectangle(x, y, 64, 64);
            //this will be how much health it regains
            health = 25;

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
        {
            this.rect.X = x;
            this.rect.Y = y;
             
            
        }
    }
}
