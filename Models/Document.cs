using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tx_backstage_view.Models
{
    public class Document
    {
        public Document() { }

        public Document(string FilePath)
        {
            this.FilePath = FilePath;
            this.Name = Path.GetFileName(this.FilePath);
        }

        public string Name { get; }
        public string FilePath { get; set; }
    }
}
