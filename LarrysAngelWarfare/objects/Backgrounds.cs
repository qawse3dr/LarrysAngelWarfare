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
    class Backgrounds : Objects
    {
        //this will check were the rect is
        public Rectangle rect;
        //this will hold the x and y of him
        public int x;
        public int y;
        //this will hold what frame is on
        public byte frame=0;
        //this will hold what weather will show
        
        public byte frameTimer = 0;
        public override void draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(image, new Vector2(x-Player.moveScreenX, y-Player.moveScreenY), new Rectangle(64 * weather, 64 * frame, 64, 64),new Color(light,light,light));
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
            this.rect = new Rectangle(x, y, 64, 64);
            this.image = Content.Load<Texture2D>("weatherSpriteSheet");
            
        }

        public override void setRect(Rectangle rect)
        {
            this.rect = rect;
        }

        public override void setRect(int x, int y)
        {
            this.x = x;
            this.y = y;
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
            //this will change what frame it will be on.
            frameTimer++;
            if (frameTimer < 30)
            {
                frame = 0;
            }
            else if (frameTimer < 60)
            {
                frame = 1;
            }
            else if (frameTimer < 90)
            {
                frame = 2;
            }
            else
            {
                frameTimer = 0;
            }
        }
    }
}
