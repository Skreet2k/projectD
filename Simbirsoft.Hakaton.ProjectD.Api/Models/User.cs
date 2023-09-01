using AspNetCore.Identity.MongoDbCore.Models;
using Microsoft.AspNetCore.Identity;
using MongoDbGenericRepository.Attributes;

namespace Simbirsoft.Hakaton.ProjectD.Api.Models;

[CollectionName("Users")]
public class User : MongoIdentityUser
{
    
}