namespace MazeServer
{
    /// <summary>
    /// Abstract class representing the bare necessities relevant
    /// for the model portion of our MVC architecture.
    /// </summary>
    abstract class Model
    {
        /// <summary>
        /// The controller portion of our MVC
        /// </summary>
        protected Controller controller;
        /// <summary>
        /// Constructor - our model needs access to
        /// the controller in order to pass on the calculations.
        /// </summary>
        /// <param name="ctrl">The controller portion of our MVC.</param>
        public Model(Controller ctrl)
        {
            this.controller = ctrl;
        }
    }
}