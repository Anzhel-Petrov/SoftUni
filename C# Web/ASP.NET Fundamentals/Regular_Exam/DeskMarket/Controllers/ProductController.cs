using System.Globalization;
using System.Security.Claims;
using DeskMarket.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DeskMarket.Data;
using DeskMarket.Data.Models;
using static DeskMarket.Common.ValidationConstants;

namespace DeskMarket.Controllers
{
    [Authorize]
    public class ProductController(ApplicationDbContext context) : Controller
    {
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var model = await context.Products
                .Where(p => !p.IsDeleted)
                .Select(p => new ProductViewModel()
                {
                    Id = p.Id,
                    ProductName = p.Name,
                    ImageUrl = p.ImageUrl,
                    Price = p.Price
                })
                .AsNoTracking()
                .ToListAsync();
            
            // var currentUserId = GetUserId();
            // var model = await context.Products.Where(p => !p.IsDeleted).
            //     Select(p => new ProductViewModel
            //     {
            //         Id = p.Id,
            //         ProductName = p.Name,
            //         Price = p.Price,
            //         ImageUrl = p.ImageUrl,
            //         IsSeller = p.SellerId == currentUserId,
            //         HasBought = context.ProductsClients.Any(x => x.ProductId == p.Id && x.ClientId == currentUserId)
            //     }).ToListAsync();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            //var categories = await _context.Categories
            //    .Select(g => new CategoryViewModel()
            //    {
            //        Id = g.Id,
            //        Name = g.Name
            //    })
            //    .ToListAsync();

            var model = new ProductAddViewModel()
            {
                Categories = await GetCategories()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(ProductAddViewModel model)
        {
            var categories = await GetCategories();

            if (categories.All(e => e.Id != model.CategoryId))
            {
                ModelState.AddModelError(nameof(model.CategoryId), "Category does not exist!");
            }

            if (!DateTime.TryParseExact(model.AddedOn, ProductAddedOnFormat, CultureInfo.InvariantCulture,
                    DateTimeStyles.None, out DateTime parseDateTime))
            {
                ModelState.AddModelError(nameof(model.AddedOn), "Added on date is not correct!");
            }

            if (!ModelState.IsValid)
            {
                model.Categories = await GetCategories();
                return View(model);
            }

            string currentUserId = GetUserId() ?? string.Empty;

            var adToAdd = new Product()
            {
                Name = model.ProductName,
                Description = model.Description,
                Price = model.Price,
                ImageUrl = model.ImageUrl,
                SellerId = currentUserId,
                AddedOn = parseDateTime,
                CategoryId = model.CategoryId
            };

            await context.Products.AddAsync(adToAdd);
            await context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var model = await context.Products
                .Where(p => p.Id == id)
                .AsNoTracking()
                .Select(p => new ProductEditViewModel()
                {
                    ProductName = p.Name,
                    Description = p.Description,
                    Price = p.Price,
                    ImageUrl = p.ImageUrl,
                    AddedOn = p.AddedOn.ToString(ProductAddedOnFormat),
                    CategoryId = p.CategoryId,
                    SellerId = p.SellerId
                })
                .FirstOrDefaultAsync();

            model.Categories = await GetCategories();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ProductEditViewModel model, int id)
        {
            var categories = await GetCategories();

            if (categories.All(c => c.Id != model.CategoryId))
            {
                ModelState.AddModelError(nameof(model.CategoryId), "Category does not exist!");
            }

            if (!DateTime.TryParseExact(model.AddedOn, ProductAddedOnFormat, CultureInfo.InvariantCulture,
                    DateTimeStyles.None, out DateTime parseDateTime))
            {
                ModelState.AddModelError(nameof(model.AddedOn), "Added on date is not correct!");
            }

            if (!ModelState.IsValid)
            {
                model.Categories = await GetCategories();
                return View(model);
            }

            string userId = GetUserId() ?? string.Empty;

            Product? product = await context.Products.FindAsync(id);

            if (product == null)
            {
                return BadRequest();
            }

            if (product.SellerId != userId)
            {
                return Unauthorized();
            }

            product.Name = model.ProductName;
            product.Description = model.Description;
            product.Price = model.Price;
            product.ImageUrl = model.ImageUrl;
            product.AddedOn = parseDateTime;
            product.CategoryId = model.CategoryId;
            
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Details), new { id });
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var model = await context.Products
                .Where(p => p.Id == id)
                .Where(p => !p.IsDeleted)
                .AsNoTracking()
                .Select(p => new ProductDeleteViewModel()
                {
                    Id = p.Id,
                    ProductName = p.Name,
                    Seller = p.Seller.UserName ?? string.Empty,
                    SellerId = p.SellerId
                })
                .FirstOrDefaultAsync();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(ProductDeleteViewModel model)
        {
            Product? product = await context.Products
                .Where(p => p.Id == model.Id)
                .Where(p => !p.IsDeleted)
                .FirstOrDefaultAsync();

            if (product == null)
            {
                return BadRequest();
            }

            string userId = GetUserId() ?? string.Empty;

            if (product.SellerId != userId)
            {
                return Unauthorized();
            }

            product.IsDeleted = true;

            await context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Cart()
        {
            var userId = GetUserId();

            var model = await context.Products
                .Where(p => !p.IsDeleted)
                .Where(p => p.ProductsClients.Any(pc => pc.ClientId == userId))
                .Select(p => new ProductCartViewModel()
                {
                    Id = p.Id,
                    ProductName = p.Name,
                    ImageUrl = p.ImageUrl,
                    Price = p.Price
                })
                .AsNoTracking()
                .ToListAsync();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddToCart(int id)
        {
            Product? productToAdd = await context.Products
                .Where(p => p.Id == id)
                .Include(p => p.ProductsClients)
                .FirstOrDefaultAsync();

            if (productToAdd == null || productToAdd.IsDeleted)
            {
                return BadRequest();
            }

            string userId = GetUserId() ?? string.Empty;
            bool isAlreadyAdded = await context.ProductsClients
                .AnyAsync(pc => pc.ClientId == userId && pc.ProductId == productToAdd.Id);

            if (isAlreadyAdded)
            {
                return RedirectToAction(nameof(Index));
            }

            productToAdd.ProductsClients.Add(new ProductClient()
            {
                ClientId = userId,
                ProductId = productToAdd.Id
            });

            await context.SaveChangesAsync();

            return RedirectToAction(nameof(Cart));
        }

        [HttpPost]
        public async Task<IActionResult> RemoveFromCart(int id)
        {
            Product? productToRemove = await context.Products
                .Where(p => p.Id == id)
                .Include(p => p.ProductsClients)
                .FirstOrDefaultAsync();

            if (productToRemove == null || productToRemove.IsDeleted)
            {
                return BadRequest();
            }

            string userId = GetUserId() ?? string.Empty;

            ProductClient? productClient = productToRemove.ProductsClients.FirstOrDefault(pc => pc.ClientId == userId);

            if (productClient != null)
            {
                productToRemove.ProductsClients.Remove(productClient);

                await context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Cart));
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var model = await context.Products
                .Where(p => p.Id == id)
                .Where(p => !p.IsDeleted)
                .AsNoTracking()
                .Select(g => new ProductDetailsViewModel()
                {
                    Id = g.Id,
                    ProductName = g.Name,
                    Description = g.Description,
                    CategoryName = g.Category.Name,
                    AddedOn = g.AddedOn.ToString(ProductAddedOnFormat),
                    ImageUrl = g.ImageUrl,
                    Price = g.Price,
                    Seller = g.Seller.UserName ?? string.Empty
                })
                .FirstOrDefaultAsync();

            return View(model);
        }

        private async Task<IEnumerable<CategoryViewModel>> GetCategories()
        {
            return await context.Categories
                .AsNoTracking()
                .Select(g => new CategoryViewModel()
                {
                    Id = g.Id,
                    Name = g.Name
                })
                .ToListAsync();
        }

        private string? GetUserId()
            => User.FindFirstValue(ClaimTypes.NameIdentifier);
    }
}
