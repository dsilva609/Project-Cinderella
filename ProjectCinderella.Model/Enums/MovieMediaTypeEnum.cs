using System.ComponentModel.DataAnnotations;

namespace ProjectCinderella.Model.Enums
{
    public enum MovieMediaTypeEnum
    {
        DVD,

        [Display(Name = "Blu-ray")]
        Bluray
    }
}