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
    public class ClassModelsController : Controller
    {
        private readonly IBaseRepository<ClassModel> _repo;

        public ClassModelsController(IBaseRepository<ClassModel> repo)
        {
           _repo = repo;
        }

        // GET: ClassModels
        public async Task<IActionResult> Index()
        {
            return View(await _repo.GetAll());
        }

        // GET: ClassModels/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var classModel = await _repo.Get(id);
            if (classModel == null)
            {
                return NotFound();
            }

            return View(classModel);
        }

        // GET: ClassModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ClassModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Class,section,totstundents,ID")] ClassModel classModel)
        {
            if (ModelState.IsValid)
            {

                await _repo.Insert(classModel);
                return RedirectToAction(nameof(Index));
            }
            return View(classModel);
        }

        // GET: ClassModels/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var classModel = await _repo.Get(id);
            if (classModel == null)
            {
                return NotFound();
            }
            return View(classModel);
        }

        // POST: ClassModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Class,section,totstundents,ID")] ClassModel classModel)
        {
            if (id != classModel.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _repo.Update(classModel);
                return RedirectToAction(nameof(Index));
            }
            return View(classModel);
        }

        // GET: ClassModels/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var classModel = await _repo.Get(id);
            if (classModel == null)
            {
                return NotFound();
            }

            return View(classModel);
        }

        // POST: ClassModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {

            await _repo.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
