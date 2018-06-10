using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Homework8.Model;
using Homework8.DAL.Abstract;
using System.Data.Entity;

namespace Homework8.DAL.Concrete
{
    public class ArtistRepository : IArtistRepository
    {
        ArtistContext context;
        public ArtistRepository(ArtistContext context)
        {
            this.context = context;
        }

        public IEnumerable<Artist> All => context.Artists;

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Artist Find(int? id)
        {
            throw new NotImplementedException();
        }

        public void InsertOrUpdate(Artist artist)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}