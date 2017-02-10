using MmsDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MmsApi.Models
{
    public class EntityParser
    {
        public UserEntity Create(UserModel user, AppContext context)
        {
            return new UserEntity()
            {
                Id = user.Id,
                Name = user.Name,
                Username = user.Username,
                Password = user.Password,
                IsAdmin = user.IsAdmin
            };
        }

        public ImageEntity Create(ImageModel image, AppContext context)
        {
            return new ImageEntity()
            {
                Id = image.Id,
                Description = image.Description,
                Location = image.Location
            };
        }
    }
}