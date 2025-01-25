using eCommerence.Core.DTO;

namespace eCommerence.Core.IServicesContract;

public interface IUserServices
{
    Task<AuthenticationResponse?> Login(LoginRequest loginRequest);
    Task<AuthenticationResponse?> Register(RegisterRequest registerRequest);

}
