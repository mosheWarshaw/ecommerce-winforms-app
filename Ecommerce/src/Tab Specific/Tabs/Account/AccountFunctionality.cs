using System;
using System.Threading.Tasks;

namespace ProjectNS.AccountNS
{
    class Functionality
    {
        private readonly IAccountData _data;
        public enum CredsType { LOGGING_IN, CREATING_ACCOUNT}
        private CredsType _credsType;
        private delegate Queries.Return QueryFunc(DbDataContext db, string username, string password);

        public Functionality(IAccountData data)
        {
            _data = data;
        }



        public async Task LogInClickedAsync()
        {
            _credsType = CredsType.LOGGING_IN;
            QueryFunc query = Queries.Exist;
            _HandleValidation(await _ValidateCredsAsync(query));
        }

        public async Task CreateAccountClickedAsync()
        {
            _credsType = CredsType.CREATING_ACCOUNT;
            QueryFunc query = Queries.Add;
            _HandleValidation(await _ValidateCredsAsync(query));
        }



        #region ValidateCreds
        private async Task<Queries.Return> _ValidateCredsAsync(QueryFunc query)
        {
            Queries.Return credsReturn = null;
            await Task.Run(() =>
            {
                credsReturn = _ValidateCreds(query);
            });
            return credsReturn;
        }

        private Queries.Return _ValidateCreds(QueryFunc query)
        {
            Queries.Return credsReturn;
            using (var db = new DbDataContext())
            {
                credsReturn = query(db, _data.Username, _data.Password);
            }
            return credsReturn;
        }
        #endregion



        private void _HandleValidation(Queries.Return credsReturn)
        {
            bool credsAreValid = credsReturn.TheBool;
            if (credsAreValid)
            {
                _data.UserId = (int) credsReturn.Id;
                _data.LoggedIn = true;
                _data.SetResponse("You're logged in.");
            }
            else
            {
                _data.SetResponse(_GetInvalidCredsMessage());
            }
        }
    

        private String _GetInvalidCredsMessage()
        {
            return _credsType == CredsType.LOGGING_IN ? "These credentials don't belong to an account." : $"Your username must be unique. {Environment.NewLine} Choose a different one.";
        }
    }
}
