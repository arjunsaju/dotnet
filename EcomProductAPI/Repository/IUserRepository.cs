namespace EcomProductAPI.Repository
{
    public interface IUserRepository
    {
        Task<bool> isValidateUser(string username, string password);
    }
}
