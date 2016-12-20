using Blog.DAL;
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
    public class PostController : Controller
    {
        // GET: Post
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult CreatePost()
        {
            return View();
        }

        public ActionResult ViewPost()
        {
            return View();
        }

        //public ActionResult SubmitPost(PostViewModel model)
        //{
        //    return View();

        //}

        [HttpPost]
        public ActionResult SubmitPost(PostViewModel model)
        {
            using (var dbContext = new BlogDbContext())
            {
                //creating new entity
                var newPost = new Post();
                newPost.UserId = User.Identity.GetUserId();
                newPost.PostTitle = model.PostTitle;
                newPost.PostContent = model.PostContent;
                newPost.DatePost = DateTime.Now;
                newPost.Counter = 0;

                //adding this entity to Posts entity
                dbContext.Posts.Add(newPost);

                //saving the the changes to the database
                dbContext.SaveChanges();

                //go to the list view
                return RedirectToAction("ViewPost");
            }
        }


    }

}