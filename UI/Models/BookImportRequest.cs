using BusinessLogic.Models;
using System.Collections.Generic;

namespace UI.Models
{
    public class BookImportRequest
    {
        public string UserID { get; set; }
        public List<Book> Books { get; set; }
    }
}