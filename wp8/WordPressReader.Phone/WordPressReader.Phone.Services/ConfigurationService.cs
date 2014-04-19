﻿using System;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Windows.Storage;
using WordPressReader.Phone.Contracts.Services;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Storage.Streams;
using System.IO;

namespace WordPressReader.Phone.Services
{
    public class ConfigurationService : IConfigurationService
    {
        public string GetCategoryFilter()
        {
            return null;
        }

        public string GetFeedUrl(string category)
        {
            //return "http://www.lepotaizdravlje.rs/category/extra/blog/feed";
            //return "http://www.vitkigurman.com/feed/";
            if (category == "<default>")
            {
                return "http://nokiamob.me/feed/";
            }
            return string.Format("http://nokiamob.me/category/{0}/feed/", category);
            //return "http://www.vecnidecak.com/feed/";
        }

        public string GetContentXPath()
        {
            //return "//div[@class='entry']";
            //return "/html[1]/body[1]/div[1]/div[2]/div[3]/div[1]/div[1]/div[3]";
            //return "//div[@class='pf-content']";
            return "//div[@class='entry-content']";
            //return "//div[@class='entry fix']";
        }

        public async Task<string> GetArticleTemplateAsync()
        {
            var file = await StorageFile.GetFileFromApplicationUriAsync(new Uri("ms-appx:///Assets/Templates/ArticleTemplate.html"));
            using (var s = await file.OpenReadAsync())
            {
                using(var reader = new StreamReader(s.AsStreamForRead()))
                {
                    return (await reader.ReadToEndAsync())
                        .Replace("{","{{").Replace("[[","{")
                        .Replace("}","}}").Replace("]]","}");
                }
            }
        }


        public string ProcessHtml(string html)
        {
            return html.Replace("width='584' height='359'", "").Trim();
        }
    }
}
