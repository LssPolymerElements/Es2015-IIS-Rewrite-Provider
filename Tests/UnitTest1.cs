using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void IeUserAgentResolvesEs5FilePath()
        {
            //Arrange
            var input = "FILE,|Mozilla/5.0 (Windows NT 10.0; WOW64; Trident/7.0; Touch; rv:11.0) like Gecko,|a=123&b=1222,|/images/test.html";
            var provider = new Polymer2RewriteProvider5.Polymer2RewriteProvider4();
            provider.Initialize(new Dictionary<string, string> { { "Delimiter", ",|" } }, null);

            //Act
            var result = provider.Rewrite(input);

            //Assert
            Assert.AreEqual("es5/images/test.html?a=123&b=1222", result);
        }

        [TestMethod]
        public void ChromeMobileUserAgentResolvesEs6FilePath()
        {
            //Arrange
            var input = "FILE,|Mozilla/5.0 (Linux; Android 7.1.2; Pixel XL Build/NKG47L) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/59.0.3071.125 Mobile Safari/537.36,|a=123&b=1222,|/images/test.html";
            var provider = new Polymer2RewriteProvider5.Polymer2RewriteProvider4();
            provider.Initialize(new Dictionary<string, string> { { "Delimiter", ",|" } }, null);

            //Act
            var result = provider.Rewrite(input);

            //Assert
            Assert.AreEqual("es6/images/test.html?a=123&b=1222", result);
        }

        [TestMethod]
        public void SafariUserAgentResolvesEs6FilePath()
        {
            //Arrange
            var input = "FILE,|Mozilla/5.0 (iPhone; CPU iPhone OS 11_0 like Mac OS X) AppleWebKit/604.1.21 (KHTML, like Gecko) Version/10.0 Mobile/15A5278f Safari/602.1,|a=123&b=1222,|/images/test.html";
            var provider = new Polymer2RewriteProvider5.Polymer2RewriteProvider4();
            provider.Initialize(new Dictionary<string, string> { { "Delimiter", ",|" } }, null);

            //Act
            var result = provider.Rewrite(input);

            //Assert
            Assert.AreEqual("es6/images/test.html?a=123&b=1222", result);
        }

        [TestMethod]
        public void SafariMobileUserAgentResolvesEs6FilePath()
        {
            //Arrange
            var input = "FILE,|Mozilla/5.0+(iPhone;+CPU+iPhone+OS+10_3_2+like+Mac+OS+X)+AppleWebKit/603.2.4+(KHTML,+like+Gecko)+Version/10.0+Mobile/14F89+Safari/602.1,|a=123&b=1222,|/images/test.html";
            var provider = new Polymer2RewriteProvider5.Polymer2RewriteProvider4();
            provider.Initialize(new Dictionary<string, string> { { "Delimiter", ",|" } }, null);

            //Act
            var result = provider.Rewrite(input);

            //Assert
            Assert.AreEqual("es6/images/test.html?a=123&b=1222", result);
        }



        
        [TestMethod]
        public void IosHomeScreenAppIconRequestUserAgentResolvesEs5FilePath()
        {
            //Arrange
            var input = "FILE,|MobileSafari/602.1+CFNetwork/811.5.4+Darwin/16.6.0,|a=123&b=1222,|/images/test.html";
            var provider = new Polymer2RewriteProvider5.Polymer2RewriteProvider4();
            provider.Initialize(new Dictionary<string, string> { { "Delimiter", ",|" } }, null);

            //Act
            var result = provider.Rewrite(input);

            //Assert
            Assert.AreEqual("es5/images/test.html?a=123&b=1222", result);
        }


        [TestMethod]
        public void IeUserAgentResolvesEs5RootPath()
        {
            //Arrange
            var input = "INDEX,|Mozilla/5.0 (Windows NT 10.0; WOW64; Trident/7.0; Touch; rv:11.0) like Gecko,|a=123&b=1222,|/search";
            var provider = new Polymer2RewriteProvider5.Polymer2RewriteProvider4();
            provider.Initialize(new Dictionary<string, string>{ { "Delimiter", ",|"}}, null);

            //Act
            var result = provider.Rewrite(input);

            //Assert
            Assert.AreEqual("es5/?a=123&b=1222", result);
        }

        [TestMethod]
        public void ChromeUserAgentResolvesEs6FilePath()
        {
            //Arrange
            var input = "FILE,|Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/59.0.3071.115 Safari/537.36,|,|/images/leavitt_group_logo.png";
            var provider = new Polymer2RewriteProvider5.Polymer2RewriteProvider4();
            provider.Initialize(new Dictionary<string, string> { { "Delimiter", ",|" } }, null);

            //Act
            var result = provider.Rewrite(input);

            //Assert
            Assert.AreEqual("es6/images/leavitt_group_logo.png", result);
        }

        [TestMethod]
        public void ChromeUserAgentResolvesEs6RootPath()
        {
            //Arrange
            var input = "INDEX,|Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/59.0.3071.115 Safari/537.36,|,|/search/asss";
            var provider = new Polymer2RewriteProvider5.Polymer2RewriteProvider4();
            provider.Initialize(new Dictionary<string, string> { { "Delimiter", ",|" } }, null);

            //Act
            var result = provider.Rewrite(input);

            //Assert
            Assert.AreEqual("es6/", result);
        }

        [TestMethod]
        public void Chrome99UserAgentResolvesEs6RootPath()
        {
            //Arrange
            var input = "INDEX,|Mozilla/5.0 (X11; Linux armv7l) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/99.77.34.5 Safari/537.36,|,|/search/asss";
            var provider = new Polymer2RewriteProvider5.Polymer2RewriteProvider4();
            provider.Initialize(new Dictionary<string, string> { { "Delimiter", ",|" } }, null);

            //Act
            var result = provider.Rewrite(input);

            //Assert
            Assert.AreEqual("es5/", result);
        }
    }
}
