using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeServer
{
    class Program
    {
        static void Main(string[] args)
        {
            Controller controller = new MazeController();
            View view = new MazeView(controller);
            Model model = new MazeModel(controller);
            controller.View = view;
            controller.Model = model;
            view.Start();
        }
    }
}
