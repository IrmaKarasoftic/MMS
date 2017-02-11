using MmsDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MmsApi.Models
{
    public class ModelFactory
    {
        public UserModel Create(UserEntity user)
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

        public ImageModel Create(ImageEntity image)
        {
            return new ImageModel()
            {
                Id = image.Id,
                Description = image.Description,
                Location = image.Location,
                Ratio = 0
            };
        }
    }
}