using System.Collections.Generic;

namespace ReportsOrder
{
    public interface IReports
    {
        string CreateDoc(List<string> reportStings, string reportdir = "Reports");
    }
}