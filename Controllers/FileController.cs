using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace filewebapp.Controllers
{
    public class FileController : Controller
    {
        private IWebHostEnvironment _env;
        private string _path;

        public FileController(IWebHostEnvironment env)
        {
            _env = env;
            _path = Path.Combine(_env.ContentRootPath, "TextFiles");
        }

        public IActionResult Index()
        {
            return View(getFileNames());
        }

        public IActionResult Content(string id)
        {
            string currentFilename = null;
            string[] filenames = getFileNames();
            foreach (string filename in filenames)
            {
                if (Path.GetFileNameWithoutExtension(filename).Equals(id))
                {
                    currentFilename = filename;
                    break;
                }
            }

            // string filename = $"{id}.txt";
            string path = Path.Combine(_path, currentFilename);
            StreamReader sr = new StreamReader(path, Encoding.UTF8);
            string content = sr.ReadToEnd();

            ViewData["title"] = id;
            ViewData["content"] = content;

            return View();
        }

        private string[] getFileNames()
        {
            string[] files = Directory.GetFiles(_path);

            string[] filenames = new string[files.Length];
            for (int i = 0; i < filenames.Length; ++i)
            {
                filenames[i] = Path.GetFileName(files[i]);
            }

            return filenames;
        }
    }
}