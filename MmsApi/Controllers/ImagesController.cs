using MmsApi.Helpers;
using MmsApi.Models;
using MmsDb;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace MmsApi.Controllers
{
    public class ImagesController : HomeController<ImageEntity>
    {
        public ImagesController(Repository<ImageEntity> repo) : base(repo) { }

        public IHttpActionResult Get()
        {
            try
            {
                var images = new List<ImageEntity>();
                ImageEntity i1 = new ImageEntity() { Id = 1, Description = "Slika1", Location = "../images/image1.jpg" };
                ImageEntity i2 = new ImageEntity() { Id = 1, Description = "Slika2", Location = "../images/image2.jpg" };
                ImageEntity i3 = new ImageEntity() { Id = 1, Description = "Slika3", Location = "../images/image3.jpg" };
                images.Add(i1);
                images.Add(i2);
                images.Add(i3);

               // var images = Repository.Get().ToList().Select(x => Factory.Create(x)).ToList();
                return Ok(images);
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
                ImageEntity image = Repository.Get(id);
                if (image != null) return Ok(image);
                return NotFound();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        public IHttpActionResult Post(ImageModel image)
        {
            if (image != null)
            {
                try
                {
                    string addToImage = "../images/";
                    string location = string.Concat(addToImage, image.Location);
                    image.Location = location;
                    Repository.Insert(Parser.Create(image, Repository.HomeContext()));
                    return Ok(image);
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
            return NotFound();
        }

        public IHttpActionResult Put(int id, ImageModel model)
        {
            if (model != null)
            {
                ImageEntity image = Parser.Create(model, Repository.HomeContext());
                if (image != null)
                {
                    Image newImage = Image.FromFile("C:\\Users\\irmaka\\Documents\\Visual Studio 2015\\Projects\\MMS\\MmsWebSite\\images\\image1.jpg");
                    ImageHelper.SaveJpeg(image.Location,newImage,30);
                    return Ok(Factory.Create(image));
                }
                return NotFound();
            }
            return NotFound();
        }

        public IHttpActionResult Delete(int id)
        {
            try
            {
                ImageEntity image = Repository.Get(id);
                if (image != null)
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