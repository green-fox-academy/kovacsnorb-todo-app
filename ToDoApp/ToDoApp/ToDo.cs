using System;

namespace ToDoApp
{
    class ToDo
    {
        public string Name { get; private set; }
        public bool IsDone { get; private set; }
        public string Description { get; private set; }

        public ToDo(string name, bool isDone = false, string description = "")
        {
            Name = name;
            IsDone = isDone;
            Description = description;
        }

        public override string ToString()
        {
            string checkSign = " ";
            if (IsDone)
            {
                checkSign = "x";
            }
            return String.Format(" - [{0}] {1}", checkSign, Name);
        }

        public void SetStatus(bool inputStatus)
        {
            IsDone = inputStatus;
        }
    }
}
