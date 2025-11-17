namespace KadelDemo.Services
{
    public interface IKadelPropertyService
    {
        Task<List<PropertyItem>> GetPropertyAsync();
        Task<PropertyItem> CreatePropertyAsync(PropertyItem property);

        //Task<List<PropertyItem>> GetFilteredPropertyAsync(string description);
    }
}
