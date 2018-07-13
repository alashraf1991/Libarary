using Library.Models.Catalog;
using LibraryData;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Library.Controllers
{
    public class CatalogController : Controller
    {
        private ILibraryAsset _assets;
        public CatalogController(ILibraryAsset assets)
        {
            _assets = assets;
        }

        public IActionResult Index()
        {                      
            var assetModels = _assets.GetAll();

            var listingResult = assetModels
                .Select(res => new AssetIndexListingModel
                {
                    Id = res.Id,
                    Imageurl = res.ImageUrl,
                    AuthorOrDirector = _assets.GetAuthorOrDirector(res.Id),
                    DeweyCallNumber = _assets.GetDeweyIndex(res.Id),
                    Title = res.Title,
                    Type = _assets.GetType(res.Id)
                });

            var model = new AssetIndexModel()
            {
                Assets = listingResult
            };          
            return View(model);
        }

    }
}
