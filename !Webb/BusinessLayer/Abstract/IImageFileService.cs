using System.Collections.Generic;
using EntityLayer.Concreate;

namespace BusinessLayer.Abstract
{
    public interface IImageFileService
    {
        List<ImageFile> GetList();
    }
}