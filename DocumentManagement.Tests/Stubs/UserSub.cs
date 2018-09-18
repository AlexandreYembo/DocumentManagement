using DocumentManagement.Domain.Models;

namespace DocumentManagement.Tests.Stubs
{
    public static class UserSub
    {
        public static User SimpleUser = new User
        {
            Id = 1,
            Login = "Login"
        };

        public static User UserCreated = new User
        {
            Id = 2,
            Login = "victorhugo2"
        };
    }
}
