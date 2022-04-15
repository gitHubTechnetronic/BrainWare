### Report Layer

https://github.com/gitHubTechnetronic/BrainWare/tree/clinton-smith/ReportLayer

Added Dependency Injection Report Layer for switching between iTextSharp, Word Document and Text file creation.  This shows the ability to switch out new third party report creation services.

### PDF ISO Specifications
https://www.loc.gov/preservation/digital/formats/fdd/fdd000277.shtml

https://opensource.adobe.com/dc-acrobat-sdk-docs/standards/pdfstandards/pdf/PDF32000_2008.pdf

I have worked with ISO Technical Codes and Specifications on other projects, so if we need to I can create our own pdf editor and reader.

### DI Code Changes for Switching

https://github.com/gitHubTechnetronic/BrainWare/blob/clinton-smith/Web/App_Start/WebApiConfig.cs
And for testing it uses
public static IOrderService CreateOrderService(ReportType rt = ReportType.PDF)
        {
            return new OrderService(CreateReportsService(rt));
        }
In code test file
https://github.com/gitHubTechnetronic/BrainWare/blob/clinton-smith/Tests/Controllers/HomeControllerTest.cs
FYI: I would refactor test to Mock httpcontext

### Reports Directory

Directory “Web/Reports”
Three example files (pdf,txt,docx) are already there.
This is where the Report gets generated each time the website loads for example.
