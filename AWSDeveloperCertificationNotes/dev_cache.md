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

## Challenges of Serving data globally

When someone browses your website or uses your application, the request is routed through many different networks to reach your origin server. The origin server (or origin) stores the original, definitive versions of your objects (for example, webpages, images, or media files). The number of network hops and the distance that the request must travel significantly affect the performance and responsiveness of your website. Further, network latency is different depending on geographic location, which is where a content delivery network (CDN) comes in.

### What is a CDN?

A Content Delivery Network (CDN) is a globally distributed system of caching servers. It copies commonly requested files (static content such as HTML, CSS, JavaScript, etc..) that the application origin server is hosting. It delivers a local copy of the requested content from a cache edge or Point of Presence (POP). 

CDNs also deliver dynamic content that is unique to the requester and not cacheable. Having a CDN deliver dynamic content improves application performance and scaling.

## Amazon CloudFront
* A fast content delivery network service that securely delivers data, videos, and applications, and APIs to customers globally with low latency and high transfer speeds. 
    * Optimized for performance and scale
    * Built-in security features
    * Deeply integrated with AWS Services
    * Highly customizable

CloudFront integrates with AWS Shield to provide built-in security against distributed denial of service (DDOS) attacks

[More information about Amazon CloudFront](https://aws.amazon.com/cloudfront/).

#### How CloudFront Works

1. A user requests files
2. DNS routes to the best CloudFront edge location
3. CloudFront checks its cache and returns the requested files and requests from the origin
4. The origin server sends the requested files back to the edge location
5. CloudFront forwards the files to the user and adds the files to the cache

The cache key is the unique identifier for every object in the cache, and it determines whether a viewer request results in a cache hit. A cache hit occurs when a viewer request generates the same cache key as a prior request, and the object for that cache key is in the edge location’s cache and valid. When a cache hit occurs, the object is served to the viewer from a CloudFront edge location.

CloudFront Distribution Types
* Web Content - Used for serving content over HTTP or HTTPS such as static and dynamic content. Origin can be an HTTP server or an S3 bucket
* Video on demand - Used for video content that users can watch at any time. Videos must be encoded to support streaming. The Origin can be an HTTP server or an S3 bucket
* Live event - Used to stream live events. Videos must be encoded and compressed for viewing devices. The origin can be AWS Elemental MediaStore or Elemental MediaPackage.

When using CloudFront to distribute your content, you create a distribution to tell CloudFront where you want content to be delivered from. This information tells CloudFront which origin servers to get your files from, and the details about how to track and manage content delivery. Then CloudFront uses edge servers that are close to your viewers to deliver that content quickly when someone wants to see it or use it.

You can use distributions to serve the following content over HTTP or HTTPS:
* Static and dynamic download content, such as .html, .css, .js, and image files.
* Video on demand in different formats, such as Apple HTTP Live Streaming (HLS) and Microsoft Smooth Streaming.
* A live event, such as a meeting, conference, or concert, in real time. For live streaming, you can create the distribution automatically by using an AWS CloudFormation stack.

CloudFront assigns a domain name to your new distribution and sends your distribution’s configuration to all of its edge locations.

#### Understanding the cache key
With CloudFront, you can control the cache key for objects that are cached at CloudFront edge locations. The cache key is the unique identifier for every object in the cache. 

Hit Ratio - You can get better performance from your website or application when you have a higher cache hit ratio. This means a higher proportion of viewer requests result in a cache hit. You can improve your cache hit ratio by including only the minimum necessary values in the cache key. 

By default the CloudFront distribution includes the following information:
* The domain name of the CloudFront distribution (for example, d111111abcdef8.cloudfront.net)
* The URL Path of the requested object (for example, /content/stories/example-story.html)

#### Controlling Cache Keys with Cache Policies
To control the cache key, you use a CloudFront cache policy. You attach a cache policy to one or more cache behaviors in a CloudFront distribution. 

A cache policy contains settings that are categorized into:
* Policy information - describes the policy. You can set the name of the policy which is used to attach the policy to a caching behavior
* Time to live (TTL) settings - Works together with the cache-control and Expires HTTP headers (if they're in the origin response). They determine how long objects in the CloudFront cache remain value before CloudFront checks the origin for updates.
* Cache key settings - Specify the values in viewer requests that CloudFront includes in the cache key. The values that you include in the cache key are automatically included in the requests that CloudFront sends to the origin, which are called origin requests. 

You can control how long your files stay in CloudFront cache before CloudFront forwards another request to your origin. 
* Reducing the duration means you can serve dynamic content
* Increasing the duration means that your users get better performance because your files are more likely to be served directly from the edge cache. A longer duration also reduces the load on your origin. 

Typically, CloudFront serves a file from an edge location until the cache duration that you specified passes—that is, until the file expires. After it expires, the next time the edge location gets a user request for the file, CloudFront forwards the request to the origin server. In this way, it can verify that the cache contains the latest version of the file.

The response from the origin depends on whether the file has changed:
* If the CloudFront cache already has the latest version, the origin returns a status code 304 Not Modified
* If the CloudFront cache does not have the latest version, the origin returns a status code 200 OK and the latest version of the file. 

Each file in the cache expires automatically after 24 hours by default but you can change this default behavior in two ways:
* You can change the cache duration for all files that match the same path pattern
* You can change the cache duration for an individual file

To control object caching, the Cache-Control max-age directive is recommended instead of the Expires header field. If you specify values both for Cache-Control max-age and for Expires, CloudFront uses only the value of Cache-Control max-age.

### Using CloudFront to accelerate S3 file transfer
Another way that CloudFront and S3 work together is the option to use S3 Transfer Acceleration.
* This bucket-level feature uses CloudFront's globally distributed edge locations to accelerate files transfers between a client and an S3 bucket over a long distance.
* As the data arrives at an edge location, data is routed to S3 over an optimized network path

You might want to use Transfer Acceleration for various reasons:
* Your customers upload to a centralized bucket from all over the world
* You transfer GBs to TBs of data on a regular basis across continents
* You can't use all of your available bandwidth over the internet when uploading to S3

This feature incurs an additional cost. However, depending on the locations of the client and the bucket, the file transfer might not be faster with this feature turned on. In general, the farther away the client is from an Amazon S3 Region, the greater is the speed improvement from using Amazon S3 Transfer Acceleration.

### Customizing at the edge with functions
You can write your own code to customize how your CloudFront distributions process HTTP requests and responses. The code that you write and attach to your CloudFront distribution is called an edge function. 

CloudFront provides two ways to write and manage edge functions:
* Lambda@Edge - An extension of AWS Lambda that offers powerful and flexible computing for complex functions and full application logic closer to your viewers. Highly secure. Run in a Node.js or Python runtime environment. Use Lambda@Edge if you need access to the body of HTTP requests. 
* CloudFront functions - Lightweight Javascript functions for high-scale, latency-sensitive CDN customizations. The CloudFront Functions runtime environment offers sub-millisecond startup times, scales immediately to handle millions of requests per second, and is highly secure.

#### Choosing between Lambda@Edge and CloudFront Functions

Generally speaking, Lambda@Edge gives you more options and capacity for creating edge functions. However, CloudFront Functions gives you a quick way to handle lightweight functions at the edge at about one-sixth the cost of Lambda@Edge, all within CloudFront.

Lambda@Edge is a good choice for functions that have these characteristics: 
* Take milliseconds or more to complete, or require adjustable memory or CPU•Depend on third-party libraries, including the AWS SDKs, for integration with other AWS services 
* Require network access to use external services for processing
* Require file system access or access to the body of HTTP requests

CloudFront Functions is a good choice for these example use cases:
* Cache key normalization
* Header manipulation
* Header URL redirects 
* Request authorization

## Caching Strategies

There are two primary caching strategies
* Lazy Loading 
    * The cache is updated only when necessary (hit or miss)
    * Use when data will be read often but written infrequently
    * Example: User profile information

Advantages
* Avoids filling up the cache with data that isn't requested
* Node failures are not fatal

Disadvantages
* Cache miss penalty and potential to get stale data

* Write-through
    * The cache is updated whenever data is written to the database
    * Use when data must be updated in real time
    * Examples: Top 100 game leaderboard or top 10 most popular news stories

Advantages
* Data in the cache is never stale

Disadvantages
* Write penalty - Every write involves two trips - a write to the cache and a write to the database
* Missing data - When a new node is created to scale up or replace a failed node, the nodes does not contain all of the data. 
* Unused data - Since most data is never read, the cluster could have a large quantity of data that is never used
* Cache churn - The cache might be updated often if certain records are updated repeatedly.




