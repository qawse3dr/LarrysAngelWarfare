using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace LarrysAngelWarfare
{
    class Button : Option
    {
        public string text;
        public currentScreen changeScreen;
        /// <summary>
        /// for basic options that are just clicks
        /// </summary>
        /// <param name="text"></param>
        /// <param name="changeScreen"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public Button(string text, currentScreen changeScreen,int x,int y)
        {
            this.text = text;
            this.changeScreen = changeScreen;
            this.x = x;
            this.y = y;
            Vector2 stringXAndY = LarrysAngelWarfare.font.MeasureString(text);
            this.x -= (int)stringXAndY.X / 2;
            rect = new Rectangle(this.x, this.y, (int)stringXAndY.X, (int)stringXAndY.Y);   
        }
        public override void Clicked()
        {   
            LarrysAngelWarfare.currentScreen = changeScreen;
        }
    }
}