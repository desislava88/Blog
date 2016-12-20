using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Blog.Models
{
    public class CommentViewModel
    {
        [Required]
        public int CommentId { get; set; }

        [Required]
        public string UserId { get; set; }

        [Required]
        public int PostId { get; set; }

        [Required]
        public string CommentContent { get; set; }

        [Required]
        public DateTime DateComment { get; set; }
    }
}