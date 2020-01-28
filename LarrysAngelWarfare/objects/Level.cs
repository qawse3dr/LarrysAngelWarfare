using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;

namespace LarrysAngelWarfare
{
    //this class will be used to create the level
    class Level
    {
        
        //this will hold the map image
        private Texture2D image;
        //this will hold the mapColour (an array of all the colours)
        public Color[] MapColours;
        //this will load the level in 
        public void load(string levelImg,SpriteBatch spriteBatch, ContentManager Content)
        {
            //this will find the map image
           image = Content.Load<Texture2D>(levelImg);
            //this will make a colour array 
            MapColours = new Color[image.Width * image.Height];
            //get all the data for the image
            image.GetData<Color>(MapColours);


            //shift 2 to the right so i lines up the colours correctly
            int coloumCounter = -2;
            int rowCounter = 0;
            //do a foreach loop of all the colours in the colour map
            foreach (Color colour in MapColours) { 
                //adds one the colour
                coloumCounter += 1;
                //this will change rows
                if (coloumCounter == image.Width -1)
            {
                    rowCounter += 1;
                    coloumCounter = -1;
            }

                if (colour == new Color(0, 0, 0))
                {
                    //this will add a background dungeon
                    Objects background = new BackWallStone();
                    background.sety(rowCounter * 64);
                    background.setx(coloumCounter * 64);
                    background.init(spriteBatch, Content);
                    ObjectsList.addObject(background);
                    background = null;
                }
                //this will check the colour of the obj and based on it add a wall
                else if (colour == new Color(255, 94, 139))
                        {
                            Objects wall = new Wall();
                            wall.sety(rowCounter * 64);
                            wall.setx(coloumCounter * 64);
                            wall.init(spriteBatch,Content);
                            ObjectsList.addObject(wall);
                            wall = null;
                        }
                else if (colour == new Color(77, 77, 77))
                {
                    Objects torch = new Torch();
                    torch.sety(rowCounter * 64);
                    torch.setx(coloumCounter * 64);
                    torch.init(spriteBatch, Content);
                    ObjectsList.addObject(torch);
                    ObjectsList.addLight(torch);
                    torch = null;
                    //this will add a background dungeon
                    Objects background = new BackWallStone();
                    background.sety(rowCounter * 64);
                    background.setx(coloumCounter * 64);
                    background.init(spriteBatch, Content);
                    ObjectsList.addObject(background);
                    background = null;
                }
                //this will check the colour of the obj and based on it add a player
                else if (colour == new Color(94, 94, 255))
                        {
                            Objects player = new Player();
                    ObjectsList.addLight(player);
                        player.sety(rowCounter * 64);
                        player.setx(coloumCounter * 64);
                        player.init(spriteBatch, Content);
                            
                        ObjectsList.addObject(player);
                        player = null;
                    //this will add a background dungeon
                    Objects background = new BackWallStone();
                    background.sety(rowCounter * 64);
                    background.setx(coloumCounter * 64);
                    background.init(spriteBatch, Content);
                    ObjectsList.addObject(background);
                    background = null;
                }
                //this will check the colour of the obj and based on it add a demon
                else if (colour == new Color(140, 0, 0))
                {
                    Objects demon = new Demon();
                    demon.sety(rowCounter * 64);
                    demon.setx(coloumCounter * 64);
                    demon.init(spriteBatch, Content);
                    ObjectsList.addObject(demon);
                    demon = null;
                    //this will add a background dungeon
                    Objects background = new BackWallStone();
                    background.sety(rowCounter * 64);
                    background.setx(coloumCounter * 64);
                    background.init(spriteBatch, Content);
                    ObjectsList.addObject(background);
                    background = null;
                }
                //this will check the colour of the obj and based on it add a bloodFountain
                else if (colour == new Color(127, 255, 197))
                {
                    Objects bloodFountain = new BloodFountianSmall();
                    bloodFountain.sety(rowCounter * 64);
                    bloodFountain.setx(coloumCounter * 64);
                    bloodFountain.init(spriteBatch, Content);
                    ObjectsList.addObject(bloodFountain);
                    //do this to save memory
                    bloodFountain = null;
                    //this will add a background dungeon
                    Objects background = new BackWallStone();
                    background.sety(rowCounter * 64);
                    background.setx(coloumCounter * 64);
                    background.init(spriteBatch, Content);
                    ObjectsList.addObject(background);
                    background = null;

                }
                //this will check the colour of the obj and based on it add a bloodfountain
                else if (colour == new Color(255, 255, 255))
                {
                    Objects bloodFountain = new BloodFountianBig();
                    bloodFountain.sety(rowCounter * 64);
                    bloodFountain.setx(coloumCounter * 64);
                    bloodFountain.init(spriteBatch, Content);
                    ObjectsList.addObject(bloodFountain);
                    bloodFountain = null;
                    //this will add a background dungeon
                    Objects background = new BackWallStone();
                    background.sety(rowCounter * 64);
                    background.setx(coloumCounter * 64);
                    background.init(spriteBatch, Content);
                    ObjectsList.addObject(background);
                    background = null;
                }
                //this will check the colour of the obj and based on it add a wall dark
                else if (colour == new Color(44, 44, 44))
                {
                    Objects wall = new Wall();
                    wall.sety(rowCounter * 64);
                    wall.setx(coloumCounter * 64);
                    wall.init(spriteBatch, Content);
                    wall.image = Images.darkWall;
                    ObjectsList.addObject(wall);
                    wall = null;
                }
                else if (colour == new Color(6, 12, 33))
                //this will check the colour of the obj and based on it add a wall blood
                {
                    Objects wall = new Wall();
                    wall.sety(rowCounter * 64);
                    wall.setx(coloumCounter * 64);
                    wall.init(spriteBatch, Content);
                    wall.image = Images.stoneWall;
                    ObjectsList.addObject(wall);
                    wall = null;
                }
                //this will be for the blob enemy
                else if (colour == new Color(126, 32, 44))
                {
                    Objects blob = new Blob();
                    blob.sety(rowCounter * 64);
                    blob.setx(coloumCounter * 64);
                    blob.init(spriteBatch, Content);
                    
                    ObjectsList.addObject(blob);
                    blob = null;
                    //this will add a background dungeon
                    Objects background = new BackWallStone();
                    background.sety(rowCounter * 64);
                    background.setx(coloumCounter * 64);
                    background.init(spriteBatch, Content);
                    ObjectsList.addObject(background);
                    background = null;
                }
                //this will be used for water
                else if (colour == new Color(0, 38, 255))
                {
                    Objects background = new Backgrounds();
                    background.sety(rowCounter * 64);
                    background.setx(coloumCounter * 64);
                    background.init(spriteBatch, Content);
                    ObjectsList.addObject(background);
                    background.weather = 2;

                    background = null;
                
                }
                //this is rain
                else if (colour == new Color(64, 64, 64))
                {
                    Objects background = new Backgrounds();
                    background.sety(rowCounter * 64);
                    background.setx(coloumCounter * 64);
                    background.init(spriteBatch, Content);
                    ObjectsList.addObject(background);
                    background.weather = 0;
                    background = null;
                    

                }
                //this will be used for snow
                else if (colour == new Color(128, 128, 128))
                {
                    Objects background = new Backgrounds();
                    background.sety(rowCounter * 64);
                    background.setx(coloumCounter * 64);
                    background.init(spriteBatch, Content);
                    ObjectsList.addObject(background);
                    background.weather = 1;
                    background = null;
                    

                }
                //this will be used for the night sky
                else if (colour == new Color(0, 255, 255))
                {
                    Objects background = new Backgrounds();
                    background.sety(rowCounter * 64);
                    background.setx(coloumCounter * 64);
                    background.init(spriteBatch, Content);
                    ObjectsList.addObject(background);
                    background.weather = 3;
                    background = null;
                    

                }
                //this will be used for the night stars
                else if (colour == new Color(244, 244, 244))
                {
                    Objects background = new Backgrounds();
                    background.sety(rowCounter * 64);
                    background.setx(coloumCounter * 64);
                    background.init(spriteBatch, Content);
                    ObjectsList.addObject(background);
                    background.weather = 4;
                    background = null;
                    

                }
                //this will be used to spawn player with water background
                else if (colour == new Color(81, 38, 255))
                {
                    
                    Objects background = new Backgrounds();
                    background.sety(rowCounter * 64);
                    background.setx(coloumCounter * 64);
                    background.init(spriteBatch, Content);
                    ObjectsList.addObject(background);
                    background.weather = 2;
                    background = null;
                    
                    Objects player = new Player();
                    ObjectsList.addLight(player);
                    player.sety(rowCounter * 64);
                    player.setx(coloumCounter * 64);
                    player.init(spriteBatch, Content);

                    ObjectsList.addObject(player);
                    player = null;


                }
            }
                }

            }
        }


        
    

