using People.IoC;
using People.Models;
using People.Repositories;
using System.Web.Mvc;

namespace People.Controllers
{
    public class PeopleController : Controller
    {
        protected readonly IRepository _repo;
        protected readonly IRequests _requests;
        protected readonly IPeopleLookup _lookups;

        public PeopleController(IRepository repo, IRequests requests, IPeopleLookup lookups)
        {
            _repo = repo;
            _requests = requests;
            _lookups = lookups;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var result = _repo.GetAll<PersonFormModel>();
            ViewBag.Successes = _requests.Successes;
            ViewBag.Failures = _requests.Failures;
            return View(result);
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.Successes = _requests.Successes;
            ViewBag.Failures = _requests.Failures;
            return View(new PersonFormModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PersonFormModel person)
        {
            
            _repo.Save<PersonFormModel>(person.IDNumber, person);
            ViewBag.Successes = _requests.Successes;
            ViewBag.Failures = _requests.Failures;
            return Redirect("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Search(PersonFormModel person)
        {

            PersonFormModel _returnResult = _lookups.GetPersonSearch(person, _requests);

            if (_returnResult.AdocFeedBack.Length != 0)
                ModelState.AddModelError("SearchIdNumber", _returnResult.AdocFeedBack);

            ViewBag.Successes = _requests.Successes;
            ViewBag.Failures = _requests.Failures;
            return View("Create", _returnResult);
            
        }

    }
}
