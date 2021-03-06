﻿using System.ComponentModel.DataAnnotations;

namespace BusinessLogic.Enums
{
    public enum CompletionStatus
    {
        [Display(Name = "Not Started")] NotStarted,
        [Display(Name = "In Progress")] InProgress,
        Completed
    }
}