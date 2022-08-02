using IdentityModel;
using IdentityServer.Services.User.Interfaces;
using IdentityServer4.Validation;
using System.Threading.Tasks;

namespace IdentityServer.Auth;

public class CustomResourceOwnerPasswordValidator : IResourceOwnerPasswordValidator
{
    private readonly IUserRepository _userRepository;

    public CustomResourceOwnerPasswordValidator(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
    {
        if (_userRepository.ValidateCredentials(context.UserName, context.Password))
        {
            var user = _userRepository.FindByUsername(context.UserName);
            context.Result = new GrantValidationResult(user.SubjectId, OidcConstants.AuthenticationMethods.Password);
        }

        return Task.FromResult(0);
    }
}