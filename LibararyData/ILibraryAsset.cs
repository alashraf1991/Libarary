using System;
using System.Collections.Generic;
using System.Text;
using LibraryData.Models;
namespace LibraryData
{
    public interface ILibraryAsset
    {
        IEnumerable<LibraryAssets> GetAll();
        LibraryAssets GetById(int id);

        void Add(LibraryAssets newAsset);

        string GetAuthorOrDirector(int id);
        string GetDeweyIndex(int id);
        string GetType(int id);
        string GetTitle(int id);
        string GetIsbn(int id);

        LibraryBranch GetCurrentLocation(int id);
    }
}
