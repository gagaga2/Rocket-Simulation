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
        static void Main(string[] args)
        {
        #if DEBUG
            args = new string[6];
            args[0] = "270";
            args[1] = "5";
            args[2] = "10000";
            args[3] = "10000";
            args[4] = "8";
            args[5] = "1507,9644737231";
        #endif

            using (var game = new Game1(args))
                game.Run();
        }
    }
#endif
}
