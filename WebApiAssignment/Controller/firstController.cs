using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApiAssignment.Controller
{
    [Route("api/firstController")]
    [ApiController]
    public class firstController : ControllerBase
    {
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
                    file.Extention = fi.Extension;
                    var empty = string.IsNullOrEmpty(fi.Extension);
                    if (!empty)
                    {
                        file.Type = "File";
                    }
                    else
                    {
                        file.Type = "Folder";
                        file.Extention = "NULL";
                    }
                    fileList.Add(file);
                }
                return fileList;
            }
            else
                return fileList;
        }
    }
}
