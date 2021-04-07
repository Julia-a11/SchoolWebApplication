//using SchoolBusinessLogic.BindingModel;
//using SchoolBusinessLogic.HelperModel;
//using SchoolBusinessLogic.Interface;
//using SchoolBusinessLogic.ViewModel;
//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace SchoolBusinessLogic.BusinessLogic
//{
//    public class ReportLogic
//    {
//        private readonly ISocietyStorage _societyStorage;

//        private readonly ILessonStorage _lessonStorage;

//        private readonly IPaymentStorage _paymentStorage;

//        public ReportLogic(ISocietyStorage societyStorage, ILessonStorage lessonStorage, IPaymentStorage paymentStorage)
//        {
//            _societyStorage = societyStorage;
//            _lessonStorage = lessonStorage;
//            _paymentStorage = paymentStorage;
//        }

//        public List<ReportViewModel> GetLesson(ReportBindingModel model)
//        {
//            var society = _societyStorage.GetFullList();

//            var lessson = _lessonStorage.GetFullList();

//            var list = new List<ReportViewModel>();

//            foreach (var lesson in society)
//            {
//                var record = new ReportViewModel
//                {
//                    LesssonName = lesson.SocietyName,
//                    Societies = new List<SocietyViewModel>(),
//                };
//                //foreach (var society in lessson)
//                //{
                    
//                //}
//                list.Add(record);
//            }
//            return list;
//        }


//        public List<ReportViewModel> GetOrders(ReportBindingModel model)
//        {
//            return _orderStorage.GetFilteredList(new OrderBindingModel
//            {
//                DateFrom = model.DateFrom,
//                DateTo = model.DateTo
//            })
//                .Select(x => new ReportViewModel
//                {
//                    DateCreate = x.DateCreate,
//                    SecureName = x.SecureName,
//                    Count = x.Count,
//                    Sum = x.Sum,
//                    Status = x.Status

//                })
//                .ToList();
//        }

//        // Сохранение компонент в файл-Word
//        public void SaveSecuresToWordFile(ReportBindingModel model)
//        {
//            SaveToWord.CreateDoc(new WordInfo
//            {
//                FileName = model.FileName,
//                Title = "Список занятий",
//                Societies = GetLesson()
//            }) ;
//        }

//        // Сохранение компонент с указаеним продуктов в файл-Excel
//        public void SaveSecureComponentToExcelFile(ReportBindingModel model)
//        {
//            SaveToExcel.CreateDoc(new ExcelInfo
//            {
//                FileName = model.FileName,
//                Title = "Список компонентов",
//                SecureComponents = GetSecureComponent()
//            });
//        }

//        // Сохранение заказов в файл-Pdf
//        [Obsolete]
//        public void SaveOrdersToPdfFile(ReportBindingModel model)
//        {
//            SaveToPdf.CreateDoc(new PdfInfo
//            {
//                FileName = model.FileName,
//                Title = "Список заказов",
//                DateFrom = model.DateFrom.Value,
//                DateTo = model.DateTo.Value,
//                Orders = GetOrders(model)
//            });
//        }
//    }
//}
