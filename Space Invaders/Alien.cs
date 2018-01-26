using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Invaders
{
    class Alien
    {
        private float xPos;
        private float yPos;
        private int ptsWorth;
        private bool state; //true - movment state 1, false - movment state 2
        private bool isDead;

        public Alien(float xPos, float yPos, int ptsWorth, bool state, bool isDead)
        {
            this.xPos = xPos;
            this.yPos = yPos;
            this.ptsWorth = ptsWorth;
            this.state = state;
            this.isDead = isDead;
        }
    }
}
