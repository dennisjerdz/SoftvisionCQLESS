using System;
using System.Collections.Generic;
using System.Text;

namespace CognizantQLESS.Core.Constants
{
    public static class Constants
    {
        public const string UI_MESSAGE = "UI_MESSAGE";
        public const string UI_DROPDOWN_STATIONLINES = "UI_STATIONLINES";
        public const string UI_DROPDOWN_STATIONS = "UI_STATIONS";

        public const string ERR_INCORRECT_SERIALNUMBER = "Transaction failed. The Serial Number you entered doesn't exist.";
        public const string ERR_INSUFFICIENT_CASH = "Top up failed. Insufficient Cash.";
        public const string ERR_SAME_ORIGINDESTINATION = "Transaction failed. Origin and Destination must be different.";
        public const string ERR_ALREADY_REGISTERED_OR_PAST_REGISTRATION = "Registration failed. Transport card registration date has expired or is already registered. Registration Date: {0}";
        public const string ERR_CARD_EXPIRED = "Transaction failed. Your card expired on {0}. Please purchase a new one.";
        public const string ERR_FAREMODEL_MISSING = "Transaction failed. Origin ID:{0} and Destination ID:{1} can't be found in Fare Matrix.\n Please contact an admin.";
        public const string ERR_INSUFFICIENT_LOAD = "Transaction failed. Card balance/load is only {0}, you need {1} to take this ride.";
        public const string ERR_DISCOUNTREGISTRATION_MISSING = "Please fillout either Senior Citizen Control Number or PWD ID Number.";
        public const string ERR_GENERIC = "Transaction failed. Please contact admin.";

        public const string SUCCESS_DISCOUNTREGISTRATION = "Discount Registration successful. Your travels will now have 20% discount.";
        public const string SUCCESS_TOPUP = "Top up successful. Your change is {0}. Your new balance is {1}.";
        public const string SUCCESS_TRAVEL = "Transaction successful. Your new balance is {0}.";

        public const string NOTE_TRAVEL = "TRAVEL";
        public const string NOTE_TOPUP = "TOPUP";

        public const string ROLE_ADMIN = "ADMIN";
        public const string ROLE_MEMBER = "MEMBER";

        public const string CACHE_FARES = "CACHE_FARES";
        public const string CACHE_STATIONLINES = "CACHE_STATIONLINES";
        public const string CACHE_STATIONS = "CACHE_STATIONS";

        #region Station Names
        public const string STATION_BACLARAN = "Baclaran";
        public const string STATION_EDSA = "Edsa";
        public const string STATION_LIBERTAD = "Libertad";
        public const string STATION_GILPUYAT = "Gil Puyat";
        public const string STATION_VITOCRUZ = "Vito Cruz";
        public const string STATION_QUIRINO = "Quirino";
        public const string STATION_PEDROGIL = "Pedro Gil";
        public const string STATION_UNAVENUE = "U.N. Avenue";
        public const string STATION_CENTRAL = "Central Terminal";
        public const string STATION_CARRIEDO = "Carriedo";
        public const string STATION_DOROTEOJ = "Doroteo Jose";
        public const string STATION_BAMBANG = "Bambang";
        public const string STATION_TAYUMAN = "Tayuman";
        public const string STATION_BLUMENTRITT = "Blumentritt";
        public const string STATION_ABADSANTOS = "Abad Santos";
        public const string STATION_RPAPA = "R. Papa";
        public const string STATION_5THAVENUE = "5th Avenue";
        public const string STATION_MONUMENTO = "Monumento";
        public const string STATION_BALINTAWAK = "Balintawak";
        public const string STATION_ROOSEVELT = "Roosevelt";

        public const string STATION_RECTO = "Recto";
        public const string STATION_LEGARDA = "Legarda";
        public const string STATION_PUREZA = "Pureza";
        public const string STATION_VMAPA = "V. Mapa";
        public const string STATION_JRUIZ = "J. Ruiz";
        public const string STATION_GILMORE = "Gilmore";
        public const string STATION_BETTYGO = "Betty-Go";
        public const string STATION_CUBAO = "Cubao";
        public const string STATION_ANONAS = "Anonas";
        public const string STATION_KATIPUNAN = "Katipunan";
        public const string STATION_SANTOLAN = "Santolan";
        #endregion
    }
}
