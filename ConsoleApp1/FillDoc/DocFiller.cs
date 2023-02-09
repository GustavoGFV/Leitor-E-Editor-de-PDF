using iText.Forms.Fields;
using iText.Forms;
using iText.IO.Image;
using iText.Kernel.Pdf.Canvas.Wmf;
using iText.Kernel.Pdf.Xobject;
using iText.Kernel.Pdf;
using iText.Signatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using iText.Layout.Element;
using iText.Layout;
using System.Data;
using System.IO;
using ConsoleApp1.EmailSender;
using System.Net.Http;

namespace ConsoleApp1.FillDoc
{
    public class DocFiller
    {
        private const float GeneralWidth = 183.003F;
        private const float GeneralHeight = 31.7044F;
        private const float GeneralLeft = 56.988F;
        private const float GeneralBottom = 469.613F;
        private const int SignaturePage = 3;

        public DocFiller() { }
        public MemoryStream DocFillerProcess(FileStream ms)
        {
            try
            {
                EmailSender.EmailSender emailSender = new EmailSender.EmailSender();

                MemoryStream outStream = new MemoryStream();

                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (PdfReader pdfReader = new PdfReader(ms))
                    {
                        using (PdfDocument pdfDocument = new PdfDocument(pdfReader, new PdfWriter(memoryStream)))
                        {
                            using (Document doc = new Document(pdfDocument))
                            {
                                ms.Position = 0;
                                PdfAcroForm form = PdfAcroForm.GetAcroForm(pdfDocument, true);
                                form.GetField("RazaoSocial").SetValue("Clovis de Barro");
                                form.GetField("CNPJ").SetValue("48.367.908/0001-64");
                                form.GetField("Endereco").SetValue("Malboro RJ, 1340 - Contagem, MG | 35126-055");
                                form.GetField("Telefone").SetValue("31 85555-5555");
                                form.GetField("Fax").SetValue("?");
                                form.GetField("Email").SetValue("teste@teste.com");
                                form.GetField("PessoadeContato").SetValue("Anderson");
                                form.GetField("Cidade").SetValue("Contagem");
                                form.GetField("UF").SetValue("MG");
                                form.GetField("CEP").SetValue("35126-055");
                                form.GetField("Dia").SetValue("15");
                                form.GetField("Mes").SetValue("Março");
                                form.GetField("Ano").SetValue("2023");

                                var sign = ("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");
                                byte[] imageBytes = Convert.FromBase64String(sign);
                                Image image = new Image(ImageDataFactory.Create(imageBytes, true));

                                image.ScaleToFit(GeneralWidth, GeneralHeight);
                                image.SetFixedPosition(SignaturePage, GeneralLeft, GeneralBottom);

                                form.RemoveField("Assinatura");
                                form.FlattenFields();

                                doc.Add(image);

                                doc.Close();
                            }
                            pdfDocument.Close();

                            return new MemoryStream(memoryStream.ToArray());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

