using Fringes.Models;
using Microsoft.EntityFrameworkCore;

namespace Fringes.Services
{
    public class RoleService : IRoleService
    {
        private readonly FringeAppDbContext _fringeAppDbContext;

        public RoleService(FringeAppDbContext fringeAppDbContext)
        {
            _fringeAppDbContext = fringeAppDbContext;
        }
        public async Task<Role> CreateRole(Role role)
        {
            if (role == null)
            {
                throw new ArgumentNullException(nameof(role));
            }

            await _fringeAppDbContext.Roles.AddAsync(role);
            await _fringeAppDbContext.SaveChangesAsync();
            return role;
        }

        public async Task DeleteRole(string id)
        {
            var existingRole = await _fringeAppDbContext.Roles.FindAsync(id);
            if (existingRole == null)
            {
                throw new ArgumentNullException(nameof(existingRole));
            }

            _fringeAppDbContext.Remove(existingRole);
            _fringeAppDbContext.SaveChanges();

        }

        public async Task<IEnumerable<Role>> GetAllRoles()
        {
            return await _fringeAppDbContext.Roles.ToListAsync();


        }

        public async Task<Role> GetRolesById(string id)
        {
            var role = await _fringeAppDbContext.Roles.FindAsync(id);

            if (role == null)
            {
                throw new ArgumentNullException(nameof(role));

            }

            return role;
        }

        public async Task<Role> UpdateRole(string id, Role role)
        {
            if (role == null)
            {
                throw new ArgumentNullException(nameof(role));
            }

            var existingRole = await _fringeAppDbContext.Roles.FindAsync(id);
            if (existingRole == null)
            {
                return null;
            }

            existingRole.Name = role.Name;

            _fringeAppDbContext.Roles.Update(existingRole);
            await _fringeAppDbContext.SaveChangesAsync();
            return existingRole;
        }
    }
}
