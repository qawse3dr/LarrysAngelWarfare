
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LarrysAngelWarfare 
{
    class helpScreen: Screen
    {
        public helpScreen()
        {
            //this will keep track of where the obj x and why should be
            int xOfOption = 400;
            int yOfOption = 75;
            //this list will hold the options in the list
            optionList = new List<Button>();
            optionsSpacing = 400 / 5;
            addButton("Help", currentScreen.help, xOfOption, yOfOption);
            yOfOption += optionsSpacing;
            addButton("Movement (Arrow Keys or WASD)", currentScreen.help, xOfOption, yOfOption);
            yOfOption += optionsSpacing;
            addButton("shooting (Mouse(left click))", currentScreen.help, xOfOption, yOfOption);
            yOfOption += optionsSpacing;
            addButton("Pause Menu Esc", currentScreen.help, xOfOption, yOfOption);
            yOfOption += optionsSpacing;
            addButton("Back", currentScreen.startScreen, xOfOption, yOfOption);
        }
    }
}
