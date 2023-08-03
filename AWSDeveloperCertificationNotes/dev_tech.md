# Developer Technology 
## From Monoliths to Microservices

### Traditional Monolithic Architecture
* Each application has all processes tightly coupled and runs as a single service
* If one process of an application experiences a spike in demand, the entire architecture must be scaled
* Adding or improving features becomes more complex as the code-base grows
* Limits experimentation and makes it difficult to implement new ideas
* Adds risk for application availability since you have many dependent and tightly coupled processes
* Increases the place of a single process failure

### Microservice Architecture
* Design approach for building a single application as a set of small services
* Each service runs its own process and communicates with other services through a well-defined interface (HTTP API)
* Built around business capabilities - each service is scoped with a single purpose
* You can use different frameworks or programming languages to write microservices
* Deploy things independently as a single service or group of services

[AWS Microservices](https://aws.amazon.com/microservices/)

#### Benefits of a Microservice Architecture
* Agility - Helps small teams be more independent and take ownership of their services. Shortens development cycles.
* Flexible Scaling - Allows each service to be independently scaled to meet demand. Allows you to right-size infrastructure needs.
* Easy deployment - Enables continuous integration and continuous delivery, making it easy to try new ideas. Easy to roll back if something doesn't work. The low cost of failure allows for experimentation.
* Technological Freedom - Teams have the freedom to choose the best tool to solve their specific problems. 
* Reusable Code - Dividing software into small, well-defined modules. Enables teams to use functions for multiple purposes. 
* Resilience - Service independence increases an application's resistance to failure. 
