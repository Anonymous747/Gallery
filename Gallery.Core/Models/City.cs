using Gallery.Core.Models.Interfaces;

namespace Gallery.Core.Models
{
    public class City : ICity
    {
        public string Name { get; set; }
        public string Data { get; set; }
        public string Path { get; set; }

        public City(string name, string data, string path)
        {
            Name = name;
            Data = data;
            Path = path;
        }
    }
}
