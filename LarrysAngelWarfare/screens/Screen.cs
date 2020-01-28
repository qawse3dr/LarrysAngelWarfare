using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LarrysAngelWarfare
{
    abstract class Screen
    {
        public virtual List<Button> optionList { get; set; }
        public virtual int optionsSpacing { get; set; }
        public virtual string title { get; set; }
        public  void draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Images.menuBackground, new Vector2(0, 0), Color.White);
            foreach (Button options in optionList)
            {
                spriteBatch.DrawString(LarrysAngelWarfare.font, options.text, new Vector2(options.x, options.y), Color.Red);


            }
        }
        public void update()
        {

            foreach(Option options in optionList)
            {
                if (options.rect.Intersects(new Rectangle(LarrysAngelWarfare.mouseState.X, LarrysAngelWarfare.mouseState.Y,1,1))
                    && LarrysAngelWarfare.mouseState.LeftButton == ButtonState.Pressed && LarrysAngelWarfare.mouseClicked == false)
                {
                    LarrysAngelWarfare.mouseClicked = true;
                        options.Clicked();
                }
            }
        }
        public void addButton(string OptionText, currentScreen changeScreen,int x,int y)
        {
            optionList.Add(new Button(OptionText, changeScreen,x,y));   
        }
    }
}
