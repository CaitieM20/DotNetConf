DotNetConf
==========
Example Code From DotNetConf 2013 Presentation

###SQL
folder contains scripts to create the example database used in the presentation.

###Azure 
folder contains Solution for simple stats storage using Azure Storage.  This code is not asynchronous, thread safe!

##Patterns & Best Practices For Moving From RDBMS to Azure Storage


Moving from storing your data in an RDBMS like SQL Server to a NoSQL data store like Azure Table requires a programming paradigm shift. This talk will share the knowledge the Halo Services Team gained while making the jump from SQL to Azure Storage while working on Halo 4. I’ll start with an overview of the core differences between the two data stores. In addition I’ll discuss the importance of partitions in Azure Table, and how to perform transactions. Finally I’ll cover how to incorporate other data best practices, and explore how to achieve transaction like behavior across partitions using the Saga Pattern.
