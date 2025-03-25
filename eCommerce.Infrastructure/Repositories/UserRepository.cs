

using Dapper;
using eCommerce.Core.DTO;
using eCommerce.Core.Entities;
using eCommerce.Core.RepositoryContracts;
using eCommerce.Infrastructure.DbContext;

namespace eCommerce.Infrastructure.Repositories
{
    public class UserRepository : IUsersRepository
    {
        private readonly DapperDbContext _dbContext;
        public UserRepository(DapperDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<ApplicationUser?> AddUser(ApplicationUser User)
        {
            // Generate a new unique ID for the user
            User.UserID = Guid.NewGuid();
            //sql query
            string query = "Insert into public.\"Users\"(\"UserID\",\"Email\",\"PersonName\",\"Gender\",\"Password\")" +
                "Values(@UserID,@Email,@PersonName,@Gender,@Password)";
          int result=await  _dbContext.dbConnection.ExecuteAsync(query,User);
            if(result > 0 )
            {
                return User;
            }
            else { return null; }
        }

        public async Task<ApplicationUser?> GetUserByEmailAndPassword(string? email, string? password)
        {
            //sql query
            string query = "Select * from public.\"Users\" where \"Email\"=@Email and \"Password\"=@Password";
            //creating new parm
            var par = new { Email = email, Password = password };
            ApplicationUser? result = await _dbContext.dbConnection.QueryFirstOrDefaultAsync<ApplicationUser>(query, par);
                if (result == null)
            {
                return null;
            }
                return result;
            //return new ApplicationUser()
            //{
            //    UserID = Guid.NewGuid(),
            //    Email = email,
            //    Password = password,
            //    PersonName = "P1",
            //    Gender = GenderOptions.Male.ToString()
            //};
        }
    }
}
