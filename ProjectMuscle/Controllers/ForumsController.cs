using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectMuscle.Data;
using ProjectMuscle.Models;

namespace ProjectMuscle.Controllers
{
    public class ForumsController : Controller
    {
        private readonly ForumsDatabaseContext _context;

        public ForumsController(ForumsDatabaseContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            //List<Forum> forumList = await ApplicationDbContext
            /*
            Forum testForum = new Forum();
            testForum.BoardList = new List<ForumBoard>();
            ForumBoard testBoard = new ForumBoard();
            testForum.BoardList.Add(testBoard);

            ViewData["TestForum"] = testForum;
            */
            return View();
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var forum = await _context.ForumTable.FirstOrDefaultAsync(m => m.ForumID == id);
            if (forum == null)
            {
                return NotFound();
            }

            return View(forum);
        }
    }
}