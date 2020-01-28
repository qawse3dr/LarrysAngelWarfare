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
    //This will be used as the background of the game
    class BackWallStone : Objects
    {
        //this will be the rect that is used for hit which it will never hit
        private Rectangle rect = new Rectangle(0,0,64,64);
        private int x;
        private int y;


        public override void draw(SpriteBatch spriteBatch)
        {
            
          
                //This will draw the block
                spriteBatch.Draw(image, new Vector2(x - Player.moveScreenX, y - Player.moveScreenY), new Color(light, light, light));
            
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
        {
            
            this.image = Images.darkWall;
            //sets it to not emit light
            emitLight = false;
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
            rect.X = this.x;
            rect.Y = this.y;
        }
    }
}
