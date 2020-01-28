using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LarrysAngelWarfare
{
    class menuScreen : Screen
    {
        
        //this will be called when the obj is created
        public menuScreen()
        {
            //this will keep track of where the obj x and why should be
            int xOfOption = 400;
            int yOfOption = 100;
            //this list will hold the options in the list
            optionList = new List<Button>();
            optionsSpacing = 400 / 5;
            addButton("Play", currentScreen.loadScreen,xOfOption,yOfOption);
            yOfOption += optionsSpacing;
            addButton("Options", currentScreen.options, xOfOption, yOfOption);
            yOfOption += optionsSpacing;
            addButton("Help", currentScreen.help, xOfOption, yOfOption);
            yOfOption += optionsSpacing;
            addButton("Credits", currentScreen.credits, xOfOption, yOfOption);
            yOfOption += optionsSpacing;
            addButton("Exit", currentScreen.exit, xOfOption, yOfOption);
            
           

        }
        
    }
}
