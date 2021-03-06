﻿using HackNet.Security;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Core;
using System.Linq;
using System.Web;

namespace HackNet.Data
{
    [Serializable]
    public partial class Items
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public ItemType ItemType { get; set; }
        public byte[] ItemPic { get; set; }
        public string ItemDesc { get; set; }
        public int ItemPrice { get; set; }
        public int ItemBonus { get; set; }

        internal static Items GetItem(int id, int itemType = -1, bool ReadOnly = true, DataContext db = null)
        {
            if (ReadOnly)
            {
                using (DataContext db1 = new DataContext())
                {
                    Items itm = new Data.Items();
                    if (itemType == -1)
                    {
                        itm = (from i in db1.Items where i.ItemId == id select i).FirstOrDefault();
                    }
                    else
                    {
                        itm = (from i in db1.Items where (i.ItemId == id && i.ItemType == (ItemType)itemType) select i).FirstOrDefault();
                    }
                    return itm;
                }
            }
            else
            {
                Items itm;
                if (itemType == -1)
                {
                    itm = (from i in db.Items where i.ItemId == id select i).FirstOrDefault();
                }
                else
                {
                    itm = (from i in db.Items where (i.ItemId == id && i.ItemType == (ItemType)itemType) select i).FirstOrDefault();
                }

                return itm;
            }

     
        }

        internal static List<Items> GetItems(int itemType)
        {
            List<Items> itemList = new List<Items>();
            try
            {
                using (DataContext db = new DataContext())
                {
                    if (itemType != -1)
                    {
                        var query = from i in db.Items where i.ItemType == (ItemType)itemType select i;
                        return query.ToList();
                    }
                    else
                    {
                        var query = from i in db.Items where (itemType != 5) select i;
                        return query.ToList();

                    }
                }
            }
            catch (EntityCommandExecutionException)
            {
                throw new ConnectionException("Database link failure has occured");
            }
        }
    }

    public enum ItemType
    {
        PartCpu = 1,
        PartRam = 2,
        PartPower = 3,
        PartGpu = 4,
        Bonus = 0,
        Currency = 5
    }


    public static class ItemTypeExtension
    {

        public static bool IsPart(this ItemType it)
        {
            switch (it)
            {
                case ItemType.PartCpu:
                    return true;
                case ItemType.PartGpu:
                    return true;
                case ItemType.PartPower:
                    return true;
                case ItemType.PartRam:
                    return true;
                case ItemType.Bonus:
                    return false;
                case ItemType.Currency:
                    return true;
                default:
                    return false;
            }
        }
    }
}