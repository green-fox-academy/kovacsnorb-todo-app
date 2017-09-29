using System;

namespace ToDoApp
{
    class ToDo
    {
        public string Name { get; private set; }
        public bool IsDone { get; private set; }
        public int Priority { get; private set; }

        public ToDo(string name, bool isDone = false, int priority = 2)
        {
            Name = name;
            IsDone = isDone;
            Priority = priority;
        }

        public override string ToString()
        {
            string checkSign = " ";
            string prioSign;

            if (IsDone)
            {
                checkSign = "x";
            }

            if (Priority == 2)
            {
                prioSign = "  MEDIUM ";
            }
            else if (Priority == 3)
            {
                prioSign = "! HIGH   ";
            }
            else
            {
                prioSign = "  LOW    ";
            }
            return String.Format("  [{0}]  {1}  {2}", checkSign, prioSign, Name);
        }

        public void SetStatus(bool inputStatus)
        {
            IsDone = inputStatus;
        }
    }
}
