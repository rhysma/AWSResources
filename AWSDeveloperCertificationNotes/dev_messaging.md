## Developing with Messaging Services

### Processing requests asynchronously

In a synchronous model, the client generates a request message to the consumer. Then the client waits until the message is processed and the client gets a response from the consumer. In this model, strong interdependency exists between the producer and the consumer. This creates a tightly coupled system which has the disadvantage of being not fault tolerant. 

In asynchronous processing, the client sends a request and might get an acknowledgment that the event was received. However, the client doesn't receive a response that includes the results of the request. The disadvantage is that service B does not have a channel to pass back results to channel A. You need to write your applications to handle errors asynchronously. The advantage is that you reduce the dependencies on downstream activities and this reduction improves responsiveness back to the client. 

Asynchronous processing with messaging services - There are three types of messaging services that you can use for asynchronous processing:
* Message queues
* Publish/subscribe (sub/sub)
* Data streams

The type of messaging service you choose depends on the use case. 

#### Message Queues
A message queue is a temporary repository for messages that are waiting to be processed. Messages are usually small and can be requests, replies, error messages, or other information. 

The following steps describe a message queue workflow:
1. A producer adds a message to the queue. The message is stored in the queue until another component (a consumer) retrieves and processes the message.
2. Consumers poll the queue to determine if new messages are available to process.
3. Each consumer processes each new message it retrieves.
4. If processing is successful, the consumer deletes the message from the queue so that no other consumer tries to process the same message.

#### Pub/Sub 
With publish/subscribe messaging, publishers send messages to topics. Message topics provide a lightweight mechanism to broadcast asynchronous event notifications. Topics also provide endpoints that software components connect to. 

Unlike with queues, subscribers do not need to check for messages in a pub/sub model. Messages that are published to a topic are pushed out to all topic subscribers. With this model, you can easily notify large numbers of subscribers about events. 

#### Data Streams
Data streams are similar to queues in that they provide a temporary repository for producer messages, and consumers poll the stream to check for new messages. However, streams are different from queues in that the rate of messages is typically much higher. Rather than processing each individual message on the queue, streams are typically used to analyze high volumes of data in near-real time. Another difference is that multiple consumers might process the same messages and do entirely different actions with them. Consumers all view the same data and act on the messages for their own purposes. Consumers do not delete messages from a stream. 

### Amazon Simple Queue Service (SQS)
A fully managed message queuing service that eliminates the complexity and overhead associated with managing and operating message queues. 
* Limits administrative overhead
* Reliably delivers messages at very high volume and throughput
* Scales dynamically
* Can keep data secure
* Offers standard and FIFO operations

You can use Amazon SQS to transmit any volume of data at any level of throughput, without losing messages or requiring other services to be available. With Amazon SQS, you can decouple application components so that they run and fail independently, which increases the overall fault tolerance of the system. Multiple copies of every message are stored redundantly across multiple Availability Zones so that they are available when they are needed.

Queue Types
* Standard - Best effort ordering, at-least-once delivery. Nearly unlimited throughput. Use cases: let users upload media while resizing or encoding it, and process a high number of credit card validation requests. You can use standard message queues in many scenarios, as long as your application can process messages that arrive more than once and are out of order.
* FIFO - Message order is preserved, exactly-once delivery. More limited throughput. Use Cases: Ensure a deposit is recorded before a bank withdrawal happens, and ensure a credit card transaction is not processed more than once. You use FIFO queues for applications when the order of operations and events is critical, or in cases where duplicates can't be tolerated. 

You can integrate Amazon SQS with other AWS services to make applications more reliable and scalable.

The lifecycle of an Amazon SQS message is as follows:
1. A producer component sends a message to the SQS queue. Amazon SQS redundantly stores the message across multiple Amazon SQS servers.
2. A consumer component retrieves the message from the queue, and Amazon SQS starts the visibility timeout period. During the visibility timeout period, no other consumers can pick the message up from the queue.
3. The consumer component processes the message and then deletes it from the queue during the visibility timeout period. Note that if the message is not processed and deleted from the queue before the visibility timeout period expires, another consumer might pick up and process the same message.

You can perform these actions with the SendMessage, ReceiveMessage, and DeleteMessage API calls, respectively, either programmatically or from the Amazon SQS console. A variety of configuration options affect cost, message processing, and message retention.

Functions and Terminology
* SendMessage - delivers a message to a specific queue. Requires the MessageBody of maximum size 256KB and the QueueURL where the message should be sent
    * Optionally you can include MessageAttribute to attach additional metadata and DelaySeconds which is the amount of time you wish to delay a message sending.
* ReceiveMessage - You can retrieve one or more (up to 10) messages from the queue by using ReceiveMessage. You set the number of messages that you want to retrieve by using the MaxNumberOfMessages parameter.
    * If you receive a message more than once, you get a different receipt handle each time that you receive it. You need the receipt handle to delete the message or change its visibility on the queue.
* Visibility Timeout - Immediately after a message is received using the ReceiveMessage operation, Amazon SQS sets a visibility timeout. The visibility timeout is a period during which other consumers cannot receive and process the message. Before the visibility timeout expires, the consumer is expected to process AND then delete the message from the queue. Amazon SQS doesn't automatically delete the message because, as a distributed system, there's no guarantee that the consumer actually received and handled the message. 
    * The timeout defaults to 30 seconds. The minimum is 0 seconds and the maximum is 12 hours
    * You can use the VisibilityTimeout parameter on the ReceiveMessage operation to modify the visibility timeout for a ReceiveMessage request.
    * If your consumer doesn't delete the message before the visibility timeout expires, the message becomes visible to other consumers, and Amazon SQS flags the message as being returned to the queue. Amazon SQS increments its counter each time the message becomes visible on the queue.
* Dead-letter queue - The dead-letter queue can receive messages from the source queue after the maximum number of processing attempts (maxReceiveCount) has been reached. Dead-letter queues can help you troubleshoot incorrect transmission operations and stop your queue from continually trying to process a corrupted message.
    * You can create a dead-letter queue from the Amazon SQS API or the Amazon SQS console.
* Short polling - By default, when you make a ReceiveMessageAPI call, Amazon SQS performs short polling, in which it samples a subset of SQS servers (based on a weighted random distribution). Amazon SQS immediately returns only the messages that are on the sampled servers. 
* Long polling - Amazon SQS queries all of the servers and waits until a message is available in the queue before it sends a response. Long polling helps reduce the cost of using Amazon SQS by eliminating the number of empty responses (when no messages are available for a ReceiveMessage request) and false empty responses (when messages are available but aren't included in a response).
    * To enable long polling, set the WaitTimeSeconds parameter of the ReceiveMessage request to a non-zero value between 1 and 20 seconds.
* DeleteMessage - To prevent a message from being received and processed again when the visibility timeout expires, the consumer must delete the message. You can use the DeleteMessage operation to delete a specific message from a specific queue, or you can use DeleteMessageBatch to delete up to 10 messages.
    * Amazon SQS automatically deletes messages that have been in a queue longer than the queue’s configured message retention period. The default message retention period is 4 days. However, you can set the message retention period to a value from 60 seconds to 1,209,600 seconds (14 days) by using the SetQueueAttributes action.


#### SQS Queue Security

There are three ways to secure your SQS resources:
* Identity and Access Management (IAM) and SQS Policies - Access to Amazon SQS requires credentials that AWS can use to authenticate your requests. These credentials must have permission to access AWS resources, such as SQS queues and messages. Use AWS Identity and Access Management (IAM) policies and Amazon SQS policies. 
* Server-side encryption(SSE) with AWS Key Management Service - Encrypt your data using server-side encryption (SSE). With SSE, you can transmit sensitive data in encrypted queues. SSE protects the contents of messages in SQS queues by using keys that are managed by AWS KMS. When you enable SSE on an SQS queue, Amazon SQS will encrypt an incoming message before storing it on the queue and unencrypt it upon delivery to the consumer.
* Amazon Virtual Private Cloud endpoint - If you use Amazon Virtual Private Cloud (Amazon VPC ) to host your AWS resources, you can establish a connection between your VPC and Amazon SQS. You can use this connection to send messages to your SQS queues without crossing the public internet.

### Amazon Simple Notification Service
Fully managed messaging service with pub/sub functionality for many-to-many messaging between distributed systems, microservices, and event-driven applications.
* Offloads message filtering logic from your subscriber systems and message routing logic from your publisher systems. 
* Reliably delivers messages and provides failure management features
* Scales dynamically
* Offers FIFO topics option, which works with FIFO SQS queues to preserve message order

Amazon SNS includes substantial retry policies to limit the potential for delivery failures and provides a dead-letter queue option for messages that continue to fail.

Topics
* A SNS topic is a logical access point, which acts as a communication channel. 
* Instead of including a specific destination address in each message, a publisher sends a message to the topic.
* Amazon SNS matches the topic to a list of subscribers for that topic. 
* The service then delivers the message to each subscriber.
* Each topic has a unique name which identifies the SNS endpoint for publishers to post messages and subscribers to register for notifications

A publisher can send messages to topics that they have created or to topics they have permission to publish. When you create an SNS topic, you can control access to it by defining policies that determine which publishers and subscribers can communicate with the topic.

To receive messages that are published on a topic, you must subscribe to an endpoint to the topic. When you subscribe an endpoint to a topic, the endpoint begins to receive messages published to the associated topic. Subscribers receive all messages that are published to the topics that they subscribe to, and all subscribers to a topic receive the same messages

#### Fanout Pattern Example
When a message must be processed by more than one consumer, you can combine pub/sub messaging with a message queue in a fanout design pattern. In a fanout pattern, you use an SNS topic to receive a message that is then pushed out to multiple subscribers for parallel processing.
* When a message is pushed from that topic, each queue gets an identical message but performs its own asynchronous processing.
* Subscribers in a fanout pattern can be a combination of endpoint types including HTTP endpoints or email addresses.

#### Developing with SNS
When a publisher sends a message to a topic, Amazon SNS returns a message ID and then attempts to deliver the message to all subscriber endpoints.

Amazon SNS defines a delivery policy for each delivery protocol. The delivery policy defines how Amazon SNS retries the delivery of messages when server-side errors occur (when the system that hosts the subscribed endpoint becomes unavailable). When the delivery policy is exhausted, Amazon SNS stops retrying the delivery and discards the message—unless a dead-letter queue is attached to the subscription.

SNS API Operations:
* CreateTopic - Creates a topic, requires the topic name
* Subscribe - Prepares to subscribe to an endpoint. Requires the subscriber's endpoint, protocol, ARN of topic
* ConfirmSubscription - Verifies an endpoint owner's intent to receive messages. Requires a token to be sent to the endpoint
* Publish - Sends a message to all of a topic's subscribed endpoints. Requires the message, any message attributes or structure, the subject, and ARN
* DeleteTopic - Deletes a topic and all of the subscriptions. Requires the ARN of the topic.

[Amazon SNS Developer Guide](https://docs.aws.amazon.com/sns/latest/dg/sns-message-delivery-retries.html)

#### SNS Security
You have detailed control over which endpoints a topic allows, who is able to publish to a topic, and under what conditions:
* Identity and Access Management (IAM) and SNS Policies - Access to Amazon SNS requires credentials that AWS can use to authenticate your requests. These credentials must have permission to access AWS resources, such as SNS topics and messages. Use AWS Identity and Access Management (IAM) policies and Amazon SNS policies. 
* Server-side encryption(SSE) with AWS Key Management Service - Encrypt your data using server-side encryption (SSE). SSE protects the contents of messages in SNS topics by using keys that are managed in AWS KMS.
* Amazon Virtual Private Cloud endpoint - If you use Amazon Virtual Private Cloud (Amazon VPC ) to host your AWS resources, you can establish a connection between your VPC and Amazon SNS. You can use this connection to send messages to your SNS topics without crossing the public internet.

### Kinesis Data Streams
Fully managed, massively scalable, and durable real-time data streaming service that you can use to ingest, buffer, and process streaming data in real-time. 
* Continuously capture GBs of data per second
* Source stream data and source including website clickstreams, database event streams, financial transactions, social media feeds, IT logics, and location tracking events.
* Easily process data with built-in integrations with Lambda and other services.

Common Kinesis Data Streams use cases include the following: 
* Log and event data collection: Collect log and event data, and continuously process the data, generate metrics, power live dashboards, and emit aggregated data into stores like Amazon S3.
* Real-time analytics: Run real-time analytics on high-frequency event data such as sensor data.
* Mobile data capture: Push mobile application data to a data stream from hundreds of thousands of devices, and make the data available to you as soon as it is produced.
* Gaming data feed: Continuously collect data about player-game interactions, and feed the data into your gaming platform.

Streams Overview
* A producer collects data and puts it onto the stream; for example, a web server that sends log data to a Kinesis data stream is a producer.
* Data records also include a partition key and a data blob. The partition key is used to group data by shard within a stream. 
    * The sequence number is unique per partition key within its shard. For writes, a shard can support up to 1,000 records per second or up to a maximum of 1 MB per second. For reads, a shard can support up to 5 transactions per second or up to a maximum of 2 MB per second.
* Kinesis Data Streams store a unit of data as a data record. 
* A data stream represents a group of data records.
* The data stream ingests a large amount of data in real-time, durably stores the data, and makes the data available for consumption.
* The data records in a data stream are distributed into shards.
* After a record is added to the stream, the record is available for a specified retention period, which you can set per stream. 
* The Kinesis Data Streams service adds shards to scale horizontally.
    * When you create a stream, you specify the number of shards for the stream. The total capacity of a stream is the sum of the capacities of its shards.
* Each shard has a uniquely identified sequence of data records, and each data record has a sequence number that Kinesis assigns.
* A partition key is used to group data by shard within a stream.
* A consumer is an application that polls the data stream and processes the data from a Kinesis data stream.
    * You can have multiple consumers on a data stream.
    * When you have multiple consumers, they share the read-throughput of the stream among them. An option called enhanced fanout lets you give each consumer its own allotment of read throughput.

#### Other Kinesis Data Streaming Services

Amazon Kinesis Data Firehose
* Deliver streaming data to data stores without writing consumer applications for your stream
* Automatically convert incoming data to open and standards-based before the data is delivered

Amazon Kinesis Data Analytics
* Perform real-time analysis on data in the stream using SQL queries before persisting the data
* Use Apache Flink, Java, Scala, or Python for your analysis applications

#### Comparison of Queues and Streams
* Data Value
   * Queues - The value comes from processing individual messages
   * Streams - The value comes from aggregating messages to get actionable data
* Message rate
   * Queues - The message rate is variable
   * Streams - The message rate is continuous and high volume
* Message processing
   * Queues - Messages are deleted after a consumer successfully processes them
   * Streams - Messages are available to multiple consumers to process in parallel and each consumer maintains a points but does not delete records
