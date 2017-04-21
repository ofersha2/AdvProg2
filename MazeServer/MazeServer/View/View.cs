namespace MazeServer
{
    /// <summary>
    /// Abstract class representing the bare necessities relevant
    /// for the view portion of our MVC architecture.
    /// </summary>
    abstract class View
    {
        /// <summary>
        /// The controller portion of our MVC
        /// </summary>
        protected Controller controller;
        /// <summary>
        /// Constructor - our view needs access to
        /// the controller in order to pass on the user's requests.
        /// </summary>
        /// <param name="ctrl">The controller portion of our MVC.</param>
        public View(Controller ctrl)
        {
            this.controller = ctrl;
        }
        /// <summary>
        /// Initiate the view.
        /// </summary>
        public abstract void Start();
        /// <summary>
        /// Displays a given message to a given client.
        /// </summary>
        /// <param name="msg">The message to be displayed.</param>
        /// <param name="clientId">The ID by which we identify the client to send to.</param>
        public abstract void DisplayToClient(string msg, int clientId);
    }
}