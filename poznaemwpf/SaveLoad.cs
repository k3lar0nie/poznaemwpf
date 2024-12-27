using System.IO;
using System.Collections.Generic;
using System.Windows.Controls;

namespace poznaemwpf;

public static class SaveLoad
{
    public static void SaveBookString(string str)
    {
        if (File.Exists($"books.txt"))
        {
            using (StreamWriter streamWriter = new StreamWriter("books.txt", true))
            {
                streamWriter.WriteLine(str);
            }
        }
        else
        {
            using (FileStream stream = File.Create("books.txt"))
            {
                stream.Close();
            }
            SaveBookString(str);
        }
            
    }
    public static void Rewrite(List<Book> list)
    {
        if (File.Exists("books.txt"))
        {
            using (StreamWriter streamWriter = new StreamWriter("books.txt"))
            {
                foreach (var item in list)
                {
                    streamWriter.WriteLine($"{item.Name}#{item.Author}#{item.Genre}#{item.TakenBy}");
                }
            }
        }
        else
        {
            using (FileStream stream = File.Create("books.txt"))
            {
                stream.Close();
            }
            Rewrite(list);
        }
    }
    public static void LoadBooks(DataGrid MainTable)
    {
        List<Book> result = new List<Book>();

        using (StreamReader streamReader = new StreamReader("books.txt"))
        {
            string line;
            while ((line = streamReader.ReadLine()) != null)
            {
                result.Add(new Book(line.Split('#')[0], line.Split('#')[1], line.Split('#')[2], line.Split('#')[3]));
            }
        }

        MainTable.ItemsSource = result;
    }

    // READERS CARD                    ----------------------------------------
    public static void SaveReaderString(string str)
    {
        if (File.Exists($"readersCard.txt"))
        {
            using (StreamWriter streamWriter = new StreamWriter("readersCard.txt", true))
            {
                streamWriter.WriteLine(str);
            }
        }
        else
        {
            using (FileStream stream = File.Create("readersCard.txt"))
            {
                stream.Close();
            }
            SaveReaderString(str);
        }
    }
    
    
    public static void LoadReadersCard(DataGrid MainTable)
    {
        List<ReadersCard> result = new List<ReadersCard>();
        
        using (StreamReader streamReader = new StreamReader("readersCard.txt"))
        {
            string line;
            while((line = streamReader.ReadLine()) != null)
            {
                result.Add(new ReadersCard(line.Split('#')[0], line.Split('#')[1], line.Split('#')[2], line.Split('#')[3], line.Split('#')[4], line.Split('#')[5], line.Split('#')[6]));
            }
        }
        MainTable.ItemsSource = result;   
    }
    public static void Rewrite(List<ReadersCard> list)
    {
        if (File.Exists("readersCard.txt"))
        {
            using (StreamWriter streamWriter = new StreamWriter("readersCard.txt"))
            {
                foreach (var item in list)
                {
                    streamWriter.WriteLine($"{item.Name}#{item.Surname}#{item.MiddleName}#{item.Age}#{item.PhoneNumber}#{item.Email}#{item.Id}");
                }
            }
        }
        else
        {
            using (FileStream stream = File.Create("readersCard.txt"))
            {
                stream.Close();
            }
            Rewrite(list);
        }
    }
}