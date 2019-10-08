    using System.ComponentModel.DataAnnotations;
    using System.Collections.Generic;
    using System;
    namespace ChefDish.Models
    {
        public class ChefsDish
        {
            public List<Chef> Chefs {get;set;}
            public Dish Dish {get;set;}
        }

    }