using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

public static class Utillities
{
    public static void SetLimit(this TextBox tbox, params char[] characters)
    {
        List<char> charactersToCheck = new List<char>(characters);
        tbox.KeyPress += (obj, e) =>
            {
                if (!charactersToCheck.Contains(e.KeyChar))
                    e.KeyChar = '\b';
            };
    }

    public static void SetToNumeric(this TextBox tbox, string placeHolder = "")
    {
        tbox.Text = placeHolder;

        tbox.SetLimit('0', '1', '2', '3', '4', '5', '6', '7', '8', '9', ',', '.');
        tbox.OnKey(',', (x, e) =>
        {
            if (x.Text.Split(',').Length > 1)
                return false;
            return true;
        });
        tbox.OnKey('.', (x, e) =>
        {
            if (x.Text.Split(',').Length > 1)
                return false;
            e.KeyChar = ',';
            return true;
        });
        //remove 0 at front
        tbox.TextChanged += (x, y) =>
        {
            string[] split = tbox.Text.Split(',');
            if (split.Length > 1)
            {
                int selectionStart = tbox.SelectionStart;
                int selectionEnd = tbox.SelectionLength;

                if (split[0] == "" || int.Parse(split[0]) == 0)
                    split[0] = "0";

                if (split[1].Length > 2)
                    split[1] = split[1][0].ToString() + split[1][1];

                tbox.Text = split[0] + "," + split[1];

                if (selectionStart > tbox.TextLength)
                    tbox.SelectionStart = tbox.TextLength;
                else if (selectionStart != tbox.SelectionStart)
                    tbox.SelectionStart = selectionStart;
                if (selectionEnd > tbox.TextLength - tbox.SelectionStart)
                    tbox.SelectionLength = tbox.TextLength - tbox.SelectionStart;
            }
            else
            {
                int value = 0;
                //value is not placeholder
                if (int.TryParse(tbox.Text, out value))
                    tbox.Text = value.ToString();
            }

        };
        tbox.OnEmpty(placeHolder);
    }

    public static void OnEmpty(this TextBox tbox, string placeholder)
    {
        tbox.TextChanged += (x, y) =>
        {
            if (tbox.Text.Trim() == "")
                tbox.Text = placeholder;
        };
    }

    /// <param name="func"></param>
    public static void OnKey(this TextBox tbox, char key, Func<TextBox, KeyPressEventArgs, bool> func)
    {
        tbox.KeyPress += (obj, e) =>
        {
            if(e.KeyChar == key)
                if (!func(tbox, e))
                    e.KeyChar = '\0';
        };
    }
}
