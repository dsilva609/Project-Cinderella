using System.ComponentModel.DataAnnotations;

namespace BusinessLogic.Enums
{
    public enum MovieMediaTypeEnum
    {
        DVD,

        [Display(Name = "Blu-ray")]
        Bluray
    }
}