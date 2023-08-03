# Developing Storage Solutions

## Working with S3
Object storage service that offers scalability, data availability, security, and performance
Designed to hold large amounts of data at 11 9s of durability
* Provides easy-to-use management features
* Can respond to event triggers - notifications when objects are changed, replication events, etc...and can be sent to other services.

### Use Cases
* Content storage and distribution - distribute content from S3 or through Cloudfront
* Backup, restore, and archive - Use S3 as a long-term storage solution 
* Data lakes and big data analytics - Centralized repo for storing structured and unstructured data
* Disaster recovery - Protect critical data and systems in the cloud or on-prem
* Static website hosting - Individual pages of static content and client-side scripts

### Components
* Buckets - Regional places to hold information. A container for items at the highest level
    *  https://s3-<aws-region>.amazonaws.com/<bucket-name>/
* Objects - Objects are information that is held in buckets. An object can be any kind of file. An object key is a unique value that is used to identify an object in a bucket. 
    *  https://s3-<aws-region>.amazonaws.com/<bucket-name>/<object-key>

### Creating S3 Buckets
* Bucket names must be globally unique
* Names must be 3-63 characters
* Only use lowercase letters, numbers, and hyphens
* Do not use uppercase characters or underscores
* Names cannot be changed once the bucket is created
* You must specify a region where the bucket will be hosted - you cannot change the region once it's created

### Implied Folder Structure
While S3 does not support folders it does allow for the use of prefixes to imply a folder structure in an S3 bucket. 
When a prefix is queried, the results returned will only be those objects that contain that prefix.

### Working with S3 Objects
Objects in S3 are made up of object metadata. This is a set of key-value pairs that provide additional information about the object. 
* System-defined
    *  Information that Amazon S3 controls such as object-creation data, object size, and version
    *  Information you can modify such as storage-class configuration and server-side encryption
* User-defined
    *  Information you assign to an object

### Operations
* PUT - Used to load entire objects into a bucket. Should be a single upload for objects up to 5GB but must be a multipart upload over 5GB. Allows for parallel uploading to improve throughput and it's recommended that you use multipart upload for files over 100MB. You can resume uploads where it left off and it allows for a maximum object size of 5TB.
* GET - Gets the complete object or a range of bytes. Requires read access to the bucket. 
* SELECT - You can use structured query language to find objects. 
* DELETE - Removes an object from the bucket - If the object isn't versioned, the object is deleted permanently. If versioning is enabled, then the object isn't removed but trying to access it will result in a 404 message. 

### Versioning
* A way to keep multiple variants of an object in the same bucket
* A way to recover from unintended user actions and application failures
* In versioning-enabled S3 buckets, each object has a version ID
* After versioning is enabled, it can only be suspended (cannot be disabled)
* Versioned buckets support object locking 


## Protecting S3 Data and Managing Access

### Data Encryption
* In Transit
    * Can use SSL/TLS encrypted endpoints with HTTPS
    * Client-side encryption of data before transmission - clients must support TLS 1.0 but AWS recommends at least 1.2
* At Rest
    * Client-side encryption - you manage the encryption process
    * Server-side encryption - AWS encrypts your data at the object level
        * Amazon S3-managed keys
        * AWS KMS-managed keys
        * Customer-provided keys

* Note - S3 will not encrypt objects in the bucket when encryption is enabled. It will only encrypt objects that are added after encryption is enabled.

### Access Policies
* Identity-based policies - attached to identities such as users, groups, or roles. 
* Resource-based policies - policies applied to resources 
    * Access Control Lists (ACLs) - Manages access at the object level or bucket levels
    * Use to grant basic read/write permission to other AWS accounts
    * Bucket policies - Uses the IAM policy language to grant granular permission to Amazon S3 resources
* Presigned URLs
    * Provide access to PUT or GET objects without granting permissions to perform any other actions
    * Use the permissions of the user who creates the URL
    * Provide security credentials, a bucket name, an object key, an HTTP method, and an expiration date/time
    * Only valid until the expiration time (max 1 week)

* Cross-origin Resource Sharing (CORS) - defines a way for client web applications that are loaded in one domain to interact with resources that are in a different domain. 
    * You can enable CORS to allow JavaScript to access resources in an S3 bucket by creating a JSON file that contains the permissions parameters. 






