using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace HtmlSelectHelper
{
    public static class SelectListHelper
    {
        

        public static SelectList GetSelectList<T>(IEnumerable<T> e, string valueField, string textField, bool pleaseSelect=false, string pleaseSelectText="", string pleaseSelectValue="")
        {
            if (e == null)
                throw new ArgumentNullException();

            if (!e.Any())
                throw new Exception("IEnumerable was not contains any element.");

            var list = new List<ListItem>();

            foreach (var item in e)
            {
                var t = new ListItem();
                var va = GetPropValue(item, valueField);
                var te = GetPropValue(item, textField);

                t.Value = va;
                t.Text = te;
                list.Add(t);
            }
            if(pleaseSelect)
                list.Insert(0, new ListItem { Text = string.IsNullOrEmpty(pleaseSelectText) ? "Please select" : pleaseSelectText, Value = string.IsNullOrEmpty(pleaseSelectValue) ? "" : pleaseSelectValue});

            return new SelectList(list,valueField,textField);

        }

        public static SelectList ToSelectList<T>(this IEnumerable<T> e, string valueField, string textField, bool pleaseSelect = false, string pleaseSelectText = "", string pleaseSelectValue = "")
        {
            return GetSelectList(e, valueField, textField, pleaseSelect, pleaseSelectText, pleaseSelectValue);
        }



        private static string GetPropValue(object src, string propName)
        {
            //http://stackoverflow.com/questions/1196991/get-property-value-from-string-using-reflection-in-c-sharp
            //var v = src.GetType().GetProperty(propName).GetValue(src, null);

            var type = src.GetType();
            var prop = type.GetProperty(propName);
            
            if (prop == null)
                throw new Exception("The object does not contain property named '" + propName + "'");

            var val = prop.GetValue(src, null);

            if (val == null)
                return string.Empty;

            return val.ToString();
        }


    }
}
