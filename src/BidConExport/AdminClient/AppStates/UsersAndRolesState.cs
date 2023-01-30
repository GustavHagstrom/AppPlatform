using DataAccessLibrary.Stores;
using SharedLibrary.Models;

namespace AdminClient.AppStates;
public class UsersAndRolesState
{
    private readonly IRoleStore _roleStore;
    private readonly IUserStore _userStore;
    private bool _isUpdatingUsers = false;
    private bool _isUpdatingRoles = false;

    public UsersAndRolesState(IRoleStore roleStore, IUserStore userStore)
    {
        _roleStore = roleStore;
        _userStore = userStore;
    }
    public List<UserRole> Roles { get; set; } = new();
    public List<User> Users { get; set; } = new();
    public bool IsUpdatingUsers
    {
        get => _isUpdatingUsers; set
        {
            _isUpdatingUsers = value;
            OnUsersChanged?.Invoke();
        }
    }
    public bool IsUpdatingRoles
    {
        get => _isUpdatingRoles; set
        {
            _isUpdatingRoles = value;
            OnRolesChanged?.Invoke();
        }
    }
    public event Action? OnUsersChanged;
    public event Action? OnRolesChanged;
    public async Task UpdateUsersListAsync()
    {
        IsUpdatingUsers = true;
        Users = (await _userStore.GetAllAsync()).ToList();
        IsUpdatingUsers = false;
    }
    public async Task UpdateRoleListAsync()
    {
        IsUpdatingRoles = true;
        Roles = (await _roleStore.GetAllAsync()).ToList();
        IsUpdatingRoles = false;
    }
}
