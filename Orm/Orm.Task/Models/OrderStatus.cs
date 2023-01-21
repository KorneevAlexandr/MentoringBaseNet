namespace Orm.Task.Models
{
    public enum OrderStatus : int
    {
        NotStarted = 0,
        Loading = 1,
        InProgress = 2,
        Arrived = 3,
        Unloading = 4,
        Cancelled = 5,
        Done = 6
    }
}