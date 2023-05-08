using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concreate
{
    public class ImageFile
    {
        [Key] public int ImageID { get; set; }
        [StringLength(250)] public string ImageName { get; set; }
        [StringLength(500)] public string ImagePath { get; set; }
    }
}