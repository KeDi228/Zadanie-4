using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;


namespace Library.Data
{
    public class Book
    {
        private string? Title;
        public string? rTitle
        {
            get { return Title; }
            set { Title = value; }
        }
        private string? Author;
        public string? rAuthor
        {
            get { return Author; }
            set { Author = value; }
        }
        private string ISBN;
        public string rISBN
        {
            get { return ISBN; }
            set { ISBN = value; }
        }
        private bool IsAvailable;
        public bool rIsAvailable
        {
            get { return IsAvailable; }
            set { IsAvailable = value; }
        }
        private string? Name;
        public string? rName
        {
            get { return Name; }
            set { Name = value; }
        }

        public Book(string isbn,
            string? title,
            string? author,
            bool isavailable)
        {
            ISBN = isbn;
            Title = title;
            Author = author;
            IsAvailable = isavailable;
        }
    }
}
