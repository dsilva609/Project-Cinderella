using BusinessLogic.Models;
using System.Collections.Generic;

namespace UI.Models
{
    public class HomeViewModel
    {
        public List<Album> Albums { get; set; }
        public List<Book> Books { get; set; }
    }
}