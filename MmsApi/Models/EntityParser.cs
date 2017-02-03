using MmsDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MmsApi.Models
{
    public class EntityParser
    {
        public User Create(UserModel user, AppContext context)
        {
            return new User()
            {
                Id = user.Id,
                Name = user.Name,
                Username = user.Username,
                Password = user.Password,
                IsAdmin = user.IsAdmin
            };
        }

        public Image Create(ImageModel image, AppContext context)
        {
            return new Image()
            {
                Id = image.Id,
                Description = image.Description,
                Location = image.Location
            };
        }
    }
}