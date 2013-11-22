using System.Web.Mvc;
using PersonalSite.Entities;
using PersonalSite.Interfaces;

namespace PersonalSite.Controllers
{
    public class SkillController : Controller
    {
        private readonly IDataRepository _dataRepository;

        public SkillController()
        {

        }


        public SkillController(IDataRepository dataRepository)
        {
            _dataRepository = dataRepository;
        }
        //
        // GET: /Skill/

        [HttpPost]
        public JsonResult Delete(int? id)
        {
            var skill = _dataRepository.Query<Skill>(x => x.Id == id);
            _dataRepository.Delete(skill);

            return Json(id);
        }

        [HttpPost]
        public JsonResult Add(string name)
        {
            if (name == null)
                name = "error";


            var id = _dataRepository.Save(new Skill
            {
                Name = name,
                User = _dataRepository.Query<User>(x => x.Mail == User.Identity.Name)
            });


            return Json(new { Id = id, Name = name });
        }

    }
}
