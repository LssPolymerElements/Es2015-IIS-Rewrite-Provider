This module will rewrite urls to the es5 folder if an es5 browser is detected or es6 if a es6 browser is detected.

1. You must build and register Polymer2RewriteProviderX.dll and UAParser.dll to the GAC on the web server.  
2. You must the setup an IIS provider and add a provider setting with ",|" as a delimiter.

[MORE DOCS ON HOW TO REGISTER AND SETUP THE PROVIDER](https://docs.microsoft.com/en-us/iis/extensions/url-rewrite-module/developing-a-custom-rewrite-provider-for-url-rewrite-module)


Sample rewrite rules for web.config
``` html
 <rule name="Polymer2ExtensionLessUrls" patternSyntax="Wildcard" stopProcessing="true">
          <match url="*.*" negate="true" />
          <conditions>
            <add input="{REQUEST_FILENAME}" matchType="IsDirectory" negate="true" />
            <add input="{REQUEST_FILENAME}" matchType="IsFile" negate="true" />
          </conditions>
         <action type="Rewrite" url="{Polymer2Rewriter:INDEX,|{HTTP_USER_AGENT},|{QUERY_STRING},|{URL}}" />
        </rule>		
        <rule name="Polymer2Es5Es6Rewrite" stopProcessing="true">
          <match url="(.*)" />
         <action type="Rewrite" url="{Polymer2Rewriter:FILE,|{HTTP_USER_AGENT},|{QUERY_STRING},|{URL}}" />
        </rule>   
      </rules>

```
