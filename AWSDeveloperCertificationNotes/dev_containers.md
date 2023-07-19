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
* Dockerfile - Plain text file that provides instructions to create a container image
* Container image - Read-only template that is used to create writable containers
* Container - Runnable instance of an image
* Container layer - Thin read/write layer that is used to make changes to the running container
* Container registry - Private or public images that you can base other images on

### Docker CLI Commands
You can run Docker CLI commands from a Bash terminal to manage your Docker images and containers.

For example, you can build an image from a Dockerfile by running docker build. You can then verify your image by running docker images. To launch a container from the image, run docker run. To verify that the container is running, enter docker ps.

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






     
     
     
     
    
    






