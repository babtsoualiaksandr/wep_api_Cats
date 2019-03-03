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
    public class CatsController : ControllerBase
    {
        private readonly WgContext _context;

        public CatsController(WgContext context)
        {
            _context = context;
            if (_context.Cats.Count() == 0)
            {
                Console.WriteLine("Котиков нет");
            }
        }



        // GET /cats
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cat_colors_info>>> Get()
        {
            List<Cat> cats = await _context.Cats.ToListAsync();
            List<Cat_colors_info> list_cat_Colors_Info = new List<Cat_colors_info>();
            var colorgroup = from cat in cats
                             group cat by cat.Color into g
                             select new Cat_colors_info() { Color = g.Key, Count = g.Count() };

            if (_context.Cat_colors_infs.Count() != 0)
            {

                foreach (var item in _context.Cat_colors_infs)
                {
                    _context.Cat_colors_infs.Remove(item);

                }

               
            }

            if (_context.Cats_stats.Count() != 0)
            {

                foreach (var item in _context.Cats_stats)
                {
                    _context.Cats_stats.Remove(item);

                }

                await _context.SaveChangesAsync();
            }


            foreach (var item in colorgroup)
            {
                _context.Cat_colors_infs.Add(new Cat_colors_info() { Color = item.Color, Count = item.Count });

            }
            await _context.SaveChangesAsync();

            Cats_stat cats_Stat = new Cats_stat();
            int count = _context.Cats.Count();
            int[] tail = _context.Cats.Select(t=>t.Tail_length).ToArray();
            int[] whiskers= _context.Cats.Select(t=>t.Whiskers_length).ToArray();
            

            //средняя длина хвоста
            cats_Stat.tail_length_mean = tail.Average();
            //средняя длина усов,
            cats_Stat.whiskers_length_mean = tail.Average();
            //медиана длин хвостов,
            int numberCount = count;
            int halfIndex = count / 2;
            var sortedNumbers = tail.OrderBy(n => n);
            if ((numberCount % 2) == 0)
            {
                cats_Stat.tail_length_median = ((sortedNumbers.ElementAt(halfIndex) +
                    sortedNumbers.ElementAt((halfIndex - 1))) / 2);
            }
            else
            {
                cats_Stat.tail_length_median = sortedNumbers.ElementAt(halfIndex);
            }
            //медиана длин усов,
            numberCount = count;
            halfIndex = count / 2;
            sortedNumbers = whiskers.OrderBy(n => n);
            if ((numberCount % 2) == 0)
            {
                cats_Stat.whiskers_length_median = ((sortedNumbers.ElementAt(halfIndex) +
                    sortedNumbers.ElementAt((halfIndex - 1))) / 2);
            }
            else
            {
                cats_Stat.whiskers_length_median = sortedNumbers.ElementAt(halfIndex);
            }

            //мода длин хвостов,

            cats_Stat.tail_length_mode = tail.OrderBy(c => c).ToArray();


            //мода длин усов.
            cats_Stat.whiskers_length_mode = whiskers.OrderBy(c => c).ToArray();


            _context.Cats_stats.Add(cats_Stat);
            await _context.SaveChangesAsync();

            return colorgroup.ToList();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

       


    }
}
