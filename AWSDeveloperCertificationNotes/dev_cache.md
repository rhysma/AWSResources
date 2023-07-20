## Caching Information for Scalability

### Challenges of modern application data
* Modern applications continue to evolve in scope and complexity, and the demands on the infrastructure for performance and scale go in only one direction: up.
* Applications have evolved from single-server applications with hundreds of users to distributed global applications that millions use. 
* Think about the data expectations for applications that use Internet of Things (IoT) devices in the field to send millions of requests

Developers must rethink how they store and access data to meet these performance demands, and how to support the scale and reach of modern applications. Caching is one strategy for addressing these challenges

### What is caching?
* Caching is serving requests from a copy of data rather than making the request to the original source of the data. The cache is the copy of the data, and the original source of the data is called the origin. The cache is a high-speed data storage layer, and it stores data transiently. Data in the cache has a time to live (TTL) so that the data in the cache doesn't get too stale.

You can apply caches and use them throughout various layers of technology to improve performance: 
* Accelerate retrieval of web content on the client side by using HTTP cache-control headers.
* Accelerate retrieval of web content from web servers and manage web sessions on the server side. You can use Amazon CloudFront, Amazon ElastiCache for Redis, Amazon ElastiCache for Memcached, and AWS Partner solutions.
* Accelerate application performance and data access by using ElastiCache for Redis, ElastiCache for Memcached, and AWS Partner solutions.
* Reduce latency that is associated with database query requests by using ElastiCache for Redis and ElastiCache for Memcached.

Workloads that benefit from caching - Caching can benefit both read-heavy and compute-intensive workloads:
* Read-heavy application workloads: Caching can significantly reduce latency and improve input/output operations per second (IOPS) for many read-heavy application workloads, such as social networking,gaming, media sharing, and question and answer (Q&A) portals.
* Compute-intensive workloads: Caching can also benefit compute-intensive workloads that manipulate datasets, such as recommendation engines and high performance computing (HPC) simulations. In these applications, large datasets must be accessed in real-time across clusters of machines, which can span hundreds of nodes. Due to the speed of the underlying hardware, manipulating this data in a disk-based store is a significant bottleneck for these applications.

### Factors for considering whether to cache
* Speed and expense - Is a slow, expensive query required to generate the data?
* Data and access patterns - Is the data relatively static and frequently accessed?
* Staleness - Can the data afford to be stale?
* Trade-offs - Will caching be work the added development complexity and potential costs?

## Caching with ElastiCache

Amazon ElastiCache is an in-memory, key-value store that sits between your application and the data store (database) that it accesses. The primary purpose of an in-memory, key-value store is to provide ultrafast (sub-millisecond latency) and inexpensive access to copies of data.

Benefits of ElastiCache include the following:
* Fully managed - manages the work involved in setting up a distributed in-memory environment, from provisioning the server resources that you request to installing the software. Automates common administrative tasks such as failure detection, recovery, and software patching. 
* Extreme performance - Works as an in-memory data store and cache to support the most demanding applications that require sub-millisecond response times. 
* Scalable - ElastiCache can scale out, in and up to meet fluctuating application demands.

### ElastiCache Engines

ElastiCache supports two open-source, in-memory caching engines: Memcached and Redis.

ElastiCache for Memcached offers:
* Multithreading - can use more CPU cores than redis
* Low maintenance - designed to be relatively simple and requires less maintenance than Redis
* Easy horizontal scalability with Auto Discovery - When Memcached clusters are used in ElastiCache, the clusters can easily add and remove nodes by using the Auto Discovery feature. This feature automatically discovers changes to the node membership in a cluster, such as new nodes that are added or nodes that were subtracted. The ElastiCache client reconfigures automatically in response.

ElastiCache for Redis offers:
* Support for complex data types - Examples of these data types include strings, hashes, lists, sets, sorted sets, and bitmaps. By contrast, Memcached is designed to cache flat strings—such as flat HTML pages or serialized JSON—and objects, like databases.
* Persistance - Data in Redis has persistence and you can use it as a primary data store. The Memcached engine does not support persistence. 
* High availability (replication) - Replicate your data from the primary node to one or more read replicas for read-intensive applications.
* Automatic failover - In certain cases, Redis detects and replaces the primary node. 
* Publish/subscribe capabilities - In the publish/subscribe paradigm, you send a message to a specific channel without knowing who, if anyone, receives it. Subscribers to the channel receive the message. You can use Redis to manage the channels and enable quick messaging and communication between publishers and subscribers. 

Overall, if you must decide which ElastiCache engine to use, base your decision on a use case that can justify the use of Redis. Memcached is typically preferred when your cache doesn't need the advanced features that Redis offers.

## ElastiCache Terminology

* Node - A fixed-size chunk of secure, network-attached RAM. A cluster is a logical grouping of one or more ElastiCache nodes. 
    * Every node within a cluster is the same instance type and runs the same cache engine. Each cache node has its own DNS name and port. Multiple types of cache nodes are supported, each with varying amounts of associated memory.
* Endpoint - The unique address of an ElastiCache node or cluster that your application attaches to. 
* Cluster - A grouping of nodes. With the Memcached engine, data is partitioned across nodes in a cluster. The max is 20 nodes. 
* Redis Shard - Also called a node group in the API and CLI. A grouping or one to six related nodes. 
* Redis Cluster - Also called a replication group in the API and CLI. A logical grouping or one or more shards. 

## Development Process 

Your focus as a developer is on writing the code to handle these logical actions: 
1. Request data from the cache
     * If you find the data in the cache and it has not expired (which is called a cache hit), go to step 2.
     * If you don’t find the data you need in the cache or the cached value has expired (which is called a cache miss), go to step 3.
2. Return it to the requester.
3. Request the data from the origin. 
4. Return the data to the requester.
5. Update the cache with the data that is retrieved from the origin.

### Cache miss penalty and Time to Live (TTL)

With a cache miss, three trips are related to the request. You must send the initial request to the cache, then query the database, and then update the cache. A cache miss can noticeably delay returning data to the application. 
     * One strategy is to load all data into the cache in advance, rather than a subset. You might use this strategy if your application cannot tolerate the cache miss penalty for any requests.
     * A cache miss might happen if the desired value is not in the cache or the requested key has expired (TTL has expired). 

Cache expiration can get complex quickly. In a real application, a given page or screen often caches many different kinds of data at the same time. For example, these types of data can include profile data, top news stories, recommendations, comments—all of which have different update methods.