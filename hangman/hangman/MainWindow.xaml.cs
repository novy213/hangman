using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
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
        public MainWindow()
        {
            InitializeComponent();
        }        
        private void Play_click(object sender, RoutedEventArgs e)
        {            
            MainMenu.Visibility = Visibility.Collapsed;
            PlauGrid.Visibility = Visibility.Collapsed;
            StreamReader sr = new StreamReader("hasla.txt");
            line = sr.ReadLine();
            while (line != null)
            {
                wordList.Add(line);
                line = sr.ReadLine();
            }
            sr.Close();
        }
       
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
