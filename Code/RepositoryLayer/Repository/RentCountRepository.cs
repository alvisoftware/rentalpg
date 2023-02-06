using Domain_Layer.Data;
using DomainLayer.Models;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.CustomeModel;
using RepositoryLayer.IRepository;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Repository
{
    public class RentCountRepository<T> : IRentCountRepository<T> where T : class
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private DbSet<T> values;
        public RentCountRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
            values = _applicationDbContext.Set<T>();
        }

        public void AddRentDetails(List<RentDetails> listofrentdetails)
        {
            _applicationDbContext.rentTables.AddRange(listofrentdetails);
            _applicationDbContext.SaveChanges();
        }

        public List<RentCountModel> RentCalculation(RentCountModel rentCountModel)
        {
            List<RentCountModel> rentCounts = new List<RentCountModel>();
            var date = rentCountModel.startdate;// DateTime.ParseExact(rentCountModel.startdate.ToShortDateString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
            var enddate = rentCountModel.enddate;// DateTime.ParseExact(rentCountModel.enddate.ToShortDateString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
            string amount = rentCountModel.amount.ToString();
            var startOfWeek = GetStartOfWeek(date);

            while (enddate > startOfWeek)
            {
                DateTime endOfWeekDate = startOfWeek.AddDays(6);
                rentCounts.Add(new RentCountModel() { startdate = startOfWeek, enddate = endOfWeekDate, amount = amount });
                startOfWeek = endOfWeekDate.AddDays(1);
            }
            return rentCounts;
        }

        public void SaveChanges()
        {
            _applicationDbContext.SaveChanges();
        }
        DateTime GetStartOfWeek(DateTime date)
        {
            return date.AddDays(-(date.DayOfWeek - DayOfWeek.Monday)).Date;
        }
    }
}



////List<RentCountModel> rentCounts = new List<RentCountModel>().Select(R => new RentCountModel
////{
////    startdate = R.startdate.

////});

//List<RentCountModel> rentCount = new List<RentCountModel>()
//{
//    new RentCountModel
//    {

//    }
//};

//return null;