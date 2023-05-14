using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collie.Tests;
public class TempTests
{
    //[Test]
    [TestCase("mypage/lol")]
    [TestCase("/mypage/lol")]
    [TestCase("")]
    public void TempTest1(string href)
    {
        //string uri = "http://www.google.se/mypage/lol/1/";
        //var actualPath = uri.Replace("http://www.google.se/", string.Empty);

        //if (href.FirstOrDefault() == '/')
        //{
        //    href = href[1..];
        //}
        

        Assert.That(href[0..href.Length], Is.EqualTo(href));
    }
}
