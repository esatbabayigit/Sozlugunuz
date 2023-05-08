using System.Collections.Generic;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concreate;

namespace BusinessLayer.Concreate
{
    public class ImageFileMenager:IImageFileService
    {
        private IImageFileDal _image;

        public ImageFileMenager(IImageFileDal image)
        {
            _image=image;
        }

        public List<ImageFile> GetList()
        {
           return _image.List();
        }
    }
}