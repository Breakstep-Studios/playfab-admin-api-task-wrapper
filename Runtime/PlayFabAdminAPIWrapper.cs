using System.Threading.Tasks;
using PlayFab;
using PlayFab.AdminModels;
using ThomasBrown.PlayFab;

namespace BreakstepStudios.Scripts.Runtime.PlayFab
{
    public static class PlayFabAdminAPIWrapper
    {
        /// <inheritdoc cref="PlayFabAdminAPI.GetTitleData"/>
        public static Task<PlayFabCommonResponse<GetTitleDataResult>> GetTitleDataAsync(
            GetTitleDataRequest request)
        {
            var taskCompletionSource = new TaskCompletionSource<PlayFabCommonResponse<GetTitleDataResult>>();
            PlayFabAdminAPI.GetTitleData(request, (result) =>
            {
                taskCompletionSource.SetResult(new PlayFabCommonResponse<GetTitleDataResult>(result,null));
            }, (error) =>
            {
                taskCompletionSource.SetResult(new PlayFabCommonResponse<GetTitleDataResult>(null, error));
            });
            return taskCompletionSource.Task;
        }
    }
}