using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MmsApi.Models
{
    public class ImageModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public int Ratio { get; set; }
    }
}