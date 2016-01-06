using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace tx_backstage_view.Models
{
    public class DocumentViewModel
    {
        public string DocumentName { get; set; }
        public string BinaryDocument { get; set; }
    }

    public class LoadDocumentViewModel
    {
        public string DocumentName { get; set; }
    }
}