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

        public ReportLogic(ISocietyStorage societyStorage)
        {
            _societyStorage = societyStorage;
        }

        public void SaveSocietiesToWordFile(ReportBindingModel model)
        {
            SaveToWordLogic.CreateDoc(new ListInfo
            {
                FileName = model.FileName,
                Title = "Список занятий",
                Societies = _societyStorage.GetFilteredList(new SocietyBindingModel
                {
                    ClientId = model.ClientId,
                    SelectedSocieties = model.SelectedSocieties
                })
            });
        }

        public void SaveSocietiesToExcelFile(ReportBindingModel model)
        {
            SaveToExcelLogic.CreateDoc(new ListInfo
            {
                FileName = model.FileName,
                Title = "Список занятий",
                Societies = _societyStorage.GetFilteredList(new SocietyBindingModel 
                { 
                    ClientId = model.ClientId,
                    SelectedSocieties = model.SelectedSocieties
                })
            });
        }

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
                    DateFrom = model.DateFrom,
                    ClientId = model.ClientId
                })
            });
        }
    }
}
