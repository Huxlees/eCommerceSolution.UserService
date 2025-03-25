using AutoMapper;
using eCommerce.Core.DTO;
using eCommerce.Core.Entities;
using eCommerce.Core.RepositoryContracts;
using eCommerce.Core.UserContracts;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Core.Services
{
    internal class UsersService : IUsersService
    {
        private readonly IUsersRepository _usersRepository;
        private readonly IMapper _mapper;
        public UsersService(IUsersRepository usersRepository ,IMapper mapper)
        {
            _usersRepository = usersRepository;
            _mapper = mapper;
        }
        public async Task<AuthencationResponse> Login(LoginRequest loginRequest)
        {
          ApplicationUser? user= await _usersRepository.GetUserByEmailAndPassword(loginRequest.Email, loginRequest.Password);
            if (user == null)
            {
                return null;
            }
            return _mapper.Map<AuthencationResponse>(user) with { Sucess=true,Token="token"};//<destination>(source) extra value using with
            //return new AuthencationResponse(user.UserID, user.Email, user.PersonName, user.Gender, "token", Sucess:true);
        }

        public async Task<AuthencationResponse> Register(RegisterRequest registerRequest)
        {

            //ApplicationUser user = new ApplicationUser();
            // _mapper.Map(user, registerRequest);
            ApplicationUser user = _mapper.Map<ApplicationUser>(registerRequest);
            ApplicationUser? result= await _usersRepository.AddUser(user);
            if (result == null)
            {
                return null;
            }
            return _mapper.Map<AuthencationResponse>(result) with { Sucess = true, Token = "token" };
            //return  new AuthencationResponse(result.UserID, result.Email, user.PersonName,user.Gender, "Token", Sucess: true); 
        }
    }
}
