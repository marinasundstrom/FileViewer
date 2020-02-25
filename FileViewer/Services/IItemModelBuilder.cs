using FileViewer.Models;

namespace FileViewer.Services
{
    public interface IItemModelBuilder
    {
        Item CreateModel(Node node);
    }
}