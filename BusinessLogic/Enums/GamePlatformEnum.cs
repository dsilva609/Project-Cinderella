using System.ComponentModel.DataAnnotations;

namespace BusinessLogic.Enums
{
    public enum GamePlatformEnum
    {
        PC,

        PlayStation,

        [Display(Name = "Playstation 2")]
        PlayStation2,

        [Display(Name = "Playstation 3")]
        PlayStation3,

        [Display(Name = "Playstation 4")]
        PlayStation4,

        Xbox,

        [Display(Name = "Xbox 360")]
        Xbox360,

        [Display(Name = "Xbox One")]
        XboxOne,

        [Display(Name = "Nintendo 64")]
        Nintendo64,

        GameCube,
        Wii,

        [Display(Name = "Wii U")]
        WiiU,

        [Display(Name = "Game Boy")]
        GameBoy,

        [Display(Name = "Game Boy Advance")]
        GameBoyAdvance,

        [Display(Name = "Nintendo DS")]
        NintendoDS,

        [Display(Name = "Nintendo 3DS")]
        Nintendo3DS,
    }
}