# _Hair salon_

#### _Application using C#, SQL, Nancy, Razor, and Xunit that tracks the clients of stylist, 12/19/16_

#### By _**James R. Howard**_

## Description

_This application uses a one to many database relationship to track the clients a stylist has. The one to many relationship is a client can only have one stylist but a stylist can have many clients. We assign the foreign key to the clients table with the column stylist_id, this creates our one to many relationship in our database._

## Specs


| Behavior - plain english                                    | Input                 | Output                                |
|-------------------------------------------------------------|-----------------------|---------------------------------------|
| User creates entry for stylist                              | Jake                  | id = 1 : name = Jake                  |
| User creates entry for stylist(First stylist entry remains) | Jenny                 | id = 2 : name = Jenny                 |
| User creates entry for client for stylist Jake              | Dave                  | id = 1 : name = Dave : stylistid = 1  |
| User creates entry for client for stylist Jake(one to many) | Sally                 | id = 2 : name = Sally : stylistid = 1 |
| User updates client name entry from Dave to David           | update: Dave to David | id = 1 : name = David : stylistid = 1 |
| User updates stylist name entry from Jenny to Jen           | update: Jenny to Jen  | id = 1 : name = Jen                   |
| User deletes client David from stylist Jake                 | delete: David         | David is removed from Jake's list     |
| User deletes stylist Jake from application                  | delete: Jake          | Jake is removed from application      |

## Known Bugs

_There are no known bugs at this point in time._

## Support and contact details

_If you have any questions or concerns please contact me at jrh682@gmail.com_

## Technologies Used

_This application uses_
* _HTML_
* _C#_
* _"Microsoft.AspNet.Server.Kestrel": "1.0.0-*"_
* _"Microsoft.AspNet.Owin": "1.0.0-*"_
* _"Nancy": "1.3.0"_
* _"Nancy.ViewEngines.Razor": "1.3.0_
* _"xunit": "2.1.0"_
* _"xunit.runner.dnx": "2.1.0-rc1-*"_
* _SQL_

### License

*The MIT License (MIT)
Copyright (c) <2016> <James R. Howard>

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.*

Copyright (c) 2016 **_James R. Howard Student at EPICODUS_**
