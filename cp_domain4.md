# Domain 4

* Domain 4: Billing and Pricing
  * 4.1 Compare and contrast the various pricing models for AWS
  * 4.2 Recognize the various account structures in relation to AWS billing and pricing
  * 4.3 Identify resources available for billing support

## AWS Pricing Model
* Three fundamental drivers of cost with AWS
   * Compute
      * Charged per hour/second
      * Varies by instance type 
   * Storage
      * Charged typically per GB 
   * Data Transfer 
      * Outbound is aggregated and charged
      * Inbound has no charge (with some exception)
      * Charged typically per GB

* How do you pay for AWS?
   * Pay for what you use - Unless you build data centers for a living, you might have spent too much time and money building them. With AWS, you pay only for the services that you consume with no large upfront expenses. You can lower variable costs, so you no longer need to dedicate valuable resources to building costly infrastructure, including purchasing servers, software licenses, or leasing facilities.
   * Pay less when you reserve - For certain services like AmazonElastic Compute Cloud (Amazon EC2) and Amazon Relational Database Service (Amazon RDS), you can invest in reserved capacity. With Reserved Instances, you can save up to 75 percent over equivalent on-demand capacity. Reserved Instances are available in three options:
      *  All Upfront Reserved Instance (or AURI)
      *  Partial Upfront Reserved Instance (or PURI)
      *  No Upfront Payments Reserved Instance (or NURI)
   * Pay less by using more - With AWS, you can get volume-based discounts and realize important savings as your usage increases. For services like Amazon Simple StorageService (Amazon S3), pricing is tiered, which means that you pay less per GB when you use more. In addition, data transfer inis always free. Multiple storage services deliver lower storage costs based on your needs. As a result, as your AWS usage needs increase, you benefit from the economies of scale that enable you to increase adoption and keep costs under control.
   * Pay less when you use more and as AWS grows - AWS constantly focuses on reducing data center hardware costs, improving operational efficiencies, lowering power consumption, and generally lowering the cost of doing business. These optimizations and the substantial and growing economies of scale of AWS result in passing savings back to you as lower pricing. Since 2006, AWS has lowered pricing 75times (as of September 2019).Another benefit of AWS growth is that future, higher-performing resources replace current ones for no extra charge.
   * Custom pricing - AWS realizes that every customer has different needs. If none of the AWS pricing models work for your project, custom pricing is available for high-volume projects with unique requirements.

[AWS Pricing Overview doc](https://d0.awsstatic.com/whitepapers/aws_pricing_overview.pdf)

### AWS Free Tier
To help new AWS customers get started in the cloud, AWS offers a free usage tier (the AWSFree Tier)for new customers for up to 1 year.The AWS Free Tier applies to certain services and options. If youare a new AWS customer, you can run a free Amazon Elastic Compute Cloud (Amazon EC2) T2 micro instance for a year, while also using a free usage tier for Amazon S3, Amazon Elastic Block Store (Amazon EBS), Elastic Load Balancing, AWS data transfer, and other AWS services.

[AWS Free Tier](https://aws.amazon.com/free/?all-free-tier.sort-by=item.additionalFields.SortRank&all-free-tier.sort-order=asc&awsf.Free%20Tier%20Types=*all&awsf.Free%20Tier%20Categories=*all)

## Total Cost of Ownership
* Total Cost of Ownership (TCO) is the financial estimate to help identity direct and indirect costs of a system
* You can identify the best option by comparing the on-premises solution to a cloud solution. Total Cost of Ownership (or TCO) is a financial estimate that is intended to help buyers and owners determine the direct and indirect costs of a product or system. TCO includes the cost of a service, plus all the costs that are associated with owning the service. 
* Some of the costs that are associated with data center management include: 
   * Server costs for both hardware and software, and facilities costs to house the equipment. 
   * Storage costs for the hardware, administration, and facilities. 
   * Network costs for hardware, administration, and facilities. •And IT labor costs that are required to administer the entire solution.

## AWS pricing Calculator

* Use the AWS Pricing Calculator to:
   * Estimate monthly costs
   * Identify opportunities to reduce monthly costs
   * Model your solutions before building them
   * Explore price points and calculations behind your estimate
   * Find the available instance types and contract terms that meet your needs
   * Name your estimate and create and name groups of services

[AWS Pricing Calculator website](https://calculator.aws/#/)
