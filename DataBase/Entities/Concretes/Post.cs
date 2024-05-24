using DataBase.Entities.Abstracts;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Entities.Concretes
{
    public class Post:Entity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ?ImgUrl { get; set; }
        [NotMapped]
        public IFormFile ImgFile { get; set; }
    }
}
