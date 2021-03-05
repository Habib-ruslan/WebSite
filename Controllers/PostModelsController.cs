using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using _1.Data;
using _1.Models;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;

namespace _1.Controllers
{
    public class PostModelsController : Controller
    {
        private readonly PostContext _context;
        //ImageContext _ImContext;
        IWebHostEnvironment _appEnvironment;

        public PostModelsController(PostContext context, IWebHostEnvironment appEnvironment/*ImageContext ImContext*/)
        {
            _context = context;
            _appEnvironment = appEnvironment;
            //_ImContext = ImContext;
        }

        // GET: PostModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.PostModels.Include(f=> f.Images).ToListAsync());
        }

        // GET: PostModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var postModel = await _context.PostModels.Include(f=> f.Images)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (postModel == null)
            {
                return NotFound();
            }

            return View(postModel);
        }

        // GET: PostModels/Create
        public IActionResult Create()
        {
            return View();
        }
        /*
        [HttpPost]
        public async Task<IActionResult> Create([Bind("PostModelId,Name,Id,Image")] PostModel Post, IFormFile Image) 
        { 
            if (ModelState.IsValid)
                {
                if (Image != null)

                {
                    if (Image.Length > 0)
                    {
                        using (var fs1 = Image.OpenReadStream())
                        using (var ms = new MemoryStream())
                        {
                            fs1.CopyTo(ms);
                            Post.Image = ms.ToArray();
                        }
                        _context.Add(Image);
                        await _context.SaveChangesAsync();
                        return RedirectToAction("Create");
                    }
                }
            }
            return View(Post);
  
        }
        */
        // POST: PostModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Text,Images")] PostModel postModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(postModel);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            return View(postModel);
        }

        // GET: PostModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var postModel = await _context.PostModels.Include(f => f.Images)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (postModel == null)
            {
                return NotFound();
            }
            return View(postModel);
        }

        // POST: PostModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, PostModel postModel, IFormFile[] UploadedFile)
        {
            if (id != postModel.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    foreach (IFormFile uploadedFile in UploadedFile)
                    {
                        if (uploadedFile != null)
                        {
                            string path = "/Images/" + uploadedFile.FileName;
                            using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
                            {
                                await uploadedFile.CopyToAsync(fileStream);
                            }
                            ImageModel file = new ImageModel { Name = uploadedFile.FileName, Path = path, PostModelId = id };
                            _context.Images.Add(file);
                        }
                        _context.Update(postModel);
                        await _context.SaveChangesAsync();
                    }
                    _context.Update(postModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PostModelExists(postModel.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(postModel);
        }


        // GET: PostModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var postModel = await _context.PostModels
                .FirstOrDefaultAsync(m => m.Id == id);
            if (postModel == null)
            {
                return NotFound();
            }

            return View(postModel);
        }

        // POST: PostModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var postModel = await _context.PostModels.FindAsync(id);
            _context.PostModels.Remove(postModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PostModelExists(int id)
        {
            return _context.PostModels.Any(e => e.Id == id);
        }

        
        //      Изображения
        [HttpPost, ActionName("DeleteImage")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteIm(int id)
        {
            var imageModel = await _context.Images.FindAsync(id);
            _context.Images.Remove(imageModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
