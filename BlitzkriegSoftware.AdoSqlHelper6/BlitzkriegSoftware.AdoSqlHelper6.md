<a name='assembly'></a>
# BlitzkriegSoftware.AdoSqlHelper6

## Contents

- [SqlHelper](#T-BlitzkriegSoftware-AdoSqlHelper6-SqlHelper 'BlitzkriegSoftware.AdoSqlHelper6.SqlHelper')
  - [Timeout_Default](#F-BlitzkriegSoftware-AdoSqlHelper6-SqlHelper-Timeout_Default 'BlitzkriegSoftware.AdoSqlHelper6.SqlHelper.Timeout_Default')
  - [CleanParameters(parameters)](#M-BlitzkriegSoftware-AdoSqlHelper6-SqlHelper-CleanParameters-System-Collections-Generic-List{System-Data-SqlClient-SqlParameter}- 'BlitzkriegSoftware.AdoSqlHelper6.SqlHelper.CleanParameters(System.Collections.Generic.List{System.Data.SqlClient.SqlParameter})')
  - [ExecuteSqlWithParametersNoReturn(connectionString,SQL,parameters,TimeOut)](#M-BlitzkriegSoftware-AdoSqlHelper6-SqlHelper-ExecuteSqlWithParametersNoReturn-System-String,System-String,System-Collections-Generic-List{System-Data-SqlClient-SqlParameter},System-Int32- 'BlitzkriegSoftware.AdoSqlHelper6.SqlHelper.ExecuteSqlWithParametersNoReturn(System.String,System.String,System.Collections.Generic.List{System.Data.SqlClient.SqlParameter},System.Int32)')
  - [ExecuteSqlWithParametersToDataTable(connectionString,SQL,parameters,TimeOut)](#M-BlitzkriegSoftware-AdoSqlHelper6-SqlHelper-ExecuteSqlWithParametersToDataTable-System-String,System-String,System-Collections-Generic-List{System-Data-SqlClient-SqlParameter},System-Int32- 'BlitzkriegSoftware.AdoSqlHelper6.SqlHelper.ExecuteSqlWithParametersToDataTable(System.String,System.String,System.Collections.Generic.List{System.Data.SqlClient.SqlParameter},System.Int32)')
  - [ExecuteSqlWithParametersToScaler\`\`1(connectionString,SQL,parameters,TimeOut)](#M-BlitzkriegSoftware-AdoSqlHelper6-SqlHelper-ExecuteSqlWithParametersToScaler``1-System-String,System-String,System-Collections-Generic-List{System-Data-SqlClient-SqlParameter},System-Int32- 'BlitzkriegSoftware.AdoSqlHelper6.SqlHelper.ExecuteSqlWithParametersToScaler``1(System.String,System.String,System.Collections.Generic.List{System.Data.SqlClient.SqlParameter},System.Int32)')
  - [ExecuteStoredProcedureWithDataTable(connectionString,ProcedureName,parameters,TimeOut)](#M-BlitzkriegSoftware-AdoSqlHelper6-SqlHelper-ExecuteStoredProcedureWithDataTable-System-String,System-String,System-Collections-Generic-List{System-Data-SqlClient-SqlParameter},System-Int32- 'BlitzkriegSoftware.AdoSqlHelper6.SqlHelper.ExecuteStoredProcedureWithDataTable(System.String,System.String,System.Collections.Generic.List{System.Data.SqlClient.SqlParameter},System.Int32)')
  - [ExecuteStoredProcedureWithNoReturn(connectionString,ProcedureName,parameters,TimeOut)](#M-BlitzkriegSoftware-AdoSqlHelper6-SqlHelper-ExecuteStoredProcedureWithNoReturn-System-String,System-String,System-Collections-Generic-List{System-Data-SqlClient-SqlParameter},System-Int32- 'BlitzkriegSoftware.AdoSqlHelper6.SqlHelper.ExecuteStoredProcedureWithNoReturn(System.String,System.String,System.Collections.Generic.List{System.Data.SqlClient.SqlParameter},System.Int32)')
  - [ExecuteStoredProcedureWithParametersToScaler\`\`1(connectionString,ProcedureName,parameters,TimeOut)](#M-BlitzkriegSoftware-AdoSqlHelper6-SqlHelper-ExecuteStoredProcedureWithParametersToScaler``1-System-String,System-String,System-Collections-Generic-List{System-Data-SqlClient-SqlParameter},System-Int32- 'BlitzkriegSoftware.AdoSqlHelper6.SqlHelper.ExecuteStoredProcedureWithParametersToScaler``1(System.String,System.String,System.Collections.Generic.List{System.Data.SqlClient.SqlParameter},System.Int32)')
  - [FixSqlInText(inText,defaultValue,textDelimiter)](#M-BlitzkriegSoftware-AdoSqlHelper6-SqlHelper-FixSqlInText-System-String,System-String,System-Char- 'BlitzkriegSoftware.AdoSqlHelper6.SqlHelper.FixSqlInText(System.String,System.String,System.Char)')
  - [HasRows(dt)](#M-BlitzkriegSoftware-AdoSqlHelper6-SqlHelper-HasRows-System-Data-DataTable- 'BlitzkriegSoftware.AdoSqlHelper6.SqlHelper.HasRows(System.Data.DataTable)')
  - [HasTables(ds)](#M-BlitzkriegSoftware-AdoSqlHelper6-SqlHelper-HasTables-System-Data-DataSet- 'BlitzkriegSoftware.AdoSqlHelper6.SqlHelper.HasTables(System.Data.DataSet)')
  - [ParameterBuilder(name,dbType,value)](#M-BlitzkriegSoftware-AdoSqlHelper6-SqlHelper-ParameterBuilder-System-String,System-Data-SqlDbType,System-Object- 'BlitzkriegSoftware.AdoSqlHelper6.SqlHelper.ParameterBuilder(System.String,System.Data.SqlDbType,System.Object)')
  - [ParameterBuilder(name,dbType,size,value)](#M-BlitzkriegSoftware-AdoSqlHelper6-SqlHelper-ParameterBuilder-System-String,System-Data-SqlDbType,System-Int32,System-Object- 'BlitzkriegSoftware.AdoSqlHelper6.SqlHelper.ParameterBuilder(System.String,System.Data.SqlDbType,System.Int32,System.Object)')
  - [SqlTextClean(inText)](#M-BlitzkriegSoftware-AdoSqlHelper6-SqlHelper-SqlTextClean-System-String- 'BlitzkriegSoftware.AdoSqlHelper6.SqlHelper.SqlTextClean(System.String)')

<a name='T-BlitzkriegSoftware-AdoSqlHelper6-SqlHelper'></a>
## SqlHelper `type`

##### Namespace

BlitzkriegSoftware.AdoSqlHelper6

##### Summary

Helpers for dealing with SQL Server

<a name='F-BlitzkriegSoftware-AdoSqlHelper6-SqlHelper-Timeout_Default'></a>
### Timeout_Default `constants`

##### Summary

Default Timeout (seconds)

<a name='M-BlitzkriegSoftware-AdoSqlHelper6-SqlHelper-CleanParameters-System-Collections-Generic-List{System-Data-SqlClient-SqlParameter}-'></a>
### CleanParameters(parameters) `method`

##### Summary

Clean a list of SQL Parameters to fix up strings by calling  for each parameter that is 
NText, NVarChar, Test, VarChar.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| parameters | [System.Collections.Generic.List{System.Data.SqlClient.SqlParameter}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.List 'System.Collections.Generic.List{System.Data.SqlClient.SqlParameter}') | Parameters to clean |

<a name='M-BlitzkriegSoftware-AdoSqlHelper6-SqlHelper-ExecuteSqlWithParametersNoReturn-System-String,System-String,System-Collections-Generic-List{System-Data-SqlClient-SqlParameter},System-Int32-'></a>
### ExecuteSqlWithParametersNoReturn(connectionString,SQL,parameters,TimeOut) `method`

##### Summary

Execute SQL with parameters with no return of data or values

##### Returns

Rows affected

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| connectionString | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Connection String |
| SQL | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | SQL Statement |
| parameters | [System.Collections.Generic.List{System.Data.SqlClient.SqlParameter}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.List 'System.Collections.Generic.List{System.Data.SqlClient.SqlParameter}') | Parameters |
| TimeOut | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | Timeout in seconds, with default |

<a name='M-BlitzkriegSoftware-AdoSqlHelper6-SqlHelper-ExecuteSqlWithParametersToDataTable-System-String,System-String,System-Collections-Generic-List{System-Data-SqlClient-SqlParameter},System-Int32-'></a>
### ExecuteSqlWithParametersToDataTable(connectionString,SQL,parameters,TimeOut) `method`

##### Summary

Execute SQL with parameters with a DataTable return

##### Returns

DataTable

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| connectionString | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Connection String |
| SQL | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | SQL Statement |
| parameters | [System.Collections.Generic.List{System.Data.SqlClient.SqlParameter}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.List 'System.Collections.Generic.List{System.Data.SqlClient.SqlParameter}') | Parameters |
| TimeOut | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | Timeout in seconds, with default |

<a name='M-BlitzkriegSoftware-AdoSqlHelper6-SqlHelper-ExecuteSqlWithParametersToScaler``1-System-String,System-String,System-Collections-Generic-List{System-Data-SqlClient-SqlParameter},System-Int32-'></a>
### ExecuteSqlWithParametersToScaler\`\`1(connectionString,SQL,parameters,TimeOut) `method`

##### Summary

Execute a parameterized SQL statement with a single value return

##### Returns

T

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| connectionString | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Connection String |
| SQL | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |
| parameters | [System.Collections.Generic.List{System.Data.SqlClient.SqlParameter}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.List 'System.Collections.Generic.List{System.Data.SqlClient.SqlParameter}') |  |
| TimeOut | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') |  |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T | Type |

<a name='M-BlitzkriegSoftware-AdoSqlHelper6-SqlHelper-ExecuteStoredProcedureWithDataTable-System-String,System-String,System-Collections-Generic-List{System-Data-SqlClient-SqlParameter},System-Int32-'></a>
### ExecuteStoredProcedureWithDataTable(connectionString,ProcedureName,parameters,TimeOut) `method`

##### Summary

Execute a stored procedure that returns rows

##### Returns

Datatable or null

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| connectionString | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Connection String |
| ProcedureName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | SP Name |
| parameters | [System.Collections.Generic.List{System.Data.SqlClient.SqlParameter}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.List 'System.Collections.Generic.List{System.Data.SqlClient.SqlParameter}') | Stored Procedure Arguments |
| TimeOut | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | Timeout in seconds, with default |

<a name='M-BlitzkriegSoftware-AdoSqlHelper6-SqlHelper-ExecuteStoredProcedureWithNoReturn-System-String,System-String,System-Collections-Generic-List{System-Data-SqlClient-SqlParameter},System-Int32-'></a>
### ExecuteStoredProcedureWithNoReturn(connectionString,ProcedureName,parameters,TimeOut) `method`

##### Summary

Executes a Stored Procedure with no rows returned

##### Returns

Rows affected (not always correct)

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| connectionString | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Connection String |
| ProcedureName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | SP Name |
| parameters | [System.Collections.Generic.List{System.Data.SqlClient.SqlParameter}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.List 'System.Collections.Generic.List{System.Data.SqlClient.SqlParameter}') | Stored Procedure Arguments |
| TimeOut | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | Timeout in seconds, with default |

<a name='M-BlitzkriegSoftware-AdoSqlHelper6-SqlHelper-ExecuteStoredProcedureWithParametersToScaler``1-System-String,System-String,System-Collections-Generic-List{System-Data-SqlClient-SqlParameter},System-Int32-'></a>
### ExecuteStoredProcedureWithParametersToScaler\`\`1(connectionString,ProcedureName,parameters,TimeOut) `method`

##### Summary

Execute Stored Procedure With Parameters To Scaler

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| connectionString | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Connection String |
| ProcedureName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | SP Name |
| parameters | [System.Collections.Generic.List{System.Data.SqlClient.SqlParameter}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.List 'System.Collections.Generic.List{System.Data.SqlClient.SqlParameter}') | Stored Procedure Arguments |
| TimeOut | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | Timeout in seconds, with default |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T | Type |

<a name='M-BlitzkriegSoftware-AdoSqlHelper6-SqlHelper-FixSqlInText-System-String,System-String,System-Char-'></a>
### FixSqlInText(inText,defaultValue,textDelimiter) `method`

##### Summary

Fixes comma separated lists to be quoted correctly and removes last list delimiter for SQL 'IN' clauses

##### Returns

fixed up list

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inText | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | text to process |
| defaultValue | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | default value (can be empty) |
| textDelimiter | [System.Char](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Char 'System.Char') | delimiter to wrap around each item |

<a name='M-BlitzkriegSoftware-AdoSqlHelper6-SqlHelper-HasRows-System-Data-DataTable-'></a>
### HasRows(dt) `method`

##### Summary

Does data table have rows?

##### Returns

true if so

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| dt | [System.Data.DataTable](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Data.DataTable 'System.Data.DataTable') | DataTable |

<a name='M-BlitzkriegSoftware-AdoSqlHelper6-SqlHelper-HasTables-System-Data-DataSet-'></a>
### HasTables(ds) `method`

##### Summary

Does data set have any tables?

##### Returns

true if so

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| ds | [System.Data.DataSet](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Data.DataSet 'System.Data.DataSet') | DataSet |

<a name='M-BlitzkriegSoftware-AdoSqlHelper6-SqlHelper-ParameterBuilder-System-String,System-Data-SqlDbType,System-Object-'></a>
### ParameterBuilder(name,dbType,value) `method`

##### Summary

Parameter Builder

##### Returns

SqlParameter

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| name | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Name, please include (at) |
| dbType | [System.Data.SqlDbType](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Data.SqlDbType 'System.Data.SqlDbType') | Type |
| value | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | Values |

<a name='M-BlitzkriegSoftware-AdoSqlHelper6-SqlHelper-ParameterBuilder-System-String,System-Data-SqlDbType,System-Int32,System-Object-'></a>
### ParameterBuilder(name,dbType,size,value) `method`

##### Summary

Parameter Builder w. size

##### Returns

SqlParameter

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| name | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Name, please include (at) |
| dbType | [System.Data.SqlDbType](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Data.SqlDbType 'System.Data.SqlDbType') | Type |
| size | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | SQL Size |
| value | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | Values |

<a name='M-BlitzkriegSoftware-AdoSqlHelper6-SqlHelper-SqlTextClean-System-String-'></a>
### SqlTextClean(inText) `method`

##### Summary

Encodes apostrophe to two apostrophe keeping SQL statements from bombing

##### Returns

Clean text (never null)

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inText | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Text to clean |
