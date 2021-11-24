namespace Degenooru.Berate.Client
{
    /// <summary>
    ///     A standard API error.
    /// </summary>
    public readonly struct ApiError
    {
        /// <summary>
        ///     The error code, if applicable. Defaults to <c>-1</c>.
        /// </summary>
        public readonly int ErrorCode;
        
        /// <summary>
        ///     The error reason, if applicable. Defaults to <c>""</c>.
        /// </summary>
        public readonly string ErrorReason;

        public ApiError(int errorCode = -1, string errorReason = "")
        {
            ErrorCode = errorCode;
            ErrorReason = errorReason;
        }
    }
}