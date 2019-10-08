    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Collections.Generic;
    using System;
    namespace ChefDish.Models
    {
        public class Chef
        {
            [Key]
            public int ChefId {get;set;}
            [Required]
            [MinLength(3)]
            [Display(Name = "First Name:")]
            public string FirstName {get;set;}
            [Required]
            [MinLength(3)]
            [Display(Name = "Last Name:")]
            public string LastName {get;set;}
            [CheckAge(18)]
            [Display(Name = "Age:")]
            [DataType(DataType.Date)]
            public DateTime Birthday {get;set;}
            [NotMapped]
            public int Age
            {
                get
                {
                    return (int)Math.Floor(((DateTime.Now - Birthday).TotalDays + 1)/365.2422);
                }
            }
            public List<Dish> Dishes {get;set;}

            public DateTime CreatedAt {get;set;} = DateTime.Now;
            public DateTime UpdatedAt {get;set;} = DateTime.Now;
        }
        
        public class CheckAgeAttribute : ValidationAttribute
        {
            private int _age;

            public CheckAgeAttribute(int age)
            {
                _age = age;
            }
            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                DateTime bday = (DateTime)value;
                DateTime today = DateTime.Today;
                double userAge = ((today - bday).TotalDays + 1)/365.2422;
                if(userAge < _age)
                {
                    return new ValidationResult($"You must be at least {_age} years old.");
                }
                return ValidationResult.Success;
            }
        }
    }