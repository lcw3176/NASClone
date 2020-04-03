using System;

namespace Client.ModelSource
{
    public delegate void ModelHandler<IModel>(IModel sender, ModelEventArgs e);

    public class ModelEventArgs:EventArgs
    {
        public string newval;
        public ModelEventArgs(string v)
        {
            newval = v;
        }

    }
   
    public interface IModelObserver
    {
        void ValueChanged(IModel model, ModelEventArgs e);
        void ValueAdd(IModel model, ModelEventArgs e);
        void ProgressbarAdd(IModel model, ModelEventArgs e);
    }


    public interface IModel
    {
        void Attach(IModelObserver observer);
        void ShowList();
        void Download(string fileName);
        void valueCheck(bool data);
        void Upload();
        void Redownload(string fileName);
        void delete(string fileName);

    }
}
