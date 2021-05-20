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
    public class LessonStorage : ILessonStorage
    {
        public static LessonViewModel CreateViewModel(Lesson lesson)
        {
            return new LessonViewModel
            {
                Id = lesson.Id,
                LessonName = lesson.LessonName,
                LessonCount = lesson.LessonCount,
                Price = lesson.Price,
                EmployeeId = lesson.EmployeeId,
                EmployeeName = lesson.Employee?.User.Name
            };
        }

        public List<LessonViewModel> GetFullList()
        {
            using (var context = new SchoolDataBase())
            {
                return context.Lessons
                    .Include(rec => rec.Employee)
                    .ThenInclude(rec => rec.User)
                    .Select(CreateViewModel)
                    .ToList();
            }
        }

        public List<LessonViewModel> GetFilteredList(LessonBindingModel model)
        {
            if (model == null)
            {
                return null;
            }

            using (var context = new SchoolDataBase())
            {
                return context.Lessons
                    .Include(rec => rec.Employee)
                    .ThenInclude(rec => rec.User)
                    .Where(rec => rec.LessonName.Contains(model.LessonName))
                    .Select(CreateViewModel)
                    .ToList();
            }
        }

        public LessonViewModel GetElement(LessonBindingModel model)
        {
            if (model == null)
            {
                return null;
            }

            using (var context = new SchoolDataBase())
            {
                var lesson = context.Lessons
                    .Include(rec => rec.Employee)
                    .ThenInclude(rec => rec.User)
                    .FirstOrDefault(rec => rec.LessonName == model.LessonName ||
                    rec.Id == model.Id);

                return lesson != null ? CreateViewModel(lesson) : null;
            }
        }
    }
}
