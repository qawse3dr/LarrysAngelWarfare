using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LarrysAngelWarfare
{
    class CreditScreen : Screen
    {
        public CreditScreen()
        {
            //this will keep track of where the obj x and why should be
            int xOfOption = 400;
            int yOfOption = 75;
            //this list will hold the options in the list
            optionList = new List<Button>();
            optionsSpacing = 400 / 5;
            addButton("Credits", currentScreen.credits, xOfOption, yOfOption);
            yOfOption += optionsSpacing;
            addButton("Back", currentScreen.startScreen, xOfOption, yOfOption);
        }
    }
}
