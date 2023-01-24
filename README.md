# CodeChallenge
In this repo I will publish my code to my Unosquare CodeChallenge

## Repository Pattern
This pattern allow us reuse a single file to Connect to our DB, it means, this pattern use define a unique Process using Generics

## Unit of Work
This pattern group some Repositories to manage them as an Unit of Work, it means, ``` If we have some DataBase requests, we are able to group and senf them at same time```.

In our IUnitOfWork interface we will have an property per each Repository to use.

## RabbitMQ 
This a software that acts like a MessageBroker/ServiceBus, it means, RabbitMQ is where we publish our messages when we works with asynchronous programming.

An ***Exchange*** is a place where we want to have more than one ***Consumer***. This element doesn't save any kind of info, it means if an Exchange doesn't have consumers, our messages will lose.

Whit RabbitMQ we can't consume message from an Exchange directly, we need another Exchange or a Queue. This action is called ***binding***.

A ***Broker*** is the grouping of *exchanges*, *queues* and *bindings*.

The ***RoutingKey*** is a property in our messages that define the direction of them. 

### Exchanges Types
#### Direct
This type will only send the message to the bindings with the RoutingKey configured.
#### Topic
Allow us to send the message to all bindings that matches with our RoutingKey (looks like a wildcard).

#### Header
This type sends the messages to the binding which has all the headers configured as arguments in the message.

#### Fanout
This type publish the message to all bindings, and it doesn't matter anything else.
