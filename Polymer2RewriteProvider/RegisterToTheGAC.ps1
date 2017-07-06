Set-location "C:\Users\aaron-drabeck\Desktop\c\"
[System.Reflection.Assembly]::Load("System.EnterpriseServices, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")
$publish = New-Object System.EnterpriseServices.Internal.Publish
$publish.GacInstall("C:\Users\aaron-drabeck\Desktop\c\Polymer2RewriteProvider5.dll")

Set-location "C:\Users\aaron-drabeck\Desktop\c\"
[System.Reflection.Assembly]::Load("System.EnterpriseServices, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")
$publish = New-Object System.EnterpriseServices.Internal.Publish
$publish.GacInstall("C:\Users\aaron-drabeck\Desktop\c\UAParser.dll")
iisreset





