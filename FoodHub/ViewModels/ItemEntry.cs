using FoodHub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodHub.ViewModels
{
    public class ItemEntry
    {
        public ITEM ITEM { get; set; }
        public List<ITEMLIST> ITEMLIST { get; set; }
        public List<STATUS_DROPDOWN> STATUS_DROPDOWN { get; set; }
        public List<ITEM_TYPE_DROPDOWN> ITEM_TYPE_DROPDOWN { get; set; }
        public List<CATE_CD_DROPDOWN> CATE_CD_DROPDOWN { get; set; }
        public string IMG_FILE { get; set; }
    }
    public class STATUS_DROPDOWN
    {
        public string Value { get; set; }
        public string Text { get; set; }
    }
    public class ITEM_TYPE_DROPDOWN
    {
        public string Value { get; set; }
        public string Text { get; set; }
    }
    public class CATE_CD_DROPDOWN
    {
        public int Value { get; set; }
        public string Text { get; set; }
    }
}