# PlayFab Admin API Task Wrapper
The PlayFab admin API Task wrapper wraps the Unity admin API to convert the async callback pattern to task async await pattern.

### Usage Note
In most cases it would be preferrable to utilize the [PlayFab C# SDK](https://docs.microsoft.com/en-us/gaming/playfab/sdks/c-sharp/) ([Additional notes here](https://community.playfab.com/questions/47743/unity-stripping-doesnt-work-on-low-setting.html)) within Unity. This tool is most beneficial for projects that have already gone the Unity SDK route and are looking to gradually move code base to async await pattern. 

# Quick Start
Add the following line to your Unity package `Packages/manifest.json`
```json
{
  "dependencies": {
    "com.breakstepstudios.playfab-admin-api-task-wrapper": "https://github.com/Breakstep-Studios/playfab-admin-api-task-wrapper.git#release",
  }
}
```
# Examples
### Example Conversion
```csharp
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
```

### Example Usage
```csharp
public async PlayFabCommonResponse<GetTitleDataResult> GetTitleDataData()
{
    var getTitleDataRequest = new GetTitleDataRequest
    {
        Keys = new List<string> { "Data" }
    };
    var result = await PlayFabAdminAPIWrapper.GetTitleDataAsync(getTitleDataRequest);
    if (result.ContainsError)
    {
        return result;
    }
}
```
# TODO
- [ ] This package currently relies on [playfab-admin-client-task-wrapper](https://github.com/Breakstep-Studios/playfab-client-api-task-wrapper). This dependency is only due to the fact that `playfab-client-api-task-wrapper` defines some data models this repo relies/will rely on. In the long run it would more beneficial to pull those data models in to a seperate repo that both the client & admin api rely on. For example something like `playfab-core-api-task-wrapper`.
