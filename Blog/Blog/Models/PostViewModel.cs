using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Blog.Models
{
    public class PostViewModel
    {
        [Required]
        public int PostId { get; set; }

        [Required]
        [Display(Name = "Title")]
        public string PostTitle { get; set; }

        [Required]
        [Display(Name = "Content")]
        public string PostContent { get; set; }

        [Required]
        [Display(Name = "Posted on")]
        public DateTime DatePost { get; set; }

        [Required]
        [Display(Name = "Views")]
        public int Counter { get; set; }

        [Required]
        public string UserId { get; set; }

    }
}