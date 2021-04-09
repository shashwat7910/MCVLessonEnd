using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Models;
using MVCLessonEnd;
using MVCLessonEnd.Models;

namespace MVCLessonEnd.Controllers
{
    public class SubjectModelsController : Controller
    {
        private readonly IBaseRepository<SubjectModel> repo;

        public SubjectModelsController(IBaseRepository<SubjectModel> repo)
        {
            this.repo = repo;
        }

        // GET: SubjectModels
        public async Task<IActionResult> Index()
        {
            return View(await repo.GetAll());
        }

        // GET: SubjectModels/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subjectModel = await repo.Get(id);
            if (subjectModel == null)
            {
                return NotFound();
            }

            return View(subjectModel);
        }

        // GET: SubjectModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SubjectModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,ID")] SubjectModel subjectModel)
        {
            if (ModelState.IsValid)
            {
                await repo.Insert(subjectModel);
                return RedirectToAction(nameof(Index));
            }
            return View(subjectModel);
        }

        // GET: SubjectModels/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subjectModel = await repo.Get(id);
            if (subjectModel == null)
            {
                return NotFound();
            }
            return View(subjectModel);
        }

        // POST: SubjectModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Name,ID")] SubjectModel subjectModel)
        {
            if (id != subjectModel.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await repo.Update(subjectModel);
                return RedirectToAction(nameof(Index));
            }
            return View(subjectModel);
        }

        // GET: SubjectModels/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subjectModel = await repo.Get(id);
                
            if (subjectModel == null)
            {
                return NotFound();
            }

            return View(subjectModel);
        }

        // POST: SubjectModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            
            await repo.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
