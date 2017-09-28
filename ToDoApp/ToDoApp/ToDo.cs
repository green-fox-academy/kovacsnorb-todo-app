using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApp
{
    class ToDo
    {
        private string name;
        private bool isDone;
        private string description;

        public ToDo(string name, bool isDone = false, string description = "")
        {
            this.name = name;
            this.isDone = isDone;
            this.description = description;
        }

        public override string ToString()
        {
            string checkSign = " ";
            if (isDone)
            {
                checkSign = "X";
            }
            return String.Format(" - [{0}] {1}", checkSign, name);
        }
    }
}
