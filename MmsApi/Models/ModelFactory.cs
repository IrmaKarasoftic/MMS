using MmsDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MmsApi.Models
{
    public class ModelFactory
    {
        public UserModel Create(User user)
        {
            return new UserModel()
            {
                Id = user.Id,
                Name = user.Name,
                Username = user.Username,
                Password = user.Password,
                IsAdmin = user.IsAdmin
            };
        }

        public ImageModel Create(Image image)
        {
            return new ImageModel()
            {
                Id = image.Id,
                Description = image.Description,
                Location = image.Location
            };
        }
    }
}