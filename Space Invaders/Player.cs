using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Invaders
{
    class Player
    {
        private int pts;
        private enum KeyState { Right, Left, None };
        private int numOfLives;
        private bool isDead;

        public Player(int numOfLives)
        {
            this.pts = 0;
            this.numOfLives = numOfLives;
        }

        public void CheckDeath()
        {
            if (this.numOfLives == 0)
                this.isDead = true;
            else
                this.isDead = false; 
        }
    }
}
