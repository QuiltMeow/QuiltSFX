using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuiltSFX
{
    public class ListViewFileComparer : IComparer
    {
        public const string FOLDER_KEY = "/資料夾";

        public int Compare(object left, object right)
        {
            ListViewItem leftItem = left as ListViewItem;
            ListViewItem rightItem = right as ListViewItem;

            string leftImageKey = leftItem.ImageKey;
            string rightImageKey = rightItem.ImageKey;

            string leftText = leftItem.Text;
            string rightText = rightItem.Text;
            if (leftImageKey == FOLDER_KEY && rightImageKey == FOLDER_KEY)
            {
                return string.Compare(leftText, rightText);
            } else if (leftImageKey == FOLDER_KEY)
            {
                return -1;
            } else if (rightImageKey == FOLDER_KEY)
            {
                return 1;
            }
            return string.Compare(leftText, rightText);
        }
    }
}