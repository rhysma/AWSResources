# Containers and Container Services

## Introducing Containers
A container is a standardized unit of software designed to run quickly and reliably on any computing environment that runs the containerization platform.
* Containers provide OS virtualization so you can run an application and its dependencies in resource-isolated processes
* A container is a lightweight, standalone software package that contains everything that a software application needs to run.
* It can contain the application code, runtime engine, system tools, system libraries, and settings.
* A single server can host several containers that all share the underlying host system's OS kernel. 

Bare-metal servers - You had to build the architectural layers, such as the infrastructure and application software layers. 
* For example, you would install an OS on top of your server hardware. Then, you would install any shared libraries on the OS, and then install the applications that use those libraries. This architecture was inefficient.

## Introducing Docker
Docker - This lightweight platform provides tooling to create, store, manage, and run containers. It is easy to integrate with automated build, test, and deployment pipelines.

Benefits:
* Portable runtime application environment
* Application and dependencies can be packaged in a single, immutable artifact called an image
* Ability to run different application versions with different dependencies simultaneously
* Faster development and deployment cycles
* Better resource utilization and efficiency

Docker Container Components
* Dockerfile - Plain text file that provides instructions to create a container image. Each instruction in the file creates a read-only layer in the container image.
* Container image - Read-only template that is used to create writable containers
* Container - Runnable instance of an image
* Container layer - Thin read/write layer that is used to make changes to the running container
* Container registry - Private or public images that you can base other images on

### Docker CLI Commands
You can run Docker CLI commands from a Bash terminal to manage your Docker images and containers.

For example, you can build an image from a Dockerfile by running docker build. You can then verify your image by running docker images. To launch a container from the image, run docker run. To verify that the container is running, enter docker ps.

Example: This docker CLI command creates a container named my_app_1 from the image named node_app
docker run --name my_app_1 node_app

[For more information about Docker CLI commands](https://docs.docker.com/engine/reference/commandline/cli/)

## Using Containers for Microservices
* Traditional monolithic architecture - Tightly coupled processes, difficult to scale independently. Adding or improving features becomes more complex as the code base grows, which limits experimentation and complicates the implementation of new ideas or technology stacks. Monolithic architectures also add risk for application availability because having many dependent and tightly coupled processes increases the impact of a single process failure.

( Microservices - an architectural and organizational approach to software development that is designed to speed up deployment cycles. The microservices approach fosters innovation and ownership, and improves the maintainability and scalability of software applications.

## AWS Container Services
* Container orchestration platforms - They handle the scheduling and placement of containers based on the underlying hardware infrastructure and needs of the application. Container orchestration platforms integrate with other services, such as services for networking, persistent storage, security, monitoring, and logging.

### Amazon Elastic Container Service (ECS)
* A fully managed container orchestration service
* Scales rapidly to thousands of containers with no additional complexity
* Schedules placement across managed clusters
* Integrates with third-party schedulers and other AWS Services

For more information about Amazon ECS, [see the product page](https://aws.amazon.com/ecs/).

### Amazon Elastic Container Registry (ECR)
* A fully managed container registry that you can use to store, run, and manage container images for applications that run on ECS
* Scalable and highly available
* Integrated with ECS and Docker CLI
* Secure - encryption at rest and integration with IAM service

For more information about Amazon ECR, [see the product page](https://aws.amazon.com/ecr/).

### Amazon ECS Solution Architecture

The following procedure is a high-level overview of Amazon ECS
* First, container images are pulled from a registry. This registry can be Amazon ECR—which is one of many AWS services that integrate with Amazon ECS—or a third-party or private registry.
* Next, you define your application. Customize the container images with the necessary code and resources, and then create the appropriate configuration files to group. Then, define your containers as short-running tasks or long-running services within Amazon ECS.
* When you are ready to bring your services online, you select one of two launch types: AWS Fargate or Amazon EC2. You can mix and match the two launch types as needed within your application. The next slide highlights distinctions between these two launch types.
* Finally, you can use Amazon ECS to manage your containers. Amazon ECS scales your application and manages your containers for availability.

#### Launch Types

The Fargate launch type provides a near-serverless experience, where AWS completely manages the infrastructure that supports your containers. 
* AWS manages the placement of your tasks on instances, and makes sure that each task has the appropriate amount of CPU and memory. 
* With Fargate, you can focus on the tasks and the application architecture, instead of worrying about the infrastructure.

The Amazon EC2 launch type is useful when you want more control over the infrastructure that supports your tasks. 
* You create and manage clusters of EC2 instances to support your containers.
* You also define the placement of containers across your cluster based on your resource needs, isolation policies, and availability requirements.
* You have more granular control over your environment without operating your own cluster management and configuration management systems, or worrying about scaling your management infrastructure.

For more information about AWS Fargate, [see the product page](https://aws.amazon.com/fargate/)
[For more information about the Fargate and EC2 launch types](https://docs.aws.amazon.com/AmazonECS/latest/developerguide/launch_types.html.AWS)

### Amazon Elastic Kubernetes Service (EKS)
* Managed service that runs Kubernetes on the AWS Cloud
* Built with the Kubernetes community
* Secure by default

Kubernetes is an open-source container management platform that you can use to deploy and manage containerized applications at scale.
* Kubernetes manages clusters of EC2 instances, and it runs containers on those instances with processes for deployment, maintenance, and scaling
* By using Kubernetes, you can run any type of containerized application by using the same toolset on premises and in the cloud
* When you select Amazon EKS as your container management service, you provision an Amazon EKS cluster and deploy Amazon EC2 or Fargate worker nodes (that is, worker machines) for your Amazon EKS cluster. You then connect to Amazon EKS and run your Kubernetes applications.


For more information about Amazon EKS, [see the product page](https://aws.amazon.com/eks/).

## Deploying Applications with Elastic Beanstalk

### AWS Elastic Beanstalk
* Service for deploying and scaling web applications and services
* Automatically handles deployment details like capacity provisioning, loading balancing, automatic scaling, and application health monitoring
* Provides a variety of platforms on which to build your applications
* Use to manage all of the resources that run your applications as an environment

Elastic Beanstalk Components
* Application - logical collection of beanstalk components (like a folder)
* Application version - Specific, labeled iteration of deployable code for a web application
* Environment - Collection of AWS resources that run an application version
* Environment tier - Designation of type of application that the environment runs. Determines what resources EB provisions to support it
* Environment configuration - Collection of parameters and settings that define how an environment and it's associated resources behave
* Saved configuration - Template that you can use as a starting point for creating unique environment configurations
* Platform - Combination of OS, programming language runtime, web server, application server, EB components,. You design and target your web application to a platform
* EB CLI - CLI for EB that provides interactive commands for creating, updating, and monitoring environments. 

#### Elastic Beanstalk Permissions
The Elastic Beanstalk permissions model requires you to assign two roles when creating an environment: the service role and the instance profile.
* Service Role - Elastic Beanstalk assumes the service role to use other AWS services on your behalf.
* Instance Profile - An instance profile is a container for an IAM role that can pass role information to an EC2 instance when the instance starts.

#### Elastic Beanstalk Deployment Policies
Elastic Beanstalk provides several options for processing deployments, including deployment policies (all at once, rolling, rolling with additional batch, immutable, and traffic splitting). It also includes options that you can use to configure batch size and health check behavior during deployments. 

Methods:
* All at once - deploys the new version to each instance. Requires some downtime but is the quickest deployment method
* Rolling - Deploys to a batch of instances at a time. Avoids downtime. Minimizes reduced availability. Longer deployment
* Rolling with batch - Launches an extra batch of instances, then performs a rolling deployment. Avoids reduced availability. Longer deployment than rolling.
* Immutable - Launches a second Auto Scaling Group and serves traffic to both old and new versions until the new instances pass health checks. Ensures the new version always goes on new instances. Allows for quick and safe rollback but longer deployment time.
* Traffic splitting - Launches a full set of new instances like an immutable deployment. Tests the health of the new version by using a portion of traffic while keeping the rest of the traffic served by the old version. Supports canary testing. No interruption of service if you must roll back. 
     
Choose the method that makes the most sense for your use case. Consider how fast you can make updates compared to how much tolerance your users have for issues with a new version and downtime during updates.
     
    
    






