namespace Client.ControllerSource
{
    public interface IController
    {
        void Refresh();
        void ClickFile(string fileName);
        void ClickUpload();
        void reDownload(string fileName);
        void DeleteButton(string fileName);
    }
}
