# LibraryManagement

## Feature
1. Distributed Lock - DONE, All insert update have lock.
1. Batch Processing - DONE, File are processed in batches.
1. Hangfire Jobs - DONE, I have one job that pull in books
1. Book Issue Processing - DONE, Operator can issue a book for a student
1. Book Queue Processing
1. Pagination - DONE, Books are returned in paginated fashion

## Job
1. Pull in data from CSV file and puts it in the queue for other to consume
1. LMS can also put new books on the queue if added manually.
1. LMS can update Price and Quantity of the book through queue.

## Customer Feature
1. Book Catalog
1. Book Issue Online
1. Add to Favourite/Likes
1. Add Review and Comments
1. New Book FAN out based on the interest
1. New Book Notification