using DataAccessLayer.AuthDTOs;

namespace Trainers.Interfaces;
public interface IUserService
{
    Task<UserRegisterResponse> UserRegister(UserRegisterRequest register);
    Task<UserLoginResponse> UserLogin(UserLoginRequest login);
}