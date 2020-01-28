using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace LarrysAngelWarfare
{   //this will keep all of the obj
    class ObjectsList
    {   //This will be used to check if it is daytime or nighttime
        public static bool Light = true;
        //this will keep a static int of the player x and y
        public static int playerx = 0;
        public static int playery = 0;
        //this will keep a static list of the bullets and obj
        public static List<Objects> objList = new List<Objects>();
        public static List<Objects> bulletList = new List<Objects>();
        //this will hold all the objs that are light sources
        public static List<Objects> lightSources = new List<Objects>();
        //this will add objs to player
        public static void addObject(Objects obj) {
            //this will add the player at the back of the last the list so it displays it over the blocks and enemies
            if (obj is Player)
            {
                objList.Add(obj);
            }
            else if (obj is BackWallStone)
            {
                objList.Insert(0, obj);
            }
            else
            {
                //adds to the front so it blits behind the player
                if (objList.Count > 2)
                {
                    objList.Insert(objList.Count - 2, obj);
                }
                else
                {
                    objList.Add(obj);
                }}}
        //adds light sources to the list
        public static void addLight(Objects obj)
        {
            lightSources.Add(obj);
        }
        public static void removeLight(Objects obj)
        {
            lightSources.Remove(obj);
        }
        //adds bullets to the list
        public static void addBullet(Objects obj)
        {
            bulletList.Add(obj);
        }
        //removes obj from the list
        public static void removeObject(Objects obj)
        {
            objList.Remove(obj);
            obj = null;
        }
        //removes bullets
        public static void removeBullet(Objects obj)
        {
            bulletList.Remove(obj);
            obj = null;
        }
        //this will be used to check collision of the objs
        static public bool collision(Objects obj) {
            //set  colision to false
            bool collide = false;
            //do a for each loop tho the list of objects
            foreach (Objects objectsInList in objList)
            {
                //checks if they are intersects with the rect
                if (objectsInList.getRect().Intersects(obj.getRect()))
                {
                    //if the obj is player
                    if (obj is Player)
                    {
                        //if the object is wall collide == True
                        if (objectsInList is Wall)
                        {
                            collide = true;
                            break;
                        }
                        //this will check if its a demon or blob and if so collide = true
                        else if (objectsInList is Demon || objectsInList is Blob)
                        {
                            collide = true;
                          
                            
                        }
                        
                        //checks if its a fountain and if it is add health based on which on it is
                        else if (objectsInList is BloodFountianBig || objectsInList is BloodFountianSmall)
                        {
                            //add health to the player
                            obj.health += objectsInList.health;
                            //sets health to zero
                            objectsInList.health = 0;
                            //kill the obj
                            objectsInList.kill = true;
                            //checks if the player health is over 100 and if it is set it too 100
                            if (obj.health > 100)
                            {
                                obj.health = 100;
                            }}}
                    //checks if the obj is a demon
                    if (obj is Demon)
                    {
                        //check if it hitting a wall or if its hitting another demon and if so collide = true
                        if (objectsInList is Wall || objectsInList is Blob || objectsInList is Demon && obj != objectsInList)
                        {
                            collide = true;
                            break;
                        }
                        //check if it hits player
                        if (objectsInList is Player)
                        {
                            //sets knock back to be true and collide to true and  -= health
                            obj.knockBack = true;
                            collide = true;
                            objectsInList.health -= 5;
                        }}
                    if (obj is Blob)
                    {
                        if (objectsInList is Wall || objectsInList is Demon || objectsInList is Blob && obj != objectsInList)
                        {
                            collide = true;
                            break;
                        }
                        if (objectsInList is Player)
                        {
                            obj.knockBack = true;
                            collide = true;
                            objectsInList.health -= 10;
                        }}
                    //checks if its bullets
                    if (obj is Bullets)
                    {   //if it is a wall just break and kill the bullet
                        if (objectsInList is Wall)
                        {
                            collide = true;
                            obj.kill = true;
                        }
                        // if its a demon do dmg to him and set knock back to true
                        if (objectsInList is Demon || objectsInList is Blob)
                        {
                            collide = true;
                            objectsInList.knockBack = true;
                            objectsInList.health -= 5;
                        }}}}
            //return collide
            return collide;
        }
        //this will draw all of the images
        public static void draw(SpriteBatch spriteBatch)
        {
            //goes tho all of the obj in the list and calls the draw function
            foreach (Objects objectsInList in objList)
            {
                if (showImage(objectsInList.getx(), objectsInList.getY()))
                {
                    //This will get the light and see if there should be some
                    if (Light == true)
                    {
                        objectsInList.light = getLight(objectsInList.getx(), objectsInList.getY());
                    }
                    else
                    {
                        objectsInList.light = 256;
                    }
                    objectsInList.draw(spriteBatch);
                }}
            //goes tho all the bullets and draw the bullets
            foreach (Objects objectsInList in bulletList)
            {
                if (Light == true)
                {
                    objectsInList.light = getLight(objectsInList.getx(), objectsInList.getY());
                }
                else
                {
                    objectsInList.light = 256;
                }
                objectsInList.draw(spriteBatch);
            }}
        //This will check if the if the image show be drawn
        private static Rectangle showImageRect = new Rectangle(0, 0, 64, 64);
        private static Rectangle screenRect = new Rectangle(-128, -128, 850+128, 600+128);
        public static bool showImage(int objX, int objY)
        {
            showImageRect.X = objX - Player.moveScreenX;
            showImageRect.Y = objY - Player.moveScreenY;
            return screenRect.Intersects(showImageRect);
        }
        //this will find the what the light source should be
        public static int getLight(int objX, int objY)
        {
            //this will make the var used to find how strong the light is
            int light = 0;
            int tempLight = 0;
            //this will will run with through the sources
            foreach (Objects sources in lightSources)
            {
                //this will check if the sources are on the screen
                if (showImage(sources.getx(), sources.getY()) && sources.emitLight == true )
                {
                    //This finds the light
                    tempLight = Math.Abs((int)(Math.Pow(Math.Pow((sources.getx() - objX), 2.0) + (Math.Pow((sources.getY() - objY), 2.0)), 0.5)));
                    //this checks if a new light sources are closer
                    //this is for checking if its closer
                    if (tempLight < 256)
                    {
                        //This will find how light an objs should be   
                        if (tempLight < 128)
                        {
                            tempLight = 255;
                        }
                        else if (tempLight < 200)
                        {
                            tempLight = 200;
                        }
                        else
                        {
                            tempLight = 150;
                        }}
                    //this will tint all other objects black
                    else
                    {
                        tempLight = 0;
                    }
                    if (tempLight > light && tempLight < 256)
                    {
                        light = tempLight;
                    }}}
            //this returns the light
            return light;}
        //this will call all the update function of the objects
        public static void update()
        {
            //this will keep track of all the bullets
            Objects killBullet = null;
            Objects killEnemy = null;
            //goes tho all the objects and update them
            foreach (Objects objectsInList in objList)
            {
                if (showImage(objectsInList.getx(), objectsInList.getY())){
                    objectsInList.update();
                    //if they wanna die kill them
                    if (objectsInList.kill == true)
                    {
                        killEnemy = objectsInList;
                    }}}
            //goes tho all the bullets
            foreach (Objects objectsInList in bulletList)
            {
                objectsInList.update();
                //if they wanna die kill them
                if (objectsInList.kill == true)
                {
                    killBullet = objectsInList;
                }}
            // if killBullet isnt empty end them
            if (killBullet != null)
            {
                removeBullet(killBullet);
                killBullet = null;
            }
            if (killEnemy != null)
            {
                removeObject(killEnemy);
                killEnemy = null;
            }}
        /*
         * 
         * TODO make knock back done by refrance to the obj that it collided with not player.
         * 
         * 
         * 
         * */
        //This will be used to achive knockback for players enemies or anything else
        public static void knockBack(Objects obj)
        {
            int knockBackdirX = 0;
            int knockBackdirY = 0;
                //set knock back to false
                obj.knockBack = false;
            //checks if the player x and obj x are the same do nothing
            if (playerx == obj.getx()) ;
            //knock them the back 
            else if (playerx > obj.getx()) knockBackdirX = -32;
            else knockBackdirX = 32;
            //knock them back to make sure that it doesnt go through a wall
            obj.setRect(obj.getRect().X + knockBackdirX, obj.getRect().Y);
            if (!collision(obj))
                        {
                            obj.setx(obj.getx()+knockBackdirX);
                        }
            obj.setRect(obj.getRect().X - knockBackdirX, obj.getRect().Y);


            if (playery == obj.getY());
            else if (playery > obj.getY()) knockBackdirY = 32;
            else knockBackdirY = -32;
            //knock them back 
                obj.setRect(obj.getRect().X , obj.getRect().Y+ knockBackdirY);
                        if (!collision(obj))
                            obj.sety(obj.getY() + knockBackdirY);
            
        }
                    
                   

                
                

            

           
            }
        

    } 

