namespace KadelDemo.Services
{
    public interface IKadelPropertyService
    {
        Task<List<PropertyItem>> GetPropertyAsync();

        //Task<List<PropertyItem>> GetFilteredPropertyAsync(string description);
    }
}
