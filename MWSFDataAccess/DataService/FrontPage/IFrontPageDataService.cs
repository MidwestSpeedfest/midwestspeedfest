using System.Threading.Tasks;
using MWSFDataAccess.Models.FrontPage;

namespace MWSFDataAccess.DataService.FrontPage
{
    public interface IFrontPageDataService
    {
        Task<IFrontPageSettingsModel> GetNewestFrontPageSettingsModel();
        Task SaveFrontPageSettings(IFrontPageSettingsModel settings);
    }
}