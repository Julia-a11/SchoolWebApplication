using SchoolBusinessLogic.BindingModel;
using SchoolBusinessLogic.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolBusinessLogic.Interface
{
    public interface ILessonStorage
    {
        List<LessonViewModel> GetFullList();

        List<LessonViewModel> GetFilteredList(LessonBindingModel model);

        LessonViewModel GetElement(LessonBindingModel model);
    }
}
