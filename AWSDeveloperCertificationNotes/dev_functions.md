## Defining Workflows to Orchestrate Functions

### Coordinating tasks in distributed applications
In modern cloud architecture, applications are decoupled into smaller, independent components that are called microservices. These are easier to develop, deploy and maintain. With microservices, you can build distributed functions or tasks and then deploy, scale, and update components quickly.

#### Challenges with distributed applications
As your application grows in size, the number of components increases and you can have many patterns to run tasks. Example - a serverless application built using Lambda functions. You might want to invoke a Lambda function immediately after another function, and only if the first function runs successfully. Maybe you want two functions to be invoked in parallel and then feed the combined results into a third function. 

Function invocation can result in an error for several reasons:
* Your code might raise an exception, time out , or run out of memory
* The runtime that your code runs might encounter an error and stop
* When an error occurs, your code might have run completely, partially, or not at all

In most cases, the client or service that invokes your function automatically retries if it encounters an error. Therefore, your code must be able to process the same event repeatedly without unwanted effects. 

You need a way to coordinate the components of your application. This coordination layer is necessary to provide the capability to scale automatically in response to changing workloads and to handle errors and timeouts. 

## Step Functions
Serverless orchestration service that you can use to combine Lambda functions and other AWS services to build critical applications
* Coordinates components of distributed applications and microservices by using visual workflows
* Automatically triggers and tracks each step and retries when errors occur
* Step Functions logs the state of each step, so you can diagnose and debug problems quickly

[For more information about Step Functions](https://aws.amazon.com/step-functions/)

### Benefits of Step Functions

You can use Step Functions to do the following:
* Build and update applications quickly - use Step Functions to build visual workflows that provide fast translation of business requirements into technical requirements. When needs change you can exchange or reorganize components without customizing any code
* Scale and recover reliably - Step Functions automatically scales the operations and underlying compute to run the steps of your application for you in response to changing workloads.
* Evolve applications easily - Step Functions manages state, checkpoints, and restarts for you to make sure that your application runs in order and as expected. It has built-in try/catch, retry and rollback capabilities. 

### Workflow options

* Run tasks in sequence
* Run tasks in parallel
* Select a task based on data
* Manage try/catch/finally behavior
* Retry failed tasks

### How Step Functions Works

* You define your workflow (or state machine) as a series of steps (or states) and transitions.
* Tasks do all of the work in a state machine
* Each state machine starts with an input. The state transforms the input and passes the output to the next state
* You can visualize and track workflows in the Step Functions console

You define state machines by using the Amazon States Language (ASL). This is a JSON-based 