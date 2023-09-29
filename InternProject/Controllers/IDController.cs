using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using IronOcr;

namespace InternProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IDController : ControllerBase
    {
        private readonly IWebHostEnvironment _environment;

        public IDController(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        [HttpPost]
        public ActionResult OCR(IFormFile file)
        {
            try
            {
                // Check if the uploaded file is an image
                if (!IsImage(file))
                {
                    return BadRequest("Invalid file format. Please upload an image.");
                }

                var ms = new MemoryStream();
                file.CopyTo(ms);
                var fileBytes = ms.ToArray();

                // Read the OCR text directly from the uploaded image
                var ocr = new IronTesseract();
                ocr.Language = OcrLanguage.Vietnamese;
                ocr.AddSecondaryLanguage(OcrLanguage.English);

                var input = new OcrInput(fileBytes);
                input.Deskew();
                input.DeNoise();

                var result = ocr.Read(input);
                string ocrText = result.Text.ToLower(); // Convert to lowercase for case-insensitive matching

                string resultFileName = Path.ChangeExtension(file.FileName, ".txt");
                string resultFilePath = Path.Combine(_environment.WebRootPath, resultFileName);
                System.IO.File.WriteAllText(resultFilePath, ocrText);

                if (ocrText.Contains("căn cước"))
                {
                    return Ok("This is a CCCD.");
                }
                else if (ocrText.Contains("passport"))
                {
                    return Ok("This is a passport.");
                }
                else
                {
                    return Ok("Unable to determine the document type.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        private bool IsImage(IFormFile file)
        {
            return file.ContentType.StartsWith("image", StringComparison.OrdinalIgnoreCase);
        }
    }
}
