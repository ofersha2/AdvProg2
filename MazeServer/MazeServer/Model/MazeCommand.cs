using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MazeServer.Commands
{
    abstract class MazeCommand
    {
        protected Model model;
        public abstract void ExecuteUnchecked(string[] parameters);
        public abstract bool CanExecute(string[] parameters);
        public void Execute(string[] parameters)
        {
            if (CanExecute(parameters))
                ExecuteUnchecked(parameters);
        }
        
    }
}
