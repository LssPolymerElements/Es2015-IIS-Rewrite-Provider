using System;
using System.Collections.Generic;
using Microsoft.Web.Iis.Rewrite;
using UAParser;

namespace Polymer2RewriteProvider5
{
   public class Polymer2RewriteProvider4 : IRewriteProvider, IProviderDescriptor
    {
        private string _delimiter;

        #region IRewriteProvider Members

        public void Initialize(IDictionary<string, string> settings, IRewriteContext rewriteContext)
        {
            string delimiterString;
            if (!settings.TryGetValue("Delimiter", out delimiterString) || string.IsNullOrEmpty(delimiterString))
                throw new ArgumentException("Delimiter provider setting is required and cannot be empty");

            if (!string.IsNullOrEmpty(delimiterString))
                _delimiter = delimiterString.Trim();
            else
                throw new ArgumentException("Delimiter parameter cannot be empty");

        }

        public string Rewrite(string value)
        {
            var parameters = value.Split(new [] { _delimiter }, StringSplitOptions.None);
            if (parameters.Length < 4)
                return "es6/";


            var type = parameters[0];
            var agent = parameters[1];
            var queryString = parameters[2];
            var path = parameters[3];
            var uaParser = Parser.GetDefault();
            var c = uaParser.Parse(agent);

            int majorVersion=0;
            int.TryParse(c.UserAgent.Major, out majorVersion);

            int minorVersion=0;
            int.TryParse(c.UserAgent.Minor, out minorVersion);

            var name = c.UserAgent.Family;

            var supportsEs2015 = ((name == "Chrome" || name == "Chrome Mobile") && majorVersion >= 49) ||
                                 (name == "Chromium" && majorVersion >= 49) ||
                                 (name == "OPR" && majorVersion >= 36) ||
                                 (name == "Vivaldi" && majorVersion >= 1) ||
                                 ((name == "Mobile Safari" || name == "Mobile Safari UIWebView") && majorVersion >= 10) ||
                                 (name == "Safari" && majorVersion >= 10) ||
                                 // Note: The Edge user agent uses the EdgeHTML version, not the main
                                 // release version (e.g. EdgeHTML 15 corresponds to Edge 40). See
                                 // https://en.wikipedia.org/wiki/Microsoft_Edge#Release_history.
                                 //
                                 // Versions before 15.15063 may contain a JIT bug affecting ES6
                                 // constructors (see #161).
                                 (name == "Edge" &&
                                  (majorVersion > 15 || (majorVersion == 15 && minorVersion >= 15063))) ||
                                 (name == "Firefox" && majorVersion >= 51);

            var esVersion = supportsEs2015 ? "es6" : "es5";

            // Used to detect airtame devices
            if (c.String.Contains("armv7l"))
                esVersion = "es5";

            if (!string.IsNullOrEmpty(queryString))
                queryString = $"?{queryString}";

            return type == "FILE" ? $"{esVersion}{path}{queryString}" : $"{esVersion}/{queryString}";
        }

        #endregion

        #region IProviderDescriptor Members

        public IEnumerable<SettingDescriptor> GetSettings()
        {
            yield return new SettingDescriptor("Delimiter", "Delimiter for value");
        }

        #endregion
    }
}
