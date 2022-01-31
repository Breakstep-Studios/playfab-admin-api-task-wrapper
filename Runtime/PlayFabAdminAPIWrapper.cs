using System.Threading.Tasks;
using PlayFab;
using PlayFab.AdminModels;
using ThomasBrown.PlayFab;

namespace BreakstepStudios.Scripts.Runtime.PlayFab
{
    public static class PlayFabAdminAPIWrapper
    {
#if ENABLE_PLAYFABADMIN_API
        /// <inheritdoc cref="PlayFabAdminAPI.GetTitleData"/>
        public static Task<PlayFabCommonResponse<GetTitleDataResult>> GetTitleDataAsync(GetTitleDataRequest request)
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
        
        /// <inheritdoc cref="PlayFabAdminAPI.SetTitleData"/>
        public static Task<PlayFabCommonResponse<SetTitleDataResult>> SetTitleDataAsync(SetTitleDataRequest request)
        {
            var taskCompletionSource = new TaskCompletionSource<PlayFabCommonResponse<SetTitleDataResult>>();
            PlayFabAdminAPI.SetTitleData(request, (result) =>
            {
                taskCompletionSource.SetResult(new PlayFabCommonResponse<SetTitleDataResult>(result,null));
            }, (error) =>
            {
                taskCompletionSource.SetResult(new PlayFabCommonResponse<SetTitleDataResult>(null, error));
            });
            return taskCompletionSource.Task;
        }
    }
#endif
}