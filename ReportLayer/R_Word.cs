using System;
using System.Collections.Generic;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Wordprocessing;

namespace ReportsOrder
{
    public class R_Word : IReports
    {                
        public string CreateDoc(List<string> reportStings, string reportdir = "Reports")
        {            
            Guid a = Guid.NewGuid();

            try
            {

                using (WordprocessingDocument wordDocument = WordprocessingDocument.Create(AppDomain.CurrentDomain.BaseDirectory + reportdir + "\\" + a.ToString() + ".docx", WordprocessingDocumentType.Document))
                {
                    MainDocumentPart mainPart = wordDocument.AddMainDocumentPart();
                    
                    mainPart.Document = new Document();
                    Body body = mainPart.Document.AppendChild(new Body());
                                        
                    foreach (string linetext in reportStings)
                    {
                        Paragraph para = body.AppendChild(new Paragraph());
                        Run run = para.AppendChild(new Run());
                                                
                        Text spacelinetext = new Text(linetext);
                        spacelinetext.Space = SpaceProcessingModeValues.Preserve;

                        run.AppendChild(spacelinetext);
                    }
                }                
            }
            finally
            {

            }

            return reportdir + "//" + a.ToString() + ".docx";
        }

    }
}
