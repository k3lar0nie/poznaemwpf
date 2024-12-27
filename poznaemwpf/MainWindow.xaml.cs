using System.Collections.Generic;
using System.IO;
using System.Windows;

namespace poznaemwpf
{
    
    public class Book
    {
        public string Name { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public string TakenBy { get; set; }

        public Book(string name, string author, string genre)
        {
            Name = name;
            Author = author;
            Genre = genre;
        }
    }

    public class ReadersCard
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string MiddleName { get; set; }
        public string Age { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public ReadersCard(string name, string surname, string middleName, string age, string phoneNumber, string email)
        {
            Name = name;
            Surname = surname;
            MiddleName = middleName;
            Age = age;
            PhoneNumber = phoneNumber;
            Email = email;
        }
    }
    
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            
            InitializeComponent();
            
            SystemReaderButtonsControl(Visibility.Visible);
            SystemReaderButtonsControl(Visibility.Hidden);
        }

        private void DeleteBook(object sender, RoutedEventArgs e)
        {
            Book selectedBook = (Book)MainTable.SelectedItem;
            List<Book> books = MainTable.ItemsSource as List<Book>;
            books.Remove(selectedBook);
            
            SaveLoad.Rewrite(books);
            SaveLoad.LoadBooks(MainTable);
        }

        private void AddBook(object sender, RoutedEventArgs e)
        {
            SaveLoad.SaveBookString($"{BookName.Text}#{BookAuthor.Text}#{BookGenre.Text}");
            SaveLoad.LoadBooks(MainTable);
        }

        
        
        public void ReaderAdd(object sender, RoutedEventArgs e)
        {
            SaveLoad.SaveReaderString($"{ReaderName.Text}#{ReaderSurname.Text}#{ReaderMiddleName.Text}#{ReaderAge.Text}#{ReaderPhoneNumber.Text}#{ReaderEmail.Text}");
            SaveLoad.LoadReadersCard(MainTable);
        }

        public void ReaderRemove(object sender, RoutedEventArgs e)
        {
            ReadersCard selectedCard = (ReadersCard)MainTable.SelectedItem;
            List<ReadersCard> cards = MainTable.ItemsSource as List<ReadersCard>;
            cards.Remove(selectedCard);
            
            SaveLoad.Rewrite(cards);
            SaveLoad.LoadReadersCard(MainTable);
        }
        
        
        
        // загрузить чит билеты
        private void LoadReadersCardButton(object sender, RoutedEventArgs e)
        {
            SystemReaderButtonsControl(Visibility.Visible);
            SystemBookButtonsControl(Visibility.Hidden);
            SaveLoad.LoadReadersCard(MainTable);
        }

        // загрузить книги
        private void LoadBooksButton(object sender, RoutedEventArgs e)
        {
            SystemBookButtonsControl(Visibility.Visible);
            SystemReaderButtonsControl(Visibility.Hidden);
            SaveLoad.LoadBooks(MainTable);
        }
        
        private void SystemBookButtonsControl(Visibility turn)
        {
            BookName.Visibility = turn;
            BookAuthor.Visibility = turn;
            BookGenre.Visibility = turn;
            
            ButtonAdd.Visibility = turn;
            ButtonDelete.Visibility = turn;
            ButtonLoadReadCard.Visibility = turn;
        }

        private void SystemReaderButtonsControl(Visibility turn)
        {
           
            ReaderName.Visibility = turn;
            ReaderSurname.Visibility = turn;
            ReaderMiddleName.Visibility = turn;
            ReaderAge.Visibility = turn;
            ReaderPhoneNumber.Visibility = turn;
            ReaderEmail.Visibility = turn;

            ReaderAddButton.Visibility = turn;
            ReaderDeleteButton.Visibility = turn;

            ButtonLoadBooks.Visibility = turn;
            
        }
    }
}