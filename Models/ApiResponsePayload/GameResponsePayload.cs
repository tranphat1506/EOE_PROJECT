using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E2E_APPLICATION.Models.ApiResponsePayload
{
    public class GetGameResponse
    {
        public int GameId { get; set; }
        public string Game_Name { get; set; }
        public string Game_Desc { get; set; }
        public string Game_Image { get; set; }
        public string GameImageId { get; set; }
        public MediaResponse GameImage { get; set; }
    }

    public class MediaResponse
    {
        public string MediaId { get; set; }
        public string MediaName { get; set; }
        public string MediaType { get; set; }
        public string MediaUrl { get; set; }
        public string Tags { get; set; }
    }
}
