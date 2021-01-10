using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project_Blackjack.Assets
{
    class Player
    {
        private int totalNumber;
        private List<string> playerHand = new List<string>();

        public int TotalNumber
        {
            get
            {
                return totalNumber;
            }

            set
            {
                //if totalNumber receives 0, reset totalNumber to 0
                if (value == 0)
                {
                    this.totalNumber = 0;
                }

                else
                {
                    this.totalNumber += value;
                }
                
            }
        }

        public List<string> PlayerHand
        {
            get {
                return playerHand;
            }
            set {
                this.playerHand.Add(value.ToString());
            }
        }

    }
}
