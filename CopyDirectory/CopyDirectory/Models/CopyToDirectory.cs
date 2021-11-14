using System.IO;

namespace CopyDirectory.Models
{
    public class CopyToDirectory
    {
        public static void Copy(string sourceDir, string targetDir)
        {
            DirectoryInfo dirSource = new DirectoryInfo(sourceDir);
            DirectoryInfo dirTarget = new DirectoryInfo(targetDir);

            CopyAll(dirSource, dirTarget);
        }
        public static void CopyAll(DirectoryInfo source, DirectoryInfo target)
        {
            Directory.CreateDirectory(target.FullName);

            foreach (FileInfo fi in source.GetFiles())
            {
                fi.CopyTo(Path.Combine(target.FullName, fi.Name), true);
            }

            foreach (DirectoryInfo dirSourceSubDir in source.GetDirectories())
            {
                DirectoryInfo nextTargetSubDir = target.CreateSubdirectory(dirSourceSubDir.Name);
                CopyAll(dirSourceSubDir, nextTargetSubDir);
            }
        }
    }
}
