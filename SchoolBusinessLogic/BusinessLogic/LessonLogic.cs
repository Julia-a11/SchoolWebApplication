using SchoolBusinessLogic.BindingModel;
using SchoolBusinessLogic.Interface;
using SchoolBusinessLogic.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolBusinessLogic.BusinessLogic
{
    public class LessonLogic
    {
        private readonly ILessonStorage _lessonStorage;

        public LessonLogic(ILessonStorage lessonStorage)
        {
            _lessonStorage = lessonStorage;
        }

        public List<LessonViewModel> Read(LessonBindingModel model)
        {
            if (model == null)
            {
                return _lessonStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<LessonViewModel> { _lessonStorage.GetElement(model) };
            }
            return _lessonStorage.GetFilteredList(model);
        }
    }
}
