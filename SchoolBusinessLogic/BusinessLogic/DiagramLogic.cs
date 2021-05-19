

using SchoolBusinessLogic.BindingModel;
using SchoolBusinessLogic.ViewModel;
using System;
using System.Linq;

namespace SchoolBusinessLogic.BusinessLogic
{
    public class DiagramLogic
    {
        private readonly SocietyLogic _societyLogic;

        public DiagramLogic(SocietyLogic societyLogic)
        {
            _societyLogic = societyLogic;
        }

        public DiagramViewModel GetDiagramByLessonsCount(int societyId)
        {
            return new DiagramViewModel
            {
                Title = "Диаграмма количества занятий",
                ColumnName = "Занятие",
                ValueName = "Количество занятий",
                Data = _societyLogic.Read(new SocietyBindingModel
                {
                    Id = societyId
                }).FirstOrDefault().Lessons.Select(rec => new Tuple<string, decimal>(rec.LessonName, rec.LessonCount)).ToList()
            };
        }

        public DiagramViewModel GetDiagramByLessonsPrice(int societyId)
        {
            return new DiagramViewModel
            {
                Title = "Диаграмма стоимости занятий",
                ColumnName = "Занятие",
                ValueName = "Стоимость занятия",
                Data = _societyLogic.Read(new SocietyBindingModel
                {
                    Id = societyId
                }).FirstOrDefault().Lessons.Select(rec => new Tuple<string, decimal>(rec.LessonName, rec.Price)).ToList()
            };
        }
    }
}
