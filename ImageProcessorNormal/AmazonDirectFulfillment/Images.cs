using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonDirectFulfillment
{
    public class Images
    {
        //ImageFileName
        //ItemNo
        //DescriptionCode
        //ASIN
        public string ImageFileName { get; set; }
        public string ItemNo { get; set; }
        public string DescriptionCode { get; set; }
        public string ASIN { get; set; }

        public string FullInfo
        {
            get
            {
                return $"{ ImageFileName } { ItemNo } { DescriptionCode } { ASIN }";
            }
        }
    }
}
