using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using eVisitor_mvcnet5.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eVisitor_mvcnet5.Controllers
{
    public class ImageController : Controller
    {

        private AppDbContext2 _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public ImageController(AppDbContext2 ctx, IWebHostEnvironment hostEnvironment)
        {
            _context = ctx;
            this._hostEnvironment = hostEnvironment;
        }


        // GET: Image
        public async Task<IActionResult> Index()
        { 
            //return await Task.Run(() => View());
            return View(await _context.tbl_Images.ToListAsync());
        }

        // Detail
        public async Task<IActionResult> Details(int? id)
        { 
            if(id == null)
            {
                return NotFound();
            }

            var ImgModel = await _context.tbl_Images.FirstOrDefaultAsync( i => i.ImageId == id);
            if(ImgModel == null)
            {
                return NotFound();
            }

            return View(ImgModel);
        }

        public IActionResult Create()
        { 
            return View();
        }

        // GET: Image/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ImageId,Title,ImageFile")] m_cls_Image imageModel)
        {
            if (ModelState.IsValid)
            {
                //Save image to wwwroot/image
                string wwwRootPath = _hostEnvironment.WebRootPath;
                string fileName = Path.GetFileNameWithoutExtension(imageModel.ImageFile.FileName);
                string extension = Path.GetExtension(imageModel.ImageFile.FileName);
                imageModel.ImageName=fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                string path = Path.Combine(wwwRootPath + "/image/", fileName);
                using (var fileStream = new FileStream(path,FileMode.Create))
                {
                    await imageModel.ImageFile.CopyToAsync(fileStream);
                }
                //Insert record
                _context.Add(imageModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(imageModel);
        }


        public IActionResult Edit()
        { 
            return View();
        }



        //
        public async Task<IActionResult> Delete(int? id)
        { 
            if(id==null)
            {
                return NotFound();
            }

            var ImageModel = await _context.tbl_Images.FirstOrDefaultAsync( i => i.ImageId == id);
            if(ImageModel == null)
            {
                return NotFound();
            }

            return View(ImageModel);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var imageModel = await _context.tbl_Images.FindAsync(id);

            //delete image from wwwroot/image
            var imagePath = Path.Combine(_hostEnvironment.WebRootPath,"image",imageModel.ImageName);
            
            if (System.IO.File.Exists(imagePath))
                System.IO.File.Delete(imagePath);
            //delete the record
            _context.tbl_Images.Remove(imageModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        private bool ImageModelExists(int id)
        {
            return _context.tbl_Images.Any(e => e.ImageId == id);
        }

        //
    }

}