using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MWSFDataAccess.Models.Alerts;

namespace MWSFDataAccess.DataService.Alerts
{
    public class AlertSqlDataService : IAlertDataService
    {
        public Task<IAlertModel> GetAlert(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<IAlertModel>> GetActiveAlerts()
        {
            throw new NotImplementedException();
        }

        public Task SaveAlert(IAlertModel alert)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAlertModel(IAlertModel alert)
        {
            throw new NotImplementedException();
        }

        public Task SetAlertStatus(IAlertModel alert, bool isActive)
        {
            throw new NotImplementedException();
        }
    }
}