using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Web.Models
{
    public class GameViewModel
    {
        [HiddenInput]
        public int Id { get; set; }

        [Display(Name = "Название")]
        public string Name { get; set; }

        [Display(Name = "Цена")]
        [DataType(DataType.Currency)]
        public int Price { get; set; }

        public int Discont { get; set; }

        [Display(Name = "Разработчик")]
        public string Developer { get; set; }
    }
}
