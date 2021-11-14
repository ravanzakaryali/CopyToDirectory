using System.IO;

namespace CopyDirectory.Models
{
    public class CopyToDirectory
    {
        /// <summary>
        /// String converts incoming links to a diractory type.
        /// </summary>
        /// <param name="sourceDir">Link of the source folder</param>
        /// <param name="targetDir">Link to the location you want to copy</param>
        public static void Copy(string sourceDir, string targetDir)
        {
            DirectoryInfo dirSource = new DirectoryInfo(sourceDir);
            DirectoryInfo dirTarget = new DirectoryInfo(targetDir);

            CopyAll(dirSource, dirTarget);
        }
        /// <summary>
        /// It can be used to upload all the folders and files in one folder to another file.
        /// </summary>
        /// <param name="source">Link of the source folder </param>
        /// <param name="target">Link to the location you want to copy</param>
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
