namespace ApiLayer.Common
{
    public class ResponseResult<T>
    {
            private bool _isError = false;
            //private bool IsSuccess { get; set; }
            private bool _isSuccess = false;
            private string _message = "";
            private int ErrorCount { get; set; }
            private int SavedCount { get; set; }

            public bool IsSuccess
            {
                get
                {
                    return _isSuccess;
                }
                set
                {
                    _isSuccess = value;
                }
            }
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
            public string message
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

            public ResponseResult()
            {

            }
            public ResponseResult(T value)
            {
                Result = value;
            }
    }
}
