using SchoolBusinessLogic.BindingModel;
using SchoolBusinessLogic.HelperModel;
using SchoolBusinessLogic.Interface;
using SchoolBusinessLogic.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SchoolBusinessLogic.BusinessLogic
{
    public class ReportLogic
    {
        private readonly ISocietyStorage _societyStorage;

        private readonly ILessonStorage _lessonStorage;

        private readonly IPaymentStorage _paymentStorage;

        private readonly ICostStorage _costStorage;

        public ReportLogic(ISocietyStorage societyStorage, ILessonStorage lessonStorage, IPaymentStorage paymentStorage, ICostStorage costStorage)
        {
            _societyStorage = societyStorage;
            _lessonStorage = lessonStorage;
            _paymentStorage = paymentStorage;
            _costStorage = costStorage;
        }

        // Сохранение компонент в файл-Word
        public void SaveSocietiesToWordFile(ReportBindingModel model)
        {
            SaveToWordLogic.CreateDoc(new ListInfo
            {
                FileName = model.FileName,
                Title = "Список занятий",
                Societies = _societyStorage.GetFullList().Where(rec => model.SocietyId.Contains(rec.Id)).ToList()
            });
        }

        // Сохранение компонент с указаеним продуктов в файл-Excel
        public void SaveSocietiesToExcelFile(ReportBindingModel model)
        {
            SaveToExcelLogic.CreateDoc(new ListInfo
            {
                FileName = model.FileName,
                Title = "Список занятий",
                Societies = _societyStorage.GetFullList().Where(rec => model.SocietyId.Contains(rec.Id)).ToList()
            });
        }

        // Сохранение заказов в файл-Pdf
        [Obsolete]
        public void SaveSocietiesToPdfFile(ReportBindingModel model)
        {
            SaveToPdfLogic.CreateDoc(new PdfInfo
            {
                FileName = model.FileName,
                Title = "Список кружков",
                DateFrom = model.DateFrom.Value,
                DateTo = model.DateTo.Value,
                Societies = _societyStorage.GetFilteredList(new SocietyBindingModel
                {
                    DateTo = model.DateTo,
                    DateFrom = model.DateFrom
                })
            });
        }
    }
}
