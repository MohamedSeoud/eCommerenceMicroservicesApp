using AutoMapper;
using eCommerence.Core.DTO;
using eCommerence.Core.Entities;
using eCommerence.Core.IRepositoryContract;
using eCommerence.Core.IServicesContract;

namespace eCommerence.Core.Services
{
    internal class UserService : IUserServices
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserService(IUserRepository userRepository, IMapper mapper) 
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<AuthenticationResponse> Login(LoginRequest loginRequest)
        {
            var user = await _userRepository.GetUserByEmailAndPassword(loginRequest.Email, loginRequest.Password);
            if (user == null) 
            {
                return null;
            }
            return _mapper.Map<AuthenticationResponse>(user) with { Sucess = true, Token = "Token"};
        }

        public async Task<AuthenticationResponse> Register(RegisterRequest registerRequest)
        {
            ApplicationUser applicationUser = new ApplicationUser()
            {
                Email = registerRequest.Email,
                Password = registerRequest.Password,
                PersonName = registerRequest.PersonName,
                Gender = registerRequest.Gender.ToString(),
            };
            ApplicationUser? user = await _userRepository.AddUser(applicationUser);
            if (user == null) { return null; }
            return _mapper.Map<AuthenticationResponse>(user) with { Sucess = true, Token = "Token" };
        }
    }
}
