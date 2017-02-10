using MmsApi.Models;
using MmsDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace MmsApi.Controllers
{
    public class ImagesController : HomeController<Image>
    {
        public ImagesController(Repository<Image> repo) : base(repo) { }

        public IHttpActionResult Get()
        {
            try
            {
                var images = new List<Image>();
                Image i1 = new Image() { Id = 1, Description = "Slika1", Location = "../images/image1.jpg" };
                Image i2 = new Image() { Id = 1, Description = "Slika2", Location = "../images/image2.jpg" };
                Image i3 = new Image() { Id = 1, Description = "Slika3", Location = "../images/image3.jpg" };
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
                Image image = Repository.Get(id);
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

        public IHttpActionResult Put(ImageModel model, int id)
        {
            if (model != null)
            {
                Image image = Parser.Create(model, Repository.HomeContext());
                if (image != null)
                {
                    Repository.Update(image, id);
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
                Image image = Repository.Get(id);
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