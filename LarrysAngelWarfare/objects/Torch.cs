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
    
    class Torch : Objects
    {
        private int x;
        private int y;
        public Rectangle rect= new Rectangle();
        public override void draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(image,new Vector2(x - Player.moveScreenX, y - Player.moveScreenY), Color.White);
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
            this.image = Images.Torch;
            this.rect = new Rectangle(x, y, 64, 64);
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
            this.rect.X = x;
            this.rect.Y = y;
        }

        public override void setRect(int x, int y)
        {
            rect.X = x;
            rect.Y = y;
        }
    }
}
