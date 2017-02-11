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
                var images = Repository.Get().ToList().Select(x => Factory.Create(x)).ToList();
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
                    var loc = AppDomain.CurrentDomain.BaseDirectory;
                    loc = loc.Substring(0, loc.Length - 8) + "\\MmsWebSite\\images\\" + image.Description+".jpg";
                    Image newImage = Image.FromFile(loc);
                    ImageHelper.SaveJpeg(image.Location, newImage, 1, image);
                    ImageHelper.SaveJpeg(image.Location, newImage, 30, image);
                    ImageHelper.SaveJpeg(image.Location, newImage, 50, image);
                    ImageHelper.SaveJpeg(image.Location, newImage, 70, image);
                    ImageHelper.SaveJpeg(image.Location, newImage, 90, image);
                    return Ok(image);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            return NotFound();
        }

        public IHttpActionResult Put(int id, ImageModel model)
        {
            if (model != null)
            {
                ImageModel imageToReturn = new ImageModel();
                imageToReturn.Description = "Compressed image";
                string loc = model.Location.Substring(0, model.Location.Length - 4);
                imageToReturn.Location = loc + "-" + model.Ratio + ".jpeg";
                if (imageToReturn != null)
                {
                    return Ok(imageToReturn);
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