using BusinessLogic.Enums;

namespace UI.Enums
{
    public static class CompletionStatusHelper
    {
        public static string GetStatusClass(CompletionStatus status)
        {
            var statusClass = "fa ";
            switch (status)
            {
                case CompletionStatus.NotStarted:
                    statusClass += "fa-circle";
                    break;

                case CompletionStatus.InProgress:
                    statusClass += "fa-spinner";
                    break;

                case CompletionStatus.Completed:
                    statusClass += "fa-check-circle";
                    break;
            }

            return statusClass;
        }
    }
}