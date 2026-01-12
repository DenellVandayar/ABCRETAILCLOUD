using CloudPart3.Areas.Identity.Data;
using CloudPart3.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CloudPart3.Controllers
{
    public class ContractsController : Controller
    {

        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;


        public ContractsController(

        UserManager<ApplicationUser> userManager,
        ApplicationDbContext context)
        {

            _userManager = userManager;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult UploadDocument()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UploadDocument(IFormFile documentFile)
        {
            if (documentFile != null && documentFile.Length > 0)
            {
                // Convert the uploaded file into a byte array
                using (var memoryStream = new MemoryStream())
                {
                    await documentFile.CopyToAsync(memoryStream);
                    var fileContent = memoryStream.ToArray(); // Convert the file to byte[]

                    // Create the Document object with the uploaded file's details
                    var document = new Documents
                    {
                        FileName = documentFile.FileName,
                        FileType = documentFile.ContentType,
                        FileContent = fileContent // Store file as binary data
                    };

                    // Save the document in the database
                    _context.Documents.Add(document);
                    await _context.SaveChangesAsync();
                }

                return RedirectToAction("DisplayDocuments");
            }

            return View();
        }

        [HttpGet]
        public IActionResult DisplayDocuments()
        {
            var documents = _context.Documents.ToList(); // Fetch all documents from the database
            return View(documents);
        }

        [HttpGet]
        public FileResult DownloadDocument(int id)
        {
            var document = _context.Documents.Find(id);
            if (document == null)
            {
                return null;
            }

            // Return the document file as a downloadable file
            return File(document.FileContent, document.FileType, document.FileName);
        }

    }
}
