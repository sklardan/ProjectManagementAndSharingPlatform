﻿namespace DPSP_UI_LG.Models
{
    public class TokenModel
    {
        public string access_token { get; set; }
        public string token_type { get; set; }
        public string expires_in { get; set; }
        public string userName { get; set; }
        public string error { get; set; }
        public string error_description { get; set; }
    }


}
