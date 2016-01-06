using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using tx_backstage_view.Models;

namespace tx_backstage_view.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetView(string viewName)
        {
            switch (viewName)
            {
                case "Open":
                    var documents = new List<Document>();

                    foreach (string file in Directory.GetFiles(Server.MapPath("/App_Data/documents")))
                    {
                        Document doc = new Document(file);
                        documents.Add(doc);
                    }

                    return PartialView("Stageviews/Open", documents);
            }

            return PartialView("Stageviews/" + viewName);
        }

        // loads a document into the ServerTextControl and returns the
        // document as a base64 encoded string
        [HttpPost]
        public string LoadTemplate(LoadDocumentViewModel model)
        {
            byte[] data;

            using (TXTextControl.ServerTextControl tx = new TXTextControl.ServerTextControl())
            {
                tx.Create();

                TXTextControl.StreamType streamType = TXTextControl.StreamType.WordprocessingML;

                switch(Path.GetExtension(model.DocumentName))
                {
                    case ".doc":
                        streamType = TXTextControl.StreamType.MSWord;
                        break;
                    case ".rtf":
                        streamType = TXTextControl.StreamType.RichTextFormat;
                        break;
                    case ".tx":
                        streamType = TXTextControl.StreamType.InternalUnicodeFormat;
                        break;
                    case ".pdf":
                        streamType = TXTextControl.StreamType.AdobePDF;
                        break;
                }

                tx.Load(Server.MapPath("/App_Data/documents/" + model.DocumentName), streamType);

                tx.Save(out data, TXTextControl.BinaryStreamType.InternalUnicodeFormat);
            }

            return Convert.ToBase64String(data);
        }
    }
}