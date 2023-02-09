using ConsoleApp1.FillDoc;
//using ConsoleApp1.FillSignature;

try
{
    DocFiller filler = new DocFiller();
    //SignatureFiller signatureFiller = new SignatureFiller();

    using (MemoryStream ms = new MemoryStream())
    {
        using (MemoryStream teste = new MemoryStream())
        {
            var testes = filler.DocFillerProcess(ms);
            //var teste2 = signatureFiller.SignatureFillerProcess(ms);
        }
    }
}
catch (Exception ex)
{
    throw;
}