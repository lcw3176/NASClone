using Client.ModelSource;
using Client.ViewSource;

namespace Client.ControllerSource
{
    public class Controller : IController
    {
        IView view;
        IModel model;
        
        public Controller(IView v, IModel m)
        {
            view = v;
            model = m;
            view.SetController(this);
            model.Attach((IModelObserver)view);
            view.isConnect += new ViewHandler<IView>(this.ConnectionChanged);
        }

        public void ClickUpload()
        {
            model.Upload();
        }

        public void ConnectionChanged(IView v, ViewEventArgs e)
        {
            model.valueCheck(e.isTrue);
        }

        public void ClickFile(string fileName)
        {
            model.Download(fileName);
        }

        public void DeleteButton(string fileName)
        {
            model.delete(fileName);
        }

        public void Refresh()
        {
            model.ShowList();
        }

        public void reDownload(string fileName)
        {
            model.Redownload(fileName);
        }

    }
}
