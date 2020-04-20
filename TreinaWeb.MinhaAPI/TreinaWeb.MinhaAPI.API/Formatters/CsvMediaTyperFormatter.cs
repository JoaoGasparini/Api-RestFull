﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Web;

namespace TreinaWeb.MinhaAPI.API.Formatters
{
    public class CsvMediaTyperFormatter : BufferedMediaTypeFormatter
    {
        public CsvMediaTyperFormatter()
        {
            SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/csv"));
        }
        public override bool CanReadType(Type type)
        {
            return false;
        }
        public override bool CanWriteType(Type type)
        {
            if (type == null)
            {
                throw new ArgumentNullException("type");
            }
            return true;
        }

        public override void WriteToStream(Type type, object value, Stream writeStream, HttpContent content)
        {
            using (StreamWriter writer = new StreamWriter(writeStream))
            {
                IEnumerable enumerable = value as IEnumerable;
                if (enumerable == null)
                {
                    writer.WriteLine(string.Join(";", GetPropertyNames(type)));
                    WriteElement(value, writer);
                }
                else
                {
                    var dtoType = value.GetType().GetGenericArguments()[0];
                    writer.WriteLine(string.Join(";", GetPropertyNames(dtoType)));

                    foreach(var item in enumerable)
                    {
                        WriteElement(value, writer);
                    }
                }
            }
        }
        private IEnumerable<string> GetPropertyNames(Type type)
        {
            return type.GetProperties().Select(s=>s.Name);
        }
        private void WriteElement(object item, StreamWriter Writer)
        {

            string value = string.Empty;
            foreach (string property in GetPropertyNames(item.GetType()))
            {
                var propertyValue = item.GetType().GetProperty(property).GetValue(item);
                if (propertyValue != null)
                {
                    value += propertyValue.ToString();

                }
                value += ";";
                Writer.WriteLine(value.Substring(0, value.Length - 2));            
            };
        }
    }
}