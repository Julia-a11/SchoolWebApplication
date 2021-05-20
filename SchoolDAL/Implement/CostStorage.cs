using Microsoft.EntityFrameworkCore;
using SchoolBusinessLogic.BindingModel;
using SchoolBusinessLogic.Interface;
using SchoolBusinessLogic.ViewModel;
using SchoolDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SchoolDAL.Implement
{
    public class CostStorage : ICostStorage
    {
        public static CostViewModel CreateViewModel(Cost cost)
        {
            return new CostViewModel
            {
                Id = cost.Id,
                Sum = cost.Sum,
                CostDate = cost.CostDate,
                Description = cost.Description,
            };
        }

        private CostViewModel CreateViewModelOnSociety(SocietyCost cost)
        {
            return new CostViewModel
            {
                Id = cost.Cost.Id,
                Sum = cost.Cost.Sum,
                CostDate = cost.Cost.CostDate,
                Description = cost.Cost.Description,
                AdditionalCost = cost.AdditionalCosts
            };
        }

        public List<CostViewModel> GetFullList()
        {
            using (var context = new SchoolDataBase())
            {
                return context.Costs
                    .Include(rec => rec.SocietyCosts)
                    .ThenInclude(rec => rec.Society)
                    .Select(CreateViewModel)
                    .ToList();
            }
        }

        public List<CostViewModel> GetFilteredList(CostBindingModel model)
        {
            using (var context = new SchoolDataBase())
            {
                return context.SocietyCosts
                    .Include(rec => rec.Cost)
                    .Include(rec => rec.Society)
                    .Where(rec => rec.Cost.CostDate.Date >= model.DateFrom.Date && rec.Cost.CostDate.Date <= model.DateTo.Date &&
                    rec.SocietyId == model.SocietyId)
                    .Select(CreateViewModelOnSociety)
                    .ToList();
            }
        }
    }
}