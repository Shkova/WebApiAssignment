using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApiAssignment.Controller
{
    [Route("api/secondController")]
    [ApiController]
    public class secondController : ControllerBase
    {
        [Route("create")]
        [HttpPost]
        public string createFileOrFolder([FromBody] FileCreateStructure data)
        {

            if (Directory.Exists(data.CreateOn))
            {
                for (int i = 0; i < data.FileStructure.Count; i++)
                {
                    string fileName = data.CreateOn + "\\" + data.FileStructure[i].Name;
                    if (data.FileStructure[i].Extention == null)
                    {
                        Directory.CreateDirectory(fileName);
                    }
                    else
                    {
                        FileStream fs = System.IO.File.Create(fileName);
                    }
                }
                return "File(s) and/or folder(s) created";
            }
            return "Directory does not exist so cannot make them";

        }
    }
}
