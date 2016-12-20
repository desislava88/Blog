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
        public string PostTitle { get; set; }

        [Required]
        public string PostContent { get; set; }

        [Required]
        public DateTime DatePost { get; set; }

        [Required]
        public int Counter { get; set; }

        [Required]
        public string UserId { get; set; }

    }
}