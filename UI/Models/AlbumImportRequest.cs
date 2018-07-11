using BusinessLogic.Models;
using System.Collections.Generic;

namespace UI.Models
{
    public class AlbumImportRequest
    {
        public string UserID { get; set; }
        public List<Album> Albums { get; set; }
    }
}