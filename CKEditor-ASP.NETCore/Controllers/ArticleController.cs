using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using CKEditor_ASP.NETCore.Data;
using CKEditor_ASP.NETCore.Models;

namespace CKEditor_ASP.NETCore.Controllers
{
    [Authorize]
    public class ArticleController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        //Constructor
        public ArticleController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }


        /************************************************************************************/
        ////Create Article
        //Method to display 'CreateArticle' page to update or create new article
        [HttpPost]
        public async Task<IActionResult> WriteArticle(UserArticle article)
        {
            string loggedInUserId = _userManager.GetUserId(User);
            article.UserId = loggedInUserId;

            if (article.ArticleId > 0)
                UpdateArticle(article);
            else
                CreateArticle(article);

            if (await SaveChanges())
                return RedirectToAction("AllArticles");
            else
                return View(article);
        }
        [HttpGet]
        public ActionResult<UserArticle> WriteArticle(int? id)
        {
            if (id == null)
            {
                return View(new UserArticle());
            }
            else
            {
                var article = GetArticleById((int)id);
                return View(article);
            }
        }
        //Method to create the Article
        public void CreateArticle(UserArticle article)
        {
            if (article == null)
            {
                throw new ArgumentNullException(nameof(article));
            }
            _context.UserArticles.Add(article);
        }

        //Method to update the Article
        public void UpdateArticle(UserArticle article)
        {
            _context.UserArticles.Update(article);
        }


        /************************************************************************************/
        ////Display all articles
        //Method to display all articles which is received from 'GetAllArticles' method
        public IActionResult AllArticles()
        {
            var articles = GetAllArticles();
            return View(articles);
        }

        //Method to get all articles in the database
        public IEnumerable<UserArticle> GetAllArticles()
        {
            return _context.UserArticles.ToList();
        }


        /************************************************************************************/
        ////Display single article
        //Method to view a single article on SingleArticleView
        public IActionResult SingleArticle(int id)
        {
            var article = GetArticleById(id);

            return View(article);
        }


        /************************************************************************************/
        ////Delete article
        //Method called by the view to delete the Article
        public async Task<IActionResult> RemoveArticle(int id)
        {
            DeleteArticle(id);
            await SaveChanges();
            return RedirectToAction("AllArticles");
        }

        //Method to delete the Article from the database
        public void DeleteArticle(int id)
        {
            _context.UserArticles.Remove(GetArticleById(id));
        }


        /************************************************************************************/
        ////Supportive methods
        //To get Articles by ArticleID
        public UserArticle GetArticleById(int id)
        {
            return _context.UserArticles.FirstOrDefault(a => a.ArticleId == id);
        }

        //Method to save the changes in the database
        public Task<bool> SaveChanges()
        {
            return Task.FromResult(_context.SaveChanges() >= 0);
        }
    }
}
