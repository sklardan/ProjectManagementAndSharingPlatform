using DPSP_DAL;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DPSP_BLL
{
    public class UserService : IUserService
    {
        private readonly DboContext _context;

        public UserService(DboContext context)
        {
            _context = context;
        }

        public User CreateUser(string aspUserId, string role)
        {
            var dbUser = _context.Users.Add(new User
            {
                AspNetUsersId = aspUserId,
                Status = UserStatus.Active,
                Roles = _context.Roles.Where(x => x.Name == role).ToList(),
                Projects = _context.Projects.Where(x => x.IsActive && role == nameof(RoleType.Employee)).ToList()
            });
            _context.SaveChanges();
            return dbUser;

        }

        public User AddNames(User dbUser, string FirstName, string LastName)
        {
            using (var db = new DboContext())
            {
                dbUser.FirstName = FirstName;
                dbUser.LastName = LastName;
                db.SaveChanges();
                return dbUser;
            }

        }

        public User AddProject(User dbUser, IList<Guid> projectIds)
        {
            using (var db = new DboContext())
            {
                foreach (var item in projectIds)
                {
                    db.Users.FirstOrDefault(x => x.Id == dbUser.Id).Projects.Add(db.Projects.FirstOrDefault(x => x.Id == item));
                }
                db.SaveChanges();
                return dbUser;
            }
        }

        public User GetUser(string aspUserId)
        {
            return (_context.Users.FirstOrDefault(x => x.AspNetUsersId == aspUserId));

            using (var db = _context)
            {
                return (db.Users.FirstOrDefault(x => x.AspNetUsersId == aspUserId));
            }
        }
    }
}
