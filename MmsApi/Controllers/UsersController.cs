using MmsApi.Models;
using MmsDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace MmsApi.Controllers
{
    public class UsersController : HomeController<UserEntity>
    {
        public UsersController(Repository<UserEntity> repo) : base(repo) { }

        public IHttpActionResult Get()
        {
            try
            {
                UserEntity user = new UserEntity() { Id = 1, IsAdmin = true, Name = "Amra", Username = "Amra", Password = "Amra" };
                UserEntity user2 = new UserEntity() { Id = 1, IsAdmin = true, Name = "Nino", Username = "Nino", Password = "Nino" };
                UserEntity user3 = new UserEntity() { Id = 1, IsAdmin = true, Name = "Amir", Username = "Amir", Password = "Amir" };
                var users = new List<UserEntity>();
                users.Add(user);
                users.Add(user2);
                users.Add(user3);

                //var users = Repository.Get().ToList().Select(x => Factory.Create(x)).ToList();
                return Ok(users);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        public IHttpActionResult Get(int id)
        {
            try
            {
                UserEntity user = Repository.Get(id);
                if (user != null) return Ok(user);
                return NotFound();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        public IHttpActionResult Post(UserModel user)
        {
            if (user != null)
            {
                try
                {
                    Repository.Insert(Parser.Create(user, Repository.HomeContext()));
                    return Ok(user);
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
            return NotFound();
        }

        public IHttpActionResult Put(UserModel model, int id)
        {
            if (model != null)
            {
                UserEntity user = Parser.Create(model, Repository.HomeContext());
                if (user != null)
                {
                    Repository.Update(user, id);
                    return Ok(Factory.Create(user));
                }
                return NotFound();
            }
            return NotFound();
        }

        public IHttpActionResult Delete(int id)
        {
            try
            {
                UserEntity user = Repository.Get(id);
                if (user != null)
                {
                    Repository.Delete(id);
                    return Ok();
                }
                return NotFound();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}