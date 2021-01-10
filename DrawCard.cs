using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace Final_Project_Blackjack
{
    class DrawCard
    {
        public DrawCard()
        {
             
        }


        //static string[] cardTypes = { "club", "diamond", "heart", "spade" };

        //public static void DrawNewCard(string playerType)
        //{
        //    Image newCard = new Image();

        //    int cardNum = 0;
        //    int typeNum = 0;
        //    bool duplicate = false;

        //    Prevent from drawing duplicate card
        //    do
        //    {
        //        cardNum = MainPage.random.Next(1, 14);
        //        typeNum = MainPage.random.Next(4);

        //        if (MainPage.allTakenCards.Contains(typeNum + cardTypes[typeNum].ToString()))
        //        {
        //            duplicate = true;
        //        }

        //    } while (duplicate == true);

        //    string cardType = MainPage.cardTypes[typeNum];

        //    BitmapImage bitmapImage = new BitmapImage();
        //    bitmapImage.UriSource = new Uri("ms-appx:///Assets/" + cardType + cardNum + ".png");

        //    newCard.Source = bitmapImage;
        //    newCard.Width = 100;
        //    newCard.Height = 100;
        //    newCard.Name = cardType + cardNum.ToString();

        //    availableCards[cardNum - 1]--;

        //    if (cardNum > 10)
        //    {
        //        cardNum = 10;
        //    }

        //    if (playerType == "user")
        //    {
        //        user.TotalNumber = cardNum;
        //        user.PlayerHand.Add(cardType + cardNum);

        //        newCard.SetValue(Grid.RowProperty, 0);
        //        newCard.SetValue(Grid.ColumnProperty, user.PlayerHand.Count());

        //        Display newCard on the table
        //        GridUserHand.Children.Add(newCard);
        //    }

        //    else
        //    {
        //        computer.TotalNumber = cardNum;
        //        computer.PlayerHand.Add(cardType + cardNum);

        //        newCard.SetValue(Grid.RowProperty, 0);
        //        newCard.SetValue(Grid.ColumnProperty, computer.PlayerHand.Count());

        //        Display newCard on the table
        //        GridComputerHand.Children.Add(newCard);
        //    }

        //    allTakenCards.Add(cardType + cardNum.ToString());
    }
}
