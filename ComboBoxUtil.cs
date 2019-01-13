/*
-----------------------------------------------------------------------------
Copyright (c) 2010 ClaimRemedi, Inc. All Rights Reserved.

PROPRIETARY NOTICE: This software has been provided pursuant to a
License Agreement that contains restrictions on its use. This software
contains valuable trade secrets and proprietary information of
ClaimRemedi, Inc and is protected by Federal copyright law.  It may not 
be copied or distributed in any form or medium, disclosed to third parties, 
or used in any manner that is not provided for in said License Agreement, 
except with the prior written authorization of ClaimRemedi, Inc.

-----------------------------------------------------------------------------
$Log: /ClaimRemedi/Code/ClaimRemedi.BatchEligibilityFTPManager/ComboBoxUtil.cs $
 
 3     5/26/10 9:07a Shanson
 Added log header
-----------------------------------------------------------------------------
*/

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Windows.Forms;

namespace GolfStatKeeper
{
    class ComboBoxUtil
    {
        public static void PopulateCBFromEnum(ComboBox cb, Type EnumType)
        {
            cb.DisplayMember = "Name";
            cb.ValueMember = "ID";
            cb.DataSource = MakeCBItemsFromEnum(EnumType);
        }
        public static void PopulateCBFromStringArray(ComboBox cb, string[] listOfNames)
        {
            cb.DisplayMember = "Name";
            cb.ValueMember = "ID";
            cb.DataSource = MakeCBItemsFromStringArray(listOfNames);
        }
        public static void PopulateCBFromCBItemArray(ComboBox cb, CBItem[] clubs)
        {
            cb.DisplayMember = "Name";
            cb.ValueMember = "ID";
            cb.DataSource = clubs;
        }
        
        public static CBItem[] MakeCBItemsFromEnum(Type EnumType)
        {
            string[] names = Enum.GetNames(EnumType);
            Array values = Enum.GetValues(EnumType);
            ArrayList itemList = new ArrayList();
            for (int i = 0; i < names.Length; i++)
            {
                string[] item = new string[2];
                item[0] = names[i];
                //item[1] = i.ToString();
                item[1] = ((int)values.GetValue(i)).ToString();

                itemList.Add(item);
            }

            return MakeCBItemsFromStringArrayList(itemList);
        }
        public static CBItem[] MakeCBItemsFromStringArrayList(ArrayList list)
        {
            CBItem[] cbItems = new CBItem[list.Count];
            for(int i = 0; i < list.Count; i++)
            {
                String[] s = list[i] as string[];
                cbItems[i] = (new CBItem(s[1], s[0]));
            }
            return cbItems;
        }
        public static CBItem[] MakeCBItemsFromStringArray(string[] listOfNames)
        {
            // assume IDs of 1 through X, and make CBItems
            CBItem[] cbItems = new CBItem[listOfNames.Length];
            for (int i = 0; i < listOfNames.Length; i++)
            {
                cbItems[i] = (new CBItem(i.ToString(), listOfNames[i]));
            }
            return cbItems;
        }
        public static CBItem GetItemByValue(ComboBox.ObjectCollection items, string value)
        {
            foreach (object item in items)
            {
                if ((item as CBItem).ID == value)
                {
                    return (item as CBItem);
                }
            }
            return null;
        }
        public static CBItem GetItemByName(ComboBox.ObjectCollection items, string name)
        {
            foreach (object item in items)
            {
                if ((item as CBItem).Name.ToLower() == name.ToLower())
                {
                    return (item as CBItem);
                }
            }
            return null;
        }

        public static void SelectItemByValue(ComboBox cb, string val)
        {
            for (int i = 0; i < cb.Items.Count; i++)
            {
                CBItem thisItem = (cb.Items[i] as CBItem);
                if (thisItem.Name == val ||
                    thisItem.ID == val)
                {
                    cb.SelectedItem = thisItem;
                    cb.SelectedText = thisItem.Name;
                    cb.SelectedValue = thisItem.ID;
                }
            }
        }
    }
    public class CBItem
    {
        private string m_strId;
        public string ID
        {
            get
            {
                return m_strId;
            }
            set
            {
                m_strId = value;
            }
        }
        private string m_strName;
        public string Name
        {
            get
            {
                return m_strName;
            }
            set
            {
                m_strName = value;
            }
        }

        public CBItem(string ID, string Name)
        {
            this.ID = ID;
            this.Name = Name;
        }
    }
}
