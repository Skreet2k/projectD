using AspNetCore.Identity.MongoDbCore.Models;
using MongoDbGenericRepository.Attributes;

namespace Simbirsoft.Hakaton.ProjectD.Api.Models;

[CollectionName("Roles")]
public class Role : MongoIdentityRole<Guid>
{
    
}