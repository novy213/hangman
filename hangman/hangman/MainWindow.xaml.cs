using System;
using System.Collections.Generic;
using System.IO;
using System.Printing.IndexedProperties;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace hangman
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string? line;
        List<string?> wordList = new List<string?>();
        int randomIndex;
        string? word;
        bool[] knownLetter;
        Random r = new Random();
        int attempLeft = 11;        
        public MainWindow()
        {
            InitializeComponent();
        }        
        private void Play_click(object sender, RoutedEventArgs e)
        {            
            MainMenu.Visibility = Visibility.Collapsed;
            PlayGrid.Visibility = Visibility.Visible;
            StreamReader sr = new StreamReader("hasla.txt");
            line = sr.ReadLine();
            while (line != null)
            {
                wordList.Add(line);
                line = sr.ReadLine();
            }
            sr.Close();
            randomIndex = r.Next(0, wordList.Count);
            word = wordList[randomIndex];
            knownLetter = new bool[word.Length];
            for (int i = 0; i < word.Length; i++)
            {
                Word.Text += "_ ";
                knownLetter[i] = false;                
            }                    
        }        
        private void Letter_click(object sender, RoutedEventArgs e)
        {            
            Word.Text = null;
            int a = 0;
            int b = 0;
            string letter = (sender as Button).Content.ToString().ToLower();
            (sender as Button).Visibility=Visibility.Collapsed;            
            int[] positions = CheckLetter(Convert.ToChar(letter));
            for(int i =0;i<positions.Length; i++)
            {
                if (positions[i] == 0 && letter[0] != word[0]) 
                    a++;
            }
            if (a == word.Length)
            {
                attempLeft--;                
            }
            else
            {
                for (int i = 0; i < word.Length; i++)
                {
                    if (positions[i] != 0 || i == 0)
                        knownLetter[positions[i]] = true;
                }
            }
            for (int i = 0; i < word.Length; i++)
            {
                if (knownLetter[i])
                {
                    Word.Text += word[i] + " ";
                }
                else Word.Text += "_ ";
            }
            Draw(attempLeft);
            if(attempLeft == 0)
            {
                WordResult.Text = "Word: "+word;
                PlayGrid.Visibility = Visibility.Collapsed;
                EndGame.Visibility = Visibility.Visible;
            }
            for(int i = 0; i < knownLetter.Length; i++)
            {
                if (knownLetter[i])
                {
                    b++;
                }
            }
            if (b == word.Length)
            {
                WinWordResult.Text = "Word: " + word;
                PlayGrid.Visibility = Visibility.Collapsed;
                WinGrid.Visibility = Visibility.Visible;
            }
        }
        
        public int[] CheckLetter(char letter)
        {
            int[] index = new int[word.Length];
            int counter=0;
            for(int i = 0; i < word.Length; i++)
            {
                if(word[i] == letter)
                {                    
                    index[counter] = i;
                    counter++;
                }
            }
            return index;
        }
        void Draw(int atteptLeft)
        {
            if(atteptLeft == 0)            
                line11.Visibility = Visibility.Visible;     
            else if (atteptLeft == 1)
                line10.Visibility = Visibility.Visible;
            else if (atteptLeft == 2)
                line9.Visibility = Visibility.Visible;
            else if (atteptLeft == 3)
                line8.Visibility = Visibility.Visible;
            else if (atteptLeft == 4)
                line7.Visibility = Visibility.Visible;
            else if (atteptLeft == 5)
                line6.Visibility = Visibility.Visible;
            else if (atteptLeft == 6)
                line5.Visibility = Visibility.Visible;
            else if (atteptLeft == 7)
                line4.Visibility = Visibility.Visible;
            else if (atteptLeft == 8)
                line3.Visibility = Visibility.Visible;
            else if (atteptLeft == 9)
                line2.Visibility = Visibility.Visible;
            else if (atteptLeft == 10)
                line1.Visibility = Visibility.Visible;            
        }

        private void Return_click(object sender, RoutedEventArgs e)
        {
            EndGame.Visibility=Visibility.Collapsed;
            MainMenu.Visibility=Visibility.Visible;
            WinGrid.Visibility=Visibility.Collapsed;
            line = null;
            wordList = new List<string?>();
            randomIndex = 0;
            word = null;
            attempLeft = 11;
            knownLetter = null;
            Word.Text = null;
            SetLayout();
        }
        private void SetLayout()
        {
            line11.Visibility = Visibility.Collapsed;
            line10.Visibility = Visibility.Collapsed;
            line9.Visibility = Visibility.Collapsed;
            line8.Visibility = Visibility.Collapsed;
            line7.Visibility = Visibility.Collapsed;
            line6.Visibility = Visibility.Collapsed;
            line5.Visibility = Visibility.Collapsed;
            line4.Visibility = Visibility.Collapsed;
            line3.Visibility = Visibility.Collapsed;
            line2.Visibility = Visibility.Collapsed;
            line1.Visibility = Visibility.Collapsed;
            button1.Visibility = Visibility.Visible;
            button2.Visibility = Visibility.Visible;
            button3.Visibility = Visibility.Visible;
            button4.Visibility = Visibility.Visible;
            button5.Visibility = Visibility.Visible;
            button6.Visibility = Visibility.Visible;
            button7.Visibility = Visibility.Visible;
            button8.Visibility = Visibility.Visible;
            button9.Visibility = Visibility.Visible;
            button10.Visibility = Visibility.Visible;
            button11.Visibility = Visibility.Visible;
            button12.Visibility = Visibility.Visible;
            button13.Visibility = Visibility.Visible;
            button14.Visibility = Visibility.Visible;
            button15.Visibility = Visibility.Visible;
            button16.Visibility = Visibility.Visible;
            button17.Visibility = Visibility.Visible;
            button18.Visibility = Visibility.Visible;
            button19.Visibility = Visibility.Visible;
            button20.Visibility = Visibility.Visible;
            button21.Visibility = Visibility.Visible;
            button22.Visibility = Visibility.Visible;
            button23.Visibility = Visibility.Visible;
            button25.Visibility = Visibility.Visible;
            button26.Visibility = Visibility.Visible;
            button27.Visibility = Visibility.Visible;
        }
    }
}
