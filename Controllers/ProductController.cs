using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SoperStore2.Data;
using SuperStore2.Models;

namespace SuperStore2.Controllers
{
    public class ProductController : Controller
    {
        private ApplicationDBContext _context;

        public ProductController(ApplicationDBContext context)
        {
            _context = context;

		}

        private readonly List<Product> listpro = new List<Product>();
        private readonly List<Catagory> listcat = new List<Catagory>();

        public ProductController()
        {

            Catagory cateogry = new Catagory(1, "a");
            listcat.Add(cateogry);

            Catagory cateogry2 = new Catagory(2, "B");
            listcat.Add(cateogry2);

            Product items1 = new Product(1, "boots", 50.0, 1);
            listpro.Add(items1);

            Product items2 = new Product(2, "clothes", 100.0, 1);
            listpro.Add(items2);

            Product items3 = new Product(2, "shirt", 100.0, 2);
            listpro.Add(items3);
        }
        // GET: Product
        public async Task<IActionResult> Index()
        {
            var applicationDBContext = _context.Product.Include(p => p.catagory);
            return View(await applicationDBContext.ToListAsync());
        }

        // GET: Product/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Product
                .Include(p => p.catagory)
                .FirstOrDefaultAsync(m => m.ProID == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Product/Create
        public IActionResult Create()
        {
            ViewData["CatID"] = new SelectList(_context.Category, "CatID", "CatName");
            return View();
        }

        // POST: Product/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProID,ProName,ProPrice,CatID")] Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CatID"] = new SelectList(_context.Category, "CatID", "CatName", product.CatID);
            return View(product);
        }

        // GET: Product/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Product.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            ViewData["CatID"] = new SelectList(_context.Category, "CatID", "CatName", product.CatID);
            return View(product);
        }

        // POST: Product/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProID,ProName,ProPrice,CatID")] Product product)
        {
            if (id != product.ProID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.ProID))
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
            ViewData["CatID"] = new SelectList(_context.Category, "CatID", "CatName", product.CatID);
            return View(product);
        }

        // GET: Product/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Product
                .Include(p => p.catagory)
                .FirstOrDefaultAsync(m => m.ProID == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Product.FindAsync(id);
            if (product != null)
            {
                _context.Product.Remove(product);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return _context.Product.Any(e => e.ProID == id);
        }

       
        


        public IActionResult Index(string sort, string type)
        {
            if (sort != null)
            {
                if (sort.Equals("byprice"))
                {
                    return View(
                         listpro.OrderByDescending(s => s.ProPrice)
                        );
                }
                else if (sort.Equals("byname"))
                {

                    return View(
                        listpro.OrderByDescending(s => s.ProName)
                       );
                }

            }
            else if (type != null)
            {
                List<Product> items = listpro.Where(s =>
                  s.ProName.Contains(type)
                ).ToList();

                return View(items);

            }


            ViewBag.total = Double.Parse(listpro.Sum(s => s.ProPrice).ToString());

            return View(listpro);
        }

        public IActionResult serachByCat(string? catename)
        {
            int? IDcat = listcat.
                Where(c => c.CatName.Equals(catename))
                .FirstOrDefault().CatID;

            List<Product> lst_ = listpro.Where(i => i.CatID == IDcat).ToList();

            return View();
        }
    }
}
