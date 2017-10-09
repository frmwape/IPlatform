using System.Web.Mvc;

namespace People.Utils
{
    public class Provinces
    {
        public static SelectListItem[] ProvinceList()
        {
            return new SelectListItem[6] {  new SelectListItem() { Text = "UNKOWN" },
                                            new SelectListItem() { Text = "GAUTENG" },
                                            new SelectListItem() { Text = "KWAZULU NATAL" },
                                            new SelectListItem() { Text = "MPUMALANGA" },
                                            new SelectListItem() { Text = "WESTERN CAPE" },
                                            new SelectListItem() { Text = "CAPE TOWN" }
            };
        }
    }
}