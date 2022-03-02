using System.ComponentModel;

namespace TaskManager.Enums
{
    public enum Status
    {
        [Description("Открыт")] Opened = 1,
        [Description("В процессе выполнения")] InProgress,
        [Description("Закрыт")] Closed
    }
}