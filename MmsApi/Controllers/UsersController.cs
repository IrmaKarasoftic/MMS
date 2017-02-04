using MmsApi.Models;
using MmsDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace MmsApi.Controllers
{
    public class UsersController : HomeController<User>
    {
        public UsersController(Repository<User> repo) : base(repo) { }

        public IHttpActionResult Get()
        {
            try
            {
                var users = Repository.Get().ToList().Select(x => Factory.Create(x)).ToList();
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
                User user = Repository.Get(id);
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
                User user = Parser.Create(model, Repository.HomeContext());
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
                User user = Repository.Get(id);
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