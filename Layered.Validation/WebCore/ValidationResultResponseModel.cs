namespace Layered.Common.WebCore
{
    public class ValidationResultResponseModel<TResult> : ValidationResponseModel
    {
        public ValidationResultResponseModel(TResult model)
        {
            Result = model;
        }

        /// <summary>
        /// Die (primäre) Antwort der Methode.
        /// </summary>
        public TResult Result { get; set; }
    }
}
