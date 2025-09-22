
using Infrastructure.Models;

namespace Infrastructure.Interfaces;

internal interface IFileService
{
    FileResult SaveContentToFile(string path, string content);
    FileResult GetContentToFile(string path);

}
