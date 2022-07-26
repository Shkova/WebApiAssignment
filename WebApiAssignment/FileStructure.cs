namespace WebApiAssignment
{
    public class FileStructure
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string? Extention { get; set; }

        public List<FileStructure>? insideIt { get; set; }
    }
}
