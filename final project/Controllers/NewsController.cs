using final_project.Models;
using Microsoft.AspNetCore.Mvc;
using final_project.ViewModels;


namespace final_project.Controllers
{
    public class NewsController : Controller
    {
        private readonly AppDbContext _context;

        public NewsController(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }

        public IActionResult Index()
        {
            var NewsModel = _context.News.Select(x => new NewsModel()
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Status = x.Status

            }).ToList();
            return View(NewsModel);
        }
        public IActionResult Detail(int id)
        {
            var NewsModel = _context.News.Select(x => new NewsModel()
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Status = x.Status

            }).SingleOrDefault(x => x.Id == id);
            return View(NewsModel);

        }
        public IActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Insert(NewsModel model)
        {
            var News = new News();
            News.Name = model.Name;
            News.Description = model.Description;
            News.Status = model.Status;
            News.CategoryId = model.CategoryId;
            News.CategoryName = model.CategoryName;


            _context.News.Add(News);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            var NewsModel = _context.News.Select(x => new NewsModel()
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Status = x.Status

            }).SingleOrDefault(x => x.Id == id);
            return View(NewsModel);
        }

        [HttpPost]
        public IActionResult Edit(NewsModel model)
        {
            var News = _context.News.SingleOrDefault(x => x.Id == model.Id);
            News.Name = model.Name;
            News.Description = model.Description;
            News.Status = model.Status;

            _context.News.Update(News);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var NewsModel = _context.News.Select(x => new NewsModel()
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Status = x.Status

            }).SingleOrDefault(x => x.Id == id);
            return View(NewsModel);
        }

        [HttpPost]
        public IActionResult Delete(NewsModel model)
        {
            var product = _context.News.SingleOrDefault(x => x.Id == model.Id);
            _context.News.Remove(product);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }


        public IActionResult ChangeStatus(int id, bool st)
        {
            var News = _context.News.SingleOrDefault(x => x.Id == id);
            News.Status = st;
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
        public IActionResult IPage()
        {
            var NewsModel = _context.News.Select(x => new NewsModel()
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Status = x.Status

            }).ToList();
            return View(NewsModel);
        }
    }
}
