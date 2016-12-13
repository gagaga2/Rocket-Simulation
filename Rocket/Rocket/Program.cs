using System;

namespace Rocket
{
#if WINDOWS || LINUX
    /// <summary>
    /// The main class.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] argss)
        {
            // 143 0 1 1 0 0
            string[] args = new string[6];
            args[0] = "90";
            args[1] = "0";
            args[2] = "10000";
            args[3] = "11500";
            args[4] = "1";
            args[5] = "4";
           
            using (var game = new Game1(args))
                game.Run();
        }

        

    }
#endif
}
