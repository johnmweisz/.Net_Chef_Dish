    using System.ComponentModel.DataAnnotations;
    using System.Collections.Generic;
    using System;
    namespace ChefDish.Models
    {
        public class Dish
        {
            [Key]
            public int DishId {get;set;}
            [Required]
            [MinLength(3)]
            [Display(Name = "Name:")]
            public string DishName {get;set;}
            [Required]
            [Range(0, Int32.MaxValue, ErrorMessage="Calories cannot be negative")]
            [Display(Name = "Calories:")]
            public int Calories {get;set;}
            [Required]
            [Range(1, 5)]
            [Display(Name = "Tastiness:")]
            public int Tastiness {get;set;}
            [Required]
            [StringLength(100)]
            [Display(Name = "Description:")]
            public string Description {get;set;}
            [Required]
            [Display(Name = "Chef:")]
            public int ChefId {get;set;}
            public Chef Chef {get;set;}
            public DateTime CreatedAt {get;set;} = DateTime.Now;
            public DateTime UpdatedAt {get;set;} = DateTime.Now;
        }
    }