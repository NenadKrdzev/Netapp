using eCinema.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace eCinema.Repository.Interface
{
    public interface IUserRepository
    {
        IEnumerable<eCinemaUser> GetAll();
        eCinemaUser Get(string id);
        void Insert(eCinemaUser entity);
        void Update(eCinemaUser entity);
        void Delete(eCinemaUser entity);
    }
}
