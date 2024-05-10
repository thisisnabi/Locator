# Locator Service

The User Locator Service streamlines the process of finding a user's address information within your web applications. It eliminates the need for complex IP address manipulation and leverages the power of Geolocation providers.

## Features

- IpLocation
- TimeZone

## Technologies Used

- Vertical Slice Architecture
- ASP.NET Core - Minimal APIs
- EF Core
- MongoDB
- C#

## Installation

1. Clone the repository:

```bash
git clone https://github.com/thisisnabi/Locator.git
```

## Give a Star! ⭐
If you find this project helpful or interesting, please consider giving it a star on GitHub. It helps to support the project and gives recognition to the contributors.


## Getting Started


### IP Address
device connected to a network that uses the Internet Protocol (IP) for communication. It acts like a digital mailing address, allowing information to be sent and received between devices on the internet.

![image](https://github.com/thisisnabi/Locator/assets/3371886/8116bcd0-f869-4fc2-a6bc-d36efd28c92e)


### IP geolocation

IP geolocation is a technique that estimates the geographical location (country, city, region, etc.) of a device connected to the internet based on its IP address.

![image](https://github.com/thisisnabi/Locator/assets/3371886/f0e0d3ee-d3c6-4d09-af49-8ed5ec29bb30)

### Accessing to the Address
There are various solutions for this task, but the simplest one is to use GeoLocation providers, which provide you with the possibility to access the user's address easily and only by using the user's IP address.

> Remember, the user's IP comes with the HTTP request.

![image](https://github.com/thisisnabi/Locator/assets/3371886/240154d4-ca3e-4a37-83aa-ad2e1b052c1b)


### Locator on your Microservice

If your application architecture is based on microservices, it is better to develop a separate service to use this provider. This allows you to reuse and maintain and develop it separately.

![image](https://github.com/thisisnabi/Locator/assets/3371886/b2dabebf-b176-455f-814b-68affa5e63bc)

### The locator works like a proxy
Duplicate requests are always there, in order not to send a duplicate request to the Geolocation provider every time, it is better to cache your requests.


![image](https://github.com/thisisnabi/Locator/assets/3371886/72cc83a1-3f16-4a1b-80c5-03db77bd08de)



## License
This project is licensed under the MIT License: [MIT License](https://opensource.org/licenses/MIT).

## Stay Connected
Feel free to raise any questions or suggestions through GitHub issues.
