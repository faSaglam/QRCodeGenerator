

using System.DirectoryServices.AccountManagement;

namespace QRCodeGenerator
{
    internal static class Program
    {
    
        [STAThread]
        static void Main()
        {
            

            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}