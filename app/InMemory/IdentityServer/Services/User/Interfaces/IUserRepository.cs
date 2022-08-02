using IdentityServer.Entities;

namespace IdentityServer.Services.User.Interfaces;

public interface IUserRepository
{
    bool ValidateCredentials(string username, string password);

    CustomUser FindBySubjectId(string subjectId);

    CustomUser FindByUsername(string username);
}
