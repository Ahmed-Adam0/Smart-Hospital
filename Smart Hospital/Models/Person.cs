﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Smart_Hospital.Models
{
    public class Person
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        [MinLength(3,ErrorMessage ="so small")]
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string  Gender { get; set; }
        public virtual Address address { get; set; }
        [ForeignKey("address")]
        public int AddressId { get; set; }

        [RegularExpression(@"^01[0-2|5]\\d{1,8}$",ErrorMessage ="Please input a valid number!")]
        public string Phone { get; set; }

        
        public string Email { get; set; }

    }
}
