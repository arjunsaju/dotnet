using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using EcomProductAPI.Repository;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;

namespace OrderAPI.Security
{
    public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        private readonly IUserRepository repository;
        public BasicAuthenticationHandler(IOptionsMonitor<AuthenticationSchemeOptions> options, ILoggerFactory logger,
            UrlEncoder encoder, ISystemClock clock, IUserRepository repository) : base(options, logger, encoder, clock)
        {
            this.repository = repository;
        }

        protected async override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            string Email = "";

            try
            {
                var authHeader = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);

                var credentials = Encoding.UTF8.GetString(Convert.FromBase64String(authHeader.Parameter ?? String.Empty)).Split(':'); //admin:12345

                Email = credentials[0];
                string Password = credentials[1];

                if (!await repository.isValidateUser(Email, Password))
                    throw new ArgumentException("Invalid credentials");

            }

            catch (Exception ex)
            {
                return AuthenticateResult.Fail($"Authentication Failed{ex.Message}");
            }

            var claims = new[] { new Claim(ClaimTypes.Name, Email) };

            var identity = new ClaimsIdentity(claims, Scheme.Name);
            var principal = new ClaimsPrincipal(identity);
            var ticket = new AuthenticationTicket(principal, Scheme.Name);

            return AuthenticateResult.Success(ticket);
        }
    }
}
