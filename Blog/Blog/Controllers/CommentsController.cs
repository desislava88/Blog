﻿using Blog.DAL;
using Blog.DAL.Entities;
using Blog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;


namespace Blog.Controllers
{
    public class CommentsController : Controller
    {
        // GET: Comments
       public ActionResult ShowAll(PostViewModel postModel)
        {
            var commentViewModel = new CommentViewModel();

            commentViewModel.CommentContent = "bhhbfhdbfhdbfhd"; 

            return PartialView("_Comments", commentViewModel);
        }

        [HttpPost]
        public ActionResult InsertComment(string commentContent, int postId)
        {
            using (var dbContext = new BlogDbContext())
            {
                //creating new entity
                var newComment = new Comment();

                newComment.CommentContent = commentContent;
                newComment.DateComment = DateTime.Now;
                newComment.PostId = postId;
                newComment.UserId = User.Identity.GetUserId();

                //adding this entity to Posts entity
                dbContext.Comments.Add(newComment);

                //saving the the changes to the database
                dbContext.SaveChanges();

            }
            return Content("OK");
        }
    }
}