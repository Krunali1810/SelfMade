using PanAPIModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PanAPIInterface
{
    public interface IHolidaysApiService
    {
        Task<List<APIModel>> GetHolidays(string countryCode, int year);
    }
}
