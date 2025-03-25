

using eCommerce.Core.DTO;

namespace eCommerce.Core.UserContracts
{
    public interface IUsersService
    {
       Task <AuthencationResponse> Login(LoginRequest loginRequest);
        Task<AuthencationResponse> Register(RegisterRequest registerRequest);
    }
}
