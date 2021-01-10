using Final_Project_Blackjack.Assets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;
using static System.Net.Mime.MediaTypeNames;

namespace Final_Project_Blackjack
{
    class ComputerCalculate
    {
        public ComputerCalculate()
        {

        }

        //Calculate chance of drawing card for computer
        public static bool ComputerDrawOrStop(Player computer, int userTotalNumber)
        {
            bool draw = true;

            int possibleHighestNum = 21 - computer.TotalNumber;

            int possibleCardsToDraw = 0;

            if (possibleHighestNum > 12)
            {
                return draw;
            }


            for (int i = 0; i < possibleHighestNum; i++)
            {              
                possibleCardsToDraw += MainPage.availableCards[i];
            }

            string sum = "";
            foreach (int each in MainPage.availableCards)
            {
                sum = sum + " " + each.ToString();
            }

            double chanceOfDrawing = (possibleCardsToDraw * 100) / (52 - MainPage.allTakenCards.Count());

            int chanceOfDrawingPercentage = (int)Math.Ceiling(chanceOfDrawing);

            int hunredPercentage = MainPage.random.Next(1, 101);

            //although chance of drawing a card without over 21 is 20%, try to draw card since Computer's hand is lower than User's hand
            if (chanceOfDrawingPercentage > 20 && computer.TotalNumber < userTotalNumber)
            {
                draw = true;
                return draw;
            }

            if (chanceOfDrawingPercentage < hunredPercentage)
            {
                draw = false;
                return draw;
            }

            return draw;
        }
    }
}
