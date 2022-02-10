using System.IO;

namespace Store.Core.Interfaces
{
    public interface IFileStorage
    {
        string Create(Stream stream, string extension, string folder);
        void Delete(string name, string extension, string folder);
    }
}
