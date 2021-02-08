using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MWSFDataAccess.DataAccess;
using MWSFDataAccess.Models.FrontPage;

namespace MWSFDataAccess.DataService.FrontPage
{
    public class FrontPageSqlDataService : IFrontPageDataService
    {
        private readonly ISqlDataAccess _dataAccess;
        private const string DbName = "MwsfDb";

        public FrontPageSqlDataService(ISqlDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public async Task<IFrontPageSettingsModel> GetNewestFrontPageSettingsModel()
        {
            var settings = await _dataAccess.LoadData<FrontPageSettingsModel, dynamic>("dbo.spFrontPageSettings_ReadNewest",
                                                                                        new { },
                                                                                        DbName);
            return settings.FirstOrDefault();
        }

        public async Task SaveFrontPageSettings(IFrontPageSettingsModel settings)
        {
            var s = new
            {
                settings.Author,

                settings.ShowLogo,
                settings.HtmlContent,

                settings.ShowCountdown,
                settings.CountdownTitle,
                settings.CountdownUntil
            };

            await _dataAccess.SaveData("dbo.spFrontPageSettings_Create", s, DbName);
        }
    }
}
