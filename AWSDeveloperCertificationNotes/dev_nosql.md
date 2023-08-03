## Developing Flexible NoSQL Solutions

### Two majors types of databases
* Relational - a persistent store where data has relationships to other data. Because of the relationships, you must enforce the schema (or the definitions of the data that’s stored in the table) and you must also enforce how tables relate to one another.
    * You must use strict schema rules and must enforce data quality
    * Your database doesn't need extreme read/write capacity
    * If your dataset doesn't require extreme performance it can be the lowest-effort solution
* Nonrelational - often called NoSQL databases—are schemaless stores, where items in the database are not required to conform to rules. It is not uncommon to see rows in a nonrelational database table that have different attributes.
    * Use if you need your database to scale horizontally
    * Your data doesn't leave itself well to traditional schemas (can use key/value pairs)
    * Read/write rates exceed rates that can be economically supported through traditional SQL databases
    * The design of nonrelational databases means that they can scale by adding more computing to the infrastructure. That is, servers can be brought online to increase capacity when customer demand increases. When demand drops, the additional servers can be shut down to reduce costs.

### AWS Databases
* Relational 
    * Relational Database Service (RDS)
    * Aurora
*Nonrelational
    * DynamoDB
    * ElastiCache
    * Neptune

### Key Concepts for DynamoDB

The basic components of DynamoDBare:
* Tables: DynamoDB stores data in tables. A table contains items with attributes.
* Items: Each table contains zero or more items. An item is a group of attributes that is uniquely identifiable among all the other items.
* Attributes: Each item is composed of one or more attributes. An attribute is a fundamental data element, something that doesn’t need to be broken down any further.
* Primary key: A table has a primary key that uniquely identifies each item in the table. No two items can have the same key.

When these components are compared to the components of a relational database table, items are analogous to rows and attributes are analogous to columns. 

DynamoDB supports two types of primary keys:
* Simple primary key: The simple primary key is composed of one attribute that’s known as the partition key. DynamoDB builds an unordered index on this primary key attribute. Each item in the table is uniquely identified by its partition key value.
* Composite primary key: The composite primary key is composed of two attributes: the partition key and the sort key. DynamoDB builds an unordered index on the partition key attribute and a sorted index on the sort key attribute. In a table that has a partition key and a sort key, it's possible for two items to have the same partition key value. However, those two items must have different sort key values.

#### Partitions

DynamoDB stores data in partitions. A partition is an allocation of storage for a table. It’s backed by solid state drives (SSDs), and is automatically replicated across multiple Availability Zones within an AWS Region. Partition management is handled entirely by DynamoDB.

* Amazon DynamoDB stores data in partitions based on the partition key.
* With a simple primary key, the key determines which partitions are selected.
* With a composite primary key, the key still determines which partition is selected, but the order is based on the sort key.

More Information [Partitions and Data Distribution](https://docs.aws.amazon.com/amazondynamodb/latest/developerguide/HowItWorks.Partitions.html)

#### Secondary Indexes

You can use a secondary index to perform queries on attributes that aren’t part of the table’s primary key. With a secondary index, you can query the data in the table by using an alternate key, in addition to queries against the primary key.

DynamoDB supports two types of secondary indexes:
* Global secondary index: An index with a partition key and a sort key, both of which can be different from the keys in the base table. A global secondary index is considered global because queries on the index can span all the data in the base table, across all partitions. A global secondary index has no size limitations. It also has its own provisioned throughput settings for read/write activity that is separate from the throughput settings of the table. 
* Local secondary index: An index that has the same partition key as the base table, but a different sort key. A local secondary index is local because every partition is scoped to a base table partition that has the same partition key value. As a result, the total size of indexed items for any one partition key value can't exceed 10 GB. Also, the local secondary index shares provisioned throughput settings for read/write activity with the table that it indexes. 

Each table in DynamoDB can have up to 20 global secondary indexes (default limit) per table, and up to five local secondary indexes per table.

More Information [Data Access with Secondary Indexes](https://docs.aws.amazon.com/amazondynamodb/latest/developerguide/SecondaryIndexes.html)

### Streams
Applications can benefit from capturing changes to items stored in a DynamoDB table at the point when these changes occur. Streams are a time-ordered sequence of information that shares item-level modifications made to any table. The information is available for up to 24 hours. Applications that are viewing the stream can view the original and modified data items in near real-time. 
* A stream consists of stream records - each record represents a single data modification in the table the stream belongs to. Each stream record has a sequence number reflecting the order in which the record was published to the stream. 
* Anytime a CRUD operation takes place on the table, DynamoDB makes a new stream record and records the primary key attributes of the items that were modified.
* Stream records are organized into groups or shards. Each shard acts as a container for multiple stream records and it contains information that is required to access and iterate through records. 

### Global Tables
You can use global tables to keep a DynamoDB table synchronized across AWS regions. Global tables offer a solution to deploy a multi-region, multi-active database without needing to build and maintain your own replication solution. 
* When developers create a global table, they specify the regions where they want the table to be available. Then, DynamoDB performs all of the necessary tasks to create identical tables and propagate updated data.

### Backup and Restore
DynamoDB provides both on-demand backup and point-in-time recovery. You can create full backups of your tables to meet requirements for long-term data retention and archiving for any data regulations that you must follow. 
* This can be done via the API or console access

#### On-Demand Backup
When you create an on-demand backup, a time marker of the request is cataloged. The backup is created asynchronously by applying all changes until the time of the request to the last full table snapshot. These requests are processed nearly instantaneously and become available for restoration within minutes. 
* Each time you create an on-demand backup, the entire table is backed up
* No limit exists to the number of on-demand backups you can create
* All backups in DynamoDB work without consuming any provision throughput on the table.

#### Point in Time Recovery
Automatic backups that help protect your DB table from accidental write and delete operations. With point-in-time recovery, you don't have to worry about creating, maintaining or scheduling backups.
* These recoveries can be made at any point in time in the last 35 days

### Basic Operations for Dynamo Tables

Four types of operations are available
* Control operations - Create a manage tables (CreateTable)
* Data operations - Create, read, update, and delete actions on data in a table (PutItem, UpdateItem, GetItem, etc...). The majority of work happens here.
* Batch operations - Get and write batches of items in a table
* Transaction operations - Make coordinated all-or-nothing changes to multiple items within and across tables

Condition expressions can be used with data operations to ensure that your operations only run under certain conditions that you specify. 

#### Reading an Item
When reading a table (using GetItem) you must specify the table name, full primary key, and partition key and sort key if it exists. By default, all parts of the item are returned but you can create a projection expression to retrieve only certain attributes. You can also choose to use a strongly consistent read instead of the default. The expected result is a JSON object that contains the requested attributes.

#### Querying a Table
You can use the query operation to read only the items in a table or secondary index that match the primary key. The key is specified in the key condition expression. If a filter expression is specified, the query operation returns a result set, with only the items that match specified conditions. If none of the items satisfy the conditions, the operations return an empty result set. 

Queries in DynamoDB are efficient because Dynamo will only read items that match the key query condition. 

#### Scan Operation
The scan operation is similar to a query operation but the scan reads all items from the table or index. You can use a filtered expression to refine the result set. Because the scan operation reads a lot more items, it's an expensive operation vs querying. If you must do a scan operation, perform a parallel scan when possible. 

#### Optimizing Performance and Cost
When you do a query or scan, limiting the amount of data returned can improve performance and optimize cost. DynamoDB uses pagination to limit the amount of data returned. The 1MB pagination limit reduces the amount of data that a Query or Scan operation can return. A single Query or Scan will only return a result set that fits within the 1MB size limit. 
* The Limit parameter specifies the maximum number of items that a Query or Scan operation can return. 

You can use batch operations to achieve higher throughput by writing, deleting, or replacing multiple items in a single request. You can also use batch operations such as BatchGetItem (Read up to 16MB o data that consists of up to 100 items from multiple tables) or BatchWriteItem (Write up to 16MB of data that consists of up to 25 PUT or DELETE requests to multiple tables) to take advantage of parallelism without needing to manage multiple threads on your own. 
Individual items to be written can be as large as 400KB
* Note: when an item in a batch fails, the entire operation does not fail. You can retry with failed keys and data that is returned by the operation. 

#### Transactions
You can use the DynamoDB transactional read and write APIs to manage complex business workflows. These workflows might require adding, updating, and deleting multiple items. 

* TransactionWriteItems - Contains a Write set. Includes one or more PutItem, UpdateItem, and DeleteItem operations across multiple tables.

* TransactGetItems - Contains a Read set. Includes one or more GetItem operations across multiple tables.

* Note: If one operation fails, the entire transaction fails. 
