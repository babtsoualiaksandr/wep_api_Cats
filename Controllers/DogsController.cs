using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using wg_backend.Models;

namespace wg_backend.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DogsController : ControllerBase
    {
        private readonly WgContext _context;

        public DogsController(WgContext context)
        {
            _context = context;
            if (_context.Dogs.Count() == 0)
            {
                Console.WriteLine("Собачек нет");
            }
        }

        // GET /dogs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cat_colors_info>>> Get()
        {
            List<Dog> cats = await _context.Dogs.ToListAsync();
            List<Cat_colors_info> list_cat_Colors_Info = new List<Cat_colors_info>();
            var colorgroup = from cat in cats
                             group cat by cat.Color into g
                             select new Cat_colors_info() { Color = g.Key, Count = g.Count() };

foreach (var item in colorgroup)
{
    Console.WriteLine(item.Color+" = "+item.Count);
    
}
            return colorgroup.ToList();
        }
    }
}
