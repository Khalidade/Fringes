using Fringes.Models;

namespace Fringes.Services
{
    public interface IRoleService
    {
        Task<IEnumerable<Role>> GetAllRoles();
        Task<Role> GetRolesById(string id);
        Task<Role> CreateRole(Role role);
        Task<Role> UpdateRole(string id, Role role);
        Task DeleteRole(string id);
    }
}
