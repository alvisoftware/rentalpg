using Newtonsoft.Json;

namespace Presentations.Common
{
    public class ResponseResultAdmin<T>
    {
        private bool _isError = false;
        public bool IsSuccess { get; set; }
        private string _message = "";

        public int ErrorCount { get; set; }
        public int SavedCount { get; set; }

        [JsonIgnore]
        public Exception Exception { get; set; }


        public bool IsError
        {
            get
            {
                return _isError;
            }

            set
            {
                _isError = value;
            }
        }

        public string Message
        {
            get
            {
                return _message;
            }
            set
            {
                _message = value;
            }
        }
        public T Result { get; set; }

        public ResponseResultAdmin()
        {
        }

        public ResponseResultAdmin(T value)
        {
            Result = value;
        }
    }
}
