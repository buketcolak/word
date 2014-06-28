using System.Web.Mvc;
using WordSaver.Business;
using WordSaver.Business.Data;
using WordSaver.Presentation.Models;

namespace WordSaver.Presentation.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View(new WordModel());
        }

        [HttpPost]
        public ActionResult Index(WordModel model)
        {
            var service = new WordService(new Repository<Word>());

            var isSaved =service.Save(model.Name);

            if (isSaved)
            {
                model.Name = string.Empty;
                ViewBag.Message = "Kelime Kaydedildi!";
            }
            else
            {
                ViewBag.Message = "Bir sorun oluştu, tekrar deneyiniz";
            }

            return View(model);
        }
    }
}