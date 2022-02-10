using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Store.Web.Models
{
    public class GameViewModel : IEqualityComparer<GameViewModel>
    {
        [HiddenInput]
        public int? Id { get; set; }

        [Required, Display(Name = "Название")]
        public string Name { get; set; }

        [Required, Display(Name = "Цена")]
        [DataType(DataType.Currency)]
        public float Price { get; set; }

        public float Discont { get; set; }

        [Required, Display(Name = "Разработчик")]
        public string Developer { get; set; }

        public string[] Screenshots { get; set; }

        [Required]
        public ICollection<IFormFile> Files { get; set; }

        public bool IsApproved { get; set; }
        
        public int DeveloperId { get; set; }

        public bool Equals(GameViewModel x, GameViewModel y)
        {
            return x.Id == y.Id;
        }

        public int GetHashCode([DisallowNull] GameViewModel obj)
        {
            return obj.Id.GetHashCode();
        }
    }
}
