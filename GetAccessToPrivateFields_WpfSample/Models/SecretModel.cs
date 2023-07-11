namespace GetAccessToPrivateFields_WpfSample.Models
{
    internal class SecretModel
    {
        private string _secret = "PrIvAtE TeSt StRiNg!!!1111адынадынадын1111!!!";
        private static string _staticSecret = "PrIvAtE TeSt StAtIc StRiNg!!!1111адынадынадын1111!!!";

        #region Nested Class to get access to private value
        public class SecretTokenSource
        {
            private readonly SecretModel _token; 
            public SecretTokenSource(SecretModel token)
            {
                this._token = token;
            }
            public string GetSecret() => this._token._secret;
        }
        #endregion
    }
    internal static class StaticSecretModel
    {
        private static string _staticSecret = "PrIvAtE TeSt StAtIc ClAsS sTaTiC StRiNg!!!1111адынадынадын1111!!!";
    }
}
