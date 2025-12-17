namespace Diga.WebView2.Wrapper.EventArguments
{

    public class SourceChangedEventArgs : EventArgs
    {
        public SourceChangedEventArgs(bool isNewDocument, string url)
        {
            this.IsNewDocument = isNewDocument;
            this.Url = url;
        }

        public bool IsNewDocument { get; }
        public string Url { get; }

    }
}
