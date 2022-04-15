using System;
using System.Collections.Generic;
using iTextSharp.text;
using System.IO;
using iTextSharp.text.pdf;

namespace ReportsOrder
{
    public class R_iTextSharp : IReports
    {                
        public string CreateDoc(List<string> reportStings, string reportdir = "Reports", string testreportfullpath = "")
        {
            Document pdfDoc = null;
            PdfWriter writer2 = null;
            System.IO.FileStream fs = null; 

            Guid a = Guid.NewGuid();

            try
            {                
                pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);

                string basedirectory = string.IsNullOrWhiteSpace(testreportfullpath) ? AppDomain.CurrentDomain.BaseDirectory ?? testreportfullpath : testreportfullpath;

                fs = new FileStream(basedirectory + reportdir + "\\" + a.ToString() + ".pdf", FileMode.Create);
                writer2 = PdfWriter.GetInstance(pdfDoc, fs);
                
                pdfDoc.Open();
                pdfDoc.NewPage();
                
                PdfContentByte cb = new PdfContentByte(writer2); 
                
                BaseFont bf = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);

                Font cf = new Font(bf, 8);
                cf.Color = Color.BLACK;
                
                int yrow = 780;
                int linespacing = 10;

                foreach (string linetext in reportStings)
                {
                    ColumnText.ShowTextAligned(cb, Element.ALIGN_LEFT, new Phrase(linetext, cf), 50, yrow, 0);
                    yrow = yrow  - linespacing;
                    if (yrow < 60)
                    {
                        writer2.DirectContent.Add(cb);
                        pdfDoc.NewPage();
                        cb = new PdfContentByte(writer2);
                        yrow = 780;
                    }
                }
                
                writer2.DirectContent.Add(cb);

                writer2.SetFullCompression();
                writer2.CloseStream = true;
                
            }
            finally
            {
                pdfDoc.Close();
                pdfDoc = null;
                                
                fs.Close();
            }

            return reportdir + "//" + a.ToString() + ".pdf";
        }

    }
}
