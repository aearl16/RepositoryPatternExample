using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Homework8.Model;

namespace Homework8.DAL.Abstract
{
    public interface IArtistRepository : IDisposable
    {
        IEnumerable <Artist> All { get; }
        Artist Find(int? id);
        void InsertOrUpdate(Artist artist);
        void Delete(int id);
        void Save();
    }
}