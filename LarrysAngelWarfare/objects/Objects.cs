using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace LarrysAngelWarfare
{//this will be what holds all the functions for a basic obj
    abstract class  Objects {
        //this will be used for the background to check the background image that should be shown
        public virtual int weather { get; set; }
        //this will be used for lighting
        public virtual int light { get; set; }
        //this will let me know if they emit light
        public virtual bool emitLight { get; set; }
        //this will be the image
        public virtual Texture2D image { get; set; }
        //this will be the health of the obj
        public virtual int health { get; set; }
        //this will be a knockBack bool
        public virtual bool knockBack { get; set; }
        //this will be the speed of bullets
        public virtual double moveX { get; set; }
        //this will be the slope of the bullets
        public virtual double slope { get; set; }
        //this will be the run of the bullets
        public virtual int xdir { get; set; }
        //this will be used to know if the obj want to die
        public virtual bool kill { get; set; }
        //this will be where the bullets start
        public virtual double startX { get; set; }
        //this function will draw the image
        public abstract void draw(SpriteBatch spriteBatch);
        //this will do everything i need when creating an obj
        public abstract void init(SpriteBatch spriteBatch, ContentManager Content);
        //this will do anything i need to do to update the obj
        public abstract void update();
        //get x
        public abstract int getx();
        //set x
        public abstract void setx(int x);
        //this will get the y
        public abstract int getY();
        //this will set the y
        public abstract void sety(int y);
        //this will get the rect
        public abstract Rectangle getRect();
        //this will set the rect
        public abstract void setRect(Rectangle rect);
        public abstract void setRect(int x, int y);
     }}
