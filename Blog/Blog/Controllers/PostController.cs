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
        
        public ActionResult CreatePost()
        {
            return View();
        }

        public ActionResult ViewPost()
        {
            return View();
        }

        public ActionResult ListPosts()
        {
            var model = new List<PostViewModel>();
            //getting list with the blog posts from the database
            using (var dbContext = new BlogDbContext())
            {
                //getting list with all post rows
                List<Post> blogPosts = dbContext.Posts.Select(row => row).ToList();

                //filling all the post rows into the view model
                foreach (Post post in blogPosts)
                {
                    //creating empty view model object
                    var currentPost = new PostViewModel();

                    //set values to the view model object from the DB
                    currentPost.PostContent = post.PostContent;
                    currentPost.DatePost = post.DatePost;
                    currentPost.PostId = post.PostId;
                    currentPost.PostTitle = post.PostTitle;
                    currentPost.Counter = post.Counter;

                    //add the view model object to the list, which should be provided to the view
                    model.Add(currentPost);
                }
            }

            return View(model);
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

                int newPostId = newPost.PostId;

                //go to the list view
                return RedirectToAction("ViewPost");
            }
        }


    }

}