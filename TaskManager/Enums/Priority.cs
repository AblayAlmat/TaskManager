using System.ComponentModel;

namespace TaskManager.Enums
{
    public enum Priority
    {
        [Description("Низкий")] Low = 1,
        [Description("Средний")] Medium,
        [Description("Высокий")] High
    }
}