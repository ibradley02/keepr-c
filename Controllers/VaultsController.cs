namespace keepr_c.Controllers
{
    [Route("[controller]")]
    public class AccountsController : Controller
    {
        private readonly UserRepository _db;

        public AccountsController(UserRepository repo)
        {
            _db = repo;
        }

        [HttpPost("Vaults")]
        public async Task<UserReturnModel> Register([FromBody]RegisterUserModel creds)
        {
            if (ModelState.IsValid)
            {
                UserReturnModel user = _db.Register(creds);
                if (user != null)
                {
                    ClaimsPrincipal principal = user.SetClaims();
                    await HttpContext.SignInAsync(principal);
                    return user;
                }
            }
            return null;
        }

        [HttpGet("Vaults")]
        public VaultsReturnModel Authenticate()
        {
            var user = HttpContext.User;
            var id = user.Identity.Name;
            if(id != null)
            {
            return _db.GetUserById(id);
            }
            return null;
        }

        [Authorize]
        [HttpPut]
        public VaultReturnModel UpdateVault([FromBody]VaultReturnModel vault)
        {
            var name = HttpContext.User.Claims.Where(c => c.Type == ClaimTypes.Name)
                   .Select(c => c.Value).SingleOrDefault();
            var sessionUser = _db.GetUserByName(name);

            if (sessionUser.Id == user.Id)
            {
                return _db.UpdateUser(user);
            }
            return null;
        }

        [Authorize]
        [HttpPut("change-password")]
        public string ChangePassword([FromBody]ChangeUserPasswordModel user)
        {
            if (ModelState.IsValid)
            {
                var email = HttpContext.User.Claims.Where(c => c.Type == ClaimTypes.Email)
                       .Select(c => c.Value).SingleOrDefault();
                var sessionUser = _db.GetUserByEmail(email);

                if (sessionUser.Id == user.Id)
                {
                    return _db.ChangeUserPassword(user);
                }
            }
            return "How did you even get here?";
        }
       [HttpDelete("Vaults/:id")]
       public async void Logout()
       {
         
           await HttpContext.SignOutAsync();
         
       }



    }
}