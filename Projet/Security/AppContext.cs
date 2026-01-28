using Projet.Domain.Enums;

namespace Projet.Security
{
    public class AppContext
    {
        public static string Username { get; set; }

        public static Role Role { get; set; }
        public static int ResponsableKey => Username?.GetHashCode() ?? 0;

        public static bool IsAuthenticated
        {
            get { return !string.IsNullOrEmpty(Username); }

        }

        public static void Logout()
        {
            Username = null;
        }
    }
}
