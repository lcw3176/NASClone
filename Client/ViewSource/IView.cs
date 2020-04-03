using Client.ControllerSource;
using System;

namespace Client.ViewSource
{
    public delegate void ViewHandler<IView>(IView sender, ViewEventArgs e);

    public class ViewEventArgs:EventArgs
    {
        public bool isTrue;
        public ViewEventArgs(bool data)
        {
            isTrue = data;
        }
    }

    public interface IView
    {
        event ViewHandler<IView> isConnect;
        void SetController(IController controller);
    }
}
