using System.Globalization;
using GameZone.Data;
using GameZone.Data.Models;
using GameZone.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using static GameZone.Common.ValidationConstants;

namespace GameZone.Controllers
{
    [Authorize]
    public class GameController(GameZoneDbContext context) : Controller
    {
        //private readonly GameZoneDbContext context;

        //public GameController(GameZoneDbContext _context)
        //{
        //    context = _context;
        //}

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var model = await context.Games
                .Where(g => !g.IsDeleted)
                .Select(g => new GameInfoModel()
                {
                    Id = g.Id,
                    Genre = g.Genre.Name,
                    ImageUrl = g.ImageUrl,
                    Publisher = g.Publisher.UserName,
                    ReleasedOn = g.ReleasedOn.ToString(GameReleasedOnFormat),
                    Title = g.Title
                })
                .AsNoTracking()
                .ToListAsync();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var model = new GameAddViewModel();
            model.Genres = await GetGenres();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(GameAddViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Genres = await GetGenres();
                return View(model);
            }

            if (!DateTime.TryParseExact(model.ReleasedOn, GameReleasedOnFormat, CultureInfo.InvariantCulture, 
                    DateTimeStyles.None, out DateTime validDateFormat))
            {
                model.Genres = await GetGenres();
                return View(model);
            }

            Game game = new Game()
            {
                Title = model.Title,
                GenreId = model.GenreId,
                PublisherId = GetUserId(),
                Description = model.Description,
                ImageUrl = model.ImageUrl,
                ReleasedOn = validDateFormat
            };

            await context.Games.AddAsync(game);
            await context.SaveChangesAsync();

            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var model = await context.Games
                .Where(g => g.Id == id)
                .Where(g => !g.IsDeleted)
                .AsNoTracking()
                .Select(g => new GameAddViewModel()
                {
                    Description = g.Description,
                    GenreId = g.GenreId,
                    ImageUrl = g.ImageUrl,
                    ReleasedOn = g.ReleasedOn.ToString(GameReleasedOnFormat),
                    Title = g.Title
                })
                .FirstOrDefaultAsync();

            model.Genres = await context.Genres
                .Select(g => new GameGenreViewModel()
                {
                    Id = g.Id,
                    Name = g.Name,
                })
                .AsNoTracking()
                .ToListAsync();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(GameAddViewModel model, int id)
        {
            if (!ModelState.IsValid)
            {
                model.Genres = await GetGenres();
                return View(model);
            }

            if (!DateTime.TryParseExact(model.ReleasedOn, GameReleasedOnFormat, CultureInfo.InvariantCulture,
                    DateTimeStyles.None, out DateTime validDateFormat))
            {
                model.Genres = await GetGenres();
                return View(model);
            }

            Game? entity = await context.Games.FindAsync(id);

            if (entity == null || entity.IsDeleted)
            {
                return BadRequest();
            }

            entity.Title = model.Title;
            entity.GenreId = model.GenreId;
            entity.PublisherId = GetUserId();
            entity.Description = model.Description;
            entity.ImageUrl = model.ImageUrl;
            entity.ReleasedOn = validDateFormat;

            await context.SaveChangesAsync();

            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        public async Task<IActionResult> MyZone()
        {
            var user = GetUserId();

            var model = await context.Games
                .Where(g => !g.IsDeleted)
                .Where(gg => gg.GamersGames.Any(gr => gr.GamerId == user))
                .Select(g => new GameInfoModel()
                {
                    Id = g.Id,
                    Genre = g.Genre.Name,
                    ImageUrl = g.ImageUrl,
                    Publisher = g.Publisher.UserName,
                    ReleasedOn = g.ReleasedOn.ToString(GameReleasedOnFormat),
                    Title = g.Title
                })
                .AsNoTracking()
                .ToListAsync();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> AddToMyZone(int id)
        {
            Game? entity = await context.Games
                .Where(g => g.Id == id)
                .Include(g => g.GamersGames)
                .FirstOrDefaultAsync();

            if (entity == null || entity.IsDeleted)
            {
                return BadRequest();
            }

            string user = GetUserId();

            if (entity.GamersGames.All(g => g.GamerId != user))
            {
                entity.GamersGames.Add(new GamerGame()
                {
                    GamerId = user,
                    GameId = entity.Id
                });

                await context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(MyZone));
        }

        [HttpGet]
        public async Task<IActionResult> StrikeOut(int id)
        {
            Game? entity = await context.Games
                .Where(g => g.Id == id)
                .Include(g => g.GamersGames)
                .FirstOrDefaultAsync();

            if (entity == null || entity.IsDeleted)
            {
                return BadRequest();
            }

            string user = GetUserId();
            GamerGame? gamerGame = entity.GamersGames.FirstOrDefault(gr => gr.GamerId == user);

            if (gamerGame != null)
            {
                entity.GamersGames.Remove(gamerGame);

                await context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(MyZone));
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var model = await context.Games
                .Where(g => g.Id == id)
                .Where(g => !g.IsDeleted)
                .AsNoTracking()
                .Select(g => new GameDetailsViewModel()
                {
                    Id = g.Id,
                    Description = g.Description,
                    Genre = g.Genre.Name,
                    ImageUrl = g.ImageUrl,
                    ReleasedOn = g.ReleasedOn.ToString(GameReleasedOnFormat),
                    Title = g.Title,
                    Publisher = g.Publisher.UserName
                })
                .FirstOrDefaultAsync();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            return View();
        }

        private string GetUserId()
        {
            return this.User.FindFirstValue(ClaimTypes.NameIdentifier);
        }

        private async Task<IEnumerable<GameGenreViewModel>> GetGenres()
        {
            return await context.Genres
                .AsNoTracking()
                .Select(g => new GameGenreViewModel()
                {
                    Id = g.Id,
                    Name = g.Name
                })
                .ToListAsync();
        }
    }
}
