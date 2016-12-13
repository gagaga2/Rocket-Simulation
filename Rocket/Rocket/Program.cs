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
            //string[] args = new string[7];
            //args[0] = "90";
            //args[1] = "200";
            //args[2] = "10000";
            //args[3] = "11500";
            //args[4] = "1000";
            //args[5] = "10";
            //args[6] = "15";

            using (var game = new Game1(args))
                game.Run();
        }
    }
#endif
}
