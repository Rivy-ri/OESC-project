
using System.ComponentModel.DataAnnotations;


namespace OmegaSportExplorerClub.src.Enums
{
    public enum Majority
    {
        [Display(Name = "outside hitter")]
        outsideHitter,
        [Display(Name = "opposite")]
        opposite,
        [Display(Name = "setter")]
        setter,
        [Display(Name = "middle blocker")]
        middleBlocker,
        [Display(Name = "libero")]
        libero,
        [Display(Name = "defensive specialist")]
        defensiveSpecialist,
        [Display(Name = "serving specialist")]
        servingSpecialist,
        [Display(Name = "not assigned")]
        notAssigned,
    }
}
