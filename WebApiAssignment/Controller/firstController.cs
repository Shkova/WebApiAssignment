using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApiAssignment.Controller
{
    [Route("api/firstController")]
    [ApiController]
    public class firstController : ControllerBase
    {/// <summary>
    /// this method does something
    /// </summary>
    /// <param name="path">this is required from the user</param>
    /// <returns></returns>
        [Route("path-content")]
        [HttpPost]
        public List<FileStructure>? getPathContent([FromBody] string path)
        {
            List<FileStructure> fileList = new List<FileStructure>();

            if (Directory.Exists(path))
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(path);
                foreach (var fi in directoryInfo.GetFileSystemInfos())
                {
                    FileStructure file = new FileStructure();

                    file.Name = fi.Name;
                    var empty = string.IsNullOrEmpty(fi.Extension);
                    if (!empty)
                    {
                        file.Type = "File";
                        file.Extention = fi.Extension;
                    }
                    else
                    {
                        file.Type = "Folder";
                        file.Extention = "NULL";
                        List<FileStructure> innerList = inFolder(file, path);
                        file.insideIt = innerList;

                    }
                    fileList.Add(file);
                }
                return fileList;
            }
            else
                return fileList;
        }

        public List<FileStructure>? inFolder(FileStructure upperFolder, string path)
        {
            var folderName = upperFolder.Name;
            path = path + "\\"+ folderName;

            List<FileStructure> fileList = new List<FileStructure>();

            DirectoryInfo directoryInfo = new DirectoryInfo(path);
            foreach (var fi in directoryInfo.GetFileSystemInfos())
            {
                FileStructure file = new FileStructure();

                file.Name = fi.Name;
                var empty = string.IsNullOrEmpty(fi.Extension);
                if (!empty)
                {
                    file.Type = "File";
                    file.Extention = fi.Extension;
                }
                else
                {
                    file.Type = "Folder";
                    file.Extention = "NULL";
                    List<FileStructure> innerList = inFolder(file, path);
                    file.insideIt = innerList;

                }
                fileList.Add(file);
                
            }
            return fileList;
        }
    }
}
