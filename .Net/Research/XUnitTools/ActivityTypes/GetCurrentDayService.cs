namespace XUnitTools.ActivityTypes;

internal class GetCurrentDayService : IGetCurrentDayService
{
    private readonly IGetCurrentDatetimeService _getCurrentDatetimeService;

    public GetCurrentDayService(IGetCurrentDatetimeService getCurrentDatetimeService)
    {
        _getCurrentDatetimeService = getCurrentDatetimeService;
    }

    public int Get() => _getCurrentDatetimeService.Get().Day;
}
