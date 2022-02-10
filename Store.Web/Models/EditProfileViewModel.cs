using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Web.Models
{
    public class EditProfileViewModel
    {
        [HiddenInput]
        public int Id { get; set; }

        [MaxLength(100)]
        public string Nickname { get; set; }

        public IFormFile File { get; set; }
    }
}
