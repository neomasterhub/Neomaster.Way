namespace XUnitTools.ActivityTypes;

internal class GetCurrentDatetimeService : IGetCurrentDatetimeService
{
    public DateTime Get() => DateTime.Now;
}
