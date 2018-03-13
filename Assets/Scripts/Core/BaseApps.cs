using UnityEngine;
using System.Collections;
using UnityEngine.Events;

namespace BaseApps
{
    public struct CONST_VAR
    {
        private const string STATUS_AKUN = "starter/";
        private const string API_ONGKIR = "https://api.rajaongkir.com/" + STATUS_AKUN;

        public const string API_KEY = "21275b6a203cca49016095c7810bf462";
        public const string GET_CITY = API_ONGKIR + "city?key=" + API_KEY;
        public const string GET_COST = API_ONGKIR + "cost";
    }
}
