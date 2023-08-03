## Developing REST APIs
An API is a software mechanism that simplifies development by doing the following:
* Abstracting implementation details
* Exposing only objects or actions that a developer needs
* Establishing how an information provider and an information user communicate

In a typical web application, clients send requests and get responses from an API that resides on a web server. The API provides the interface to application resources such as databases. 

### API Requests and Responses
API requests use a standard protocol like SOAP (an XML-based protocol), WebSockets (a bidirectional protocol), or HTTP. A request from a device reaches your server, and your server responds with a status code and potentially some data. This process is usually carried out through an HTTP application protocol that humans can read and is commonplace across the internet.

Representational State Transfer (REST) is purely an architectural style, and APIs that you build that adhere to REST principles are called RESTful APIs.REST is the standard way of structuring requests from a client to a server. Non-RESTful APIS that use HTTP are valid and quite common.

### API Gateway
An API gateway is a proxy that is between your client and server (or servers behind a load balancer). Its task is to handle most of the common problems that developers encounter when managing dynamic server-driven applications.

You can have the proxy:
* Rate limit the application so that the server is not overwhelmed. It is similar to a doorman in a nightclub.
* Ensure that the request contains the required developer keys. Perhaps you have an API that is designed for various developers or sites to consume. Examples are Twitter or Google Maps, where you get an API key. The proxy can validate requests and drop invalid requests before they even get to your server.
* Limit access based on language headers or geographical regions. In some cases, it might reroute to the correct server for that locale.

Amazon API Gateway is a fully managed, serverless service that developers can use to easily create, publish, maintain, monitor, and secure APIs at any scale. API Gateway acts as the front door for applications to access data, business logic, or functionality from your backend services. Amazon API Gateway can also be used with serverless products such as lambda.

### RESTFul APIs in API Gateway
Two types of RESTful APIs in API Gateway

REST API
* Gives the developer full control over API requests and responses
* Supports features that are not yet available in HTTP APIs

HTTP API
* Simplifies the development of APIs that require only API proxy functionality
* Designed for the lowest cost and lowest latency
* Useful if you just need a public-facing request point for Lambda or other functionality

[Additional information](https://docs.aws.amazon.com/apigateway/latest/developerguide/http-api-vs-rest.html)

### Websocket APIs
If you want to build real-time, two-way communication applications, such as chat apps and streaming dashboards, use WebSockets or server-sent events.

### Creating an API
When you create a REST or HTTP API in Gateway (using the CLI or console) you get a URI for your API. It contains:
* The API ID
* The region
* The stage name of the API deployment (lifecycle state)

You can import an API that you might already have. Gateway supports Swagger or OpenAPI 3

### Integrating with API Gateway
Endpoint types refer to the hostname of the API and determine how the endpoints are deployed and how clients can access them. They can be:
* Edge optimized
* Regional
* Private 

#### Edge Optimized
REST APIs have the option of an edge-optimized endpoint. Gateway uses its own CloudFront distribution to reduce the round trip time for your requests and responses. 
* This type is designed for globally distributed clients. 
* It provides built-in DDoS protection
* Does not require you to set up your own CloudFront
* Not available for HTTP or Websockets

#### Regional
All API types support regional endpoints. These are recommended for general use cases and are designed for building things in the same AWS region.
* Best Practice - Set up a CloudFront distribution in front of the endpoint

#### Private
REST APIs have the option of using private endpoints which are accessible from only within a VPC
* Designed for building APIs accessed internally or by microservices

#### Client-side SDKs
You can use the API Gateway option to export an SDK for your defined API. Then use the SDK with client-side code to make calls to the API.
* Useful when working with Android or iOS

#### Integrating with Other Services
Services like lambda cannot use URIs from your API to get or make requests. You should use API Gateway to proxy requests to use AWS services on the back end. This is how you can connect to services such as DynamoDB, S3, etc...

You can also expose an API method in API Gateway that sends data directly to services like Kinesis. This is accomplished through a Mock Endpoint which can be used to abstract options and for prototyping applications. 

Example Integration Flow
* Method request - Modeling, validation, transformation
* Integration request - Encapsulating, HTTP requests for the backend
* Integration response - Transformation, Custom errors
* Method Response - Modeling, Header validation

#### Lambda non-proxy vs proxy integration
Gateway wraps client requests with metadata that lambda needs and passes the wrapped request to the target function
The response differs depending on the integration method
* In non-proxy, when the client makes a request the Gateway transforms it and forwards it to lambda. When the response comes back, it sets the header, status code, and other info
* In proxy, when the client makes a request, Gateway forwards the request to lambda without transforming. The lambda function has to be prepared to parse the request data itself and handles the response. 

### Deploying an API
Before users can access your API you must deploy it. Deployments are associated with a stage. 
Stages are snapshots of an API
* Named as you like
* Identified by API ID and stage name
* Included in the URL

Developers often create multiple stages to:
* Differentiate versions for dev environments (dev vs prod)
* Connect to different stages to different backends
* Optimize a particular deployment

HTTP APIs only have a "default" stage. 














