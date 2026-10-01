using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace lab1._1_Zimina_BPI_24_01
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ButtonCalculate.Click += CalculateMediumCost;
            bookPagesCnt.TextChanged += ValidatePages;
            bookCostInput.TextChanged += ValidateCost;
            bookNameInput.TextChanged += ValidateName;
            CreateEmptyBook();
        }

        private bool isValidPages = false;
        private bool isValidCost = false;
        private bool isValidName = false;

        private Book book;

        private void CreateEmptyBook()
        {
            book = new Book("-", 0, 0);
        }

        private void EditBookData()
        {
            string bookName = bookNameInput.Text;
            int pagesCnt = int.Parse(bookPagesCnt.Text);
            int cost = int.Parse(bookCostInput.Text);
            book.EditData(bookName, pagesCnt, cost);
        }

        private void ValidateName(object sender, TextChangedEventArgs e)
        {
            string bookName = bookNameInput.Text;
            if (string.IsNullOrEmpty(bookName))
            {
                isValidName = false;
                bookNameInput.Background = Brushes.Red;
            }
            else
            {
                isValidName = true;
                bookNameInput.Background = Brushes.Green;
            }
        }

        private void ValidatePages(object sender, TextChangedEventArgs e)
        {
            isValidPages = false;
            bookPagesCnt.Background = Brushes.Red;

            if (string.IsNullOrEmpty(bookPagesCnt.Text))
                return;

            if (int.TryParse(bookPagesCnt.Text, out int pagesCnt))
            {
                if (pagesCnt >= 0)
                {
                    isValidPages = true;
                    bookPagesCnt.Background = Brushes.Green;
                }
            }
        }

        private void ValidateCost(object sender, TextChangedEventArgs e)
        {
            isValidCost = false;
            bookCostInput.Background = Brushes.Red;

            if (string.IsNullOrEmpty(bookCostInput.Text))
                return;

            if (int.TryParse(bookCostInput.Text, out int cost) && cost > 0)
            {
                isValidCost = true;
                bookCostInput.Background = Brushes.Green;
            }
        }

        private bool CheckValid()
        {
            return isValidCost && isValidName && isValidPages;
        }

        private void CalculateMediumCost(object sender, RoutedEventArgs e)
        {
            if (CheckValid())
            {
                EditBookData();
                var (mainMediumCost, editMediumCost) = book.CalculateMediumCost();
                CostboxMain.Visibility = Visibility.Visible;
                CostboxEdit.Visibility = Visibility.Visible;
                CostboxMain.Text = "Средняя цена одной страницы: " + mainMediumCost.ToString();
                CostboxEdit.Text = "Средняя цена одной страницы с учетом названия: " + editMediumCost.ToString();
            }
            else
            {
                CostboxMain.Visibility = Visibility.Collapsed;
                CostboxEdit.Visibility = Visibility.Collapsed;
                CostboxMain.Text = string.Empty;
                CostboxEdit.Text = string.Empty;
            }
        }
    }
}
