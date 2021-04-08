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
                Sum = cost.Sum
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
    }
}
