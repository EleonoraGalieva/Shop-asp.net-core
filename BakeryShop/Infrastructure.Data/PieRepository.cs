using Domain.Core;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Data
{
    public class PieRepository : IPieRepository
    {
        private readonly AppDbContext _appDbContext;
        public PieRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Pie> AllPies
        {
            get
            {
                return _appDbContext.Pies.Include(c => c.Category);
            }
        }

        public IEnumerable<Pie> PiesOfTheWeek
        {
            get
            {
                return _appDbContext.Pies.Include(c => c.Category).Where(p => p.IsPieOfTheWeek);
            }
        }

        public void CreatePie(Pie pie)
        {
            _appDbContext.Pies.Add(pie);
            _appDbContext.SaveChanges();
        }

        public void DeletePie(Pie pie)
        {
            _appDbContext.Pies.Remove(pie);
            var items = _appDbContext.ShoppingCartItems.Where(p => p.Pie == pie);
            if (items != null)
            {
                foreach (var item in items)
                {
                    _appDbContext.ShoppingCartItems.Remove(item);
                }
            }
            _appDbContext.SaveChanges();
        }

        public Pie GetPieById(int pieId)
        {
            return _appDbContext.Pies.FirstOrDefault(p => p.PieId == pieId);
        }

        public void UpdatePie(Pie newPie)
        {
            var pie = _appDbContext.Pies.FirstOrDefault(p => p.PieId == newPie.PieId);
            if (pie != null)
            {
                pie.Name = newPie.Name;
                pie.ShortDescription = newPie.ShortDescription;
                pie.AllergyInfo = newPie.AllergyInfo;
                pie.CategoryId = newPie.CategoryId;
                pie.ImageThumbnailUrl = newPie.ImageThumbnailUrl;
                pie.ImageUrl = newPie.ImageUrl;
                pie.InStock = newPie.InStock;
                pie.IsPieOfTheWeek = newPie.IsPieOfTheWeek;
                pie.LongDescription = newPie.LongDescription;
                pie.Price = newPie.Price;
            }
            _appDbContext.SaveChanges();
        }
    }
}
