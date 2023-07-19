## Serverless Solutions - AWS Lambda

Serverless solutions allow you to have a high level of abstraction and focus on the business logic instead of on the infrastructure. With AWS Lambda:
* No OS instances to manage
* Flexible scaling
* Pay per usage
* Built-in fault tolerance
* Zero maintenance

Building modern serverless applications means you have:
* small pieces loosely joined
* Purpose-built data stores
* Specialized services for integration
* Automation by using code

Benefits of Lambda:
* Invokes your code in response to events
* Scales automatically
* Provides built-in code monitoring and logging with CloudWatch

Core Components are Functions and Event Sources
* Upload your code to Lambda or write code in the editor
* Set up your code to run when events occur in other AWS Services, at HTTP endpoints, or as part of an in-app activity
* Lambda runs your code only when it is activated by an event and only uses the compute resources that are needed
* Pay only for the compute time that you use

Lambda Features:
* The ability to bring your own code
* Integrates with other AWS Services
* Flexible resource and concurrency modeling
* Flexible permissions model
* Built-in availability and fault tolerance
* Reduces the need to pay for idle resources

Common use cases are real-time stream processing and web applications. You can also use it for backends, data processing, chatbots, Alexa and IT automation.

### Lambda Functions
When you create a function you define the permissions for the function, the application code, and any dependencies in libraries necessary to run it. When your function is invoked, Lambda provides a runtime environment based on the runtime configuration options that you selected. 

Lambda initializes concurrent environments to maintain the pace of invocation requests up to certain quotas. 

Lambda supports different runtimes in different languages including:
* nodeJS
* Python
* Ruby
* Java
* Go
* .NET
You can implement a custom runtime if you need a different language

Each instance of lambda is run in an ephemeral environment that is initialized on demand and then is removed when it is finished. Lambda handles creating and removing these environments 

#### Concurrency
Concurrency is the number of function invocations that are running at one time. Lambda can quickly scale horizontally 
* Reserved Concurrency - optional value per function that reserves a subset of the regional quota for the function. This value also establishes the maximum concurrent instances that are permitted for the function. 
* The regional quota is the total number of invocations that can run concurrently across all Lambda functions within an account by region. AWS sets this number as a soft quota on the account.
* Burst quote - prevents concurrency from increasing too quickly if a large spike of requests occurs in a short time. You cannot modify this limit and each region has one.  
* Request rate and function duration - the rate at which new invocation requests for the function arrive in conjunction with how long lambda takes to run the function.
* Event source - where lambda manages concurrency of requests in different ways based on the type of event which has invoked it. 


#### Invoking Lambda Functions
Each event source invokes the lambda function by using either a push or a pull model
 * Push Model - In a push model an event source directly invokes the lambda function when the event occurs.

##### Types of Push Events
* Synchronous - The other service waits for a response from your function and there is no retry built in and you must manage your retry strategy in your application code.
* Asynchronous - Lambda queues the event before passing it to your function. The other service gets a success response as soon as the event is queued and doesn't know what happens after that. If an error occurs, lambda will automatically retry the invocation twice. It can send failed events to a dead letter queue that you configure. 

 * Pull Model (polling) - In a pull model lambda polls for events and invokes the function with batches of records. Lambda uses event source mappings to get information about events from a stream or queue. 

As it pulls the streamer queue, if it finds records, it delivers the payload and invokes the function. 

Polling doesn't incur a charge. You are only charged if actions resulting from the poll invoke the function. 

* Failing records - With streams, lambda will retry the failed record until it succeeds or it reaches a 24 hour expiration. Since failing records can block processing you can configure error handling options to bypass failing records and send them to an on-failure destination for offline processing.

#### Status Codes
* When invoking an event synchronously, you receive a 200 status code for success of receipt
* When invoking an event asynchronously, you receive a 202 status code for success of receipt


### Permissions
Two types of permissions
* Event sources need permissions to invoke a function
* Functions need permissions to interact with other AWS services and resources

An IAM resource policy gives permissions to invoke a function
The resource policy
* Associated with synchronous or asynchronous event sources
* Allows the event source to take the lambda:invokefunction action

Execution Role:
The Lambda execution role specifies what the lambda function is permitted to do such as upload a file to S3, read from a DynamoDB table, poll a queue in SQS or write logs to CloudWatch. 
The execution role contains:
* The IAM Policy
* The Trust Policy - Allows the lambda service to assume the execution role

### Authoring and Configuring Functions
When you create a lambda function you specify the function handler. The function handler is the entry point that is called to start your function.
It always takes two objects:
* Event object 
     * Passes event information to the handler
     * Uses a predefined object format for AWS integration and events
     * Can be tested with user-defined custom objects
* Context object
     * Passes runtime information to the handler
     * Includes at minimum these methods or properties:
          * awsRequestId - important for error reporting or when contacting support
          * getRemainingTimeInMillis() - Method that returns the number of milliseconds remaining before running your function times out.
          * logStreamName - The Cloudwatch logstream that your log statements will be sent to

#### Performance Related Configurations
* Memory
* Timeout
* Concurrency
* Provisioned concurrency
* Monitoring and operations

These configurations can affect your billing. With lambda you are charged based on the total number of requests across all your functions. You are also charged based on the duration. The price depends on the amount of memory that you allocate to your function. 

In Lambda, concurrency is the number of in-flight requests your function is handling at the same time. There are two types of concurrency controls available:
 * Reserved concurrency – Reserved concurrency is the maximum number of concurrent instances you want to allocate to your function. When a function has reserved concurrency, no other function can use that concurrency. There is no charge for configuring reserved concurrency for a function.

 * Provisioned concurrency – Provisioned concurrency is the number of pre-initialized execution environments you want to allocate to your function. These execution environments are prepared to respond immediately to incoming function requests. Configuring provisioned concurrency incurs charges to your AWS account.

Lambda provides resource-related configurations to help control how lambda interactions with other AWS resources and to adapt to different use cases
* Triggers
* Permissions
* Asynchronous invocation
* VPC
* State machines
* Database proxies
* File systems

Code-related configurations
* Runtime
* Environment variables
* Tags
* Code Signing

##### Best Practices
* Treat functions as stateless
* Include only what you need
* Choose dependencies that are not complex and think about your startup time
* Reuse the temporary runtime environment
* Separate the core business logic (outside of the handler method)
* Write modular functions
* Include logging statement
* Include results information
* Use environment variables
* Avoid recursive code
* Don't call one function from another

### Deploying Lambda Functions

Deployment options:
* zip archive - choose a runtime when you create the function. Compress files for application code and dependencies and upload them to lambda
     * Use the lambda console editor - if your code does not required libraries other than AWS
     * Upload from your IDE - used when your code requires custom libraries (50 MB limit)
     * Compress and upload to an S3 bucket. You can then provide lambda with the bucket information.
* Container image - Choose a runtime and linux distro when creating the image. Package your code and dependencies as a container image. Upload the image to your container registry that is hosted on the Elastic Container Registry

Deployment Package Limits
* 50MB for compressed and direct upload
* 250MB for non-compressed including layers
* 3MB when using the console editor
* 512KB maximum for an individual file

Versioning
* You can create different versions of your function to work with your development workflow. 

