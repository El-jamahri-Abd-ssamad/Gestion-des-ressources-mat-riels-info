using Projet.Domain.Enums;

namespace Projet.Security
{
    public static class AppContext
    {
        public static string Username { get; set; }
        public static Role Role { get; set; }

<<<<<<< HEAD
        
        public static int UserId { get; set; }
        
=======

        public static bool IsAuthenticated
        {
            get { return !string.IsNullOrEmpty(Username); }
>>>>>>> fd6a54f031cc1f8c05face9741645e0d3836bec2

        public static bool IsAuthenticated => !string.IsNullOrEmpty(Username);

        public static void Logout()
        {
            Username = null;
        }
        
    }
}
