using Final_Project_Blackjack.Assets;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Final_Project_Blackjack
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            Windows.UI.ViewManagement.ApplicationView.PreferredLaunchWindowingMode = Windows.UI.ViewManagement.ApplicationViewWindowingMode.FullScreen;
        }

        static Player user = new Player();
        static Player computer = new Player();

        static string[] cardTypes = { "club", "diamond", "heart", "spade" };

        public static List<string> allTakenCards = new List<string>();

        public static List<int> availableCards = new List<int> { 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4 };

        public static Random random = new Random();

        string playerType = "";

        bool IsUserStopped = false;
        bool IsComputerStopped = false;
        bool IsTestModeOn = false;

        private async void Exit_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new MessageDialog("Do you want to quit?");
            dialog.Commands.Add(new UICommand { Label = "Yes" });
            dialog.Commands.Add(new UICommand { Label = "No" });

            var result = await dialog.ShowAsync();

            //Close this game if User wants to quit
            if (result.Label == "Yes")
            {
                Application.Current.Exit();
            }
            
        }

        private async void Question_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new MessageDialog("Rules" + "\n" + "1. Whoever has a total card number closer to 21 wins" +
                                            "\n" + "2. If player's hand exceeds more than 21, the player loses" +
                                            "\n" + "3. Each player can draw one card in their turn, but they can stop drawing" +
                                            "\n" + "4. If player decides to stop drawing cards, he/she can't not draw anymore" +
                                            "\n" + "5. If every player stops drawing, compare each other's hand and whoever has the highest total number wins" +                                            
                                            "\n" + "6. Cards with symbol B, A, K are considered as 10");
            dialog.Commands.Add(new UICommand { Label = "Yes" });

            await dialog.ShowAsync();
        }

        private void TestMode_Click(object sender, RoutedEventArgs e)
        {
            //Reset game whenver there is mode switch
            ResetGame();

            string btnTestModeText = this.btnTestMode.Content.ToString();
            string testMode_On = "Enter Test Mode(Show computer's hand)";
            string testMode_OFf = "Exit Test Mode";

            if (btnTestModeText == testMode_On)
            {
                this.btnTestMode.Content = testMode_OFf;
                IsTestModeOn = true;
            }

            else
            {
                this.btnTestMode.Content = testMode_On;
                IsTestModeOn = false;
            }

            
                
        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            //each player draws two cards
            GenerateNewCard("user");
            GenerateNewCard("user");
            GenerateNewCard("computer");
            GenerateNewCard("computer");

            btnDraw.IsEnabled = true;

            //hide btnStart button
            btnStart.Visibility = Visibility.Collapsed;

            //show btnDraw and btnStop buttons
            btnDraw.Visibility = Visibility.Visible;
            btnStop.Visibility = Visibility.Visible;
        }

        private async void Draw_Click(object sender, RoutedEventArgs e)
        {
            playerType = "user";

            GenerateNewCard(playerType);

            await Task.Delay(500);

            //Check if user's hand is over 21
            if (user.TotalNumber > 21)
            {
                var dialog = new MessageDialog("You lost." + "\n" + "Your Total Number: " + user.TotalNumber.ToString() + "\n" + "Computer's Total Number: " + computer.TotalNumber.ToString());
                dialog.Commands.Add(new UICommand { Label = "Restart" });

                RevealComputerHand();

                var result = await dialog.ShowAsync();

                if (result.Label == "Restart")
                {
                    ResetGame();
                }

            }

            else
            {
                //if Computer decides to continue drawing
                if (IsComputerStopped == false)
                {
                    //pass turn to computer
                    Computer_Turn();
                }
                
            }

        }

        private void GenerateNewCard(string playerType)
        {
            //Create newCard Object to show drawn card
            Image newCard = new Image();

            int cardNum = 0;
            int typeNum = 0;
            bool duplicate = false;

            //Prevent from drawing duplicate card
            do
            {
                cardNum = random.Next(1, 14);
                typeNum = random.Next(4);

                if (allTakenCards.Contains(typeNum + cardTypes[typeNum].ToString()))
                {
                    duplicate = true;
                }

            } while (duplicate == true);

            string cardType = cardTypes[typeNum];

            //Store Drawn Card
            allTakenCards.Add(cardType + cardNum.ToString());

            //Attach image corresponding to drawn card to Image Object
            BitmapImage bitmapImage = new BitmapImage();

            if (playerType == "computer" && IsTestModeOn == false)
            {
                bitmapImage.UriSource = new Uri("ms-appx:///Assets/CardBack.png");
            }

            else
            {
                bitmapImage.UriSource = new Uri("ms-appx:///Assets/" + cardType + cardNum + ".png");
            }
            

            //Set Image Properties
            newCard.Source = bitmapImage;
            newCard.Width = 100;
            newCard.Height = 100;
            newCard.Name = cardType + cardNum.ToString();

            //Decrease drawn card's number's index by 1 in availableCards List
            //Initial availableCards List is { 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4 };
            //Index 0 of availableCards List refers to any type of card with number 1
            //if spade 1 is drawn, then this List is now { 3, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4 };
            availableCards[cardNum-1]--;

            //Jack, Queen, and King are 10
            if (cardNum > 10)
            {
                cardNum = 10;
            }

            //Add drawn card to user if this method was called from User
            if (playerType == "user")
            {
                //Store User's total card numbers 
                user.TotalNumber = cardNum;
                //Store User's drawn card
                user.PlayerHand.Add(cardType + cardNum);

                //find the grid position of User's hand
                newCard.SetValue(Grid.RowProperty, 0);
                newCard.SetValue(Grid.ColumnProperty, user.PlayerHand.Count());

                //Display newCard on the table in User's hand
                GridUserHand.Children.Add(newCard);
            }

            //Add drawn card to user if this method was called from Computer
            else
            {
                //Store Computer's total card numbers 
                computer.TotalNumber = cardNum;
                //Store Computer's drawn card
                computer.PlayerHand.Add(cardType + cardNum);

                //find the grid position of Computer's hand
                newCard.SetValue(Grid.RowProperty, 0);
                newCard.SetValue(Grid.ColumnProperty, computer.PlayerHand.Count());

                //Display newCard on the table in Computer's hand
                GridComputerHand.Children.Add(newCard);
            }


        }

        private void Stop_Click(object sender, RoutedEventArgs e)
        {
            btnDraw.IsEnabled = false;
            UserStoppedSign.Visibility = Visibility.Visible;
            IsUserStopped = true;
            
            Computer_Turn();
        }

        private void ResetGame()
        {
            //Reset Cards on the table
            GridUserHand.Children.Clear();
            GridComputerHand.Children.Clear();

            //Empty each players' hand and their total card numbers
            user.TotalNumber = 0;
            computer.TotalNumber = 0;
            user.PlayerHand.Clear();
            computer.PlayerHand.Clear();
            IsUserStopped = false;
            IsComputerStopped = false;

            UserStoppedSign.Visibility = Visibility.Collapsed;
            ComputerStoppedSign.Visibility = Visibility.Collapsed;

            allTakenCards.Clear();
            availableCards.Clear();
            
            //Reset availableCards List to its initial value
            for (int i=0; i<13; i++)
            {
                availableCards.Add(4);
            }       

            //hide btnDraw and btnStop buttons          
            btnDraw.Visibility = Visibility.Collapsed;
            btnStop.Visibility = Visibility.Collapsed;

            //show btnStart button
            btnStart.Visibility = Visibility.Visible;

        }
        
        private void RevealComputerHand()
        {
            GridComputerHand.Children.Clear();

            for (int i = 0; i < computer.PlayerHand.Count(); i++)
            {
                Image newCard = new Image();
                BitmapImage bitmapImage = new BitmapImage();

                bitmapImage.UriSource = new Uri("ms-appx:///Assets/" + computer.PlayerHand[i] + ".png");

                newCard.Source = bitmapImage;
                newCard.Width = 100;
                newCard.Height = 100;
                newCard.Name = computer.PlayerHand[i].ToString();

                //find the grid position of Computer's hand
                newCard.SetValue(Grid.RowProperty, 0);
                newCard.SetValue(Grid.ColumnProperty, i);

                //Display newCard on the table in Computer's hand
                GridComputerHand.Children.Add(newCard);

            }
        }

        private async void CheckWinner()
        {
            //IF User stops drawing and Computer's hand is already bigger than User's hand
            if (IsUserStopped == true && user.TotalNumber < computer.TotalNumber)
            {
                var dialog = new MessageDialog("You lost." + "\n" + "Your Total Number: " + user.TotalNumber.ToString() + "\n" + "Computer's Total Number: " + computer.TotalNumber.ToString());
                dialog.Commands.Add(new UICommand { Label = "Restart" });

                RevealComputerHand();

                var result = await dialog.ShowAsync();

                if (result.Label == "Restart")
                {
                    ResetGame();
                }
            }

            //if both players stop drawing then compare their hands
            else if (IsUserStopped == true && IsComputerStopped == true)
            {
                //if User's hand is bigger than Computer's hand
                if (user.TotalNumber > computer.TotalNumber)
                {
                    var dialog = new MessageDialog("You won." + "\n" + "Your Total Number: " + user.TotalNumber.ToString() + "\n" + "Computer's Total Number: " + computer.TotalNumber.ToString());
                    dialog.Commands.Add(new UICommand { Label = "Restart" });

                    RevealComputerHand();

                    var result = await dialog.ShowAsync();

                    if (result.Label == "Restart")
                    {
                        ResetGame();
                    }
                }

                //if Computer's hand is bigger than User's hand
                else if (user.TotalNumber < computer.TotalNumber)
                {
                    var dialog = new MessageDialog("You lost." + "\n" + "Your Total Number: " + user.TotalNumber.ToString() + "\n" + "Computer's Total Number: " + computer.TotalNumber.ToString());
                    dialog.Commands.Add(new UICommand { Label = "Restart" });

                    RevealComputerHand();

                    var result = await dialog.ShowAsync();

                    if (result.Label == "Restart")
                    {
                        ResetGame();
                    }
                }

                //if it is a tie
                else
                {
                    var dialog = new MessageDialog("Tie!" + "\n" + "Your Total Number: " + user.TotalNumber.ToString() + "\n" + "Computer's Total Number: " + computer.TotalNumber.ToString());
                    dialog.Commands.Add(new UICommand { Label = "Restart" });

                    RevealComputerHand();

                    var result = await dialog.ShowAsync();

                    if (result.Label == "Restart")
                    {
                        ResetGame();
                    }
                }
            }

        }

        private async void Computer_Turn()
        {
            //if Computer has already stopped drawing, do not draw
            if (IsComputerStopped == true)
            {
                CheckWinner();
                return;
            }

            playerType = "computer";

            //find out if Computer decides to draw
            bool draw = ComputerCalculate.ComputerDrawOrStop(computer, user.TotalNumber);

            //var dialog1 = new MessageDialog("draw: " + draw.ToString());

            //await dialog1.ShowAsync();

            //if Computer decides to stop drawing
            if (draw == false)
            {
                IsComputerStopped = true;
                ComputerStoppedSign.Visibility = Visibility.Visible;
                CheckWinner();
            }

            //Computer draws new card
            else
            {
                GenerateNewCard(playerType);

                await Task.Delay(500);

                //Check if Computer's hand is over 21
                if (computer.TotalNumber > 21)
                {
                    var dialog = new MessageDialog("You won." + "\n" + "Your Total Number: " + user.TotalNumber.ToString() + "\n" + "Computer's Total Number: " + computer.TotalNumber.ToString());
                    dialog.Commands.Add(new UICommand { Label = "Restart" });

                    RevealComputerHand();

                    var result = await dialog.ShowAsync();

                    if (result.Label == "Restart")
                    {
                        ResetGame();
                    }
                }

                //if User stops drawing, Compyter will continously draw
                if (IsUserStopped == true)
                {
                    Computer_Turn();
                }
            }

            
        }
    }
}
