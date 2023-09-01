using AspNetCore.Identity.MongoDbCore.Models;
using MongoDbGenericRepository.Attributes;

namespace Simbirsoft.Hakaton.ProjectD.Api.Models;

[CollectionName("Users")]
public class User : MongoIdentityUser
{
}