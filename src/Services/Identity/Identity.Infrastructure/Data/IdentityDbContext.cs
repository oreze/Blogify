using Identity.Domain.AggregationModels.ApplicationUser;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Identity.Infrastructure.Data;

public class AppIdentityDbContext: IdentityDbContext<ApplicationUser>
{
    
}