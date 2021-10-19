using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serialization
{
    public class Games
    {
        
        public string name { get; set; }
        public string platform { get; set; }
        public string release_date { get; set; }
        public string summary { get; set; }
        public string meta_source { get; set; }
        public string user_review { get; set; }

        public Games()
        {
            name = "";
            platform = "";
            release_date="";
            summary="";
            meta_source = "";
            user_review = "";
                
        }
        public Games(string data)
        {
            var files = data.Split(',');
            name = files[0];
            platform = files[1];
            release_date = files[2];
            summary = files[3];
            meta_source = files[4];
            user_review = files[5];
        }
        public override string ToString()
        {
            return $"{name}";
        }
    }
}
