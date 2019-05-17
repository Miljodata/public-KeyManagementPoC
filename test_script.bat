SET execPath=%~dp0

::Simple
copy %execPath%"KeyManagementPoC\bin\Release\KeyManagementPoC.exe_simple.config" %execPath%"KeyManagementPoC\bin\Release\KeyManagementPoC.exe.config" /y

for /l %%x in (1, 1, 10) do (
%execPath%"KeyManagementPoC\bin\Release\KeyManagementPoC.exe"
copy %execPath%"BenchmarkDotNet.Artifacts\results\KeyManagementPoC.ApiDatabasePrivatePublicCertificate-report.csv" %execPath%"BenchmarkDotNet.Artifacts\results\KeyManagementPoC.ApiDatabasePrivatePublicCertificate-report_simple.csv_%%x" /y
)


::Knox
"C:\Program Files\Oracle\VirtualBox\VBoxManage.exe" controlvm UbuntuKMS savestate
timeout /t 60 /nobreak
"C:\Program Files\Oracle\VirtualBox\VBoxManage.exe" snapshot UbuntuKMS restore 6f79ca97-9c3d-4e0a-9163-6dddbbf90728
timeout /t 30 /nobreak
"C:\Program Files\Oracle\VirtualBox\VBoxManage.exe" startvm UbuntuKMS
timeout /t 60 /nobreak
copy %execPath%"KeyManagementPoC\bin\Release\KeyManagementPoC.exe_knox.config" %execPath%"KeyManagementPoC\bin\Release\KeyManagementPoC.exe.config" /y

for /l %%x in (1, 1, 10) do (
%execPath%"KeyManagementPoC\bin\Release\KeyManagementPoC.exe"
copy %execPath%"BenchmarkDotNet.Artifacts\results\KeyManagementPoC.ApiDatabasePrivatePublicCertificate-report.csv" %execPath%"BenchmarkDotNet.Artifacts\results\KeyManagementPoC.ApiDatabasePrivatePublicCertificate-report_knox.csv_%%x" /y
)

::Vault
"C:\Program Files\Oracle\VirtualBox\VBoxManage.exe" controlvm UbuntuKMS savestate
timeout /t 60 /nobreak
"C:\Program Files\Oracle\VirtualBox\VBoxManage.exe" snapshot UbuntuKMS restore d543d09e-b1f1-441f-8647-a8a8d267e518
timeout /t 30 /nobreak
"C:\Program Files\Oracle\VirtualBox\VBoxManage.exe" startvm UbuntuKMS
timeout /t 60 /nobreak
copy %execPath%"KeyManagementPoC\bin\Release\KeyManagementPoC.exe_vault.config" %execPath%"KeyManagementPoC\bin\Release\KeyManagementPoC.exe.config" /y

for /l %%x in (1, 1, 10) do (
%execPath%"KeyManagementPoC\bin\Release\KeyManagementPoC.exe"
copy %execPath%"BenchmarkDotNet.Artifacts\results\KeyManagementPoC.ApiDatabasePrivatePublicCertificate-report.csv" %execPath%"BenchmarkDotNet.Artifacts\results\KeyManagementPoC.ApiDatabasePrivatePublicCertificate-report_vault.csv_%%x" /y
)



::Keywhiz
"C:\Program Files\Oracle\VirtualBox\VBoxManage.exe" controlvm UbuntuKMS savestate
timeout /t 60 /nobreak
"C:\Program Files\Oracle\VirtualBox\VBoxManage.exe" snapshot UbuntuKMS restore 01efbc6e-a7a8-4a64-acd3-0dc832aef272
timeout /t 30 /nobreak
"C:\Program Files\Oracle\VirtualBox\VBoxManage.exe" startvm UbuntuKMS
timeout /t 60 /nobreak
copy %execPath%"KeyManagementPoC\bin\Release\KeyManagementPoC.exe_keywhiz.config" %execPath%"KeyManagementPoC\bin\Release\KeyManagementPoC.exe.config" /y

for /l %%x in (1, 1, 10) do (
%execPath%"KeyManagementPoC\bin\Release\KeyManagementPoC.exe"
copy %execPath%"BenchmarkDotNet.Artifacts\results\KeyManagementPoC.ApiDatabasePrivatePublicCertificate-report.csv" %execPath%"BenchmarkDotNet.Artifacts\results\KeyManagementPoC.ApiDatabasePrivatePublicCertificate-report_keywhiz.csv_%%x" /y
)


::Barbican
"C:\Program Files\Oracle\VirtualBox\VBoxManage.exe" controlvm UbuntuKMS savestate
timeout /t 60 /nobreak
"C:\Program Files\Oracle\VirtualBox\VBoxManage.exe" snapshot UbuntuKMS restore 2b40c204-12ae-44b5-ae32-cdc7b26aa87a
timeout /t 30 /nobreak
"C:\Program Files\Oracle\VirtualBox\VBoxManage.exe" startvm UbuntuKMS
timeout /t 60 /nobreak
copy %execPath%"KeyManagementPoC\bin\Release\KeyManagementPoC.exe_barbican.config" %execPath%"KeyManagementPoC\bin\Release\KeyManagementPoC.exe.config" /y

for /l %%x in (1, 1, 10) do (
%execPath%"KeyManagementPoC\bin\Release\KeyManagementPoC.exe"
copy %execPath%"BenchmarkDotNet.Artifacts\results\KeyManagementPoC.ApiDatabasePrivatePublicCertificate-report.csv" %execPath%"BenchmarkDotNet.Artifacts\results\KeyManagementPoC.ApiDatabasePrivatePublicCertificate-report_barbican.csv_%%x" /y
)


::Conjur
"C:\Program Files\Oracle\VirtualBox\VBoxManage.exe" controlvm UbuntuKMS savestate
timeout /t 60 /nobreak
"C:\Program Files\Oracle\VirtualBox\VBoxManage.exe" snapshot UbuntuKMS restore 29107748-1f40-4b8b-afc6-fbe57d26bb36
timeout /t 30 /nobreak
"C:\Program Files\Oracle\VirtualBox\VBoxManage.exe" startvm UbuntuKMS
timeout /t 60 /nobreak
copy %execPath%"KeyManagementPoC\bin\Release\KeyManagementPoC.exe_conjur.config" %execPath%"KeyManagementPoC\bin\Release\KeyManagementPoC.exe.config" /y

for /l %%x in (1, 1, 10) do (
%execPath%"KeyManagementPoC\bin\Release\KeyManagementPoC.exe"
copy %execPath%"BenchmarkDotNet.Artifacts\results\KeyManagementPoC.ApiDatabasePrivatePublicCertificate-report.csv" %execPath%"BenchmarkDotNet.Artifacts\results\KeyManagementPoC.ApiDatabasePrivatePublicCertificate-report_conjur.csv_%%x" /y
)






::Knox: 6f79ca97-9c3d-4e0a-9163-6dddbbf90728
::Vault: d543d09e-b1f1-441f-8647-a8a8d267e518
::Openstack: 2b40c204-12ae-44b5-ae32-cdc7b26aa87a
::Keywhiz: 01efbc6e-a7a8-4a64-acd3-0dc832aef272
::Conjur: 29107748-1f40-4b8b-afc6-fbe57d26bb36