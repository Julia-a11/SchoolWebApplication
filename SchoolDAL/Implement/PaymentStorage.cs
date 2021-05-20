using Microsoft.EntityFrameworkCore;
using SchoolBusinessLogic.BindingModel;
using SchoolBusinessLogic.Interface;
using SchoolBusinessLogic.ViewModel;
using SchoolDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SchoolDAL.Implement
{
    public class PaymentStorage : IPaymentStorage
    {
        private Payment CreateModel(PaymentBindingModel model, Payment payment)
        {
            payment.LessonId = model.LessonId;
            payment.Sum = model.Sum;
            payment.PaymentDate = model.PaymentDate;
            payment.ClientId = model.ClientId;
            return payment;
        }

        private PaymentViewModel CreateViewModel(Payment payment)
        {
            return new PaymentViewModel
            {
                Id = payment.Id,
                LessonId = payment.LessonId,
                LessonName = payment.Lesson.LessonName,
                Sum = payment.Sum,
                FullSum = payment.Lesson.Price,
                PaymentDate = payment.PaymentDate,
                ClientId = payment.ClientId
            };
        }

        public List<PaymentViewModel> GetFullList()
        {
            using (var context = new SchoolDataBase())
            {
                return context.Payments
                    .Include(rec => rec.Lesson)
                    .Include(rec => rec.Client)
                    .ThenInclude(rec => rec.User)
                    .Select(CreateViewModel)
                    .ToList();
            }
        }

        public List<PaymentViewModel> GetFilteredList(PaymentBindingModel model)
        {
            if (model == null)
            {
                return null;
            }

            using (var context = new SchoolDataBase())
            {
                return context.Payments
                    .Include(rec => rec.Lesson)
                    .Include(rec => rec.Client)
                    .ThenInclude(rec => rec.User)
                    .Where(rec => rec.ClientId == model.ClientId)
                    .Select(CreateViewModel)
                    .ToList();
            }
        }

        public PaymentViewModel GetElement(PaymentBindingModel model)
        {
            if (model == null)
            {
                return null;
            }

            using (var context = new SchoolDataBase())
            {
                var payment = context.Payments
                    .Include(rec => rec.Lesson)
                    .Include(rec => rec.Client)
                    .ThenInclude(rec => rec.User)
                    .FirstOrDefault(rec => rec.Id == model.Id);

                return payment != null ? CreateViewModel(payment) : null;
            }
        }

        public void Delete(PaymentBindingModel model)
        {
            using (var context = new SchoolDataBase())
            {
                var payment = context.Payments.FirstOrDefault(rec => rec.Id == model.Id);

                if (payment == null)
                {
                    throw new Exception("Кружок не найден");
                }

                context.Payments.Remove(payment);
                context.SaveChanges();
            }
        }

        public void Insert(PaymentBindingModel model)
        {
            using (var context = new SchoolDataBase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        model.PaymentDate = DateTime.Now;
                        context.Payments.Add(CreateModel(model, new Payment()));
                        context.SaveChanges();

                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        public void Update(PaymentBindingModel model)
        {
            using (var context = new SchoolDataBase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        var payment = context.Payments.FirstOrDefault(rec => rec.Id == model.Id);

                        if (payment == null)
                        {
                            throw new Exception("Кружок не найден");
                        }

                        CreateModel(model, payment);
                        context.SaveChanges();

                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }
    }
}
