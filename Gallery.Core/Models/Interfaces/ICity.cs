using System;
using System.Collections.Generic;
using System.Text;

namespace Gallery.Core.Models.Interfaces
{
    public interface ICity
    {
        string Name { get; set; }
        string Data { get; set; }
        string Path { get; set; }
    }
}
