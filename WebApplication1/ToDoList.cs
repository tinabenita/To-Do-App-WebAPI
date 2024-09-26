namespace ToDoList2.Api
{
    public class ToDoList
    {
        public int TaskId { get; set; }
        public string TaskName { get; set; } = string.Empty;

        public DateOnly TaskDate { get; set; }

        public bool IsCompleted { get; set; }
    }
}
