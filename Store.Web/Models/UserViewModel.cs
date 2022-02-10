using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Web.Models
{
    public class UserViewModel
    {
        [HiddenInput]
        public int? Id { get; set; }

        [Required, MaxLength(100)]
        public string Nickname { get; set; }

        [Required, MaxLength(50)]
        public string Login { get; set; }

        [Display(Name = "Roles")]
        [Required, MinLength(1)]
        public int[] RoleIds { get; set; }
        public IEnumerable<SelectListItem> Roles { get; set; }

        public string Password { get; set; }

        public string Salt { get; set; }

        public float Balance { get; set; }

        public string Avatar { get; set; }

        public IFormFile File { get; set; }
    }
}
