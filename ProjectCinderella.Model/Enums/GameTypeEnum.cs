using System.ComponentModel.DataAnnotations;

namespace ProjectCinderella.Model.Enums
{
    public enum GameTypeEnum
    {
        [Display(Name = "Full Game")]
        FullGame,

        DLC,
        Expansion
    }
}