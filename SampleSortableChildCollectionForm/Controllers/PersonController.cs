using System.Web.Mvc;
using System.Diagnostics;
//using MyToolkit.Html;
using SampleSortableChildCollectionForm.Extensions;
using SampleSortableChildCollectionForm.Models;
using SampleSortableChildCollectionForm.Models.Editors;

namespace SampleSortableChildCollectionForm.Controllers
{
    public class PersonController : Controller
    {
        public ActionResult Index()
        {
            return View(new PersonEditViewModel());
        }

        [HttpPost]
        public ActionResult Index(PersonEditViewModel viewModel)
        {
            // Custom validation
            foreach (var address in viewModel.Addresses)
            {
                if (address.Street.Length < 3)
                {
                    var path = CollectionEditorUtilities.GetItemPropertyPath("Addresses", 0, "Street");
                    ModelState.AddModelError(path, "MyCustomError");
                }
            }

            if (ModelState.IsValid)
            {
                // TODO: Save changes of viewModel.Addresses to database
                // Inspect viewModel and see that the addresses collection is sorted in the same order as they were left onthe form
                Debugger.Break();

                return RedirectToAction("Index");
            }
            else
                return View(viewModel);
        }

        public ActionResult GetAddressEditor()
        {
            return PartialView("Editors/_AddressEditorTable", new AddressEditorViewModel());
        }
    }
}