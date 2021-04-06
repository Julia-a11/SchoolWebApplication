using SchoolBusinessLogic.BindingModel;
using SchoolBusinessLogic.Interface;
using SchoolBusinessLogic.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolBusinessLogic.BusinessLogic
{
    public class PaymentLogic
    {
        public class PaymentBusinessLogic
        {
            private readonly IPaymentStorage _paymentStorage;

            public PaymentBusinessLogic(IPaymentStorage PaymentStorage)
            {
                _paymentStorage = PaymentStorage;
            }

            public List<PaymentViewModel> Read(PaymentBindingModel model)
            {
                if (model == null)
                {
                    return _paymentStorage.GetFullList();
                }
                if (model.Id.HasValue)
                {
                    return new List<PaymentViewModel> { _paymentStorage.GetElement(model) };
                }
                return _paymentStorage.GetFilteredList(model);
            }

            public void CreateOrUpdate(PaymentBindingModel model)
            {
                var element = _paymentStorage.GetElement(new PaymentBindingModel
                {
                    Sum = model.Sum
                });
                if (element == null)
                {
                    throw new Exception("Сумма не найдена");
                }
                if (model.Id.HasValue)
                {
                    _paymentStorage.Update(model);
                }
                else
                {
                    _paymentStorage.Insert(model);
                }
            }

            public void Delete(PaymentBindingModel model)
            {
                var element = _paymentStorage.GetElement(new PaymentBindingModel
                {
                    Id = model.Id
                });
                if (element == null)
                {
                    throw new Exception("Сумма не найдена");
                }
                _paymentStorage.Delete(model);
            }
        }
    }
}

