using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LarrysAngelWarfare
{
    class Slider : Option
    {
        public int max;
        public int min;
        public int current;
        public int length;
        
        public Slider(int x, int y,int max , int length,int current,string Title)
        {
            this.x = x;
            this.y = y;
            min = 0;
            this.max = max;
            this.length = length;
            this.current = current;
            this.Title = Title;

        }
        public override void Clicked()
        {
            current = (int)(LarrysAngelWarfare.mouseState.X - this.x/ this.length);

        }

        
    }
}
