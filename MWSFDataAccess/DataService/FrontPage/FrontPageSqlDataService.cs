using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Configuration;
using MWSFDataAccess.DataAccess;
using MWSFDataAccess.Models.FrontPage;

namespace MWSFDataAccess.DataService.FrontPage
{
    public class FrontPageSqlDataService : AbstractGenericDataService<IFrontPageSettingsModel>, IFrontPageDataService 
    {
        private readonly ISqlDataAccess _dataAccess;
        private const string DbName = DataServiceConstants.DbName;

        public FrontPageSqlDataService(ISqlDataAccess dataAccess, IConfiguration config) : base(config)
        {
            _dataAccess = dataAccess;
            TableName = "FrontPageSettings";
        }

        public async Task<IFrontPageSettingsModel> GetNewestFrontPageSettingsModel()
        {
            using (IDbConnection db = new SqlConnection(LoadConnectionString()))
            {
                var query = $"Select top 1 * from {TableName} order by ID DESC";
                return await db.QueryFirstAsync<FrontPageSettingsModel>(query);
            }
        }

        public async Task SaveFrontPageSettings(IFrontPageSettingsModel settings)
        {
            await InsertAsync(settings);
        }
    }
}
