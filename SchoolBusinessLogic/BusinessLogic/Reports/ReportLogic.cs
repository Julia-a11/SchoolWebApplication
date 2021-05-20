using SchoolBusinessLogic.BindingModel;
using SchoolBusinessLogic.HelperModel;
using SchoolBusinessLogic.Interface;
using SchoolBusinessLogic.ViewModel;
using System.Collections.Generic;

namespace SchoolBusinessLogic.BusinessLogic
{
    public class ReportLogic
    {
        private readonly ISocietyStorage _societyStorage;

        private readonly ICostStorage _costStorage;

        public ReportLogic(ISocietyStorage societyStorage, ICostStorage costStorage)
        {
            _societyStorage = societyStorage;
            _costStorage = costStorage;
        }

        private List<SocietyViewModel> GetSocietyWithCosts(ReportBindingModel model)
        {
            var list = _societyStorage.GetFilteredList(new SocietyBindingModel
            {
                DateFrom = model.DateFrom,
                DateTo = model.DateTo,
                ClientId = model.ClientId
            });

            foreach (var society in list)
            {
                society.Costs = _costStorage.GetFilteredList(new CostBindingModel
                {
                    DateFrom = model.DateFrom.Value,
                    DateTo = model.DateTo.Value,
                    SocietyId = society.Id
                });
            }
            return list;
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
                Societies = GetSocietyWithCosts(model)
            });
        }
    }
}
