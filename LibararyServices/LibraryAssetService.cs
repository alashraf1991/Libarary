using LibraryData;
using LibraryData.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LibraryServices
{
    public class LibraryAssetService : ILibraryAsset
    {

        private LibraryContext _contex;

        public LibraryAssetService(LibraryContext context)
        {
            _contex = context;
        }

        public void Add(LibraryAssets newAsset)
        {
            _contex.Add(newAsset);
            _contex.SaveChanges();
        }

        public IEnumerable<LibraryAssets> GetAll()
        {
            return _contex.libraryAssets
                .Include(asset => asset.StatusId)
                .Include(asset => asset.Location);
        }

        public LibraryAssets GetById(int id)
        {
            return _contex.libraryAssets
               .Include(asset => asset.StatusId)
               .Include(asset => asset.Location)
               .FirstOrDefault(asset => asset.Id == id);
        }

        public LibraryBranch GetCurrentLocation(int id)
        {
            return _contex.libraryAssets.FirstOrDefault(asset => asset.Id == id).Location;
        }

        public string GetDeweyIndex(int id)
        {
            if (_contex.Books.Any(book => book.Id == id))
            {
                return _contex.Books.FirstOrDefault(book => book.Id == id).DeweyIndex;
            }

            else return "";
        }

        public string GetIsbn(int id)
        {
            if (_contex.Books.Any(book => book.Id == id))
            {
                return _contex.Books.FirstOrDefault(a => a.Id == id).ISBN;
            }

            return "";
        }

        public string GetTitle(int id)
        {
            return _contex.libraryAssets
                .FirstOrDefault(a => a.Id == id).Title;
        }

        public string GetType(int id)
        {
            var book = _contex.libraryAssets.OfType<Book>()
                .Where(b => b.Id == id);

            return book.Any() ? "Book" : "Video" ?? "";
        }

        public string GetAuthorOrDirector(int id)
        {
            var isBook = _contex.LibraryBranches.OfType<Book>()
                  .Where(asset => asset.Id == id).Any();

            return isBook ?
                _contex.Books.FirstOrDefault(book => book.Id == id).Author :
                _contex.Videos.FirstOrDefault(vid => vid.Id == id).Director
                ?? "Unknown";
        }
    }
}
