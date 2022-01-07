using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MWSFDataAccess.Models.Alerts;

namespace MWSFDataAccess.DataService.Alerts
{
    public interface IAlertDataService
    {
        Task<IAlertModel> GetAlert(int id);
        Task<List<IAlertModel>> GetActiveAlerts();
        Task SaveAlert(IAlertModel alert);
        Task UpdateAlertModel(IAlertModel alert);
        Task SetAlertStatus(IAlertModel alert, bool isActive);
    }
}
