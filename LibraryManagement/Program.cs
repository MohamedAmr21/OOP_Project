class Book
{
    public string Title { get; set; }
    public string Author { get; set; }
    public string ISBN { get; set; }
    public bool IsAvailable { get; set; }

     public Book(string title, string author, string isbn)
    {
        Title = title;
        Author = author;
        ISBN = isbn;
        IsAvailable = true;
    }

    public override string ToString()
    {
        return $"Title: {Title}, Author: {Author}, ISBN: {ISBN}, " +
               $"Available: {IsAvailable}";
    }
    
    
}

class Library
{
     private List<Book> books = new List<Book>();

    // Add a new book
    public void AddBook(Book book)
    {
        books.Add(book);
        Console.WriteLine("Book added successfully.");
    }

    // List all books
    public void ListBooks()
    {
        if (books.Count == 0)
        {
            Console.WriteLine("No books in the library.");
            return;
        }

        foreach (Book book in books)
        {
            Console.WriteLine(book);
        }
    }

    // Search by title
    public void SearchByTitle(string title)
    {
        bool found = false;

        foreach (Book book in books)
        {
            if (book.Title.Equals(title, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine(book);
                found = true;
            }
        }

        if (!found)
        {
            Console.WriteLine("Book not found.");
        }
    }

    // Check out a book
    public void CheckOutBook(string title)
    {
        foreach (Book book in books)
        {
            if (book.Title.Equals(title, StringComparison.OrdinalIgnoreCase))
            {
                if (book.IsAvailable)
                {
                    book.IsAvailable = false;
                    Console.WriteLine("Book checked out successfully.");
                }
                else
                {
                    Console.WriteLine("Book is already checked out.");
                }

                return;
            }
        }

        Console.WriteLine("Book not found.");
    }
    
}

class Program
{
    static void Main()
    {

         Library library = new Library();

        // Add books
        library.AddBook(
            new Book("Clean Code", "Robert C. Martin", "9780132350884")
        );

        library.AddBook(
            new Book("The Pragmatic Programmer", "Andrew Hunt", "9780135957059")
        );

        library.AddBook(
            new Book("C# in Depth", "Jon Skeet", "9781617294532")
        );

        Console.WriteLine("\n--- All Books ---");
        library.ListBooks();

        Console.WriteLine("\n--- Search Book ---");
        library.SearchByTitle("Clean Code");

        Console.WriteLine("\n--- Check Out Book ---");
        library.CheckOutBook("Clean Code");

        Console.WriteLine("\n--- Books After Checkout ---");
        library.ListBooks();

        Console.ReadKey();
        
    }
}