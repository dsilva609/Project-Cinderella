using System.ComponentModel.DataAnnotations;

namespace ProjectCinderella.Model.Enums
{
    public enum GameRatingEnum
    {
        EC,
        E,

        [Display(Name = "E-10")]
        E10,

        T,
        M,
        A
    }
}