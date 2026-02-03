using Projet.Domain.enums;

namespace Projet.Security
{
    public static class AppContext
    {
        public static string Username { get; set; }
        public static Role Role { get; set; }

        public static int UserId { get; set; }
        public static bool IsAuthenticated => !string.IsNullOrEmpty(Username);

        public static void Logout()
        {
            Username = null;
            Role = default;
            UserId = 0;
        }

    }
}
