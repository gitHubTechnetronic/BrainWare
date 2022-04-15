using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace ReportsOrder
{
    public class R_Text : IReports
    {
                
        public string CreateDoc(List<string> reportStings, string reportdir = "Reports")
        {

            System.IO.FileStream fs = null; 

            Guid a = Guid.NewGuid();

            try
            {                
                fs = new FileStream(AppDomain.CurrentDomain.BaseDirectory + reportdir + "\\" + a.ToString() + ".txt", FileMode.Create);
                
                byte[] newline = Encoding.ASCII.GetBytes(Environment.NewLine);
                
                foreach (string linetext in reportStings)
                {                    
                    byte[] info = new UTF8Encoding(true).GetBytes(linetext + "");
                    fs.Write(info, 0, info.Length);
                    fs.Write(newline, 0, newline.Length);                    
                }                
            }
            finally
            {                
                fs.Close();
            }

            return reportdir + "//" + a.ToString() + ".txt";
        }

    }
}
