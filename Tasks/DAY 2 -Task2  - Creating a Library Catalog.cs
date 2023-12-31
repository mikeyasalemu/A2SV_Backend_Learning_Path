using System;
using System.Collections.Generic;

public class Library
{
    public string Name { get; }
    public string Address { get; }
    public List<Book> Books { get; }
    public List<MediaItem> MediaItems { get; }

    public Library(string name, string address)
    {
        Name = name;
        Address = address;
        Books = new List<Book>();
        MediaItems = new List<MediaItem>();
    }

    public void AddBook(Book book)
    {
        Books.Add(book);
        Console.WriteLine($"Book '{book.Title}' added to the library.");
    }

    public void RemoveBook(Book book)
    {
        if (Books.Remove(book))
        {
            Console.WriteLine($"Book '{book.Title}' removed from the library.");
        }
        else
        {
            Console.WriteLine($"Book '{book.Title}' not found in the library.");
        }
    }

    public void AddMediaItem(MediaItem item)
    {
        MediaItems.Add(item);
        Console.WriteLine($"Media item '{item.Title}' added to the library.");
    }

    public void RemoveMediaItem(MediaItem item)
    {
        if (MediaItems.Remove(item))
        {
            Console.WriteLine($"Media item '{item.Title}' removed from the library.");
        }
        else
        {
            Console.WriteLine($"Media item '{item.Title}' not found in the library.");
        }
    }


   public void UserAddBook()
    {
        Console.WriteLine("Enter the details for the book:");

        // Validate title
        string? title;
        do
        {
            Console.Write("Title: ");
            title = Console.ReadLine();
        } while (string.IsNullOrWhiteSpace(title));

        // Validate author
        string? author;
        do
        {
            Console.Write("Author: ");
            author = Console.ReadLine();
        } while (string.IsNullOrWhiteSpace(author));

        // Validate ISBN
        string? isbn;
        do
        {
            Console.Write("ISBN: ");
            isbn = Console.ReadLine();
        } while (string.IsNullOrWhiteSpace(isbn));

        // Validate Publication Year
        int publicationYear;
        string? publicationYearInput;
        do
        {
            Console.Write("Publication Year: ");
            publicationYearInput = Console.ReadLine();
        } while (string.IsNullOrWhiteSpace(publicationYearInput) || !int.TryParse(publicationYearInput, out publicationYear));

        Book book = new Book(title, author, isbn, publicationYear);
        Books.Add(book);
        Console.WriteLine($"Book '{book.Title}' added to the library.");
    }


    public void UserAddMediaItem()
    {
        Console.WriteLine("Enter the details for the media item:");

        // Validate title
        string? title;
        do
        {
            Console.Write("Title: ");
            title = Console.ReadLine();
        } while (string.IsNullOrWhiteSpace(title));

        // Validate media type
        string? mediaType;
        do
        {
            Console.Write("Media Type: ");
            mediaType = Console.ReadLine();
        } while (string.IsNullOrWhiteSpace(mediaType));

        // Validate duration
        int duration;
        string? durationInput;
        do
        {
            Console.Write("Duration (minutes): ");
            durationInput = Console.ReadLine();
        } while (string.IsNullOrWhiteSpace(durationInput) || !int.TryParse(durationInput, out duration));

        MediaItem item = new MediaItem(title, mediaType, duration);
        MediaItems.Add(item);
        Console.WriteLine($"Media item '{item.Title}' added to the library.");
    }

    public void PrintCatalog()
    {
        Console.WriteLine($"Catalog of Library: {Name} ({Address})");
        Console.WriteLine("Books:");
        foreach (var book in Books)
        {
            Console.WriteLine($"- {book.Title} by {book.Author} (ISBN: {book.ISBN}, Year: {book.PublicationYear})");
        }
        Console.WriteLine("Media Items:");
        foreach (var item in MediaItems)
        {
            Console.WriteLine($"- {item.Title} ({item.MediaType}), Duration: {item.Duration} minutes");
        }
    }
}

public class Book
{
    public string Title { get; }
    public string Author { get; }
    public string ISBN { get; }
    public int PublicationYear { get; }

    public Book(string title, string author, string isbn, int publicationYear)
    {
        Title = title;
        Author = author;
        ISBN = isbn;
        PublicationYear = publicationYear;
    }
}

public class MediaItem
{
    public string Title { get; }
    public string MediaType { get; }
    public int Duration { get; }

    public MediaItem(string title, string mediaType, int duration)
    {
        Title = title;
        MediaType = mediaType;
        Duration = duration;
    }
}

public class Day2T2
{
    public static void Main()
    {
        Library library = new Library("Awesome Library", "123 Main Street");

        Book book1 = new Book("The Great Gatsby", "F. Scott Fitzgerald", "9780743273565", 1925);
        Book book2 = new Book("To Kill a Mockingbird", "Harper Lee", "9780061120084", 1960);
        MediaItem media1 = new MediaItem("Inception", "DVD", 148);
        MediaItem media2 = new MediaItem("Dark Side of the Moon", "CD", 43);

        library.AddBook(book1);
        library.AddBook(book2);
        library.AddMediaItem(media1);
        library.AddMediaItem(media2);


        Console.WriteLine("Enter books and media items for the library.");
        while (true)
        {
            
            string? itemType;
            do
            {
                Console.Write("Enter 'book' or 'media' (or 'exit' to stop): ");
                itemType = Console.ReadLine();

            } while (string.IsNullOrEmpty(itemType));

            itemType = itemType.ToLower();

            if (itemType == "exit")
                break;

            if (itemType == "book")
            {
                library.UserAddBook();
            }
            else if (itemType == "media")
            {
                library.UserAddMediaItem();
            }
            else
            {
                Console.WriteLine("Invalid item type. Please enter 'book' or 'media'.");
            }
        }


        Console.WriteLine("\n--- Catalog of the Library ---");
        library.PrintCatalog();

        Console.WriteLine("\n--- Removing Book and Media Item ---");
        library.RemoveBook(book1);
        library.RemoveMediaItem(media2);

        Console.WriteLine("\n--- Updated Catalog of the Library ---");
        library.PrintCatalog();
    }
}
