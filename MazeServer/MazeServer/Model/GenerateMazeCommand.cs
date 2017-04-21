using MazeServer.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeServer
{
    class GenerateMazeCommand : MazeCommand
    {
        public GenerateMazeCommand(Model model)
        {
            this.model = model;
        }
        public override bool CanExecute(string[] parameters)
        {
            if (parameters.Count() != 3)
                return false;
            return true;
        }

        public override void ExecuteUnchecked(string[] parameters)
        {
            throw new NotImplementedException();
        }
    }
}