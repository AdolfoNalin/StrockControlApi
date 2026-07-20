namespace StockControlApi.Libiries
{
    public class MessageException
    {
        #region MessageBadRequest
        /// <summary>
        /// Function responsable for settings the message BadRequest
        /// </summary>
        /// <param name="ex"></param>
        /// <returns>String format</returns>
        public static string MessageBadRequest(Exception ex)
        {
            return $"{ex.Message}, {ex.StackTrace}, {ex.HelpLink}";
        }
        #endregion
    }
}
