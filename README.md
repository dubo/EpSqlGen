# EpSqlGen
Simple Excel / Json generator  for SQL databases, based on EpPlus library - https://github.com/JanKallman/EPPlus

**Dependency**

.Net 4.5.1

for Oracle DB:  Oci Client or Oracle Data Provider for .NET (ODP.NET)

**Supported databases ( tested mainly with Oracle and PgSql ) :** 

 - Oracle  providerName="System.Data.OracleClient"     https://github.com/ericmend/oracleClientCore-2.0
			     providerName="Mono.Data.OracleClientCore"
 - MSSQL	 providerName="System.Data.SqlClient"
 - SqLite  providerName="System.Data.SQLite"
 - MySQL	 providerName="MySql.Data"
 - PgSql	 providerName="Npgsql"

 
## Usage - simple
**XLSX output** 
  
	 EpSqlGen.exe  AuthorFilms.sql			

**JSON output** 
  
	 EpSqlGen.exe AuthorFilms.sql -j
   
**JSON output to console** 
 
	 EpSqlGen.exe AuthorFilms.sql -j

**Help** 
       
	  EpSqlGen.exe -h
      
**Directory settings for simple usage** 

Don't forget set definitions/outputs directory in app config to your path. But you can set full path to config or output file in cmd line too

    <configuration>
      <appSettings>
        <add key="DefinitionsDir" value="c:\work\EpSqlGenCore\definitions"/>
        <add key="OutputsDir" value="c:\work\EpSqlGenCore\outputs"/>
       ...
      </appSettings>

   
## Usage -advanced
**sql definition file for simple one tab XLSX output (portable/Win exe sample)**

	EpSqlGen.exe MySqlQuery.sql -oMyOutputFileName -a:MyArgument1:Argument1Type:Argumet1value -a:MyArgument2:Argument2Type:Argumet2value

 **json definition file for complex XLSX output with more tabs**

    EpSqlGen.exe MyJsonDefinition.json -oMyOutputFileName -a:MyArgument1:Argument1Type:Argumet1value -aMyArgument2:Argument2Type:Argumet2value

**Sample-sql def to XLSX** 
 
    EpSqlGen.exe MySqlQuerry.sql -oMyOutputfile  -dt -a:Statuses:array:'P9','K9','O9' -a:Ids:array:31,32,3 -a:Produkt:string:UO -a:Od:date:4.2.2015 -a:Zmluva:number:505115

**Sample-json def to  XLSX**  

    EpSqlGen.exe Test.json -oMyOutputfile -do -a:Stavy:array:'P9','K9','O9' -a:Ids:array:31,32,3 -a:Produkt:string:UO -a:Od:date:4.2.2015 -a:Contract:integer :505115

**Sample-sql def to JSON**

    EpSqlGen.exe MySqlQuerry.sql -oMyOutputfile -j -a:Stavy:array:'P9','K9','O9' -a:Ids:array:31,32,3 -a:Produkt:string:UO -a:Od:date:4.2.2015 -a:Contract:integer:505115

**Supported arguments types**  
string || char || varchar2 || varchar || date || integer || decimal || number || array

