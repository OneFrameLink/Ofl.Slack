namespace Ofl.Slack.WebApi.Methods
{
    internal abstract class Methods
    {
        #region Constructor

        protected Methods(WebApi webApi)
        {
            // Validate parameters.
            WebApi = webApi;
        }

        #endregion

        #region Instance, read-only state

        protected WebApi WebApi { get; }

        #endregion
    }
}
