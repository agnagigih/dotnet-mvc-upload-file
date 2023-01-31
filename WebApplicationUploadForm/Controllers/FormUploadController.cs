using Microsoft.AspNetCore.Mvc;
using WebApplicationUploadForm.Repository;

namespace WebApplicationUploadForm.Controllers
{
    public class FormUploadController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public FormUploadController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<FormUploadEntity> uploads = _context.FormUploadEntities.ToList();
            return View(uploads);
        }

        [HttpGet]
        public IActionResult Create()
        {
            FormUploadEntity formUpload = new FormUploadEntity();
            return View(formUpload);
        }

        [HttpPost]
        public IActionResult Create(FormUploadEntity formUpload)
        {
            string uniqueFileName = UploadedFile(formUpload);
            formUpload.ImageUrl = uniqueFileName;
            _context.Add(formUpload);
            _context.SaveChanges();
            return Redirect("Index");
        }

        private string UploadedFile(FormUploadEntity formUpload)
        {
            string uniqueFileName = null;
            if (formUpload.Image != null)
            {
                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + formUpload.Image.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    formUpload.Image.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }
    }
}
