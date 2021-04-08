using SchoolBusinessLogic.BindingModel;
using SchoolBusinessLogic.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolBusinessLogic.Interface
{
    public interface ICostStorage
    {
        List<CostViewModel> GetFullList();
    }
}
