using MmsApi.Models;
using MmsDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace MmsApi.Controllers
{
    public class LoginController : HomeController<UserEntity>
    {
        public LoginController(Repository<UserEntity> repo) : base(repo) { }
        public IHttpActionResult Post(UserModel userModel)
        {
            try
            {
                AppContext context = new AppContext();
                LoginModel model = new LoginModel();
                UserEntity user = new UserEntity() { Id = 1, IsAdmin = true, Name = "Irma", Username = "Irma", Password = "Irma" };
                //User user = new Repository<User>(context).Get().ToList().Where(x => x.Username == userModel.Username).FirstOrDefault();
                if (user == null)
                {
                    return NotFound();
                }
                else
                {
                    if (user.IsAdmin) model.isAdmin = true;
                    else model.isAdmin = false;
                }
                return Ok(model);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}