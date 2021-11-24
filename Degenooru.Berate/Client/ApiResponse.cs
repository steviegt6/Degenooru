namespace Degenooru.Berate.Client
{
    /// <summary>
    ///     A standard response from an API module.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public struct ApiResponse<T>
    {
        /// <summary>
        ///     The response's value. Will be <see langword="null"/> if an error was caught and handled, but a return value could not be produced.
        /// </summary>
        public readonly T? Value;

        /// <summary>
        ///     The description of the caught-but-not-managed error. Will be <see langword="null"/> if there were no errors.
        /// </summary>
        public readonly ApiError? Error;

        public ApiResponse(T? value, ApiError? error)
        {
            Value = value;
            Error = error;
        }
    }
}