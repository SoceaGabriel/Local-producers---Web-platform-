using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProducatoriLocali.Repositories
{
    public enum ApiAccountResponse
    {
        LOGIN_SUCCESS,
        LOGIN_ERROR,
        LOGIN_EXCEPTION,
        REGISTER_SUCCESS,
        REGISTER_ERROR,
        REGISTER_EXCEPTION,
        LOGOUT_EXCEPTION,
        MODIFYACCOUNTINFO_SUCCESS,
        MODIFYACCOUNTINFO_ERROR,
        MODIFYACCOUNTINFO_EXCEPTION,
    }
}