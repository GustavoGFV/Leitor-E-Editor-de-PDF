using ConsoleApp1.FillDoc;
using ConsoleApp1.EmailSender;

try
{
    DocFiller filler = new DocFiller();
    EmailSender emailSender = new EmailSender();

    using (MemoryStream ms = new MemoryStream())
    {
        using (FileStream file = new FileStream(@"C:\Users\Usuario\Downloads\Arquivo.pdf", FileMode.Open, FileAccess.Read))
        {
            var filledResult = filler.DocFillerProcess(file);
            emailSender.EmailSenderProcess(filledResult);
        }
    }
}
catch (Exception ex)
{
    throw ex;
}