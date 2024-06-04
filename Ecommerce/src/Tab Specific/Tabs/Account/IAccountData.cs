using System;

namespace ProjectNS.AccountNS
{
    interface IAccountData
    {
        int UserId { set; }
        String Username { get; }
        String Password { get; }
        void SetResponse(String response);
        bool LoggedIn { get; set; }
    }
}
