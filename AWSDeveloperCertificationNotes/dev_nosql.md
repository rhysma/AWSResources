## Developing Flexible NoSQL Solutions

### Two majors types of databases
* Relational - a persistent store where data has relationships to other data. Because of the relationships, you must enforce the schema (or the definitions of the data that’s stored in the table) and you must also enforce how tables relate to one another.
    * You must use strict schema rules and must enforce data quality
    * Your database doesn't need extreme read/write capacity
    * If your dataset doesn't require extreme performance it can be the lowest effort solution
* Nonrelational - often called NoSQL databases—are schemalessstores, where items in the database are not required to conform to rules. It is not uncommon to see rows in a nonrelational database table that have different attributes.
    * Use if you need your database to scale horizontally
    * Your data doesn't left itself well to traditional schemas (can use key/value pairs)
    * Read/write rates exeed rates that can be economically supported through traditional SQL databases
    * The design of nonrelational databases means that they can scale by adding more compute to the infrastructure. That is, servers can be brought online to increase capacity when customer demand increases. When demand drops, the additional servers can be shut down to reduce costs.

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
* Simple primary key:The simple primary key is composed of one attribute that’s known as the partition key. DynamoDB builds an unordered index on this primary key attribute. Each item in the table is uniquely identified by its partition key value.
* Composite primary key:The composite primary key is composed of two attributes: the partition key and the sort key. DynamoDB builds an unordered index on the partition key attribute and a sorted index on the sort key attribute. In a table that has a partition key and a sort key, it's possible for two items to have the same partition key value. However, those two items must have different sort key values.

#### Partitions

DynamoDB stores data in partitions. A partition is an allocation of storage for a table. It’s backed by solid state drives (SSDs), and is automatically replicated across multiple Availability Zones within an AWS Region. Partition management is handled entirely by DynamoDB.

* Amazon DynamoDB stores data in partitions based on the partition key.
* With a simple primary key, the key determines which partitions are selected.
* With a composite primary key, the key still determines which partition is selected, but the order is based on the sort key.

More Information [Partitions and Data Distribution](https://docs.aws.amazon.com/amazondynamodb/latest/developerguide/HowItWorks.Partitions.html)

#### Secondary Indexes

You can use a secondary index to perform queries on attributes that aren’t part of the table’s primary key. With a secondary index, you can query the data in the table by using an alternate key, in addition to queries against the primary key.

DynamoDB supports two types of secondary indexes:
* Global secondary index: An index with a partition key and a sort key, both of which can be different from the keys in the base table. A global secondary index is considered globalbecause queries on the index can span all the data in the base table, across all partitions. A global secondary index has no size limitations. It also has its own provisioned throughput settings for read/write activity that are separate from the throughput settings of the table. 
* Local secondary index: An index that has the same partition key as the base table, but a different sort key. A local secondary index is localbecause every partition is scoped to a base table partition that has the same partition key value. As a result, the total size of indexed items for any one partition key value can't exceed 10 GB. Also, a local secondary index shares provisioned throughput settings for read/write activity with the table that it indexes. 

Each table in DynamoDB can have up to 20 global secondary indexes (default limit) per table, and up to five local secondary indexes per table.

More Information [Data Access with Secondary Indexes](https://docs.aws.amazon.com/amazondynamodb/latest/developerguide/SecondaryIndexes.html)

