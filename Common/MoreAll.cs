using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class MoreAll
    {
        public class commond
        {
            public static string Enable(string enable)
            {
                if (enable.Trim().Equals("0"))
                {
                    return "<i class=\"icon-check-empty\"></i>";
                }
                return "<i class=\"icon-check\"></i>";
            }
        }
        public static string NamNam(object date)
        {
            return (Convert.ToDateTime(date).ToString("yyyy"));
        }
        public static string Date_ngay(object date)
        {
            return (Convert.ToDateTime(date).ToString("dd"));
        }
        public static string Date_Thang(object date)
        {
            return Thang((Convert.ToDateTime(date).ToString("MM")));
        }
        private static string Thang(string gNumber)
        {
            string result = "";
            switch (gNumber)
            {
                case "01":
                    result = "JAN";
                    break;
                case "02":
                    result = "Feb";
                    break;
                case "03":
                    result = "Mar";
                    break;
                case "04":
                    result = "Apr";
                    break;
                case "05":
                    result = "May";
                    break;
                case "06":
                    result = "Jun";
                    break;
                case "07":
                    result = "Jul";
                    break;
                case "08":
                    result = "Aug";
                    break;
                case "09":
                    result = "Sep";
                    break;
                case "10":
                    result = "Oct";
                    break;
                case "11":
                    result = "Now";
                    break;
                case "12":
                    result = "Dec";
                    break;
            }
            return result;
        }
        public static string FormatDate(object date)
        {
            return (Convert.ToDateTime(date).ToString("dd/MM/yyyy hh:mm"));
        }
        public static string Date(object date)
        {
            return (Convert.ToDateTime(date).ToString("dd/MM/yyyy"));
        }
        public static string NgayThang(object date)
        {
            return (Convert.ToDateTime(date).ToString("dd/MM"));
        }
        public static string IDDate(object date)
        {
            return (Convert.ToDateTime(date).ToString("ddMMyyyy"));
        }
        public static string Enable(string enable)
        {
            if (enable.Trim().Equals("0"))
            {
                return "<i class=\"icon-check-empty\"></i>";
            }
            return "<i class=\"icon-check\"></i>";
        }
        public static string Image(string image)
        {
            if (image.Length > 0)
            {
                return "<img src='" + image + "' style='Width:100px;Height:100px'  border=0>";
            }
            return "";
        }
        public static string FormatMoney(string money)
        {
            if (money.Length > 0)
            {
                double value = Convert.ToDouble(money.ToString());
                string str = value.ToString("#,##,##");
                return str.Replace(",", ",") + " đ";
            }
            else
            {
                return "0 đ";
            }
        }
    }
}
