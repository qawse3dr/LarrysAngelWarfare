using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LarrysAngelWarfare
{
    abstract class Option
    {
        public abstract void Clicked();
        public virtual int x { set; get; }
        public virtual int y { set; get; }
        public virtual string Title { set; get; }
        public virtual Rectangle rect { set; get; }
        

}
}
